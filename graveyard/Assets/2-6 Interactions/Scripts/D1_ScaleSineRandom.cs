using UnityEngine;
using System.Collections;

/*
 *  Note, this is nearly identical to C1_MoveSineFunction. See that script for an explanation
 * */

public class D1_ScaleSineRandom : MonoBehaviour {

	Vector3 newScale;//The calculated next position
	Vector3 startScale;//The original position.
	Vector3 offset;	//Determins where in the wave the object begins its motion
	Vector3 range;//Controls the distance an object will travel in each direction
	public bool moving = false;

	float angle; // in radians

	void Start () {
		Destroy(gameObject.GetComponent<Collider>()); //Don't want to move colliders unless a rigidbody is attached
		startScale = transform.localScale;
		//The argument to the Sine function is in radians
		offset = new Vector3 (Random.Range(0f, 2f * Mathf.PI), Random.Range(0f, 2f * Mathf.PI), Random.Range(0f, 2f * Mathf.PI));
		range = new Vector3 (Random.Range(.1f, .5f), Random.Range(.1f, .5f), Random.Range(.1f, .5f));

	}

	void FixedUpdate(){
		if(moving){
			newScale.x = Mathf.Abs(Mathf.Sin(angle + offset.x) *  range.x);
			newScale.y = Mathf.Abs(Mathf.Sin(angle + offset.y) *  range.y);
			newScale.z = Mathf.Abs(Mathf.Sin(angle + offset.z) *  range.z);
			transform.localScale = newScale + startScale;
			angle += Time.deltaTime;
		}
	}

}

