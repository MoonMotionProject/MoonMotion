using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Visualize: provides methods for editor visualization ("gizmos") //
public static class Visualize
{
	public static void nextColorToBe(Color? color, bool boolean = true)
	{
		if (boolean)
		{
			Gizmos.color = color ?? Default.visualizationColor;
		}
	}

	public static void lineFrom(Vector3 startPosition, Vector3 endPosition, bool boolean = true, Color? color = null)
	{
		if (boolean)
		{
			nextColorToBe(color);
			Gizmos.DrawLine(startPosition, endPosition);
		}
	}

	public static void raycastLineFrom(Vector3 startPosition, Vector3 direction, float distance, bool boolean = true, Color? color = null)
		=> lineFrom(startPosition, startPosition.positionAlong(direction, distance),
			boolean,
			color);
	public static void raycastLineFrom(GameObject startObject, Vector3 direction, Distinctivity distinctivity, float distance, bool boolean = true, Color? color = null)
		=> raycastLineFrom(startObject.position(), direction.toGlobalDirectionFromDistinctivityOf(distinctivity, startObject), distance,
			boolean,
			color);
	public static void raycastLineFrom(Component startComponent, Vector3 direction, Distinctivity distinctivity, float distance, bool boolean = true, Color? color = null)
		=> raycastLineFrom(startComponent.gameObject, direction, distinctivity, distance,
			boolean,
			color);
	public static void localRaycastLineFrom(GameObject startObject, Vector3 localDirection, float distance, bool boolean = true, Color? color = null)
		=> raycastLineFrom(startObject, localDirection, Distinctivity.relative, distance,
			boolean,
			color);
	public static void localRaycastLineFrom(Component startComponent, Vector3 localDirection, float distance, bool boolean = true, Color? color = null)
		=> localRaycastLineFrom(startComponent.gameObject, localDirection, distance,
			boolean,
			color);

	public static void sphereAt(Vector3 position, float radius, bool boolean = true, Color? color = null)
	{
		if (boolean)
		{
			nextColorToBe(color);
			Gizmos.DrawSphere(position, radius);
		}
	}
}