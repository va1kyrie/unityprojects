using UnityEngine;
using System.Collections;

public class D1_Teleporter : MonoBehaviour {

	public Transform destination;

	void OnTriggerEnter(Collider obj){
		if(obj.gameObject.tag == "Player"){
			obj.transform.position = destination.position;
		}
	}
}
