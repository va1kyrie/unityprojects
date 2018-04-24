using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch2_14 : MonoBehaviour {
	AudioSource aud;
	public GameObject ballpre;
	GameObject ball;
	// Use this for initialization
	void Start () {
		aud = GetComponent<AudioSource> ();
	//	aud.Play ();
	}

	void OnTriggerEnter (Collider obj){
		if (obj.gameObject.tag == "Player") {
			aud.Play ();
			ball = Instantiate (ballpre, transform.position, transform.rotation) as GameObject;
			ball.transform.GetComponent<Rigidbody> ().AddForce (Random.Range(5f, 20f), Random.Range(2f, 5f), Random.Range(5f, 20f));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
