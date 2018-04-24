using UnityEngine;
using System.Collections;

public class C1_SimpleMouseCube : MonoBehaviour {

	Color myColor;


	void OnMouseDown(){
		if (myColor == Color.red){
			myColor = Color.blue;
		} else if (myColor == Color.blue){
			myColor = Color.green;
		} else {
			myColor = Color.red;
		}
		transform.GetComponent<Renderer>().material.color = myColor;
	}
}
