using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulbs : MonoBehaviour {
	Light lit;
	Renderer rend;
	Color ocol = new Color(135f,28f,0f);
	Color ncol = new Color(243f,217f,177f);
	Color mcol = new Color(244f,68f,46f);
	
	// Use this for initialization
	void Start () {
		lit = GetComponentInChildren<Light> ();
		rend = GetComponent<Renderer> ();
	}

	void OnTriggerEnter(Collider obj){
		if (obj.CompareTag ("Player")) {
			lit.enabled = true;
			//rend.material.color = ocol;
			rend.enabled = true;
		}
	}

	void OnTriggerExit(Collider obj){
		if (obj.CompareTag ("Player")) {
			lit.enabled = false;
			//rend.material.color = Color.clear;
			rend.enabled = false;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
