using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C6_ExpBallLaunch : MonoBehaviour {
	public GameObject ballPrefab;
	GameObject newBall;

	private AudioSource audio1;


	void Start() {
		audio1 = GetComponent<AudioSource>();
	}

	void OnTriggerEnter (Collider otherObj) {
		if(otherObj.gameObject.tag == "Player"){
			InvokeRepeating("Launch", 0f, 3f);
		}
	}
	void OnTriggerExit (Collider otherObj) {
		if(otherObj.gameObject.tag == "Player"){
			CancelInvoke();
		}
	}

	void Launch(){

		newBall = Instantiate(ballPrefab, transform.position, transform.rotation);
		newBall.transform.parent = transform;
		audio1.Play();



	}
}
