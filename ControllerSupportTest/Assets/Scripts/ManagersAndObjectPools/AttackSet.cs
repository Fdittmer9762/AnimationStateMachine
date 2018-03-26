using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Attack Set")]
public class AttackSet : ScriptableObject {

	[Tooltip("Elemetal Prefabs of attack, starts at 1, last is 5")]
	public GameObject Water, Fire, Earth, Wind, Lightning, Default;

	public void Use(int elementIndex, Transform spawn){
		switch (elementIndex) {
		case 1:
			GameObject.Instantiate (Water, spawn.position, spawn.rotation);
			break;
		case 2:
			GameObject.Instantiate (Fire, spawn.position, spawn.rotation);
			break;
		case 3:
			GameObject.Instantiate (Earth, spawn.position, spawn.rotation);
			break;
		case 4:
			GameObject.Instantiate (Wind, spawn.position, spawn.rotation);
			break;
		case 5:
			GameObject.Instantiate (Lightning, spawn.position, spawn.rotation);
			break;
		default:
			GameObject.Instantiate (Default, spawn.position, spawn.rotation);
			break;
		}
	}

}
