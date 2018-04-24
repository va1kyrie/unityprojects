using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intensity : MonoBehaviour {

	static Color pcol = new Color(.96f,.27f,.18f,.39f); //orangey red

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Light>().color = new Color (pcol.r * Mathf.Sin (Time.time), pcol.g * Mathf.Sin (Time.time), pcol.b * Mathf.Sin (Time.time));
		gameObject.GetComponent<Light>().intensity = Mathf.Cos (Time.time) * 5f;
	}
}
