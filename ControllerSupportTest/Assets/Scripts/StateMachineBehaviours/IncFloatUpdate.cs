using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncFloatUpdate : StateMachineBehaviour {

    public float rate;
    public string floatPara;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat(floatPara, animator.GetFloat(floatPara) + (Time.deltaTime * rate));
    }

}
