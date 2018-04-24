using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class D1_GetDistance : MonoBehaviour {

	public Transform player;
	float dist;
	string distText;
	public Text sign;


	void Start () {
		InvokeRepeating("GetDistance", 1f, 1f);
	}

	void GetDistance(){
		dist = Vector3.Distance(player.position, transform.position);
		distText = "You are " + (int) dist + " meters from this box.";
		sign.text = distText;
		transform.LookAt(player);
	}
}
