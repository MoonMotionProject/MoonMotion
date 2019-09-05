using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Direction Extensions: provides extension methods for handling directions //
public static class DirectionExtensions
{
	#region conversion

	// method: return the (global) direction vector corresponding to this given direction //
	public static Vector3 asGlobalDirectionVector(this Direction direction)
	{
		switch (direction)
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

	// method: return the local direction vector for this given direction, as relative to the given transform //
	public static Vector3 asDirectionVectorRelativeTo(this Direction direction, Transform transform)
	{
		switch (direction)
		{
			case Direction.random:
				return Random.insideUnitSphere;
			case Direction.forward:
				return transform.forward();
			case Direction.backward:
				return transform.backward();
			case Direction.right:
				return transform.right();
			case Direction.left:
				return transform.left();
			case Direction.up:
				return transform.up();
			case Direction.down:
				return transform.down();
		}
		return Vector3.zero;
	}
	#endregion conversion
}