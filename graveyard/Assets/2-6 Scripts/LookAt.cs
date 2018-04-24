using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	Quaternion startRotation;
	bool looking;
	Transform player;

	void Start () {
		startRotation = transform.rotation;
	}
	void Update(){
		if(looking){
			transform.LookAt(player);
		}
	}
	


	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			player = other.gameObject.transform;
			transform.rotation = Quaternion.identity;
			looking = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player"){
			transform.rotation = startRotation;
			looking = false;
		}
	}
}
