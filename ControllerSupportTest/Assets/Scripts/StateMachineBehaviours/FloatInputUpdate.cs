using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatInputUpdate : StateMachineBehaviour {

	public string inputAxis;

	public string inputParam;

	public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetFloat (inputParam, Input.GetAxis (inputAxis));
	}

}
