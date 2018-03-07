using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressTrigger : StateMachineBehaviour {

    public string triggerParam;

    public string inputName;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (Input.GetButtonDown(inputName)) {
            animator.SetTrigger(triggerParam);
        }
    }


}
