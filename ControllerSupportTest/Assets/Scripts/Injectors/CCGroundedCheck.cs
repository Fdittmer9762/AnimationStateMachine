using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CCGroundedCheck : MonoBehaviour {

	public string groundedParameter ="NotGrounded";

	private CharacterController cc;
	private Animator anim;

	void Start(){
		cc = GetComponent<CharacterController> ();
		anim = GetComponentInChildren<Animator> ();
	}

	public void CheckGrounded(){
		anim.SetBool (groundedParameter, cc.isGrounded);
	}

}
