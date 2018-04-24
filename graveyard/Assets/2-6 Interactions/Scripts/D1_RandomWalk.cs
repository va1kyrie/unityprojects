using UnityEngine;
using System.Collections;

public class D1_RandomWalk2 : MonoBehaviour {


		Vector3 newPos;
		static public int ballCount; 

		void Start () {
			Destroy(gameObject.GetComponent<Collider>());
			transform.localScale = new Vector3(.3f, .3f, .3f);
			newPos = transform.position;
			gameObject.AddComponent<D1_SetRandomColor>();
			gameObject.name = "Ball " + ballCount;
			ballCount++;
		}

		void Update(){
	
			transform.position = GetNewPos();
		}

		Vector3 GetNewPos(){

			if(Random.Range (0f, 10f)  > 5f){
				newPos.x += .1f; // Move right a tenth of a meter
			} else {
				newPos.x -= .1f; // Move right a tenth of a meter
			}

			if(Random.Range (0f, 10f)  > 5f){
				newPos.y += .1f; // Move right a tenth of a meter
			} else {
				newPos.y -= .1f; // Move right a tenth of a meter
			}
			if(Random.Range (0f, 10f)  > 5f){
				newPos.z += .1f; // Move right a tenth of a meter
			} else {
				newPos.z -= .1f; // Move right a tenth of a meter
			}
			return newPos;

		}


}


