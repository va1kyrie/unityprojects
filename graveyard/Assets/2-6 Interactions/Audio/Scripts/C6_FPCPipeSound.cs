using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C6_FPCPipeSound : MonoBehaviour {

	float startVolume;
	AudioSource fpcAuidio;

	void OnTriggerEnter(Collider otherObj){

		if(otherObj.gameObject.tag == "Player"){
			fpcAuidio = otherObj.GetComponent<AudioSource>();
			startVolume = fpcAuidio.volume;
			fpcAuidio.volume = 1f;
		}
	}

	void OnTriggerExit(Collider otherObj){

		if(otherObj.gameObject.tag == "Player"){
			fpcAuidio.volume = startVolume;
		}
	}
}
