using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWeaponSet : StateMachineBehaviour {

	[Tooltip("THis is the intParam that will store the players current element index")]
	public string ElementParam = "Element";

	public AttackSet WeaponSet;

	//[Tooltip("This is where the attack will spawn from")]
	//public Transform attackOrigin;

	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		WeaponSet.Use (animator.GetInteger(ElementParam), animator.transform);
	}

}
