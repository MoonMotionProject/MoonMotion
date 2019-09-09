using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Direction: provides basic direction ('BasicDirection') directions as (global) direction (floats vector) properties //
public static class Direction
{
	public static Vector3 forward => Vector3.forward;

	public static Vector3 backward => -Vector3.forward;

	public static Vector3 right => Vector3.right;

	public static Vector3 left => -Vector3.right;

	public static Vector3 up => Vector3.up;

	public static Vector3 down => -Vector3.up;
}