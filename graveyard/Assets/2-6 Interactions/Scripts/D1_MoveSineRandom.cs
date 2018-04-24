using UnityEngine;
using System.Collections;

public class D1_MoveSineRandom : MonoBehaviour {

	Vector3 newPosition;//The calculated next position
	Vector3 startPosition;//The original position.
	Vector3 offset;	//Determins where in the wave the object begins its motion
	Vector3 range;//Controls the distance an object will travel in each direction

	float angle; // in radians

	void Start () {
		Destroy(gameObject.GetComponent<Collider>()); //Don't want to move colliders unless a rigidbody is attached
		startPosition = transform.position;
		offset.x = Random.Range(0f, 2f * Mathf.PI);	//The argument to the Sine function is in radians
		range = new Vector3 (Random.Range(1f, 6f), 0, 0);

	}

	void FixedUpdate(){
		newPosition.x = Mathf.Sin(angle + offset.x) *  range.x;
		transform.position = newPosition + startPosition;
		angle += Time.deltaTime;
	}

}


/*	Continuously moving objects
 * 
 * 
 * 
 *
 *The Minimum
 
public class C1_MoveSineFunction : MonoBehaviour {

	Vector3 newPosition;//The calculated next position
	float angle; // in radians

	void Start () {
		Destroy(gameObject.GetComponent<Collider>()); //Don't want to move colliders unless a rigidbody is attached
	}

	void FixedUpdate(){
		newPosition.x = Mathf.Sin(angle) ;
		transform.position = newPosition;
		angle += Time.deltaTime;
		print(newPosition);
	}
}

This will work, but if you change the initial position of the box, you'll 
notice that it goes back to 0.0.0 anyway. Another way to see this is to 
create a sphere, name it Ball, and attache this sript to the Ball.

As you see, both will go to the same position and track.
To get around this, we need to create a new Vector3 called startPosition like this:

	Vector3 startPosition;//The original position. 

Then in the Start function we'll set it equal to whatever position the 
box happens to be in, like this:

	startPosition = transform.position;

Finally, after we've calculated next position, we'll add it to start position
like this:

	transform.position = newPosition + startPosition;

So the entire script will look like this:


public class C1_MoveSineFunction : MonoBehaviour {

	Vector3 newPosition;//The calculated next position
	Vector3 startPosition;//The original position.
	float angle; // in radians

	void Start () {
		Destroy(gameObject.GetComponent<Collider>()); //Don't want to move colliders unless a rigidbody is attached
		startPosition = transform.position;
	}

	void FixedUpdate(){
		newPosition.x = Mathf.Sin(angle) ;
		transform.position = newPosition + startPosition;
		angle += Time.deltaTime;
		print(newPosition);
	}
}


Now, when we start the game, both the ball and the box move from where they started,
but they are locked together, which we'd rather not have. We'd rather have each of them
start from a different place in the Sine curve.

To do that, we need to create an offset to add to angle and, because we may eventually 
want to do it in all three dimensions, we'll create a Vector3 to hold it.

We'll declare the offset like this:

	Vector3 offset;	//Determins where in the wave the object begins its motion

Then we'll create a random value in offset.x. Because the argument to Sine is in radians
we'll have to use a range from 0 to 2PI like this:

	offset = new Vector3.zero;

Assign a random number in radians like this: 

	offset.x = Random.Range(0f, 2f * Mathf.PI);	//The argument to the Sine function is in radians

And add the number to the angle like this:

	newPosition.x = Mathf.Sin(angle + offset.x) ;

Now, when you run it, you'll see the ball and the box, moving, but not locked together.

Of course it would be better still, if we could vary the distance they go. We can do that by
multiplying the result of our calculation by some number. That number will determine the range 
over which the object will travel (or the speed, if you'd like to think of it that way).

We start by declaring a new Vector3

	Vector3 range;//Controls the distance an object will travel in each direction

Give range.x a random value like this;

	range = new Vector3 (Random.Range(1f, 6f), 0, 0);

And add it to our calculation like this:

	newPosition.x = Mathf.Sin(angle + offset.x) *  range.x;



That makes the final code look like this. Of course, you'll want to make it move in the other 
two directions, and should, but this is a solid start.

//=========================================
using UnityEngine;
using System.Collections;

public class C1_MoveSineFunction : MonoBehaviour {

	Vector3 newPosition;//The calculated next position
	Vector3 startPosition;//The original position.
	Vector3 offset;	//Determins where in the wave the object begins its motion
	Vector3 range;//Controls the distance an object will travel in each direction

	float angle; // in radians

	void Start () {
		Destroy(gameObject.GetComponent<Collider>()); //Don't want to move colliders unless a rigidbody is attached
		startPosition = transform.position;
		offset.x = Random.Range(0f, 2f * Mathf.PI);	//The argument to the Sine function is in radians
		range = new Vector3 (Random.Range(1f, 6f), 0, 0);

	}

	void FixedUpdate(){
		newPosition.x = Mathf.Sin(angle + offset.x) *  range.x;
		transform.position = newPosition + startPosition;
		angle += Time.deltaTime;
	}

}







 */
