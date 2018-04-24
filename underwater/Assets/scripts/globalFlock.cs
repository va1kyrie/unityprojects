using UnityEngine;
using System.Collections;

//This script is adapted from Flocking Fish in Unity 5: Creating Schooling behaviour with simple AI by Holistic3D
//https://www.youtube.com/watch?v=eMpI1eCsIyM


public class globalFlock : MonoBehaviour {

	public GameObject fishPrefab;
	public GameObject foodPrefab;

	//Static makes things available for other scripts

	public static int schoolArea = 80;

	public static int numFish = 65;
	public static GameObject[] allFish = new GameObject[numFish];
	public static Vector3 goalPos = Vector3.zero;

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < numFish; i++) 
		{
			Vector3 pos = new Vector3 (Random.Range (-schoolArea, schoolArea),
				Random.Range (-schoolArea, schoolArea),
				Random.Range (-schoolArea, schoolArea));
			allFish[i] = (GameObject) Instantiate(fishPrefab, pos, Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if(Random.Range(0,10000) < 40)
		{
			goalPos = new Vector3 (Random.Range (-schoolArea, schoolArea),
				Random.Range (-schoolArea, schoolArea),
				Random.Range (-schoolArea, schoolArea));
			foodPrefab.transform.position = goalPos;
		}
	}
}
