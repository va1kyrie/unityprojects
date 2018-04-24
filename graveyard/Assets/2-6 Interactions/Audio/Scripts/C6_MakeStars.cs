using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C6_MakeStars : MonoBehaviour {

	public GameObject stars;
	bool alreadyDark;

	void Start () {
		skybox = RenderSettings.skybox;
		skybox.SetFloat ("_AtmosphereThickness", 1f);
		skybox.SetFloat ("_Exposure", 1f);
		skybox.SetFloat ("_SunSize", 0f);

	}

	void OnTriggerEnter (Collider otherObj) {
		if((otherObj.gameObject.tag == "Player") & !alreadyDark){
			alreadyDark = true;
			ChangeSky();
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();

		}

	}
		


	float atmosStart;
	float atmosTarget;
	float transitionTime;
	float endTime;
	float currentThickness;
	Material skybox;

	void ChangeSky(){
		transitionTime = 8f;
		atmosStart = skybox.GetFloat("_AtmosphereThickness");
		currentThickness = atmosStart;
		endTime = Time.time + transitionTime;
		if(currentThickness > .5f){
			atmosTarget = 0.0f;
			InvokeRepeating("DarkenSky", 0f, .01f);
		} else {
			atmosTarget = 1.0f;
			InvokeRepeating("BrightenSky", 0f, .01f);
		}
	}


	void DarkenSky(){

		if(currentThickness > atmosTarget){
			currentThickness = Mathf.Lerp(atmosTarget , atmosStart, (endTime - Time.time)/transitionTime);
			skybox.SetFloat ("_AtmosphereThickness", currentThickness);
			if((currentThickness < .3f) && !stars.activeSelf) stars.SetActive(true);
		} else {
			CancelInvoke();

		}
	}

	void BrightenSky(){
		if(currentThickness < atmosTarget){
			currentThickness = Mathf.Lerp(atmosTarget, atmosStart, (endTime - Time.time)/transitionTime);
			skybox.SetFloat ("_AtmosphereThickness", currentThickness);
			if((currentThickness > .5f) && stars.activeSelf) stars.SetActive(false);
		} else {
			CancelInvoke();
		}
	}

	

}
