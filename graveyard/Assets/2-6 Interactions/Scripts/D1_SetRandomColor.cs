using UnityEngine;
using System.Collections;

public class D1_SetRandomColor : MonoBehaviour {


	void Start () {
		SetColor();// When this command happens...
	}

	void SetColor(){// this set of commands will change the color of the object to something new;
		float r = Random.Range(.25f, .75f);
		float g = Random.Range(.25f, .75f);
		float b = Random.Range(.25f, .75f);
		Color c = new Color(r, g, b, 1f);
		transform.GetComponent<Renderer>().material.color = c;
	}
}
