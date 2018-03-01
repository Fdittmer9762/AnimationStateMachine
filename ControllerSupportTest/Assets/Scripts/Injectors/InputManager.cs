using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public Animator anim;

	private Vector3 moveInput;

	void Update () {
		CheckInput ();
	}

	void CheckInput(){
		anim.SetFloat ("TempX", Input.GetAxis ("Horizontal"));

		anim.SetFloat ("TempZ", Input.GetAxis ("Vertical"));

		moveInput = new Vector3(anim.GetFloat("TempX"), 0f, anim.GetFloat("TempZ"));
		anim.SetFloat("Speed", Vector3.Distance(Vector3.zero, moveInput));

		if (Input.GetButtonDown ("Jump")) {
			anim.SetTrigger ("Jump");
		}

        if (Input.GetButtonDown("Ability01")) {
            anim.SetTrigger("Ability01");
        }

        if (Input.GetButtonDown("Ability02")) {
            anim.SetTrigger("Ability02");
        }

        if (Input.GetButtonDown("Ability03")) {
            anim.SetTrigger("Ability03");
        }
    }

}
