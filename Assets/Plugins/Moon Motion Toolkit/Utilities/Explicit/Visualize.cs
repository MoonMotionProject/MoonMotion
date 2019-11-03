﻿using System.Collections;
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




	#region rays


	#region vector directions

	public static void rayFrom(Vector3 startPosition, Vector3 direction, bool boolean = true, Color? color = null)
		=> lineFrom(startPosition, direction, Positions.maxSafeCoordinateDistance, boolean, color);
	public static void rayFrom(GameObject startGameObject, Vector3 direction, Distinctivity distinctivity, bool boolean = true, Color? color = null)
		=> rayFrom(startGameObject.position(), direction.toGlobalDirectionFromDistinctivityOf(distinctivity, startGameObject),
			boolean,
			color);
	public static void rayFrom(Component startComponent, Vector3 direction, Distinctivity distinctivity, bool boolean = true, Color? color = null)
		=> rayFrom(startComponent.gameObject, direction, distinctivity,
			boolean,
			color);
	public static void localRayFrom(GameObject startGameObject, Vector3 localDirection, bool boolean = true, Color? color = null)
		=> rayFrom(startGameObject, localDirection, Distinctivity.relative,
			boolean,
			color);
	public static void localRayFrom(Component startComponent, Vector3 localDirection, bool boolean = true, Color? color = null)
		=> localRayFrom(startComponent.gameObject, localDirection,
			boolean,
			color);
	#endregion vector directions


	#region basic directions

	public static void rayFrom(Vector3 startPosition, BasicDirection basicDirection, bool boolean = true, Color? color = null)
		=> rayFrom(startPosition, basicDirection.asGlobalDirection(),
			boolean,
			color);
	public static void rayFrom(GameObject startGameObject, BasicDirection basicDirection, Distinctivity distinctivity, bool boolean = true, Color? color = null)
		=> rayFrom(startGameObject, basicDirection.asGlobalDirection(), distinctivity,
			boolean,
			color);
	public static void rayFrom(Component startComponent, BasicDirection basicDirection, Distinctivity distinctivity, bool boolean = true, Color? color = null)
		=> rayFrom(startComponent, basicDirection.asGlobalDirection(), distinctivity,
			boolean,
			color);
	public static void localRayFrom(GameObject startGameObject, BasicDirection localBasicDirection, bool boolean = true, Color? color = null)
		=> localRayFrom(startGameObject, localBasicDirection.asGlobalDirection(),
			boolean,
			color);
	public static void localRayFrom(Component startComponent, BasicDirection localBasicDirection, bool boolean = true, Color? color = null)
		=> localRayFrom(startComponent, localBasicDirection.asGlobalDirection(),
			boolean,
			color);
	#endregion basic directions
	#endregion rays




	#region lines


	#region from start and end positions

	public static void lineFrom(Vector3 startPosition, object endPosition_PositionProvider, bool boolean = true, Color? color = null)
	{
		if (boolean)
		{
			nextColorToBe(color);
			Gizmos.DrawLine(startPosition, endPosition_PositionProvider.providePosition());
		}
	}
	public static void lineFrom(GameObject startGameObject, object endPosition_PositionProvider, bool boolean = true, Color? color = null)
		=>	lineFrom(startGameObject.position(), endPosition_PositionProvider.providePosition(),
				boolean,
				color);
	public static void lineFrom(Component startComponent, object endPosition_PositionProvider, bool boolean = true, Color? color = null)
		=>	lineFrom(startComponent.position(), endPosition_PositionProvider.providePosition(),
				boolean,
				color);
	#endregion from start and end positions


	#region from start position, direction, and distance

	#region vector directions
	public static void lineFrom(Vector3 startPosition, Vector3 direction, float distance, bool boolean = true, Color? color = null)
	{
		if (distance.isInfinite())
		{
			rayFrom(startPosition, direction,
				boolean,
				color);
		}
		else
		{
			lineFrom(startPosition, startPosition.positionAlong(direction, distance),
				boolean,
				color);
		}
	}
	public static void lineFrom(GameObject startGameObject, Vector3 direction, Distinctivity distinctivity, float distance, bool boolean = true, Color? color = null)
		=>	lineFrom(startGameObject.position(), direction.toGlobalDirectionFromDistinctivityOf(distinctivity, startGameObject), distance,
				boolean,
				color);
	public static void lineFrom(Component startComponent, Vector3 direction, Distinctivity distinctivity, float distance, bool boolean = true, Color? color = null)
		=>	lineFrom(startComponent.gameObject, direction, distinctivity, distance,
				boolean,
				color);
	public static void localLineFrom(GameObject startGameObject, Vector3 localDirection, float distance, bool boolean = true, Color? color = null)
		=>	lineFrom(startGameObject, localDirection, Distinctivity.relative, distance,
				boolean,
				color);
	public static void localLineFrom(Component startComponent, Vector3 localDirection, float distance, bool boolean = true, Color? color = null)
		=>	localLineFrom(startComponent.gameObject, localDirection, distance,
				boolean,
				color);
	#endregion vector directions

	#region basic directions
	public static void lineFrom(Vector3 startPosition, BasicDirection basicDirection, float distance, bool boolean = true, Color? color = null)
		=> lineFrom(startPosition, basicDirection.asGlobalDirection(), distance,
			boolean,
			color);
	public static void lineFrom(GameObject startGameObject, BasicDirection basicDirection, Distinctivity distinctivity, float distance, bool boolean = true, Color? color = null)
		=>	lineFrom(startGameObject, basicDirection.asGlobalDirection(), distinctivity, distance,
				boolean,
				color);
	public static void lineFrom(Component startComponent, BasicDirection basicDirection, Distinctivity distinctivity, float distance, bool boolean = true, Color? color = null)
		=>	lineFrom(startComponent, basicDirection.asGlobalDirection(), distinctivity, distance,
				boolean,
				color);
	public static void localLineFrom(GameObject startGameObject, BasicDirection localBasicDirection, float distance, bool boolean = true, Color? color = null)
		=>	localLineFrom(startGameObject, localBasicDirection.asGlobalDirection(), distance,
				boolean,
				color);
	public static void localLineFrom(Component startComponent, BasicDirection localBasicDirection, float distance, bool boolean = true, Color? color = null)
		=>	localLineFrom(startComponent, localBasicDirection.asGlobalDirection(), distance,
				boolean,
				color);
	#endregion basic directions
	#endregion from start position, direction, and distance
	#endregion lines




	#region boxes


	public static void boxAt(object position_PositionProvider, Color? color = null, bool boolean = true, Vector3? dimensions = null)
	{
		if (boolean)
		{
			nextColorToBe(color);
			Gizmos.DrawCube(position_PositionProvider.providePosition(), dimensions ?? Default.boxVisualizationDimensions);
		}
	}

	public static void boxSittingAt(object position_PositionProvider, Color? color = null, bool boolean = true, Vector3? dimensions = null)
		=>	boxAt
			(
				position_PositionProvider.providePosition()
					.withY(position_PositionProvider.providePosition().y + ((dimensions ?? Default.boxVisualizationDimensions).y / 2f)),
				color,
				boolean,
				dimensions
			);
	#endregion boxes




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




	#region wire spheres


	public static void wireSphereAt(Vector3 position, float radius, bool boolean = true, Color? color = null)
	{
		if (boolean)
		{
			nextColorToBe(color);
			Gizmos.DrawWireSphere(position, radius);
		}
	}
	#endregion wire spheres




	#region icons


	public static void iconAt(object position_PositionProvider, string name, bool allowScaling = Default.scalingOfVisualizedIcons, bool boolean = true)
	{
		if (boolean)
		{
			Gizmos.DrawIcon(position_PositionProvider.providePosition(), name, allowScaling);
		}
	}
	#endregion icons




	#region textures


	public static void textureAt(Rect screenRectangle, Texture texture, bool boolean = true)
	{
		if (boolean)
		{
			Gizmos.DrawGUITexture(screenRectangle, texture);
		}
	}
	#endregion textures
}