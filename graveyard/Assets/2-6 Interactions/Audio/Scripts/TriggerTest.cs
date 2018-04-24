using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter (Collider otherObj) {
		print("testhit");
		print(otherObj.gameObject.name);

	}
}
