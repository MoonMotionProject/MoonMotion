using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tugging Extensions: provides extension methods for tugging (raycastedly directedly forcing (applying directed force to raycasted targets))
// #force #raycasting
public static class TuggingExtensions
{
	// methods: apply a directed force with the given or declared affinity from this given raycasting position or provider of a raycasting position (respectively) along the given raycast direction with the given or appropriate distinctivity, with the given magnitude, affecting rigidbodies (ensuring unique rigidbodies; a methods variant to affect rigidbodies repeatedly for each collider hit is not implemented yet) with colliders matching the given layer mask (if specified) and only within the given raycasting distance and using the given raycast query and trigger collider query, diminishing magnitude from the raycasting position (to raycasting distance) to zero using the given curve, then return the set of objects affected //


	#region tugging with the given affinity
	
	public static HashSet<GameObject> tug
	(
		this Vector3 raycastingPosition,
		Affinity affinity,
		Vector3 raycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingPosition.raycastedRigidbodiesAlong
			(
				raycastDirection,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			).applyDirectedForceToEachFrom
			(
				raycastingPosition,
				raycastDirection * affinity.asOppositeSign(),
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve
			).uniqueObjects();
	public static HashSet<GameObject> tug
	(
		this Vector3 raycastingPosition,
		Affinity affinity,
		object raycastEndPosition_PositionProvider,
		float magnitude = Default.forceMagnitude,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingPosition.tug
		(
			affinity,
			raycastingPosition.directionTo(raycastEndPosition),
			magnitude,
			raycastingPosition.distanceWith(raycastEndPosition),
			raycastDistanceMagnitudeZeroingCurve,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<GameObject> tug
	(
		this GameObject raycastingObject,
		Affinity affinity,
		Vector3 raycastDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.raycastedRigidbodiesAlong
			(
				raycastDirection,
				raycastDistinctivity,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			).applyDirectedForceToEachFrom
			(
				raycastingObject,
				raycastDirection * affinity.asOppositeSign(),
				raycastDistinctivity,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve
			).uniqueObjects();
	public static HashSet<GameObject> tug
	(
		this GameObject raycastingObject,
		Affinity affinity,
		BasicDirection raycastBasicDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.tug
			(
				affinity,
				raycastBasicDirection.asGlobalDirection(),
				raycastDistinctivity,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> tug
	(
		this GameObject raycastingObject,
		Affinity affinity,
		Vector3 localRaycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.tug
			(
				affinity,
				localRaycastDirection,
				Distinctivity.relative,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> tugGlobally
	(
		this GameObject raycastingObject,
		Affinity affinity,
		Vector3 raycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.tug
			(
				affinity,
				raycastDirection,
				Distinctivity.absolute,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> tug
	(
		this GameObject raycastingObject,
		Affinity affinity,
		object raycastEndPosition_PositionProvider,
		float magnitude = Default.forceMagnitude,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingObject.position().tug
		(
			affinity,
			raycastEndPosition,
			magnitude,
			raycastDistanceMagnitudeZeroingCurve,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<GameObject> tug
	(
		this Component raycastingComponent,
		Affinity affinity,
		Vector3 raycastDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.gameObject.tug
			(
				affinity,
				raycastDirection,
				raycastDistinctivity,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> tug
	(
		this Component raycastingComponent,
		Affinity affinity,
		Vector3 localRaycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.tug
			(
				affinity,
				localRaycastDirection,
				Distinctivity.relative,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> tugGlobally
	(
		this Component raycastingComponent,
		Affinity affinity,
		Vector3 raycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.tug
			(
				affinity,
				raycastDirection,
				Distinctivity.absolute,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> tug
	(
		this Component raycastingComponent,
		Affinity affinity,
		object raycastEndPosition_PositionProvider,
		float magnitude = Default.forceMagnitude,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingComponent.position().tug
		(
			affinity,
			raycastEndPosition,
			magnitude,
			raycastDistanceMagnitudeZeroingCurve,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion tugging with the given affinity


	#region pulling (tugging attractively)

	public static HashSet<GameObject> pullAlong
	(
		this Vector3 raycastingPosition,
		Vector3 raycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingPosition.tug
			(
				Affinity.attraction,
				raycastDirection,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> pullWithin
	(
		this Vector3 raycastingPosition,
		object raycastEndPosition_PositionProvider,
		float magnitude = Default.forceMagnitude,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingPosition.tug
		(
			Affinity.attraction,
			raycastEndPosition,
			magnitude,
			raycastDistanceMagnitudeZeroingCurve,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<GameObject> pullAlong
	(
		this GameObject raycastingObject,
		Vector3 raycastDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.tug
			(
				Affinity.attraction,
				raycastDirection,
				raycastDistinctivity,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> pullAlong
	(
		this GameObject raycastingObject,
		Vector3 localRaycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.pullAlong
			(
				localRaycastDirection,
				Distinctivity.relative,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> forwardlyPull
	(
		this GameObject raycastingObject,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.pullAlong
			(
				Direction.forward,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> backwardlyPull
	(
		this GameObject raycastingObject,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.pullAlong
			(
				Direction.backward,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> rightwardlyPull
	(
		this GameObject raycastingObject,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.pullAlong
			(
				Direction.right,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> leftwardlyPull
	(
		this GameObject raycastingObject,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.pullAlong
			(
				Direction.left,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> upwardlyPull
	(
		this GameObject raycastingObject,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.pullAlong
			(
				Direction.up,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> downwardlyPull
	(
		this GameObject raycastingObject,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.pullAlong
			(
				Direction.down,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> pullAlongGlobal
	(
		this GameObject raycastingObject,
		Vector3 raycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.pullAlong
			(
				raycastDirection,
				Distinctivity.absolute,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> pullWithin
	(
		this GameObject raycastingObject,
		object raycastEndPosition_PositionProvider,
		float magnitude = Default.forceMagnitude,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingObject.position().pullWithin
		(
			raycastEndPosition,
			magnitude,
			raycastDistanceMagnitudeZeroingCurve,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<GameObject> pullAlong
	(
		this Component raycastingComponent,
		Vector3 raycastDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.gameObject.pullAlong
			(
				raycastDirection,
				raycastDistinctivity,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> pullAlong
	(
		this Component raycastingComponent,
		Vector3 localRaycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.pullAlong
			(
				localRaycastDirection,
				Distinctivity.relative,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> forwardlyPull
	(
		this Component raycastingComponent,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.pullAlong
			(
				Direction.forward,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> backwardlyPull
	(
		this Component raycastingComponent,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.pullAlong
			(
				Direction.backward,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> rightwardlyPull
	(
		this Component raycastingComponent,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.pullAlong
			(
				Direction.right,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> leftwardlyPull
	(
		this Component raycastingComponent,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.pullAlong
			(
				Direction.left,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> upwardlyPull
	(
		this Component raycastingComponent,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.pullAlong
			(
				Direction.up,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> downwardlyPull
	(
		this Component raycastingComponent,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.pullAlong
			(
				Direction.down,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> pullAlongGlobal
	(
		this Component raycastingComponent,
		Vector3 raycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.pullAlong
			(
				raycastDirection,
				Distinctivity.absolute,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> pullWithin
	(
		this Component raycastingComponent,
		object raycastEndPosition_PositionProvider,
		float magnitude = Default.forceMagnitude,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingComponent.position().pullWithin
		(
			raycastEndPosition,
			magnitude,
			raycastDistanceMagnitudeZeroingCurve,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion pulling (tugging attractively)


	#region pushing (tugging repulsively)

	public static HashSet<GameObject> pushAlong
	(
		this Vector3 raycastingPosition,
		Vector3 raycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingPosition.tug
			(
				Affinity.repulsion,
				raycastDirection,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> pushWithin
	(
		this Vector3 raycastingPosition,
		object raycastEndPosition_PositionProvider,
		float magnitude = Default.forceMagnitude,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingPosition.tug
		(
			Affinity.repulsion,
			raycastEndPosition,
			magnitude,
			raycastDistanceMagnitudeZeroingCurve,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<GameObject> pushAlong
	(
		this GameObject raycastingObject,
		Vector3 raycastDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.tug
			(
				Affinity.repulsion,
				raycastDirection,
				raycastDistinctivity,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> pushAlong
	(
		this GameObject raycastingObject,
		Vector3 localRaycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.pushAlong
			(
				localRaycastDirection,
				Distinctivity.relative,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> forwardlyPush
	(
		this GameObject raycastingObject,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.pushAlong
			(
				Direction.forward,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> backwardlyPush
	(
		this GameObject raycastingObject,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.pushAlong
			(
				Direction.backward,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> rightwardlyPush
	(
		this GameObject raycastingObject,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.pushAlong
			(
				Direction.right,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> leftwardlyPush
	(
		this GameObject raycastingObject,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.pushAlong
			(
				Direction.left,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> upwardlyPush
	(
		this GameObject raycastingObject,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.pushAlong
			(
				Direction.up,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> downwardlyPush
	(
		this GameObject raycastingObject,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.pushAlong
			(
				Direction.down,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> pushAlongGlobal
	(
		this GameObject raycastingObject,
		Vector3 raycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.pushAlong
			(
				raycastDirection,
				Distinctivity.absolute,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> pushWithin
	(
		this GameObject raycastingObject,
		object raycastEndPosition_PositionProvider,
		float magnitude = Default.forceMagnitude,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingObject.position().pushWithin
		(
			raycastEndPosition,
			magnitude,
			raycastDistanceMagnitudeZeroingCurve,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<GameObject> pushAlong
	(
		this Component raycastingComponent,
		Vector3 raycastDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.gameObject.pushAlong
			(
				raycastDirection,
				raycastDistinctivity,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> pushAlong
	(
		this Component raycastingComponent,
		Vector3 localRaycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.pushAlong
			(
				localRaycastDirection,
				Distinctivity.relative,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> forwardlyPush
	(
		this Component raycastingComponent,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.pushAlong
			(
				Direction.forward,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> backwardlyPush
	(
		this Component raycastingComponent,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.pushAlong
			(
				Direction.backward,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> rightwardlyPush
	(
		this Component raycastingComponent,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.pushAlong
			(
				Direction.right,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> leftwardlyPush
	(
		this Component raycastingComponent,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.pushAlong
			(
				Direction.left,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> upwardlyPush
	(
		this Component raycastingComponent,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.pushAlong
			(
				Direction.up,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> downwardlyPush
	(
		this Component raycastingComponent,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.pushAlong
			(
				Direction.down,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> pushAlongGlobal
	(
		this Component raycastingComponent,
		Vector3 raycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.pushAlong
			(
				raycastDirection,
				Distinctivity.absolute,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> pushWithin
	(
		this Component raycastingComponent,
		object raycastEndPosition_PositionProvider,
		float magnitude = Default.forceMagnitude,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingComponent.position().pushWithin
		(
			raycastEndPosition,
			magnitude,
			raycastDistanceMagnitudeZeroingCurve,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion pushing (tugging repulsively)
}