using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Position Extensions: provides extension methods for handling positions //
public static class PositionExtensions
{
	#region localizing

	// method: returns the global position for this given vector as a position local to the given local transform //
	public static Vector3 toGlobalPositionFrom(this Vector3 vector, Transform localTransform)
		=> localTransform.TransformPoint(vector);

	// method: returns the global position for this given transform as the local transform for the given local position //
	public static Vector3 globalPositionFor(this Transform transform, Vector3 localPosition)
		=> transform.TransformPoint(localPosition);
	#endregion localizing
}