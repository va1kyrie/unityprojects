using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1 : MonoBehaviour {

	Rigidbody rb;
	Vector3 targetDirection, currentDirection, startPosition;

	enum Fish {swimming, returning, hunting};
	Fish action;

	void Start () {
		rb = GetComponent<Rigidbody>();
		InvokeRepeating ("SetTargetDirection", 0f, 2f);
		startPosition = transform.position;
		action = Fish.swimming;
	}

	void FixedUpdate () {
		Move();
	}

	void SetTargetDirection(){
		float distance = (transform.position - startPosition).magnitude;

		if(action == Fish.swimming){
			targetDirection = Random.onUnitSphere;
			if(distance > 5f){
				action = Fish.returning;
			}
		} else if(action == Fish.returning) {
			targetDirection = (startPosition - transform.position).normalized;
			if(distance < 1f){
				action = Fish.swimming;
			}
		}

	}

	void Move(){

		currentDirection = Vector3.RotateTowards(transform.forward, targetDirection, .05f, 0.1F);
		rb.AddForce(currentDirection.normalized * 2f);
		transform.rotation = Quaternion.LookRotation(currentDirection);

		Debug.DrawRay(transform.position, targetDirection * 2, Color.green, .2f);
		Debug.DrawRay(transform.position, currentDirection * 2, Color.red, .2f);
	}
}
