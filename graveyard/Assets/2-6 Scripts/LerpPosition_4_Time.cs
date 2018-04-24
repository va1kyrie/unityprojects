using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPosition_4_Time : MonoBehaviour {

	/*
	 * Sometimes you want to control the time it takes to get from one position
	 * to the next. In this example:
	 * 
	 * 		startPos and endPos define where the object will move
	 * 		lerp is the number that controls what fraction of the trip is made
	 * 		travelTime is the amount of time we want the trip to last.
	 * 		stopTime is the time at which the object must stop moving.
	 * 		Time.time is the time in microseconds since the game began
	 * 
	 * Time.time will give us the current time. If we add that to travel time and put
	 * the result into stopTime, we'll want the motion to stop when Time.time = stopTime.
	 * That will happen when Time.time / stopTime = 1 (because they are the same number).
	 * 
	 * */


	public Vector3 direction = new Vector3(0f, 3f, 0f);
	public float travelTime = 5f;

	Vector3 startPos, endPos;
	float lerp, stopTime;



	void Start () {
		startPos = transform.position;
		endPos = startPos + direction;
		stopTime = Time.time + travelTime;
		endPos = startPos + direction;
	}


	void Update () {
		lerp = Time.time / stopTime;
		transform.position = Vector3.Lerp(startPos, endPos, lerp);
	}
}