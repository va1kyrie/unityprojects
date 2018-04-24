using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpRotation : MonoBehaviour {

	/*
	 * To control rotation, Unity uses a structure called a Quaternion.
	 * Doing so prevents a lot of messy problems, but they are not 
	 * intuitive for those of us who think of rotations around the x, y, and z
	 * axis.
	 * 
	 * There is a quaternion function that allows us to set rotations using
	 * ordinary degrees. It is called Quaternion.Euler(). The last is pronounced
	 * "oiler" and is a refference to the 18th century Swiss mathematician
	 * Leonhard Euler, easily one of the greeatest in history.
	 * 
	 * Here is how you use that function to set a rotation to x = 0, y = 75, and z = 5:
	 * 
	 * 		transform.rotation = Quaternion.Euler(0f, 75f, 5f);
	 * 
	 * The function returns a quaternion so the rotation is set correctly.
	 * 
	 * There is a Quaternion.Lerp function. Below is an example. Notice that, when lerp 
	 * <= .001, a function called SetRotation() is called. It sets startRot whatever the 
	 * current rotation is, and picks a new random rotation for endPos.
	 * 
	 * */



	Quaternion temp, startRot, endRot;
	public float lerp;

	void Start () {
		SetRotation();
	}

	void Update () {
		lerp = (Mathf.Sin(Time.time) / 2f) +.5f;
		transform.rotation = Quaternion.Lerp(startRot, endRot, lerp);
		if(lerp <= 0.001f) {
			SetRotation();
		}

	}
	void SetRotation(){
		startRot = transform.rotation;
		endRot = Random.rotation;
	}
}
