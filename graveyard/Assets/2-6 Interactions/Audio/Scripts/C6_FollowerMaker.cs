using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C6_FollowerMaker : MonoBehaviour {

	public GameObject followerPrefab;
	GameObject follower;
	public Transform followerPos;

	void OnTriggerEnter (Collider otherObj) {
		if(otherObj.gameObject.tag == "Player"){
			follower = Instantiate(followerPrefab, followerPos.position, Quaternion.identity) as GameObject;
			follower.transform.parent = transform;
			follower.GetComponent<C6_Follower>().target = otherObj.transform;
			Destroy(follower, 25f);

		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
