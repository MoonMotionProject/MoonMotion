using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rotation Extensions: provides extension methods for handling rotation //
public static class RotationExtensions
{
	#region euler rotation

	// method: (according to the given boolean:) have this given transform rotate by the given (x, y, and z) rotation angles, then return this given transform //
	public static Transform rotate(this Transform transform, Vector3 rotationAngles, bool boolean = true)
	{
		if (boolean)
		{
			transform.Rotate(rotationAngles);
		}

		return transform;
	}
	// method: (according to the given boolean:) have this given game object rotate by the given (x, y, and z) rotation angles, then return this given game object //
	public static GameObject rotate(this GameObject gameObject, Vector3 rotationAngles, bool boolean = true)
		=> gameObject.transform.rotate(rotationAngles, boolean).gameObject;

	// method: (according to the given boolean:) have this given transform rotate by the given x, y, and z rotation angles, then return this given transform //
	public static Transform rotate(this Transform transform, float x, float y, float z, bool boolean = true)
	{
		if (boolean)
		{
			transform.Rotate(x, y, z);
		}

		return transform;
	}
	// method: (according to the given boolean:) have this given game object rotate by the given x, y, and z rotation angles, then return this given game object //
	public static GameObject rotate(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.transform.rotate(x, y, z, boolean).gameObject;

	// method: (according to the given boolean:) have this given transform rotate by the given x rotation angle, then return this given transform //
	public static Transform rotateX(this Transform transform, float x, bool boolean = true)
		=> transform.rotate(FloatsVector.zeroes.withX(x), boolean);
	// method: (according to the given boolean:) have this given game object rotate by the given x rotation angle, then return this given game object //
	public static GameObject rotateX(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.transform.rotateX(x, boolean).gameObject;

	// method: (according to the given boolean:) have this given transform rotate by the given y rotation angle, then return this given transform //
	public static Transform rotateY(this Transform transform, float y, bool boolean = true)
		=> transform.rotate(FloatsVector.zeroes.withY(y), boolean);
	// method: (according to the given boolean:) have this given game object rotate by the given y rotation angle, then return this given game object //
	public static GameObject rotateY(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.rotateY(y, boolean).gameObject;

	// method: (according to the given boolean:) have this given transform rotate by the given z rotation angle, then return this given transform //
	public static Transform rotateZ(this Transform transform, float z, bool boolean = true)
		=> transform.rotate(FloatsVector.zeroes.withZ(z), boolean);
	// method: (according to the given boolean:) have this given game object rotate by the given z rotation angle, then return this given game object //
	public static GameObject rotateZ(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.rotateZ(z, boolean).gameObject;
	#endregion euler rotation
}