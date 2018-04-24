using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh2 : MonoBehaviour {
	public GameObject[] targets;
	Vector3 target;
	int nextTarget;
	NavMeshAgent agent;
	StopSign sign;
	bool waiting;
	float speed;

	// Use this for initialization
	void Start () {
		targets = GameObject.FindGameObjectsWithTag ("TARGET");
		agent = GetComponent < NavMeshAgent > ();
		FindNextTarget ();
	}

	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, target) < 1f) {
			FindNextTarget ();
		}
		if (waiting) {
			if (!sign.stop) {
				agent.speed = speed;
				waiting = false;
			}
		}
	}

	void FindNextTarget(){
		nextTarget = (int) Random.Range (0f, targets.Length);
		target = targets [nextTarget].transform.position;
		agent.destination = target;
	}

	void OnTriggerEnter(Collider obj){
		if (obj.CompareTag ("Stop")) {
			sign = obj.transform.GetComponent<StopSign> ();
			if (sign.stop) {
				speed = agent.speed;
				agent.speed = 0;
				waiting = true;
			}
		}
	}

}
