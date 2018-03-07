using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public Round[] Rounds;																		//an array of rounds that handle the enemies and spawning
	[HideInInspector] public Round currentRound;												//holds the current round, used to access the current round info
	[HideInInspector] public  int roundNumber = 0;												//the round number of the current round, used when accessing the array of rounds

	public int defaultEnemyPoolSize = 20;														//default number of enemies that the game will use, used when instancating the first pools of enemies
	public Enemy smallEnemySO, medEnemySO, bigEnemySO;											//stores the enemie Scriptable objects, used to instanciate more enemies
	//private string smallName, medName, bigName; 												//used to make the switch statement in pull enemy work
	[HideInInspector] public List<GameObject> smallEnemies, medEnemies, bigEnemies;				//list of enemy GOs that are pooled offscreen
	[HideInInspector] public int lastSmlEn, lastMedEn, lastBigEn;								//stores the index of the last enemy accessed in each list, for ease of access
	[HideInInspector] public int roundEnemy = 0;												//stores the index of the last enemy spawned from the round data
	public Transform poolLocation;																//transform set in inspector, location used to store all unused "deactivated" enemies

	public Transform playerPos;																	//stores the location of the player, used to find the closest spawn point
	public Transform[] enemySpawnPoints;														//an array of enemy spawn points, used to set the enemys position on spawn
	[HideInInspector]public bool playerActive = true;													//bool used to stop the round manager if the player is killed

	private void Start(){
		SetUpSpawning ();
	}

	private void SetUpSpawning(){																//SetsUp Spawning System
		/*smallName = smallEnemySO.EnemyType;
		medName = medEnemySO.EnemyType;
		bigName = bigEnemySO.EnemyType;*/
		for (int i = 0; i < defaultEnemyPoolSize;i++) {											//creates a pool for each of the enemy types;
			ExpandPool (smallEnemies, smallEnemySO, false, poolLocation.position);				//small enemies
			ExpandPool (medEnemies, medEnemySO, false, poolLocation.position);					//med enemies
			ExpandPool (bigEnemies, bigEnemySO, false, poolLocation.position);					//big enemies
		}
		roundNumber = 0;
		currentRound = Rounds [roundNumber];																//sets the current round to the first round
		StartCoroutine (RoundManager());														//starts the round manager
	}

	private void ExpandPool(List<GameObject> _pool,Enemy enemyArch, bool toActivate, Vector3 loc){	//used to create more enemies if they are needed; pool is the list to be added to, enemy arch is the type of enemy to add, to activate is wether or not it should be active (pooled or spawned), loc is where it should be spawned  
		_pool.Add (enemyArch.CreateEnemyInstance(loc, toActivate));										//Adds an enemy to the list
	}

	private GameObject FindInactive(List<GameObject> pool,Enemy _enemyArch, int lastActive){			//Finds the next inactive (not currently chasing the player) enemy by iterating through the list of enemies that its given. if none are found then it adds another by calling expandPool()
		bool foundGO = false;																		//temp bool used to break out of for loops
		lastActive++;																				//makes sure it starts one after the last one accessed
		for (int i = lastActive; i < pool.Count; i++) {												//starts iterating through the pooled enemies to find an inactive enemy
			if(!pool[i].activeSelf){ 
				foundGO = true; lastActive = i; return pool [i];}		//if an inactive enemy is found then it changes foundGO to true, returns the gameobject and breaks out of the loop (stops looking)
		}
		if (!foundGO) {																				//if an the end of the list was reached before an inactive object was found then it tries again from index 0
			for (int i = 0; i < lastActive; i++) {													//looks from the start of the list to the first one checked
				if (!pool [i].activeSelf) { foundGO = true;	lastActive = i; return pool [i];}//if one is found then it returns the game object, sets the new last active, and breaks out of the loop (stops checking)
			}
		} 																							//if a gameobject was found then it breaks out of the method
		if (!foundGO) {																				//if the entire list has been checked and nothing has been found
			ExpandPool (pool, _enemyArch, false, poolLocation.position);							//then an new enemy is created, added to the list and moved to the pool location
			return pool [pool.Count];																//return the last gameobject (enemy) in the list
		}
		return pool[lastActive];	//system needed a a gaurenteed return value, may cause issues
	}

	void PullEnemy(Vector3 loc){															//uses a switch statmenet to determine which kind of enemy to spawn
		/*string _enemy = currentRound.enemies[roundEnemy].EnemyType;									//added to make the switch staement work
		switch (_enemy) {																			//switch pulls the info from the current round enemy
		case smallName:																				//if it is a small enemy
			currentRound.EnemySpawn (FindInactive (smallEnemies, smallEnemySO, lastSmlEn), loc);
			break;																					//Calls enemy spawn which needs a GO and Transform move the desired enemy, Find inactive finds the correct game object from the correct list, location to spawn at
		case medName:																				//MED Enemy
			currentRound.EnemySpawn (FindInactive (medEnemies, medEnemySO, lastMedEn), loc);
			break;																					//Calls enemy spawn which needs a GO and Transform move the desired enemy, Find inactive finds the correct game object from the correct list, location to spawn at
		case bigName:																				//BIG Enemy
			currentRound.EnemySpawn (FindInactive (bigEnemies, bigEnemySO, lastBigEn), loc);
			break;																					//Calls enemy spawn which needs a GO and Transform move the desired enemy, Find inactive finds the correct game object from the correct list, location to spawn at 
		default:																					//if it's unsure of which enemy to spawn, it simply spawns a small enemy
			currentRound.EnemySpawn (FindInactive (smallEnemies, smallEnemies, lastSmlEn), loc);
			break;																					//Calls enemy spawn which needs a GO and Transform move the desired enemy, Find inactive finds the correct game object from the correct list, find closest finds the position to spawn the creatur at
		}*/
		//switch staement wants constant values
		if(currentRound.enemies[roundEnemy].EnemyType == smallEnemySO.EnemyType){
			currentRound.EnemySpawn (FindInactive (smallEnemies, smallEnemySO, lastSmlEn), loc);
		}
		if (currentRound.enemies [roundEnemy].EnemyType == bigEnemySO.EnemyType) {
			currentRound.EnemySpawn (FindInactive (bigEnemies, bigEnemySO, lastBigEn), loc);
		}
		if (currentRound.enemies [roundEnemy].EnemyType == medEnemySO.EnemyType) {
			currentRound.EnemySpawn (FindInactive (medEnemies, medEnemySO, lastBigEn), loc);
		}
	}

	private void ChangeRound(){
		roundEnemy = 0;																			//resets the roundEnemy index
		roundNumber++;																			//adds 1 to the round index
		currentRound = Rounds[roundNumber];														//sets the current round to the next using the index
		StartCoroutine(RoundManager());															//starts the next round
	}

	IEnumerator RoundManager(){																	
		yield return new WaitForSeconds (currentRound.roundDelay);								//Waits for the round start delay
		for(int i = roundEnemy; i < currentRound.enemies.Length; i += currentRound.enemiesPerSpawn ){					//spawns the enemies in order
			Vector3 SP = currentRound.FindClosest (playerPos, enemySpawnPoints).position;               //finds the closest spawnpoint to the player
            for (int x = 0; x < currentRound.enemiesPerSpawn; x++) {								//spawns enemies in bulk if needed
				PullEnemy(SP);                                                                  //Calls pull enemy to activate, passes the spawn Point location 
                roundEnemy++; 
				yield return null;																//waits for a frame before spawning more enemies (looping back around)
			}
			yield return new WaitForSeconds (currentRound.enemySpawnDelay);						//waits before spwaning the next wave of enemies
			//if(playerActive= false) { print("breaking");break; }														//if player has died break out of the loop
		}
        ChangeRound();
		//if(playerActive) { ChangeRound (); }													//if the player is still active, alive, then it starts the next round
	}

}
