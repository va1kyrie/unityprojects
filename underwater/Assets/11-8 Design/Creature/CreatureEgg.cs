using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Terrain must be tagged Terrain
 * 
 * 
 * */

public class CreatureEgg : MonoBehaviour {

	public GameObject creature;
	GameObject newCreature;

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "Terrain"){
			newCreature = Instantiate(creature, GetNewPosition(), Quaternion.identity);
			newCreature.transform.parent = transform.parent;

			newCreature.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range (50f, 200f));
			Destroy(gameObject);
		}
	}

	Vector3 GetNewPosition(){
		
		return transform.position + Vector3.up;
	}
}
