using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour {
	public float floatS;
	public int rand;
	ParticleSystem lite;
	bool on;

	static Color ocol = new Color(.53f,.11f,0f,.39f); //dark reddish orange

	static Color ncol = new Color(.95f,.85f,.69f,.39f); //tan/peachy??
	static Color mcol = new Color(.96f,.27f,.18f,.39f); //orangey red
	static Color pcol = new Color(.93f,.18f,.55f,.39f); //PINK

	static Color first = new Color(.76f,.18f,.18f); //THE OG COLOR

//
//	Color[] choose = { ocol, ncol, mcol, pcol, first };
	float origy, origx, origz;
	Vector3 floaty;


	// Use this for initialization
	void Start () {
		lite = GetComponent <ParticleSystem> ();
		origy = transform.position.y;
		origx = transform.position.x;
		origz = transform.position.z;
		on = false;
	}

	void OnTriggerEnter(Collider obj){
		if (obj.CompareTag ("Player") && !lite.isPlaying) {
			lite.Play ();
			on = true;
		}

		//lite.colorOverLifetime.color 
	}

	void OnTriggerExit(Collider obj){
		if (obj.CompareTag ("Player") && lite.isPlaying) {
			lite.Stop ();
			on = false;
		}
	}
		
	void Update(){
		if (on) {
			//lite.lights.light.color = new Color (pcol.r * Mathf.Sin (Time.time), pcol.g * Mathf.Sin (Time.time), pcol.b * Mathf.Sin (Time.time));
			lite.lights.light.intensity = Mathf.Cos (Time.time) * 1.2f;
			floaty = transform.position;
			//int r = Random.Range (0, rand);
			//floaty.y = origy + (Mathf.Sin (Time.time) * floatS);
			floaty.z = origz + (Mathf.Sin (Time.time) * floatS);
			floaty.x = origx + (Mathf.Sin (Time.time) * (floatS));
			transform.position = floaty;
		}
	}



}
