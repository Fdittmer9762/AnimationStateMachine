using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Damager : MonoBehaviour {


	public int damage, KB;

	void OnTriggerEnter(Collider other)
	{
		Health _health = other.GetComponent<Health> ();

		if (_health != null) {
			Vector3 _dir = other.transform.position - this.transform.position;
			_health.TakeDamage (damage, KB, _dir);
		}
	}

}
