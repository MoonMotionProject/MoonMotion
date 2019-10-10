using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Position Extensions: provides extension methods for handling positions //
public static class PositionExtensions
{
	#region localizing

	// method: returns the global position for this given vector as a position local to the given provided local transform //
	public static Vector3 toGlobalPositionFrom(this Vector3 vector, object localTransform_TransformProvider)
	{
		Transform localTransform = Provide.transformVia(localTransform_TransformProvider);

		return localTransform.TransformPoint(vector);
	}

	// method: returns the global position for this given transform as the local transform for the given provided local position //
	public static Vector3 globalPositionFor(this Transform transform, Vector3 localPosition)
		=> transform.TransformPoint(localPosition);
	#endregion localizing


	#region determining another position along the given direction

	// method: return the (global) position at the given distance away from this given (global) position, in the given direction //
	public static Vector3 positionAlong(this Vector3 position, Vector3 direction, float distance)
		=> new Ray(position, direction).GetPoint(distance.ifFiniteOtherwise(()=> Positions.maxSafeCoordinateDistance));
	// method: return the (global) position at the given distance away from this given component, in the given direction //
	public static Vector3 positionAlong(this Component component, Vector3 direction, float distance)
		=> component.position().positionAlong(direction, distance);
	// method: return the (global) position at the given distance away from this given game object, in the given direction //
	public static Vector3 positionAlong(this GameObject gameObject, Vector3 direction, float distance)
		=> gameObject.position().positionAlong(direction, distance);

	// methods: return the (global) position at the given distance away from this given provided transform, in the given local direction relative to this given provided transform //
	public static Vector3 positionAlongLocal(this GameObject gameObject, Vector3 localDirection, float distance)
		=> gameObject.positionAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(gameObject), distance);
	public static Vector3 positionAlongLocal(this Component component, Vector3 localDirection, float distance)
		=> component.gameObject.positionAlongLocal(localDirection, distance);
	#endregion determining another position along the given direction
}