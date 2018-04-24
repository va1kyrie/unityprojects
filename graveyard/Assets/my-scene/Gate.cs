using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {
	Rigidbody gate;

	// Use this for initialization
	void Start () {
		gate = gameObject.GetComponent<Rigidbody> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		if (col.collider.CompareTag ("Player")) {
			ContactPoint contact = col.contacts [0];
			Vector3 pos = contact.point;
			gate.AddForce (pos);
		}
	}
}
