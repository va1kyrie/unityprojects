using UnityEngine;
using System.Collections;

public class flock : MonoBehaviour {

	//The speed of the fish

	public float speed = 1f;
	public float rotationSpeed = 3f;
	public float minSpeed = 1.0f; 
	public float maxSpeed = 2.0f;

	Vector3 averageHeading;
	Vector3 averagePosition;

	//Maximum distance for fish to be within to flock, they'll only flock if they are near each other
	public float neighborDistance = 235.0f;

	Vector3 newGoalPos;
	bool turning = false;

	void OnTriggerEnter(Collider other)
	{
		if (!turning) {
			newGoalPos = this.transform.position - other.gameObject.transform.position;
		}

		turning = true;

	}

	void OnTriggerExit(Collider other)
	{
		turning = false;
	}

	// Use this for initialization
	void Start () 
	{
		speed = Random.Range (minSpeed, maxSpeed); //This is for the fish to have different speeds.
		Animator animator = GetComponent<Animator>();
		animator.speed = speed / 2f;
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance(transform.position, Vector3.zero) >= globalFlock.schoolArea) 
		{
			turning = true;
		} 
		else
			turning = false;

		if (turning) {
			Vector3 direction = Vector3.zero - transform.position;
			transform.rotation = Quaternion.Slerp(transform.rotation,
				Quaternion.LookRotation (direction),
				rotationSpeed * Time.deltaTime);
			speed = Random.Range (50f, 80);
		} 
		else 
		{
			if (Random.Range (0, 10) < 1)
				ApplyRules ();
		}
		transform.Translate (0, 0, Time.deltaTime * speed); //This pushes the fish forward.
	}
	void ApplyRules()
	{
		GameObject[] gos;
		gos = globalFlock.allFish;

		Vector3 vcentre = Vector3.zero;
		Vector3 vavoid = Vector3.zero;
		float gSpeed = 1.3f;
	
		Vector3 goalPos = globalFlock.goalPos;

		float dist;

		int groupSize = 0; //Group size is based on neighbor distance. The fish will join the flock if they are with in it.
		foreach (GameObject go in gos) 
		{
			if (go != this.gameObject) 
			{
				dist = Vector3.Distance (go.transform.position, this.transform.position);
				if (dist <= neighborDistance) 
				{
					vcentre += go.transform.position;
					groupSize++;

					if (dist < 20.0f) //The fish will turn away from each other if they are within this distance. 
					{
						vavoid = vavoid + (this.transform.position - go.transform.position);
					}

					flock anotherFlock = go.GetComponent<flock>();
					gSpeed = gSpeed + anotherFlock.speed;
				}
			}
		}
		if (groupSize > 0) 
		{
			vcentre = vcentre / groupSize + (goalPos - this.transform.position);
			speed = gSpeed / groupSize;

			Vector3 direction = (vcentre + vavoid) - transform.position;
			if (direction != Vector3.zero)
				transform.rotation = Quaternion.Slerp (transform.rotation,
					Quaternion.LookRotation (direction),
					rotationSpeed * Time.deltaTime);
		}
	}
}
	//This is for the slider adjustments
//	public void AdjustSpeedMultiplier (float newRotationSpeed) {
//		rotationSpeed = newRotationSpeed;
//	}

