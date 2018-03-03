using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputCheck : StateMachineBehaviour {

	[Header("Script Takes and Updates Player Input")]

	private Vector3 moveInput;

	public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetFloat ("TempX", Input.GetAxis ("Horizontal"));

		animator.SetFloat ("TempZ", Input.GetAxis ("Vertical"));

		moveInput = new Vector3(animator.GetFloat("TempX"), 0f, animator.GetFloat("TempZ"));
		animator.SetFloat("Speed", Vector3.Distance(Vector3.zero, moveInput));

		if (Input.GetButtonDown ("Jump")) {
			animator.SetTrigger ("Jump");
		}

		if (Input.GetButtonDown("Ability01")) {
			animator.SetTrigger("Ability01");
		}

		if (Input.GetButtonDown("Ability02")) {
			animator.SetTrigger("Ability02");
		}

		if (Input.GetButtonDown("Ability03")) {
			animator.SetTrigger("Ability03");
		}
	}

}
