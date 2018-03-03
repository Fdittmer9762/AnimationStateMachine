using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitEvent : StateMachineBehaviour{

    public GameEvent gameEvent;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameEvent.Raise();
    }

}
