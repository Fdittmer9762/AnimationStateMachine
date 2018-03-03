using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoolParam : StateMachineBehaviour {

    public bool setBoolTo;
    public string paraName;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(paraName, setBoolTo);
    }

}
