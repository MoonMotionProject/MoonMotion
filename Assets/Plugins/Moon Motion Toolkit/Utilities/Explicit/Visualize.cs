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


	#region from start and end positions

	public static void lineFrom(Vector3 startPosition, dynamic endPosition_PositionProvider, bool boolean = true, Color? color = null)
	{
		Vector3 endPosition = Provide.positionVia(endPosition_PositionProvider);

		if (boolean)
		{
			nextColorToBe(color);
			Gizmos.DrawLine(startPosition, endPosition);
		}
	}
	public static void lineFrom(GameObject startObject, dynamic endPosition_PositionProvider, bool boolean = true, Color? color = null)
	{
		Vector3 endPosition = Provide.positionVia(endPosition_PositionProvider);

		lineFrom(startObject.position(), endPosition,
			boolean,
			color);
	}
	public static void lineFrom(Component startComponent, dynamic endPosition_PositionProvider, bool boolean = true, Color? color = null)
	{
		Vector3 endPosition = Provide.positionVia(endPosition_PositionProvider);

		lineFrom(startComponent.position(), endPosition,
			boolean,
			color);
	}
	#endregion from start and end positions


	#region from start position, direction, and distance

	#region vector directions
	public static void lineFrom(Vector3 startPosition, Vector3 direction, float distance, bool boolean = true, Color? color = null)
		=> lineFrom(startPosition, startPosition.positionAlong(direction, distance),
			boolean,
			color);
	public static void lineFrom(GameObject startObject, Vector3 direction, Distinctivity distinctivity, float distance, bool boolean = true, Color? color = null)
		=> lineFrom(startObject.position(), direction.toGlobalDirectionFromDistinctivityOf(distinctivity, startObject), distance,
			boolean,
			color);
	public static void lineFrom(Component startComponent, Vector3 direction, Distinctivity distinctivity, float distance, bool boolean = true, Color? color = null)
		=> lineFrom(startComponent.gameObject, direction, distinctivity, distance,
			boolean,
			color);
	public static void localLineFrom(GameObject startObject, Vector3 localDirection, float distance, bool boolean = true, Color? color = null)
		=> lineFrom(startObject, localDirection, Distinctivity.relative, distance,
			boolean,
			color);
	public static void localLineFrom(Component startComponent, Vector3 localDirection, float distance, bool boolean = true, Color? color = null)
		=> localLineFrom(startComponent.gameObject, localDirection, distance,
			boolean,
			color);
	#endregion vector directions

	#region basic directions
	public static void lineFrom(Vector3 startPosition, BasicDirection basicDirection, float distance, bool boolean = true, Color? color = null)
		=> lineFrom(startPosition, basicDirection.asGlobalDirection(), distance,
			boolean,
			color);
	public static void lineFrom(GameObject startObject, BasicDirection basicDirection, Distinctivity distinctivity, float distance, bool boolean = true, Color? color = null)
		=> lineFrom(startObject, basicDirection.asGlobalDirection(), distinctivity, distance,
			boolean,
			color);
	public static void lineFrom(Component startComponent, BasicDirection basicDirection, Distinctivity distinctivity, float distance, bool boolean = true, Color? color = null)
		=> lineFrom(startComponent, basicDirection.asGlobalDirection(), distinctivity, distance,
			boolean,
			color);
	public static void localLineFrom(GameObject startObject, BasicDirection localBasicDirection, float distance, bool boolean = true, Color? color = null)
		=> localLineFrom(startObject, localBasicDirection.asGlobalDirection(), distance,
			boolean,
			color);
	public static void localLineFrom(Component startComponent, BasicDirection localBasicDirection, float distance, bool boolean = true, Color? color = null)
		=> localLineFrom(startComponent, localBasicDirection.asGlobalDirection(), distance,
			boolean,
			color);
	#endregion basic directions
	#endregion from start position, direction, and distance
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