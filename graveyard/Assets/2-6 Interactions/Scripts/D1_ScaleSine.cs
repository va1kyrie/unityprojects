using UnityEngine;
using System.Collections;

public class D1_ScaleSine : MonoBehaviour {


	Vector3 newScale;//The calculated next position
	Vector3 startScale;//The original position.
	public Vector3 offset;	//Determins where in the wave the object begins its motion
	public Vector3 range;//Controls the distance an object will travel in each direction

	float angle; // in radians

	void Start () {
		//Destroy(gameObject.GetComponent<Collider>()); //Don't want to move colliders unless a rigidbody is attached
		startScale = transform.localScale;
		//offset.x = Random.Range(0f, 2f * Mathf.PI);	//The argument to the Sine function is in radians
		//range = new Vector3 (Random.Range(1f, 6f), 0, 0);

	}

	void FixedUpdate(){
		newScale.x = Mathf.Sin(angle + offset.x) *  range.x;// 1f +  Mathf.Abs(Mathf.Sin(angle + offset.x) *  range.x);
		newScale.y = Mathf.Sin(angle + offset.y) *  range.y;//1f +  Mathf.Abs(Mathf.Sin(angle + offset.y) *  range.y);
		newScale.z = Mathf.Sin(angle + offset.z) *  range.z;//1f +  Mathf.Abs(Mathf.Sin(angle + offset.z) *  range.z);
		transform.localScale = newScale + startScale;
		angle += Time.deltaTime;
	}

}