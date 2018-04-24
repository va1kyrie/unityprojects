using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour {

	int maxCreatures = 30;
	public static int creatureCount;
	Rigidbody rb;// Reference to the Rigidbody attached to the object

	void Start () {
		creatureCount++; // Increase the number of creatures

		rb = GetComponent<Rigidbody>();
		Move();
		reproTimer = Time.time + Random.Range(3f, 10f);
	}
		
	float motionTimer, reproTimer;//Controls how often the object moves and reproduces

	void FixedUpdate () {
		if(Time.time > motionTimer){
			Move();
		} 
		if(Time.time > reproTimer){
			if(creatureCount < maxCreatures){
				LayEgg();
			}
		} 
	}


	/*
	 * Motion Control
	 * 
	 * This function adds a random force and resets the motion timer
	 * 
	 * */

	void Move(){
		rb.AddForce(Random.onUnitSphere * 20f);
		motionTimer = Time.time + Random.Range(1f, 5f);
	}

	/*
	 * Laying eggs
	 * 
	 * The following code, creates a new egg, which will produce a new creature
	 * 
	 * */


	public GameObject egg; //A prefab of the object that will produce a creature



	void LayEgg(){
		GameObject newEgg; //The copy we'll make of the prefab

		newEgg = Instantiate(egg, GetNewPosition(), Quaternion.identity); //create the egg
		newEgg.transform.parent = transform.parent;
		newEgg.GetComponent<Rigidbody>().AddForce(GetNewDirection() * Random.Range(100f, 300f));

		reproTimer = Time.time + Random.Range(3f, 10f); // set the time when the next egg will be laid.
	}

	Vector3 GetNewPosition(){
		Vector3 newPos;

		newPos = transform.position;
		newPos.y -= 1f; //Be sure the egg is below this object

		return newPos;
	}

	Vector3 GetNewDirection(){
		Vector2 nd; // Random.insideUnitCircle returns only an x, y vector.

		nd = Random.insideUnitCircle; // Get a random position inside a circle
		return new Vector3(nd.x, 0f, nd.y); // Assign it to a Vector3
	}


	void OnDestroy(){

		creatureCount--;
	}
}
