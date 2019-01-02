using UnityEngine;
using System.Collections;

// Rotation
// • enumerates possible directions of rotation
//   · includes a random direction
// • provides methods for determining rotational direction vectors for either possible relativity of direction:
//   · absolute (relative to nothing \global)
//   · relative to a given transform
// • spins (rotates) this object according to the specified settings //
public class Rotation : MonoBehaviour
{
	// enumerations //

	
	// enumeration of: possible directions //
	public enum Direction
	{
		random,
		forward,
		backward,
		right,
		left,
		up,
		down
	}




	// variables //

	
	// variables for: spinning this object //
	[Header("Spinning")]
	public Direction direction;		// setting: direction in which to rotate this object
	public bool relative = false;		// setting: whether this rotation should be relative to the object's transform (versus absolute)
	public float speed;		// setting: the speed at which to rotate this object
	
	
	
	
	// methods //

	
	// method: determine the vector for the given absolute direction of rotation //
	public static Vector3 vectorFor(Direction absoluteDirection)
	{
		switch (absoluteDirection)
		{
			case Direction.random:
				return Random.insideUnitSphere;
			case Direction.forward:
				return Vector3.forward;
			case Direction.backward:
				return -Vector3.forward;
			case Direction.right:
				return Vector3.right;
			case Direction.left:
				return -Vector3.right;
			case Direction.up:
				return Vector3.up;
			case Direction.down:
				return -Vector3.up;
		}
		return Vector3.zero;
	}
	// method: determine the vector for the given relative direction of rotation, relative to the given transform //
	public static Vector3 vectorFor(Direction relativeDirection, Transform relativityTransform)
	{
		switch (relativeDirection)
		{
			case Direction.random:
				return Random.insideUnitSphere;
			case Direction.forward:
				return relativityTransform.forward;
			case Direction.backward:
				return -relativityTransform.forward;
			case Direction.right:
				return relativityTransform.right;
			case Direction.left:
				return -relativityTransform.right;
			case Direction.up:
				return relativityTransform.up;
			case Direction.down:
				return -relativityTransform.up;
		}
		return Vector3.zero;
	}




	// at each update: //
	protected virtual void Update()
	{
		// determine the direction vector for rotation //
		Vector3 directionVector = (!relative ? vectorFor(direction) : vectorFor(direction, transform));
		// rotate this object by the set speed in the determined direction vector //
		transform.Rotate(directionVector * Time.deltaTime * speed);
	}
}
