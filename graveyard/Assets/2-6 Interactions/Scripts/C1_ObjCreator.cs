using UnityEngine;
using System.Collections;

public class C1_ObjCreator : MonoBehaviour {

	GameObject newObject;
	public GameObject objPrefab;

	// Use this for initialization
	void Start () {
	
		InvokeRepeating("MakeAnObj", 0f, 8f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void MakeAnObj(){

		StartCoroutine(CreateObj());
	}

	IEnumerator CreateObj() {
		//print(Time.time);
		yield return new WaitForSeconds(Random.Range(1f,5f));
		newObject = Instantiate(objPrefab, transform.position, transform.rotation) as GameObject;
		newObject.transform.parent = transform;
		newObject.GetComponent<Rigidbody>().AddTorque(transform.up * Random.Range(-360f, 360f));
		newObject.GetComponent<Rigidbody>().AddTorque(transform.right * Random.Range(-360f, 360f));
		newObject.gameObject.tag = "RBCreatorBall";
		Destroy(newObject, 30f);
			
	}
}
