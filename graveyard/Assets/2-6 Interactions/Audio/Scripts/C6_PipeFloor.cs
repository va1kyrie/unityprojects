using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C6_PipeFloor : MonoBehaviour {

	public float scrollSpeedH = .05f;  //How fast the scrolling will take place
	public float scrollSpeedV = .05f;
	public bool moveNormal = true;
	Renderer rend;
	Vector2 offset;

	void Start () {
		rend = GetComponent<Renderer>();
		offset = new Vector2();
	}

	// Update is called once per frame
	void Update () {
		offset.x = Time.time * scrollSpeedH;
		offset.y = Time.time * scrollSpeedV;
		rend.material.SetTextureOffset("_MainTex", offset);
		if(moveNormal){
			rend.material.SetTextureOffset("_BumpMap", offset);
		}

	}
}
