using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chesire : MonoBehaviour {

	public float floatS;
	//public int rand;

	static Color ocol = new Color(.53f,.11f,0f,.39f); //dark reddish orange

	static Color ncol = new Color(.95f,.85f,.69f,.39f); //tan/peachy??
	static Color mcol = new Color(.96f,.27f,.18f,.39f); //orangey red
	static Color pcol = new Color(.93f,.18f,.55f,.39f); //PINK

	static Color first = new Color(.76f,.18f,.18f); //THE OG COLOR

	Color emit;

	Color[] choose = { ocol, ncol, mcol, pcol, first };

	float origy, origx, origz;
	Vector3 floaty;

	bool trigent;

	// Use this for initialization
	void Start () {
		origy = transform.position.y;
		origx = transform.position.x;
		origz = transform.position.z;
		emit = gameObject.GetComponent<Renderer> ().material.GetColor("_EmissionColor");
		//print ("render mode float = " + gameObject.GetComponent<Renderer> ().material.GetFloat ("_Mode"));
		trigent = false;
	}

	void OnTriggerEnter(Collider obj){
		if (obj.CompareTag ("Player")) {
			trigent = true;
		}
	}

	void OnTriggerExit(Collider obj){
		if (obj.CompareTag ("Player")) {
			trigent = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.activeInHierarchy) {
			//int rand1 = Random.Range (-3, 3);
			//gameObject.GetComponent<Renderer> ().material.SetColorArray("lecolors",choose);
			//gameObject.GetComponent<Renderer> ().material.color = Color.Lerp (first, pcol, Mathf.PingPong(Time.time, 1f));
			//gameObject.GetComponent<Renderer> ().material.SetFloat ("_Mode", 2f);
			if (trigent) {
				gameObject.GetComponent<Renderer> ().material.SetColor("_EmissionColor", new Color(emit.r * Mathf.Sin(Time.time), emit.g*Mathf.Sin(Time.time),emit.b*Mathf.Sin(Time.time)));
				gameObject.GetComponent<Renderer> ().material.SetColor ("_Color", new Color (pcol.r * Mathf.Sin (Time.time), pcol.g * Mathf.Sin (Time.time), pcol.b * Mathf.Sin (Time.time)));
			}

			floaty = transform.position;
			//int r = Random.Range (0, rand);
			floaty.y = origy + (Mathf.Sin (Time.time) * floatS);
			//floaty.z = origz + (Mathf.Sin (Time.time) * floatS);
			//floaty.x = origx + (Mathf.Sin (Time.time) * (floatS/2));
			transform.position = floaty;

		}
	}
}
