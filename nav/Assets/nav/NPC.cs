using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour {
	public Transform target;
	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(target.position);

	}
}
