using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Targeted Force Extensions: provides extension methods for handling targeted force
// #force
public static class TargetedForceExtensions
{
	#region targetedly forcing
	// methods: from this given declared provider of a forcing position, apply force upon the given provided target rigidbodies (without ensuring unique targets, if targets are plural; that methods variant is unimplemented yet), using the given or respective tug and the given magnitude, reach, reach magnitude zeroing curve, boolean for whether to apply zero force outside the reach, and clamping boolean, then return this given declared provider of a forcing position //


	#region targetedly forcing with the given tug
	
	public static Vector3 forceTarget(this Vector3 forcingPosition, dynamic targetRigidbodies_RigidbodiesProvider, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, Vector3>(targetRigidbodies =>
				forcingPosition.after(()=>
					targetRigidbodies.forEach(targetRigidbody =>
						targetRigidbody.applyForceOf
						(
							targetRigidbody.directionalForceBy
							(
								forcingPosition,
								tug,
								magnitude,
								reach,
								reachMagnitudeZeroingCurve,
								zeroForceOutsideReach,
								clamp
							)
						)))));

	public static GameObject forceTarget(this GameObject forcingObject, dynamic targetRigidbodies_RigidbodiesProvider, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, GameObject>(targetRigidbodies =>
				forcingObject.after(()=>
					forcingObject.position().forceTarget
					(
						targetRigidbodies,
						tug,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					))));

	public static ComponentT forceTarget<ComponentT>(this ComponentT forcingComponent, dynamic targetRigidbodies_RigidbodiesProvider, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, ComponentT>(targetRigidbodies =>
				forcingComponent.after(()=>
					forcingComponent.position().forceTarget
					(
						targetRigidbodies,
						tug,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					))));
	#endregion targetedly forcing with the given tug


	#region targetedly attracting

	public static Vector3 attract(this Vector3 forcingPosition, dynamic targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, Vector3>(targetRigidbodies =>
				forcingPosition.forceTarget
				(
					targetRigidbodies,
					Tug.attraction,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				)));

	public static GameObject attract(this GameObject forcingObject, dynamic targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, GameObject>(targetRigidbodies =>
			   forcingObject.after(()=>
				   forcingObject.position().attract
				   (
					   targetRigidbodies,
					   magnitude,
					   reach,
					   reachMagnitudeZeroingCurve,
					   zeroForceOutsideReach,
					   clamp
				   ))));

	public static ComponentT attract<ComponentT>(this ComponentT forcingComponent, dynamic targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, ComponentT>(targetRigidbodies =>
				forcingComponent.after(()=>
					forcingComponent.position().attract
					(
						targetRigidbodies,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					))));
	#endregion targetedly attracting


	#region targetedly repelling

	public static Vector3 repel(this Vector3 forcingPosition, dynamic targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, Vector3>(targetRigidbodies =>
			   forcingPosition.forceTarget
			   (
				   targetRigidbodies,
				   Tug.repulsion,
				   magnitude,
				   reach,
				   reachMagnitudeZeroingCurve,
				   zeroForceOutsideReach,
				   clamp
			   )));

	public static GameObject repel(this GameObject forcingObject, dynamic targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, GameObject>(targetRigidbodies =>
				forcingObject.after(()=>
					forcingObject.position().repel
					(
						targetRigidbodies,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					))));

	public static ComponentT repel<ComponentT>(this ComponentT forcingComponent, dynamic targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, ComponentT>(targetRigidbodies =>
				forcingComponent.after(()=>
					forcingComponent.position().repel
					(
						targetRigidbodies,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					))));
	#endregion targetedly repelling
	#endregion targetedly forcing
}