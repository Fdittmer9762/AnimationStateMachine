using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {

	public ABS_Character character;
	private CharacterController cc;
	private Animator playerAnim;
	private Vector3 tempPos;

	void OnEnable(){
		cc = GetComponent<CharacterController> ();
		playerAnim = GetComponentInChildren<Animator> ();
	}

	public void CCMove(){
		tempPos.x = playerAnim.GetFloat ("TempX")* character.baseMoveSpeed;
		tempPos.z = playerAnim.GetFloat ("TempZ")* character.baseMoveSpeed;
		tempPos.y = playerAnim.GetFloat ("TempY");
		tempPos = transform.TransformDirection(tempPos);

		cc.Move (tempPos * Time.deltaTime);
	}

}
