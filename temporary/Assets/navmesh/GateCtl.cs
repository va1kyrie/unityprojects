using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCtl : MonoBehaviour {

	bool open;

	// Use this for initialization
	void Start () {
		open = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")){
			if (open) {
				transform.Translate (0f, -3f, 0f);
				open = false;
			} else {
				transform.Translate (0f, 3f, 0f);
				open = true;
			}
		}

	}
}
