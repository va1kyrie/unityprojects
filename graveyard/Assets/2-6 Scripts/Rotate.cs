using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public Vector3 newRot = Vector3.up *50;


	

	void Update () {
		transform.Rotate(newRot);
	}
}
