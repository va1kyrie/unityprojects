using UnityEngine;
using System.Collections;

public class C1_TicTacToe_0 : MonoBehaviour {

	Color myColor;
	static public int numClicks;

	void Start(){
		myColor = Color.white;
		transform.GetComponent<Renderer>().material.color = myColor;
	}


	void OnMouseDown(){
		if(myColor == Color.white){
			if((numClicks % 2) == 0){
				myColor = Color.blue;
				numClicks++;
			} else {
				myColor = Color.red;
				numClicks++;
			}
			transform.GetComponent<Renderer>().material.color = myColor;
		}
		//print (numClicks);
	}
}
