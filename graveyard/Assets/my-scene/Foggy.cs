using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foggy : MonoBehaviour {
	ParticleSystem lite;

	static Color ocol = new Color(.53f,.11f,0f,.39f); //dark reddish orange

	static Color ncol = new Color(.95f,.85f,.69f,.39f); //tan/peachy??
	static Color mcol = new Color(.96f,.57f,.68f,.39f); //orangey red WHO EVEN KNOWS
	static Color pcol = new Color(.93f,.18f,.55f,.39f); //PINK

	static Color first = new Color(.76f,.18f,.18f); //THE OG COLOR

	// Use this for initialization
	void Start () {
		lite = GetComponent <ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		lite.lights.light.color = new Color (mcol.r * Mathf.Sin (Time.time), mcol.g * Mathf.Sin (Time.time), mcol.b * Mathf.Sin (Time.time));
		lite.lights.light.intensity = Mathf.Cos (Time.time) * 1.4f;
	}
}
