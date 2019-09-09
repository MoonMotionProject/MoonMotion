using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Basic Direction Extensions: provides extension methods for handling basic directions //
public static class BasicDirectionExtensions
{
	#region conversion

	// method: return the (global) direction corresponding to this given basic direction //
	public static Vector3 asGlobalDirection(this BasicDirection direction)
	{
		switch (direction)
		{
			case BasicDirection.forward:
				return Direction.forward;
			case BasicDirection.backward:
				return Direction.backward;
			case BasicDirection.right:
				return Direction.right;
			case BasicDirection.left:
				return Direction.left;
			case BasicDirection.up:
				return Direction.up;
			case BasicDirection.down:
				return Direction.down;
		}
		return Vector3.zero;        // fallback
	}

	// method: return the local direction for this given basic direction, as relative to the given transform //
	public static Vector3 asDirectionRelativeTo(this BasicDirection direction, Transform transform)
	{
		switch (direction)
		{
			case BasicDirection.forward:
				return transform.forward();
			case BasicDirection.backward:
				return transform.backward();
			case BasicDirection.right:
				return transform.right();
			case BasicDirection.left:
				return transform.left();
			case BasicDirection.up:
				return transform.up();
			case BasicDirection.down:
				return transform.down();
		}
		return Vector3.zero;        // fallback
	}
	#endregion conversion
}