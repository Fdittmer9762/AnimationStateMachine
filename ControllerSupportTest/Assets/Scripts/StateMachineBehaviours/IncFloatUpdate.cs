using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncFloatUpdate : StateMachineBehaviour {

	[Tooltip("The amount per second you want to change the float")]
    public float rate;

	[Tooltip("The name of the float you want to change")]
    public string floatPara;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat(floatPara, animator.GetFloat(floatPara) + (Time.deltaTime * rate));
    }

}
