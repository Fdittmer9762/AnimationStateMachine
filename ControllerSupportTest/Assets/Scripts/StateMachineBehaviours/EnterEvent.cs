using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterEvent : StateMachineBehaviour {

    public GameEvent gameEvent;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameEvent.Raise();
    }

}
