using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Position Extensions: provides extension methods for handling Positions //
public static class PositionExtensions
{
	// method: returns the global position for this given vector as a position local to the given local transform //
	public static Vector3 toGlobalPositionFrom(this Vector3 vector, Transform localTransform)
		=> localTransform.TransformPoint(vector);

	// method: returns the global position for this given transform as the local transform for the given local position //
	public static Vector3 globalPositionFor(this Transform transform, Vector3 localPosition)
		=> transform.TransformPoint(localPosition);

	// method: return the distance from this given position to the main camera //
	public static float distanceFromCamera(this Vector3 position)
		=> position.distanceWith(Camera.main.position());

	// method: return the displacement from this given position to the main camera //
	public static Vector3 displacementFromCamera(this Vector3 position)
		=> position - Camera.main.position();

	// method: return the displacement from the main camera to this given position //
	public static Vector3 displacementToCamera(this Vector3 position)
		=> Camera.main.position() - position;
}