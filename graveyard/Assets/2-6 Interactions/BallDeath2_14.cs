using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDeath2_14 : MonoBehaviour {
	public GameObject burst;
	public AudioClip aud;

	// Use this for initialization
	void Start () {
		//aud = GetComponent <AudioSource> ();
		Invoke("Die", Random.Range(1f, 5f));
	}
	
	// Update is called once per frame
	void Die () {
		Instantiate (burst, transform.position, transform.rotation);
		AudioSource.PlayClipAtPoint (aud, transform.position);
		Destroy (gameObject);

	}
}
