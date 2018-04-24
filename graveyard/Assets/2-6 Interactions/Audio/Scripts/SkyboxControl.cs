using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxControl : MonoBehaviour {


	void Start () {
		skybox = RenderSettings.skybox;
		ChangeSky();
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
		print("Darken " + (endTime - Time.time)/transitionTime);
		if(currentThickness > atmosTarget){
			currentThickness = Mathf.Lerp(atmosTarget , atmosStart, (endTime - Time.time)/transitionTime);
			skybox.SetFloat ("_AtmosphereThickness", currentThickness);
			print("Darken " + (endTime - Time.time)/transitionTime);
		} else {
			CancelInvoke();
		}
	}

	void BrightenSky(){
		print("Brighten " + (1f - (endTime - Time.time)/transitionTime));
		if(currentThickness < atmosTarget){
			currentThickness = Mathf.Lerp(atmosStart, atmosTarget, 1f - (endTime - Time.time)/transitionTime);
			skybox.SetFloat ("_AtmosphereThickness", currentThickness);
		} else {
			CancelInvoke();
		}
	}
}

