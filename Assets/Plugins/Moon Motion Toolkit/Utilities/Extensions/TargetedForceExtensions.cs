using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Targeted Force Extensions: provides extension methods for handling targeted force //
public static class TargetedForceExtensions
{
	#region targetedly forcing
	// methods: (assuming the target has\is a rigidbody:) from this given position or provider of a position (respectively), apply force upon the given target\targets (respectively) (if multiple, not ensuring unique targets – that methods variant is unimplemented yet), using the given or respective tug and the given magnitude, reach, reach magnitude zeroing curve, boolean for whether to apply zero force outside the reach, and clamping boolean, then return this given position or provider of a position (respectively) //

	
	
	
	#region single-targetedly forcing
	
	
	#region single-targetedly forcing with the given tug
	
	public static Vector3 forceTarget(this Vector3 position, GameObject targetObject, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=> position.after(()=>
				targetObject.applyForceOf
				(
					targetObject.directionalForceBy
					(
						position,
						tug,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					)
				));
	public static Vector3 forceTarget(this Vector3 position, Component targetComponent, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	position.forceTarget
			(
				targetComponent.gameObject,
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static GameObject forceTarget(this GameObject gameObject, GameObject targetObject, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	gameObject.after(()=>
			   gameObject.position().forceTarget
			   (
				   targetObject,
				   tug,
				   magnitude,
				   reach,
				   reachMagnitudeZeroingCurve,
				   zeroForceOutsideReach,
				   clamp
			   ));
	public static GameObject forceTarget(this GameObject gameObject, Component targetComponent, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	gameObject.forceTarget
			(
				targetComponent.gameObject,
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static ComponentT forceTarget<ComponentT>(this ComponentT component, GameObject targetObject, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	component.after(()=>
				component.position().forceTarget
				(
					targetObject,
					tug,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				));
	public static ComponentT forceTarget<ComponentT>(this ComponentT component, Component targetComponent, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	component.forceTarget
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

	public static Vector3 attractTarget(this Vector3 position, GameObject targetObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	position.forceTarget
			(
				targetObject,
				Tug.attraction,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static Vector3 attractTarget(this Vector3 position, Component targetComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	position.attractTarget
			(
				targetComponent.gameObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static GameObject attractTarget(this GameObject gameObject, GameObject targetObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	gameObject.attractTarget
			(
				targetObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static GameObject attractTarget(this GameObject gameObject, Component targetComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	gameObject.attractTarget
			(
				targetComponent.gameObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static ComponentT attractTarget<ComponentT>(this ComponentT component, GameObject targetObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	component.attractTarget
			(
				targetObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static ComponentT attractTarget<ComponentT>(this ComponentT component, Component targetComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	component.attractTarget
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

	public static Vector3 repelTarget(this Vector3 position, GameObject targetObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	position.forceTarget
			(
				targetObject,
				Tug.repulsion,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static Vector3 repelTarget(this Vector3 position, Component targetComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	position.repelTarget
			(
				targetComponent.gameObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static GameObject repelTarget(this GameObject gameObject, GameObject targetObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	gameObject.repelTarget
			(
				targetObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static GameObject repelTarget(this GameObject gameObject, Component targetComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	gameObject.repelTarget
			(
				targetComponent.gameObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static ComponentT repelTarget<ComponentT>(this ComponentT component, GameObject targetObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	component.repelTarget
			(
				targetObject,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static ComponentT repelTarget<ComponentT>(this ComponentT component, Component targetComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	component.repelTarget
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

	public static Vector3 forceTarget(this Vector3 position, IEnumerable<GameObject> targetObjects, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=> position.after(()=>
				targetObjects.forEach(targetObject =>
					position.forceTarget
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
	public static Vector3 forceTarget(this Vector3 position, IEnumerable<Component> targetComponents, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	position.forceTarget
			(
				targetComponents.objects(),
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static GameObject forceTarget(this GameObject gameObject, IEnumerable<GameObject> targetObjects, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	gameObject.after(()=>
				gameObject.position().forceTarget
				(
					targetObjects,
					tug,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				));
	public static GameObject forceTarget(this GameObject gameObject, IEnumerable<Component> targetComponents, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	gameObject.forceTarget
			(
				targetComponents.objects(),
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static ComponentT forceTarget<ComponentT>(this ComponentT component, IEnumerable<GameObject> targetObjects, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	component.after(()=>
				component.position().forceTarget
				(
					targetObjects,
					tug,
					magnitude,
					reach,
					reachMagnitudeZeroingCurve,
					zeroForceOutsideReach,
					clamp
				));
	public static ComponentT forceTarget<ComponentT>(this ComponentT component, IEnumerable<Component> targetComponents, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	component.forceTarget
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

	public static Vector3 attractTarget(this Vector3 position, IEnumerable<GameObject> targetObjects, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	position.forceTarget
			(
				targetObjects,
				Tug.attraction,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static Vector3 attractTarget(this Vector3 position, IEnumerable<Component> targetComponents, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	position.attractTarget
			(
				targetComponents.objects(),
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static GameObject attractTarget(this GameObject gameObject, IEnumerable<GameObject> targetObjects, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	gameObject.attractTarget
			(
				targetObjects,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static GameObject attractTarget(this GameObject gameObject, IEnumerable<Component> targetComponents, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	gameObject.attractTarget
			(
				targetComponents.objects(),
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static ComponentT attractTarget<ComponentT>(this ComponentT component, IEnumerable<GameObject> targetObjects, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	component.attractTarget
			(
				targetObjects,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static ComponentT attractTarget<ComponentT>(this ComponentT component, IEnumerable<Component> targetComponents, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	component.attractTarget
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

	public static Vector3 repelTarget(this Vector3 position, IEnumerable<GameObject> targetObjects, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	position.forceTarget
			(
				targetObjects,
				Tug.repulsion,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static Vector3 repelTarget(this Vector3 position, IEnumerable<Component> targetComponents, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	position.repelTarget
			(
				targetComponents.objects(),
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static GameObject repelTarget(this GameObject gameObject, IEnumerable<GameObject> targetObjects, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	gameObject.repelTarget
			(
				targetObjects,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static GameObject repelTarget(this GameObject gameObject, IEnumerable<Component> targetComponents, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	gameObject.repelTarget
			(
				targetComponents.objects(),
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static ComponentT repelTarget<ComponentT>(this ComponentT component, IEnumerable<GameObject> targetObjects, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	component.repelTarget
			(
				targetObjects,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static ComponentT repelTarget<ComponentT>(this ComponentT component, IEnumerable<Component> targetComponents, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping) where ComponentT : Component
		=>	component.repelTarget
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