using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public Wave[] Waves;
	public Round currentRound;												//holds the current round, used to access the current round info
	private int roundNumber = 0;												//the round number of the current round, used when accessing the array of rounds

	public int defaultEnemyPoolSize = 20;														//default number of enemies that the game will use, used when instancating the first pools of enemies
	public Enemy smallEnemySO, medEnemySO, bigEnemySO;											//stores the enemie Scriptable objects, used to instanciate more enemies
	[HideInInspector] public List<GameObject> smallEnemies, medEnemies, bigEnemies;				//list of enemy GOs that are pooled offscreen
	[HideInInspector] public int lastSmlEn, lastMedEn, lastBigEn;								//stores the index of the last enemy accessed in each list, for ease of access
	[HideInInspector] public int waveEnemy = 0, currentWave = 0;												//stores the index of the last enemy spawned from the round data
	public Transform poolLocation;																//transform set in inspector, location used to store all unused "deactivated" enemies

	public Transform playerPos;																	//stores the location of the player, used to find the closest spawn point
	public Transform[] enemySpawnPoints;														//an array of enemy spawn points, used to set the enemys position on spawn
	[HideInInspector]public bool playerActive = true;													//bool used to stop the round manager if the player is killed

	private void Start(){
		SetUpSpawning ();
	}

	private void SetUpSpawning(){																//SetsUp Spawning System
		for (int i = 0; i < defaultEnemyPoolSize;i++) {											//creates a pool for each of the enemy types;
			ExpandPool (smallEnemies, smallEnemySO, false, poolLocation.position);				//small enemies
			ExpandPool (medEnemies, medEnemySO, false, poolLocation.position);					//med enemies
			ExpandPool (bigEnemies, bigEnemySO, false, poolLocation.position);					//big enemies
		}		
		roundNumber = 1;
		currentRound.CreateRound (Waves, roundNumber);
		SortWaves ();
		StartCoroutine (RoundManager());														//starts the round manager
	}

	private void SortWaves(){
		foreach(Wave wave in Waves){
			wave.CalcWaveDanger ();
		}
	}

	private void ExpandPool(List<GameObject> _pool,Enemy enemyArch, bool toActivate, Vector3 loc){	//used to create more enemies if they are needed; pool is the list to be added to, enemy arch is the type of enemy to add, to activate is wether or not it should be active (pooled or spawned), loc is where it should be spawned  
		_pool.Add (enemyArch.CreateEnemyInstance(loc, toActivate));									//Adds an enemy to the list
	}

	private GameObject FindInactive(List<GameObject> pool,Enemy _enemyArch, int lastActive){		//Finds the next inactive (not currently chasing the player) enemy by iterating through the list of enemies that its given. if none are found then it adds another by calling expandPool()
		bool foundGO = false;																		//temp bool used to break out of for loops
		lastActive++;																				//makes sure it starts one after the last one accessed
		for (int i = lastActive; i < pool.Count; i++) {												//starts iterating through the pooled enemies to find an inactive enemy
			if(!pool[i].activeSelf){ 
				foundGO = true; lastActive = i; return pool [i];}									//if an inactive enemy is found then it changes foundGO to true, returns the gameobject and breaks out of the loop (stops looking)
		}
		if (!foundGO) {																				//if an the end of the list was reached before an inactive object was found then it tries again from index 0
			for (int i = 0; i < lastActive; i++) {													//looks from the start of the list to the first one checked
				if (!pool [i].activeSelf) { foundGO = true;	lastActive = i; return pool [i];}		//if one is found then it returns the game object, sets the new last active, and breaks out of the loop (stops checking)
			}
		} 																							//if a gameobject was found then it breaks out of the method
		if (!foundGO) {																				//if the entire list has been checked and nothing has been found
			ExpandPool (pool, _enemyArch, false, poolLocation.position);							//then an new enemy is created, added to the list and moved to the pool location
			return pool [pool.Count];																//return the last gameobject (enemy) in the list
		}
		return pool[lastActive];	//system needed a a gaurenteed return value, may cause issues
	}

	void PullEnemy(Vector3 loc){
		if(currentRound.roundWaves[currentWave].enemies[waveEnemy].EnemyType == smallEnemySO.EnemyType){
			currentRound.roundWaves[currentWave].EnemySpawn (FindInactive (smallEnemies, smallEnemySO, lastSmlEn), loc);
		}
		if (currentRound.roundWaves[currentWave].enemies[waveEnemy].EnemyType == bigEnemySO.EnemyType) {
			currentRound.roundWaves[currentWave].EnemySpawn (FindInactive (bigEnemies, bigEnemySO, lastBigEn), loc);
		}
		if (currentRound.roundWaves[currentWave].enemies[waveEnemy].EnemyType == medEnemySO.EnemyType) {
			currentRound.roundWaves[currentWave].EnemySpawn (FindInactive (medEnemies, medEnemySO, lastBigEn), loc);
		}
	}

	private void ChangeRound(){
		currentWave = 0;
		waveEnemy = 0;	
		roundNumber++;
		currentRound.CreateRound (Waves, roundNumber);
		StartCoroutine(RoundManager());
	}

	IEnumerator RoundManager(){		
		for (int i = 0; i < currentRound.roundWaves.Count; i++) {
			currentWave = i;
			yield return new WaitForSeconds (currentRound.roundWaves [i].waveDelay);
			waveEnemy = 0;
			for (int a = 0; a < currentRound.roundWaves [i].enemies.Length; a++) {
				Vector3 SP = currentRound.roundWaves[i].FindClosest (playerPos, enemySpawnPoints);
				for(int x = 0; x < currentRound.roundWaves[i].enemiesPerSpawn; x++){
					PullEnemy(SP);                                                                  //Calls pull enemy to activate, passes the spawn Point location 
					waveEnemy++; 
					yield return null;	
				}
			}
		}
		ChangeRound ();
	}

}
