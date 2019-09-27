using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Default: provides various default constants //
// #default #auto
public static class Default
{
	#region miscellaneous
	public const string listingSeparator = ", ";
	public const string loggingSeparator = ": ";
	public static readonly LayerMask layerMask = -1;        // "everything" (recognize all layers)
	public const Tug tug = Tug.attraction;
	public static readonly Color visualizationColor = Color.white.withAlpha(.3f);
	#endregion miscellaneous

	#region time
	public const float interval = 1f;
	#endregion time

	#region direction
	public static readonly Vector3 direction = Direction.forward;
	public const BasicDirection basicDirection = BasicDirection.forward;
	#endregion direction

	#region raycasting
	public const bool raycastQueryingForFirstHitOnly = false;
	public const bool raycastingPositionalCollidersQuerying = true;
	public static readonly Vector3 raycastingDirection = Direction.forward;
	public const BasicDirection raycastingBasicDirection = BasicDirection.forward;
	public const float raycastingDistance = 15f;
	public const RaycastQuery raycastQuery = RaycastQuery.unlimitedHitsAndAllPositionalColliders;
	public const QueryTriggerInteraction raycastingTriggerColliderQuery = QueryTriggerInteraction.Collide;
	public const Distinctivity raycastingDistinctivity = Distinctivity.relative;
	#endregion raycasting

	#region force
	public const float forceMagnitude = 10f;
	public const float forceReach = float.MaxValue;
	public const InterpolationCurve forceCurve = InterpolationCurve.quadratic;
	public const bool targetedForceClamping = true;
	public const bool targetedForceZeroingOutsideReach = true;
	public const bool directedForceClamping = true;
	public const bool directedForceZeroingOutsideReach = true;
	#endregion force

	#region radial
	public const QueryTriggerInteraction radialTriggerColliderQuery = QueryTriggerInteraction.Collide;
	public const float forceRadius = 15f;
	#endregion radial

	#region waves
	public const float waveTrough = Wave.troughSine;
	public const float waveCrest = Wave.crestSine;
	public const float waveDuration = Wave.durationSine;
	public const float waveDurationalOffset = Wave.durationalOffsetSine;
	#endregion waves
}