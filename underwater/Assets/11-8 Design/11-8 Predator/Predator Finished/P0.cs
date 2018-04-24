using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P0 : MonoBehaviour {

	Rigidbody rb;
	Vector3 targetDirection;
	Vector3 currentDirection;

	void Start () {
		rb = GetComponent<Rigidbody>();
		InvokeRepeating("SetTargetDirection", 0f, 3f);
	}
		
	void FixedUpdate () {
		Move();
	}

	void SetTargetDirection(){
		targetDirection = Random.onUnitSphere;
	}

	void Move(){

		currentDirection = Vector3.RotateTowards(transform.forward, targetDirection, .05f, 0.1F);
		rb.AddForce(currentDirection * 5f);
		transform.rotation = Quaternion.LookRotation(currentDirection);

		Debug.DrawRay(transform.position, targetDirection * 2, Color.green, .2f);
		Debug.DrawRay(transform.position, currentDirection * 2, Color.red, .2f);
	}
}
