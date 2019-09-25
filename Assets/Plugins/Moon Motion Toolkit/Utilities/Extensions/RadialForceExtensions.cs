using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Radial Force Extensions: provides extension methods for radially forcing
// #force
public static class RadialForceExtensions
{
	// methods: apply a radial force with the given or declared tug from this given center position or provider of a center position (respectively), with the given magnitude, affecting rigidbodies with colliders matching the given layer mask (if specified) and only within the given radius and using the given trigger collider query, diminishing magnitude from the center position (to radial distance) to zero using the given curve, then return the set of objects affected //

	
	#region radially forcing with the given tug
	
	public static HashSet<GameObject> forceRadially(this Vector3 centerPosition, Tug tug, float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerPosition.rigidbodiesWithin(radius, triggerColliderQuery, layerMask_MaxOf1)
				.after(rigidbodies =>
					centerPosition.forceTarget
					(
						rigidbodies,
						tug,
						magnitude,
						radius,
						radiusDistanceMagnitudeZeroingCurve
					))
				.uniqueObjects();

	public static HashSet<GameObject> forceRadially(this Component centerComponent, Tug tug, float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerComponent.position().forceRadially
			(
				tug,
				magnitude,
				radius,
				radiusDistanceMagnitudeZeroingCurve,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<GameObject> forceRadially(this GameObject centerObject, Tug tug, float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerObject.position().forceRadially
			(
				tug,
				magnitude,
				radius,
				radiusDistanceMagnitudeZeroingCurve,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	#endregion radially forcing with the given tug


	#region sucking (radially attracting)

	public static HashSet<GameObject> suck(this Vector3 centerPosition, float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerPosition.forceRadially
			(
				Tug.attraction,
				magnitude,
				radius,
				radiusDistanceMagnitudeZeroingCurve,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<GameObject> suck(this Component centerComponent, float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerComponent.position().suck
			(
				magnitude,
				radius,
				radiusDistanceMagnitudeZeroingCurve,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<GameObject> suck(this GameObject centerObject, float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerObject.position().suck
			(
				magnitude,
				radius,
				radiusDistanceMagnitudeZeroingCurve,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	#endregion sucking (radially attracting)


	#region repulsing (radially repelling)

	public static HashSet<GameObject> repulse(this Vector3 centerPosition, float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerPosition.forceRadially
			(
				Tug.repulsion,
				magnitude,
				radius,
				radiusDistanceMagnitudeZeroingCurve,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<GameObject> repulse(this Component centerComponent, float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerComponent.position().repulse
			(
				magnitude,
				radius,
				radiusDistanceMagnitudeZeroingCurve,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<GameObject> repulse(this GameObject centerObject, float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerObject.position().repulse
			(
				magnitude,
				radius,
				radiusDistanceMagnitudeZeroingCurve,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	#endregion repulsing (radially repelling)
}