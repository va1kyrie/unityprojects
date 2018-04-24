using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C2 : MonoBehaviour {
	Rigidbody rb;

	float motionTimer, reproTimer;
	void Start () {
		rb = GetComponent<Rigidbody>();
		Move();
		reproTimer = Time.time + Random.Range(3f, 10f);
	}

	void FixedUpdate () {
		if(Time.time > motionTimer){
			Move();
		} 
		if(Time.time > reproTimer){
			LayEgg();
		} 
	}

	// Move the object
	void Move(){
		rb.AddForce(Random.onUnitSphere * 10f);
		motionTimer = Time.time + Random.Range(1f, 5f);
	}

	// Lay the egg
	public GameObject egg;

	void LayEgg(){
		GameObject newEgg;

		newEgg = Instantiate(egg, GetNewPosition(), Quaternion.identity); //create the egg
		newEgg.transform.parent = transform.parent;
		reproTimer = Time.time + Random.Range(3f, 10f); // set the time when the next egg will be layed.
	}


	Vector3 GetNewPosition(){
		Vector3 newPos;

		newPos = transform.position;
		newPos.y -= 1f; //Be sure the egg is below this object

		return newPos;
	}
}
