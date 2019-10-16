using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Position Extensions: provides extension methods for handling positions //
public static class PositionExtensions
{
	#region localizing

	// method: returns the global position for this given vector as a position local to the given provided local transform //
	public static Vector3 asLocalPositionToGlobalPositionFrom(this Vector3 vector, object localTransform_TransformProvider)
		=> localTransform_TransformProvider.provideTransform().TransformPoint(vector);

	// method: returns the global position for this given transform as the local transform for the given provided local position //
	public static Vector3 globalPositionForLocal(this Transform transform, Vector3 localPosition)
		=> transform.TransformPoint(localPosition);
	#endregion localizing


	#region determining another position along the given direction

	// method: return the (global) position at the given distance away from this given (global) position, in the given direction //
	public static Vector3 positionAlong(this Vector3 position, Vector3 direction, float distance)
		=> new Ray(position, direction).GetPoint(distance.ifFiniteOtherwise(()=> Positions.maxSafeCoordinateDistance));
	// method: return the (global) position at the given distance away from this given game object, in the given direction //
	public static Vector3 positionAlong(this GameObject gameObject, Vector3 direction, float distance)
		=> gameObject.position().positionAlong(direction, distance);
	// method: return the (global) position at the given distance away from this given component, in the given direction //
	public static Vector3 positionAlong(this Component component, Vector3 direction, float distance)
		=> component.position().positionAlong(direction, distance);

	// methods: return the (global) position at the given distance away from this given provided transform, in the given local direction relative to this given provided transform //
	public static Vector3 positionAlongLocal(this GameObject gameObject, Vector3 localDirection, float distance)
		=> gameObject.positionAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(gameObject), distance);
	public static Vector3 positionAlongLocal(this Component component, Vector3 localDirection, float distance)
		=> component.gameObject.positionAlongLocal(localDirection, distance);
	#endregion determining another position along the given direction


	#region determining another position ahead of the provided transform
	
	public static Vector3 positionAheadBy(this GameObject gameObject, float distance)
		=> gameObject.positionAlong(gameObject.forward(), distance);
	public static Vector3 positionAheadBy(this Component component, float distance)
		=> component.positionAlong(component.forward(), distance);
	#endregion determining another position ahead of the provided transform


	#region determining another position relative to the provided position, along the forward direction of the provided transform
	
	public static Vector3 positionAlongForwardOf(this Vector3 position, object transform_TransformProvider, float distance)
		=> position.positionAlong(transform_TransformProvider.provideTransform().forward(), distance);
	public static Vector3 positionAlongForwardOf(this GameObject gameObject, object transform_TransformProvider, float distance)
		=> gameObject.position().positionAlongForwardOf(transform_TransformProvider, distance);
	public static Vector3 positionAlongForwardOf(this Component component, object transform_TransformProvider, float distance)
		=> component.position().positionAlongForwardOf(transform_TransformProvider, distance);
	#endregion determining another position relative to the provided position, along the forward direction of the provided transform
}