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

	public void TakeDamage(int _dam, int _KB, Vector3 _dir){
		
		anim.SetFloat (healthPara, _dam + anim.GetFloat (healthPara));

		float _force = (10 * _KB);

		_force += (anim.GetFloat (healthPara) / character.weight);

		_force *= .05f;

		_dir *= _force;

		anim.SetTrigger (damageTrigger);

		anim.SetFloat ("TempX", _dir.x);
		anim.SetFloat ("TempY", _dir.y);
		anim.SetFloat ("TempZ", _dir.z);

	}

}
