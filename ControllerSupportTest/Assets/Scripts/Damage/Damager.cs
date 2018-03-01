using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Damager : MonoBehaviour {

	public float damage;

	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		rb.isKinematic = false;
		rb.useGravity = false;
	}

	void OnTriggerEnter(Collider other)
	{
		Health _health = other.GetComponent<Health> ();

		if (_health != null) {
			_health.TakeDamage (damage);
		}
	}

}
