using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echoing : MonoBehaviour {
	AudioSource echo;
	ParticleSystem fog;

	// Use this for initialization
	void Start () {
		//get the audio, assign to echo
		echo = GetComponent <AudioSource>();
		fog = GetComponentInChildren <ParticleSystem> ();
	}

	void OnTriggerEnter(Collider obj){
		if (obj.CompareTag ("Player")) {
			//if it's the player, fade in the audio
			echo.Play();
			fog.Play();
		}
	}

	void OnTriggerExit(Collider obj){
		if (obj.CompareTag ("Player")) {
			fog.Stop ();
		}
	}
}
