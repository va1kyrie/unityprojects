using UnityEngine;
using System.Collections;

public class DestroyCollidingObject : MonoBehaviour {

	void OnCollisionEnter(Collision otherObj){

		if(otherObj.gameObject.tag == "RBCreatorBall"){
			Destroy(otherObj.gameObject);
		}
			
	}
}
