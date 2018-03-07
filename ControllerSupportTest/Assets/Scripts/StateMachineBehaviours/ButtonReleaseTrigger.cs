using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReleaseTrigger : StateMachineBehaviour {

    public string triggerParam;

    public string inputName;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetButtonUp(inputName)) {
            animator.SetTrigger(triggerParam);
        }
    }

}
