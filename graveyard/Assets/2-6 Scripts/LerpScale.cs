using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpScale : MonoBehaviour {

	/*
	 * 
	 * Animamting scale is exactly like animating position. In this case, we change the target
	 * scale whenever lerp is less than a certain limit.
	 * 
	 * Note we are using the timeOffset variable so that we can put this on multiple
	 * overlaping objects and have them scale independently.
	 * 
	 * */

	Vector3 startScale, endScale;
	float lerp, timeOffset;

	void Start () {
		SetTargets();
		timeOffset = Random.Range(0f, 360f);
	}

	void Update () {
		lerp = (Mathf.Sin(Time.time + timeOffset) / 2f) +.5f;
		transform.localScale = Vector3.Lerp(startScale, endScale, lerp);
		if(lerp < .00001f) SetTargets();

	}
	void SetTargets(){
		startScale = transform.localScale;
		endScale = new Vector3(Random.Range(.2f, 5f), Random.Range(.2f, 5),Random.Range(.2f, 5f));

	}
}