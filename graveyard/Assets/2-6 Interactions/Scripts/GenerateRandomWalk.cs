using UnityEngine;
using System.Collections;

public class GenerateRandomWalk : MonoBehaviour {

	public float numSpheres = 50;
	public GameObject spherePrefab;
	GameObject newSphere;

	void Start () {

	/*	for(int i = 0; i < numSpheres; i++){
			newSphere = Instantiate(spherePrefab, transform.position, transform.rotation) as GameObject;
			newSphere.transform.parent = transform;

		}*/
	
	}

	void OnEnable(){
		foreach( Transform child in transform){
			Destroy(child.gameObject);
		}
		for(int i = 0; i < numSpheres; i++){
			newSphere = Instantiate(spherePrefab, transform.position, transform.rotation) as GameObject;
			newSphere.transform.parent = transform;

		}


	}
	

	void Update () {
	
	}
}
