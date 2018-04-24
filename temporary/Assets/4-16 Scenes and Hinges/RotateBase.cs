using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBase : MonoBehaviour {

	Vector3 rot;
	void Start () {
		rot = Vector3.zero;
		rot.y = 15f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(rot * Time.deltaTime);
	}
}
