using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosivesManager : MonoBehaviour {


	private const int defaultPoolSize = 4;
	private int queuedExplosive = 0;
	public GameObject explosionPrefab;
	private List<GameObject> explosionList = new List<GameObject> ();

	public Transform playerLoc;

	void Start(){
		CreatePool ();
	}

	public void PullExplosive(){
		if (explosionList [queuedExplosive].activeSelf) {
			bool found = false;
			for (int i = 0; i < explosionList.Count - 1; i++) {
				if (!explosionList [i].activeSelf) {
					queuedExplosive = i;
					found = true;
					break;
				}
			}
			if (!found) {
				AddExplosive (explosionList.Count);
			}
		}
		PlaceExplosive (explosionList[queuedExplosive]);
		queuedExplosive++;
		if (queuedExplosive >= explosionList.Count - 1)
			queuedExplosive = 0;
	}

	private void PlaceExplosive(GameObject _obj){
		_obj.transform.position = playerLoc.transform.position;
		_obj.SetActive (true);
	}

	private void CreatePool(){
		for (int i = 0; i < defaultPoolSize; i++) {
			AddExplosive (i);
		}
	}

	private void AddExplosive(int _index){
		explosionList.Add (GameObject.Instantiate (explosionPrefab, Vector3.zero, Quaternion.identity));
		explosionList[_index].SetActive(false);
		queuedExplosive = _index;
	}

}
