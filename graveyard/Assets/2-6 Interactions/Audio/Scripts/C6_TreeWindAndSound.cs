using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C6_TreeWindAndSound : MonoBehaviour {
	public WindZone wind;
	float startVolume;
	float startPitch;
	AudioSource audio1;
	Vector3 startPos;
	float startDistance;
	float currentDistance;
	float fractionCovered;
	Transform player;
	bool windBlowing = false;

	void Start(){
		audio1 = GetComponent<AudioSource>();
		startVolume = audio1.volume;
		startPitch = audio1.pitch;
		wind = GetComponent<WindZone>();

		wind.windMain = 0f;
		wind.windPulseFrequency =  0f;
		wind.windTurbulence = 0f;
		wind.windPulseMagnitude  = 0f;

	}

	void OnTriggerEnter(Collider otherObj){

		if(otherObj.gameObject.tag == "Player"){
			audio1.Play();
			player = otherObj.transform;
			startDistance = Vector3.Distance(player.position, transform.position);
			windBlowing = true;
		}
	}

	void Update(){
		if(windBlowing){
			fractionCovered = 1f - Vector3.Distance(player.position, transform.position)/startDistance;
			fractionCovered += .2f;
			wind.windMain = fractionCovered;
			wind.windPulseFrequency =  fractionCovered;
			wind.windTurbulence =  fractionCovered;
			wind.windPulseMagnitude  =  fractionCovered;
			audio1.pitch = fractionCovered;
			audio1.volume = fractionCovered;
		}
	}


	void OnTriggerExit(Collider otherObj){

		if(otherObj.gameObject.tag == "Player"){
			audio1.volume = startVolume;
			audio1.pitch = startPitch;
			audio1.Stop();
			wind.windMain = 0f;
			wind.windPulseFrequency = .0f;
			wind.windTurbulence = 0;
			wind.windPulseMagnitude  = 0;
			windBlowing = false;
		}
	}
}
