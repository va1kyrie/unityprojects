using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2 : MonoBehaviour {

	Rigidbody rb;
	Vector3 targetDirection, currentDirection, startPosition;
	Transform prey;//

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
			} else if(action == Fish.hunting){
				targetDirection = (prey.position - transform.position).normalized;////
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
	//
	void OnTriggerEnter(Collider otherObj){
		if(otherObj.gameObject.tag == "Terrain"){
			action = Fish.returning;
			SetTargetDirection();
		} else if(otherObj.gameObject.tag == "Prey"){
			action = Fish.hunting;
			prey = otherObj.transform;
			SetTargetDirection();
		}
	}
	void OnTriggerExit(Collider otherObj){
		if(otherObj.gameObject.tag == "Prey"){
			action = Fish.swimming;
			SetTargetDirection();
			print("missed it");
		}
	}

	void OnCollisionEnter(Collision otherObj){
		if(otherObj.gameObject.tag == "Prey"){
			Destroy(otherObj.gameObject);
			action = Fish.swimming;
			SetTargetDirection();
			print("got it");
		}

	}
}
