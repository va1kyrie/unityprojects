using UnityEngine;
using System.Collections;

public class D1_RotateRandom : MonoBehaviour {


	Vector3 direction;
	public bool moving = false;
	void Start(){
		direction = new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), Random.Range(-50f, 50f));

	}


	void Update() 
	{
		if(moving){
			transform.Rotate(direction * Time.deltaTime);
		}
	}
}
