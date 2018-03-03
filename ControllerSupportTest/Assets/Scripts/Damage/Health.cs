using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Health : MonoBehaviour {

	public ABS_Character character;

	public string damageTrigger = "TakeDamage", healthPara = "Health";
	private Animator anim;
	private Rigidbody rb;

	void Start(){
		anim = GetComponentInChildren<Animator> ();
		if (anim == null) {
			anim = GetComponent<Animator> ();
		}
		if (anim != null) {
			anim.SetFloat (healthPara, 0f);
		}
		rb = GetComponent<Rigidbody> ();
		rb.isKinematic = false;
		rb.useGravity = false;
	}

	public void TakeDamage(float _dam){
		anim.SetFloat (healthPara, _dam + anim.GetFloat (healthPara));
		anim.SetTrigger (damageTrigger);
	}

}
