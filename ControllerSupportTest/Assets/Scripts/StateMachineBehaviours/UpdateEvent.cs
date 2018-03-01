using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateEvent : StateMachineBehaviour {

	public GameEvent gameEvent;

	public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		gameEvent.Raise();
	}

}
