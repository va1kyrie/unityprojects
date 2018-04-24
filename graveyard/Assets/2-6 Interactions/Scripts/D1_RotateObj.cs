using UnityEngine;
using System.Collections;

public class D1_RotateObj : MonoBehaviour {


	public Vector3 direction;

	void Update() 
	{
		transform.Rotate(direction * Time.deltaTime);
	}
}
