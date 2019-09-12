using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Flipping Extensions: provides extension methods for flipping //
public static class FlippingExtensions
{
	// method: (according to the given boolean:) have this given transform rotate by 180° on the x axis, then return this given transform //
	public static Transform flipX(this Transform transform, bool boolean = true)
		=> transform.rotateX(180f, boolean);
	// method: (according to the given boolean:) have this given game object rotate by 180° on the x axis, then return this given game object //
	public static GameObject flipX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.flipX(boolean).gameObject;

	// method: (according to the given boolean:) have this given transform rotate by 180° on the y axis, then return this given transform //
	public static Transform flipY(this Transform transform, bool boolean = true)
		=> transform.rotateY(180f, boolean);
	// method: (according to the given boolean:) have this given game object rotate by 180° on the y axis, then return this given game object //
	public static GameObject flipY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.flipY(boolean).gameObject;

	// method: (according to the given boolean:) have this given transform rotate by 180° on the z axis, then return this given transform //
	public static Transform flipZ(this Transform transform, bool boolean = true)
		=> transform.rotateZ(180f, boolean);
	// method: (according to the given boolean:) have this given game object rotate by 180° on the z axis, then return this given game object //
	public static GameObject flipZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.flipZ(boolean).gameObject;
}