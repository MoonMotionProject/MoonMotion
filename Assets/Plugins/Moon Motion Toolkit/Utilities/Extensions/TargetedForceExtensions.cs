using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Targeted Force Extensions: provides extension methods for handling targeted force
// #force
public static class TargetedForceExtensions
{
	#region calculating targeted force
	// methods: return the targeted force with the given or declared affinity upon this given declared provider of a force position, targeted by the given provided forcing position and for the given magnitude, reach, boolean for whether to return zero force outside the reach, and clamping boolean, diminishing magnitude from the given forcing position (until the reach) to zero using the given curve //

	
	#region calculating targeted force with the given affinity
	
	public static Vector3 targetedForceBy(this Vector3 forcePosition, object forcingPosition_PositionProvider, Affinity affinity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		float reachProgression = forcePosition.distalProgressionTo(reach, forcingPosition);

		return ((reachProgression > 1f) && zeroForceOutsideReach) ?
					FloatsVector.zeroes :
					(magnitude * forcingPosition.directionForAffinityAbout(forcePosition, affinity))
						.interpolateToZeroes
						(
							reachMagnitudeZeroingCurve,
							clamp,
							reachProgression
						);
	}

	public static Vector3 targetedForceBy(this GameObject targetObject, object forcingPosition_PositionProvider, Affinity affinity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return	targetObject.position().targetedForceBy
				(
					forcingPosition,
					affinity,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				);
	}

	public static Vector3 targetedForceBy(this Component targetComponent, object forcingPosition_PositionProvider, Affinity affinity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return	targetComponent.position().targetedForceBy
				(
					forcingPosition,
					affinity,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				);
	}
	#endregion calculating targeted force with the given affinity


	#region calculating targeted attraction

	public static Vector3 attractionTo(this Vector3 forcePosition, object forcingPosition_PositionProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return forcePosition.targetedForceBy
		(
			forcingPosition,
			Affinity.attraction,
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	}

	public static Vector3 attractionTo(this GameObject targetObject, object forcingPosition_PositionProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return	targetObject.position().attractionTo
				(
					forcingPosition,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				);
	}

	public static Vector3 attractionTo(this Component targetComponent, object forcingPosition_PositionProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return	targetComponent.position().attractionTo
				(
					forcingPosition,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				);
	}
	#endregion calculating targeted attraction


	#region calculating targeted repulsion

	public static Vector3 repulsionFrom(this Vector3 forcePosition, object forcingPosition_PositionProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return	forcePosition.targetedForceBy
				(
					forcingPosition,
					Affinity.repulsion,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				);
	}

	public static Vector3 repulsionFrom(this GameObject targetObject, object forcingPosition_PositionProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return	targetObject.position().repulsionFrom
				(
					forcingPosition,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				);
	}

	public static Vector3 repulsionFrom(this Component targetComponent, object forcingPosition_PositionProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return	targetComponent.position().repulsionFrom
				(
					forcingPosition,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				);
	}
	#endregion calculating targeted repulsion
	#endregion calculating targeted force




	#region targetedly forcing
	// methods: from this given declared provider of a forcing position, apply force upon the given provided target rigidbodies (without ensuring unique targets, if targets are plural; that methods variant is unimplemented yet), using the given or declared affinity and the given magnitude, reach, boolean for whether to apply zero force outside the reach, and clamping boolean, diminishing magnitude from the given forcing position (until the reach) to zero using the given curve, then return this given declared provider of a forcing position //

	
	#region targetedly forcing with the given affinity

	public static Vector3 forceTarget(this Vector3 forcingPosition, Rigidbody targetRigidbody, Affinity affinity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
		=>	forcingPosition.after(()=>
				targetRigidbody.applyForceOf
				(
					targetRigidbody.targetedForceBy
					(
						forcingPosition,
						affinity,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					)
				));
	public static Vector3 forceTarget(this Vector3 forcingPosition, object targetRigidbodies_RigidbodiesProvider, Affinity affinity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = Provide.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider);

		return	forcingPosition.after(()=>
					targetRigidbodies.forEach(rigidbody =>
						forcingPosition.forceTarget
						(
							rigidbody,
							affinity,
							magnitude,
							reach,
							reachMagnitudeZeroingCurve,
							zeroForceOutsideReach,
							clamp
						)));
	}
				

	public static GameObject forceTarget(this GameObject forcingObject, object targetRigidbodies_RigidbodiesProvider, Affinity affinity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = Provide.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider);

		return	forcingObject.after(()=>
					forcingObject.position().forceTarget
					(
						targetRigidbodies,
						affinity,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					));
	}

	public static ComponentT forceTarget<ComponentT>(this ComponentT forcingComponent, object targetRigidbodies_RigidbodiesProvider, Affinity affinity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping) where ComponentT : Component
	{
		List<Rigidbody> targetRigidbodies = Provide.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider);

		return	forcingComponent.after(()=>
					forcingComponent.position().forceTarget
					(
						targetRigidbodies,
						affinity,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					));
	}
	#endregion targetedly forcing with the given affinity


	#region attracting (targetedly forcing with attraction)

	public static Vector3 attract(this Vector3 forcingPosition, object targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = Provide.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider);

		return	forcingPosition.forceTarget
				(
					targetRigidbodies,
					Affinity.attraction,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				);
	}

	public static GameObject attract(this GameObject forcingObject, object targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = Provide.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider);

		return	forcingObject.after(()=>
					forcingObject.position().attract
					(
						targetRigidbodies,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					));
	}

	public static ComponentT attract<ComponentT>(this ComponentT forcingComponent, object targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping) where ComponentT : Component
	{
		List<Rigidbody> targetRigidbodies = Provide.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider);

		return	forcingComponent.after(()=>
					forcingComponent.position().attract
					(
						targetRigidbodies,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					));
	}
	#endregion attracting (targetedly forcing with attraction)


	#region repelling (targetedly forcing with repulsion)

	public static Vector3 repel(this Vector3 forcingPosition, object targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = Provide.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider);

		return	forcingPosition.forceTarget
				(
					targetRigidbodies,
					Affinity.repulsion,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				);
	}

	public static GameObject repel(this GameObject forcingObject, object targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = Provide.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider);

		return	forcingObject.after(()=>
					forcingObject.position().repel
					(
						targetRigidbodies,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					));
	}

	public static ComponentT repel<ComponentT>(this ComponentT forcingComponent, object targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping) where ComponentT : Component
	{
		List<Rigidbody> targetRigidbodies = Provide.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider);

		return	forcingComponent.after(()=>
					forcingComponent.position().repel
					(
						targetRigidbodies,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					));
	}
	#endregion repelling (targetedly forcing with repulsion)
	#endregion targetedly forcing
}