using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mistargeted Force Extensions: provides extension methods for handling "mistargeted" force (forcing one target as though targeting another)
// #force
public static class MistargetedForceExtensions
{
	// methods: from this given declared provider of a forcing position, apply force upon the given provided target rigidbodies (without ensuring unique targets, if targets are plural; that methods variant is unimplemented yet), with force targeted at the given provided "mistarget" position, using the given or declared affinity and the given magnitude, reach, boolean for whether to apply zero force outside the reach, and clamping boolean, diminishing magnitude from the given forcing position (until the reach) to zero using the given curve, then return this given declared provider of a forcing position //

	
	#region mistargetedly forcing with the given affinity

	public static Vector3 forceTargetAsThoughMistargeting(this Vector3 forcingPosition, object mistargetPosition_PositionProvider, Rigidbody targetRigidbody, Affinity affinity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.mistargetedForceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
		=>	forcingPosition.after(()=>
				targetRigidbody.applyForceOf
				(
					mistargetPosition_PositionProvider.providePosition().targetedForceBy
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
	public static Vector3 forceTargetAsThoughMistargeting(this Vector3 forcingPosition, object mistargetPosition_PositionProvider, object targetRigidbodies_RigidbodiesProvider, Affinity affinity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.mistargetedForceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = targetRigidbodies_RigidbodiesProvider.provideRigidbodies();

		return	forcingPosition.after(()=>
					targetRigidbodies.forEach(rigidbody =>
						forcingPosition.forceTargetAsThoughMistargeting
						(
							mistargetPosition_PositionProvider,
							rigidbody,
							affinity,
							magnitude,
							reach,
							reachMagnitudeZeroingCurve,
							zeroForceOutsideReach,
							clamp
						)));
	}
				

	public static GameObject forceTargetAsThoughMistargeting(this GameObject forcingObject, object mistargetPosition_PositionProvider, object targetRigidbodies_RigidbodiesProvider, Affinity affinity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.mistargetedForceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = targetRigidbodies_RigidbodiesProvider.provideRigidbodies();

		return	forcingObject.after(()=>
					forcingObject.position().forceTargetAsThoughMistargeting
					(
						mistargetPosition_PositionProvider,
						targetRigidbodies,
						affinity,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					));
	}

	public static ComponentT forceTargetAsThoughMistargeting<ComponentT>(this ComponentT forcingComponent, object mistargetPosition_PositionProvider, object targetRigidbodies_RigidbodiesProvider, Affinity affinity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.mistargetedForceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping) where ComponentT : Component
	{
		List<Rigidbody> targetRigidbodies = targetRigidbodies_RigidbodiesProvider.provideRigidbodies();

		return	forcingComponent.after(()=>
					forcingComponent.position().forceTargetAsThoughMistargeting
					(
						mistargetPosition_PositionProvider,
						targetRigidbodies,
						affinity,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					));
	}
	#endregion mistargetedly forcing with the given affinity


	#region attracting as though mistargeting (mistargetedly forcing with attraction)

	public static Vector3 attractAsThoughMistargeting(this Vector3 forcingPosition, object mistargetPosition_PositionProvider, object targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.mistargetedForceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = targetRigidbodies_RigidbodiesProvider.provideRigidbodies();

		return	forcingPosition.forceTargetAsThoughMistargeting
				(
					mistargetPosition_PositionProvider,
					targetRigidbodies,
					Affinity.attraction,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				);
	}
	public static Vector3 applyMistargetedAttractionFrom(this object targetRigidbodies_RigidbodiesProvider, Vector3 forcingPosition, object mistargetPosition_PositionProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.mistargetedForceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
		=>	forcingPosition.attractAsThoughMistargeting
			(
				mistargetPosition_PositionProvider,
				targetRigidbodies_RigidbodiesProvider,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static Vector3 attractAsThoughMistargeting<SingletonBehaviourT>(this Vector3 forcingPosition, object targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.mistargetedForceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=>	forcingPosition.attractAsThoughMistargeting
			(
				SingletonBehaviour<SingletonBehaviourT>.position,
				targetRigidbodies_RigidbodiesProvider,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static Vector3 attractAsThoughMistargeting<MistargetSingletonBehaviourT, TargetSingletonBehaviourT>(this Vector3 forcingPosition, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.mistargetedForceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping) where MistargetSingletonBehaviourT : SingletonBehaviour<MistargetSingletonBehaviourT> where TargetSingletonBehaviourT : SingletonBehaviour<TargetSingletonBehaviourT>
		=>	forcingPosition.attractAsThoughMistargeting<TargetSingletonBehaviourT>
			(
				SingletonBehaviour<TargetSingletonBehaviourT>.ensuredCorrespondingRigidbody,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static GameObject attractAsThoughMistargeting(this GameObject forcingObject, object mistargetPosition_PositionProvider, object targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.mistargetedForceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = targetRigidbodies_RigidbodiesProvider.provideRigidbodies();

		return	forcingObject.after(()=>
					forcingObject.position().attractAsThoughMistargeting
					(
						mistargetPosition_PositionProvider,
						targetRigidbodies,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					));
	}
	public static GameObject attractAsThoughMistargeting<SingletonBehaviourT>(this GameObject forcingObject, object targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.mistargetedForceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=>	forcingObject.attractAsThoughMistargeting
			(
				SingletonBehaviour<SingletonBehaviourT>.position,
				targetRigidbodies_RigidbodiesProvider,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static ComponentT attractAsThoughMistargeting<ComponentT>(this ComponentT forcingComponent, object mistargetPosition_PositionProvider, object targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.mistargetedForceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping) where ComponentT : Component
	{
		List<Rigidbody> targetRigidbodies = targetRigidbodies_RigidbodiesProvider.provideRigidbodies();

		return	forcingComponent.after(()=>
					forcingComponent.position().attractAsThoughMistargeting
					(
						mistargetPosition_PositionProvider,
						targetRigidbodies,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					));
	}

	public static RaycastHit attractAsThoughMistargeting(this RaycastHit forcingRaycastHit, object mistargetPosition_PositionProvider, object targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.mistargetedForceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = targetRigidbodies_RigidbodiesProvider.provideRigidbodies();

		return	forcingRaycastHit.after(()=>
					forcingRaycastHit.position().attractAsThoughMistargeting
					(
						mistargetPosition_PositionProvider,
						targetRigidbodies,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					));
	}
	public static RaycastHit attractAsThoughMistargeting<SingletonBehaviourT>(this RaycastHit forcingRaycastHit, object targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.mistargetedForceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=>	forcingRaycastHit.attractAsThoughMistargeting
			(
				SingletonBehaviour<SingletonBehaviourT>.position,
				targetRigidbodies_RigidbodiesProvider,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	#endregion attracting as though mistargeting (mistargetedly forcing with attraction)


	#region repelling as though mistargeting (mistargetedly forcing with repulsion)

	public static Vector3 repelAsThoughMistargeting(this Vector3 forcingPosition, object mistargetPosition_PositionProvider, object targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.mistargetedForceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = targetRigidbodies_RigidbodiesProvider.provideRigidbodies();

		return	forcingPosition.forceTargetAsThoughMistargeting
				(
					mistargetPosition_PositionProvider,
					targetRigidbodies,
					Affinity.repulsion,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				);
	}

	public static GameObject repelAsThoughMistargeting(this GameObject forcingObject, object mistargetPosition_PositionProvider, object targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.mistargetedForceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = targetRigidbodies_RigidbodiesProvider.provideRigidbodies();

		return	forcingObject.after(()=>
					forcingObject.position().repelAsThoughMistargeting
					(
						mistargetPosition_PositionProvider,
						targetRigidbodies,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					));
	}

	public static ComponentT repelAsThoughMistargeting<ComponentT>(this ComponentT forcingComponent, object mistargetPosition_PositionProvider, object targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.mistargetedForceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping) where ComponentT : Component
	{
		List<Rigidbody> targetRigidbodies = targetRigidbodies_RigidbodiesProvider.provideRigidbodies();

		return	forcingComponent.after(()=>
					forcingComponent.position().repelAsThoughMistargeting
					(
						mistargetPosition_PositionProvider,
						targetRigidbodies,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					));
	}
	#endregion repelling as though mistargeting (mistargetedly forcing with repulsion)
}