using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Targeted Force Extensions: provides extension methods for handling targeted force //
public static class TargetedForceExtensions
{
	#region targetedly forcing
	// methods: from this given provider of a forcing position, apply force upon the given provided target rigidbodies (without ensuring unique targets, if targets are plural; that methods variant is unimplemented yet), using the given or respective tug and the given magnitude, reach, reach magnitude zeroing curve, boolean for whether to apply zero force outside the reach, and clamping boolean, then return this given provider of a forcing position //




	#region single-targetedly forcing


	#region single-targetedly forcing with the given tug

	public static Vector3 forceTarget(this Vector3 forcingPosition, GameObject targetObject, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingPosition.after(()=>
				targetObject.applyForceOf
				(
					targetObject.directionalForceBy
					(
						forcingPosition,
						tug,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					)
				));
	public static Vector3 forceTarget(this Vector3 forcingPosition, Component targetComponent, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingPosition.forceTarget
			(
				targetComponent.gameObject,
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static GameObject forceTarget(this GameObject forcingObject, GameObject targetObject, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingObject.after(()=>
				forcingObject.position().forceTarget
				(
					targetObject,
					tug,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				));
	public static GameObject forceTarget(this GameObject forcingObject, Component targetComponent, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingObject.forceTarget
			(
				targetComponent.gameObject,
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static ComponentT forceTarget<ComponentT>(this ComponentT forcingComponent, GameObject targetObject, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	forcingComponent.after(()=>
				forcingComponent.position().forceTarget
				(
					targetObject,
					tug,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				));
	public static ComponentT forceTarget<ComponentT>(this ComponentT forcingComponent, Component targetComponent, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	forcingComponent.forceTarget
			(
				targetComponent.gameObject,
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	#endregion single-targetedly forcing with the given tug


	#region single-targetedly attracting

	public static Vector3 attractTarget(this Vector3 forcingPosition, GameObject targetObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingPosition.forceTarget
			(
				targetObject,
				Tug.attraction,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static Vector3 attractTarget(this Vector3 forcingPosition, Component targetComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingPosition.attractTarget
			(
				targetComponent.gameObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static GameObject attractTarget(this GameObject forcingObject, GameObject targetObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingObject.attractTarget
			(
				targetObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static GameObject attractTarget(this GameObject forcingObject, Component targetComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingObject.attractTarget
			(
				targetComponent.gameObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static ComponentT attractTarget<ComponentT>(this ComponentT forcingComponent, GameObject targetObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	forcingComponent.attractTarget
			(
				targetObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static ComponentT attractTarget<ComponentT>(this ComponentT forcingComponent, Component targetComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	forcingComponent.attractTarget
			(
				targetComponent.gameObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	#endregion single-targetedly attracting


	#region single-targetedly repelling

	public static Vector3 repelTarget(this Vector3 forcingPosition, GameObject targetObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingPosition.forceTarget
			(
				targetObject,
				Tug.repulsion,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static Vector3 repelTarget(this Vector3 forcingPosition, Component targetComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingPosition.repelTarget
			(
				targetComponent.gameObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static GameObject repelTarget(this GameObject forcingObject, GameObject targetObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingObject.repelTarget
			(
				targetObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static GameObject repelTarget(this GameObject forcingObject, Component targetComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingObject.repelTarget
			(
				targetComponent.gameObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static ComponentT repelTarget<ComponentT>(this ComponentT forcingComponent, GameObject targetObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	forcingComponent.repelTarget
			(
				targetObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static ComponentT repelTarget<ComponentT>(this ComponentT forcingComponent, Component targetComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	forcingComponent.repelTarget
			(
				targetComponent.gameObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	#endregion single-targetedly repelling
	#endregion single-targetedly forcing




	#region multi-targetedly forcing


	#region multi-targetedly forcing with the given tug

	public static Vector3 forceTarget(this Vector3 forcingPosition, IEnumerable<GameObject> targetObjects, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingPosition.after(()=>
				targetObjects.forEach(targetObject =>
					forcingPosition.forceTarget
					(
						targetObject,
						tug,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					))
				);
	public static Vector3 forceTarget(this Vector3 forcingPosition, IEnumerable<Component> targetComponents, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingPosition.forceTarget
			(
				targetComponents.objects(),
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static GameObject forceTarget(this GameObject forcingObject, IEnumerable<GameObject> targetObjects, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingObject.after(()=>
				forcingObject.position().forceTarget
				(
					targetObjects,
					tug,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				));
	public static GameObject forceTarget(this GameObject forcingObject, IEnumerable<Component> targetComponents, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingObject.forceTarget
			(
				targetComponents.objects(),
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static ComponentT forceTarget<ComponentT>(this ComponentT forcingComponent, IEnumerable<GameObject> targetObjects, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	forcingComponent.after(()=>
				forcingComponent.position().forceTarget
				(
					targetObjects,
					tug,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				));
	public static ComponentT forceTarget<ComponentT>(this ComponentT forcingComponent, IEnumerable<Component> targetComponents, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	forcingComponent.forceTarget
			(
				targetComponents.objects(),
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	#endregion multi-targetedly forcing with the given tug


	#region multi-targetedly attracting

	public static Vector3 attractTarget(this Vector3 forcingPosition, IEnumerable<GameObject> targetObjects, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingPosition.forceTarget
			(
				targetObjects,
				Tug.attraction,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static Vector3 attractTarget(this Vector3 forcingPosition, IEnumerable<Component> targetComponents, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingPosition.attractTarget
			(
				targetComponents.objects(),
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static GameObject attractTarget(this GameObject forcingObject, IEnumerable<GameObject> targetObjects, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingObject.attractTarget
			(
				targetObjects,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static GameObject attractTarget(this GameObject forcingObject, IEnumerable<Component> targetComponents, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingObject.attractTarget
			(
				targetComponents.objects(),
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static ComponentT attractTarget<ComponentT>(this ComponentT forcingComponent, IEnumerable<GameObject> targetObjects, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	forcingComponent.attractTarget
			(
				targetObjects,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static ComponentT attractTarget<ComponentT>(this ComponentT forcingComponent, IEnumerable<Component> targetComponents, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	forcingComponent.attractTarget
			(
				targetComponents.objects(),
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	#endregion multi-targetedly attracting


	#region multi-targetedly repelling

	public static Vector3 repelTarget(this Vector3 forcingPosition, IEnumerable<GameObject> targetObjects, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingPosition.forceTarget
			(
				targetObjects,
				Tug.repulsion,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static Vector3 repelTarget(this Vector3 forcingPosition, IEnumerable<Component> targetComponents, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingPosition.repelTarget
			(
				targetComponents.objects(),
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static GameObject repelTarget(this GameObject forcingObject, IEnumerable<GameObject> targetObjects, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingObject.repelTarget
			(
				targetObjects,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static GameObject repelTarget(this GameObject forcingObject, IEnumerable<Component> targetComponents, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcingObject.repelTarget
			(
				targetComponents.objects(),
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static ComponentT repelTarget<ComponentT>(this ComponentT forcingComponent, IEnumerable<GameObject> targetObjects, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	forcingComponent.repelTarget
			(
				targetObjects,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static ComponentT repelTarget<ComponentT>(this ComponentT forcingComponent, IEnumerable<Component> targetComponents, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	forcingComponent.repelTarget
			(
				targetComponents.objects(),
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	#endregion multi-targetedly repelling
	#endregion multi-targetedly forcing
	#endregion targetedly forcing
}