using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFloatUsingParam : StateMachineBehaviour {

	[Tooltip("This is the name of the float parameter, will be multiplied by the input float")]
	public string ModParam;

	[Tooltip("This is the float param you want to set or modify")]
	public string SetParam;

	[Tooltip("Will be multiplied by the modParam, value of 1 will not modify the modParam")]
	public float input = 1f;

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetFloat (SetParam, input * animator.GetFloat(ModParam));
	}

}
