using UnityEngine;
using System.Collections;

public class MaterialMover : MonoBehaviour {

	/*       Texture Control 
When this script is applied to an object with a material containing both 
a texture and a normal map, it will cause the two to move in different directions.

		Offsetting the material
Two calls to the renderer tell it to offset the material by the amounts 
in offsetH and offsetV.  They don't have to be used together and can even be 
given different values.
	
	_MainTex is the Texture
	_BumpMap is the normal map 
	_Cube is the reflection cube map 
*/

	public float scrollSpeedH = .05f;  //How fast the scrolling will take place
	public float scrollSpeedV = .05f;
	public bool moveNormal = false;
	Renderer rend;
	Vector2 offset;

	void Start () {
		rend = GetComponent<Renderer>();
		offset = new Vector2();
	}

	// Update is called once per frame
	void Update () {
		offset.x = Time.time * scrollSpeedH;
		offset.y = Time.time * scrollSpeedV;
		rend.material.SetTextureOffset("_MainTex", offset);
		if(moveNormal){
			rend.material.SetTextureOffset("_BumpMap", offset);
		}

	}
}
