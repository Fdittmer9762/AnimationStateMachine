using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Managers/Round")]
public class Round : ScriptableObject {

	public float roundDelay = 20f;				//This is the time is seconds before the round will start, time between rounds
	public float enemySpawnDelay = 1f;			//This is the time is seconds between individual enemies spawning
	public int enemiesPerSpawn = 1;				//This is the amount of enemies to spawn at a time
	public Enemy[] enemies;						//This is an array of enemies that the spawner will go through each



	public void EnemySpawn(GameObject _enemy, Vector3 SpawnPoint){
		if (enemiesPerSpawn > 1) {															//if there are multiple enimeies to spawn at once, offset them by a random amount so they dont spawn on top of eachother
			SpawnPoint += new Vector3(Random.Range(2,-2),Random.Range(2,-2),Random.Range(2,-2));
		}
		_enemy.transform.position = SpawnPoint;												//Move the enemy to the spawn point
		_enemy.SetActive(true);																//Activates enemy GO
	}

	public Transform FindClosest(Transform obj, Transform[] objToCompare){					//
		Transform currentClosest = objToCompare[0];											//A temp var used to store the current closest point
		float distClose = Vector3.Distance(obj.position, currentClosest.position);			//A float used to store the current closest distance, to reduce redundant calculations
		for (int i = 1; i < objToCompare.Length; i++) {										//for loop that checks each transform in the array
			if (Vector3.Distance (obj.position, objToCompare[i].position) < distClose) {	//if the new trans in closer to the obj
				currentClosest = objToCompare [i];											//set the new trans as the current closest
				distClose = Vector3.Distance (obj.position, objToCompare[i].position);		//set the new dist as the current closest
			}
		}
		return currentClosest;																//after checking everything return the transform for the closest point
	}

}
