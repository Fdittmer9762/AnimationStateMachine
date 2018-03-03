using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Damager : MonoBehaviour {

	public float damage;

	void OnTriggerEnter(Collider other)
	{
		Health _health = other.GetComponent<Health> ();

		if (_health != null) {
			_health.TakeDamage (damage);
		}
	}

}
