using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBKnockBack : MonoBehaviour {

	public Animator anim;

	public string DirParam_X, DirParam_Y, DirParam_Z;
	public Rigidbody rb;

	public void KnockBack ()
	{
		Vector3 _force = Vector3.zero;
		_force.x = anim.GetFloat (DirParam_X);
		_force.y = anim.GetFloat (DirParam_Y);
		_force.z = anim.GetFloat (DirParam_Z);
		ActivateRB (_force);
	}

	public void ExitKB (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		DeactivateRB ();
	}

	private void ActivateRB(Vector3 _f){
		rb.useGravity = true;
		rb.isKinematic = false;
		rb.velocity = _f;
	}

	private void DeactivateRB(){
		rb.velocity = Vector3.zero;
		rb.useGravity = false;
		rb.isKinematic = true;
	}

}
