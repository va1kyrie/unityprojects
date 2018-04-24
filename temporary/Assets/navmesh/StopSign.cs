using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSign : MonoBehaviour {

	Material mat;
	public bool stop;

	// Use this for initialization
	void Start () {
		mat = GetComponent<Renderer> ().material;
		mat.color = Color.green;
		InvokeRepeating ("ChangeColor", 3f, 3f);
	}


	
	// Update is called once per frame
	void Update () {
		
	}

	void ChangeColor(){
		if (mat.color == Color.red) {
			mat.color = Color.green;
			stop = false;
		} else {
			mat.color = Color.red;
			stop = true;
		}
	}
}
