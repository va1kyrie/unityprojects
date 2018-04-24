using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C6_SimpleTrigger : MonoBehaviour {

	AudioSource music;

	void Start() {
		music = GetComponent<AudioSource>();
	}


	void OnTriggerEnter (Collider otherObj) {
		if(otherObj.gameObject.tag == "Player"){
			music.Play();
		}
	}
	void OnTriggerExit (Collider otherObj) {
		if(otherObj.gameObject.tag == "Player"){
			music.Stop();
		}
	}
}
