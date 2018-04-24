using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C6_Follower : MonoBehaviour {

	float speed = 500f;
	public Transform target;
	Vector3 direction;
	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		direction = target.gameObject.transform.position - gameObject.transform.position;
		rb.AddForce(direction.normalized * speed * Time.deltaTime);
	}
}
