using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Visualize: provides methods for editor visualization ("gizmos") //
public static class Visualize
{
	#region color


	public static void nextColorToBe(Color? color, bool boolean = true)
	{
		if (boolean)
		{
			Gizmos.color = color ?? Default.visualizationColor;
		}
	}
	#endregion color




	#region lines


	#region nonraycasting

	public static void lineFrom(Vector3 startPosition, Vector3 endPosition, bool boolean = true, Color? color = null)
	{
		if (boolean)
		{
			nextColorToBe(color);
			Gizmos.DrawLine(startPosition, endPosition);
		}
	}
	#endregion nonraycasting


	#region raycasting

	#region vector directions
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
	#endregion vector directions

	#region basic directions
	public static void raycastLineFrom(Vector3 startPosition, BasicDirection basicDirection, float distance, bool boolean = true, Color? color = null)
		=> raycastLineFrom(startPosition, basicDirection.asGlobalDirection(), distance,
			boolean,
			color);
	public static void raycastLineFrom(GameObject startObject, BasicDirection basicDirection, Distinctivity distinctivity, float distance, bool boolean = true, Color? color = null)
		=> raycastLineFrom(startObject, basicDirection.asGlobalDirection(), distinctivity, distance,
			boolean,
			color);
	public static void raycastLineFrom(Component startComponent, BasicDirection basicDirection, Distinctivity distinctivity, float distance, bool boolean = true, Color? color = null)
		=> raycastLineFrom(startComponent, basicDirection.asGlobalDirection(), distinctivity, distance,
			boolean,
			color);
	public static void localRaycastLineFrom(GameObject startObject, BasicDirection localBasicDirection, float distance, bool boolean = true, Color? color = null)
		=> localRaycastLineFrom(startObject, localBasicDirection.asGlobalDirection(), distance,
			boolean,
			color);
	public static void localRaycastLineFrom(Component startComponent, BasicDirection localBasicDirection, float distance, bool boolean = true, Color? color = null)
		=> localRaycastLineFrom(startComponent, localBasicDirection.asGlobalDirection(), distance,
			boolean,
			color);
	#endregion basic directions
	#endregion raycasting
	#endregion lines




	#region spheres


	public static void sphereAt(Vector3 position, float radius, bool boolean = true, Color? color = null)
	{
		if (boolean)
		{
			nextColorToBe(color);
			Gizmos.DrawSphere(position, radius);
		}
	}
	#endregion spheres
}