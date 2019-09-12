using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Direction: provides basic direction ('BasicDirection') directions as (global) direction (floats vector) constants //
public static class Direction
{
	public static readonly Vector3 forward = Vector3.forward;

	public static readonly Vector3 backward = -Vector3.forward;

	public static readonly Vector3 right = Vector3.right;

	public static readonly Vector3 left = -Vector3.right;

	public static readonly Vector3 up = Vector3.up;

	public static readonly Vector3 down = -Vector3.up;
}