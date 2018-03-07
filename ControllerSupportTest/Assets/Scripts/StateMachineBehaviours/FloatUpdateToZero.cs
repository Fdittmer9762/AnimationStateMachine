using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUpdateToZero : StateMachineBehaviour{

	[Tooltip("The name of the float you want to change")]
	public string floatParam;

	[Tooltip("The rate per second it moves to zero, neg values move away from zero")]
	public float rate;

	private bool move;

	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		move = true;
	}

	public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (move) {
			if (animator.GetFloat (floatParam) >= 0) {
				animator.SetFloat (floatParam, animator.GetFloat (floatParam) - (rate * Time.deltaTime));
			} else {
				animator.SetFloat (floatParam, animator.GetFloat (floatParam) + (rate * Time.deltaTime));
			}
		}

		if (Mathf.Abs (animator.GetFloat (floatParam))<= (rate*Time.deltaTime)) {
			animator.SetFloat (floatParam, 0f);
			move = false;
		}
	}


}
