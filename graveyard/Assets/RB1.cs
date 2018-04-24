using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB1 : MonoBehaviour {

	public GameObject rbprefab;
	GameObject rb;
	// Use this for initialization
	void Start () {
		//InvokeRepeating ("MakeRB", 0f,  2f);
	}

	void MakeRB(){
		rb = Instantiate (rbprefab, transform.position, transform.rotation) as GameObject;
		rb.GetComponent<Rigidbody> ().AddForce (Random.insideUnitSphere * 50f);
		Destroy (rb, 5f*Random.value);
	}

	void OnTriggerEnter(Collider obj){
		if (obj.gameObject.tag == "Player") {
			InvokeRepeating ("MakeRB", 0f,  2f);
		}
	}

	void OnTriggerExit(Collider obj){
		if (obj.gameObject.tag == "Player") {
			CancelInvoke ();
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
