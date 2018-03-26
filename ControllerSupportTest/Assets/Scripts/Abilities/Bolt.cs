using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour {

	[Header ("!!!This is rough code, do not use in final!!!", order=0)]	
	[Space (10, order=1)]

	public float lifetime, speed;
	public int piercingLimit;
	private int count = 0;
	private Rigidbody RB;

	void Awake(){
		RB = GetComponent<Rigidbody> ();
		//Vector3 tempTrans = transform.TransformDirection (this.transform.localRotati);
		Vector3 tempTrans;
		/*tempTrans.x = transform.rotation.x;
		tempTrans.y = transform.rotation.y;
		tempTrans.z = transform.rotation.z;*/
		RB.velocity = Vector3.forward * speed;
		print (RB.velocity.x + " " + RB.velocity.z + " " + RB.velocity.y);
		Destroy (this.gameObject, lifetime);
	}

	void OnTriggerEnter(){
		count++;
		if (count >= piercingLimit) {
			Destroy (this.gameObject);
		}
	}
}
