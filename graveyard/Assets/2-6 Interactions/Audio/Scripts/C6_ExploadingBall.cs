using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C6_ExploadingBall : MonoBehaviour {
	public GameObject explosionPrefab;
	GameObject newExplosion;
	public AudioClip expSound;

	void Start() {
		StartCoroutine(Expload());
		GetComponent<Rigidbody>().AddForce(new Vector3 (Random.Range(-3f, 3f), Random.Range(1f, 4f), Random.Range(-3f, 3f)) * 50f);
	}

	IEnumerator Expload() {
		yield return new WaitForSeconds(Random.Range(3f, 6f));
		newExplosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
		Destroy(newExplosion, 5f);
		AudioSource.PlayClipAtPoint(expSound, transform.position, 1f);
		Destroy(gameObject);
	}
}
