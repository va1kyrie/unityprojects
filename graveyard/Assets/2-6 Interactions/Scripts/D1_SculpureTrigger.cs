using UnityEngine;
using System.Collections;

public class D1_SculpureTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {

		SetMotion(false);
	}

	void OnTriggerEnter(Collider obj){
		
		SetMotion(true);
	}

	void OnTriggerExit(Collider obj){

		SetMotion(false);
	}

	void SetMotion(bool m){
		foreach( Transform child in transform){
			if(child.gameObject.tag == "ScalingCube"){
				child.gameObject.GetComponent<D1_ScaleSineRandom>().moving = m;
				child.gameObject.GetComponent<D1_RotateRandom>().moving = m;
			}
		}
	}
}
