using UnityEngine;
using System.Collections;

public class D1_PingPong : MonoBehaviour {

	Vector3 pos;

	void Start () {
		pos = transform.position;
	}
	
	void Update() {
		pos.x = pos.x +( Mathf.PingPong(Time.time, 8) - 4f) * Time.deltaTime;
		transform.position = pos;
	}
}
