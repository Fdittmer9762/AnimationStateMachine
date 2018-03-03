using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFloatBehaviour : StateMachineBehaviour {

	[Tooltip("The value you want to set it as, OnStateEnter")]
    public float amount;

	[Tooltip("The name of the float you want to change")]
    public string paramName;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat(paramName, amount);
    }

}
