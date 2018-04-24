using UnityEngine;
using System.Collections;

public class D1_MoveIncrements : MonoBehaviour {

	Vector3 startPos;
	Vector3 nextPos;
	bool goingUp = true;
	float currentStep = 0;
	float maxSteps = 10;
	float stepSize = .5f;
	void Start () {
		startPos = transform.position;
		nextPos = startPos;
		InvokeRepeating( "MoveObj", 1f, .05f);
	}
	
	// Update is called once per frame
	void MoveObj () {
		if(currentStep > maxSteps){
			goingUp = false;
		} else if (currentStep < 0f){
			goingUp = true;
		}
		nextPos.y = currentStep + startPos.y;
		transform.position = nextPos;
		if(goingUp){ 
			currentStep += stepSize;
		} else {
			currentStep -= stepSize;
		}


	
	}
}
