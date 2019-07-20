using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Vectors: provides generic vector properties //
public static class Vectors
{
	// properties //


	// the vector of zeroes //
	public static Vector3 zeroesVector => Vector3.zero;


	// properties for: directions //

	public static Vector3 forward => Vector3.forward;

	public static Vector3 backward => -Vector3.forward;

	public static Vector3 right => Vector3.right;

	public static Vector3 left => -Vector3.right;

	public static Vector3 up => Vector3.up;

	public static Vector3 down => -Vector3.up;
}