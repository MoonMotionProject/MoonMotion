using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Directional Force Extensions: provides extension methods for handling directional force //
public static class DirectionalForceExtensions
{
	#region calculating directional force
	// methods: return the directional force with the given or respective tug upon this given force position or target providing a force position (respectively), tugged by the given tugging position\object\component and for the given magnitude, reach, boolean for whether to return zero force outside the reach, and clamping boolean, diminishing magnitude from the given tugging position (until the reach) to zero using the given curve //


	#region calculating directional force with the given tug
	
	public static Vector3 directionalForceBy(this Vector3 forcePosition, Vector3 tuggingPosition, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	{
		float reachProgression = forcePosition.distalProgressionTo(reach, tuggingPosition);

		return ((reachProgression > 1f) && zeroForceOutsideReach) ?
					FloatsVector.zeroes :
					(magnitude * tuggingPosition.directionForTugUpon(forcePosition, tug))
						.interpolateToZeroes
						(
							reachMagnitudeZeroingCurve,
							clamp,
							reachProgression
						);
	}
	public static Vector3 directionalForceBy(this Vector3 forcePosition, GameObject tuggingObject, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcePosition.directionalForceBy
			(
				tuggingObject.position(),
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static Vector3 directionalForceBy(this Vector3 forcePosition, Component tuggingComponent, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	forcePosition.directionalForceBy
			(
				tuggingComponent.position(),
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static Vector3 directionalForceBy(this GameObject targetObject, Vector3 tuggingPosition, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	targetObject.position().directionalForceBy
			(
				tuggingPosition,
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static Vector3 directionalForceBy(this GameObject targetObject, GameObject tuggingObject, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	targetObject.directionalForceBy
			(
				tuggingObject.position(),
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static Vector3 directionalForceBy(this GameObject targetObject, Component tuggingComponent, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	targetObject.directionalForceBy
			(
				tuggingComponent.position(),
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);

	public static Vector3 directionalForceBy(this Component targetComponent, Vector3 tuggingPosition, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	targetComponent.position().directionalForceBy
			(
				tuggingPosition,
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static Vector3 directionalForceBy(this Component targetComponent, GameObject tuggingObject, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	targetComponent.directionalForceBy
			(
				tuggingObject.position(),
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	public static Vector3 directionalForceBy(this Component targetComponent, Component tuggingComponent, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	targetComponent.directionalForceBy
			(
				tuggingComponent.position(),
				tug,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	#endregion calculating directional force with the given tug


	#region calculating directional attraction

	public static Vector3 directionalAttractionTo(this Vector3 forcePosition, Vector3 tuggingPosition, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	forcePosition.directionalForceBy
		(
			tuggingPosition,
			Tug.attraction,
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	public static Vector3 directionalAttractionTo(this Vector3 forcePosition, GameObject tuggingObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	forcePosition.directionalAttractionTo
		(
			tuggingObject.position(),
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	public static Vector3 directionalAttractionTo(this Vector3 forcePosition, Component tuggingComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	forcePosition.directionalAttractionTo
		(
			tuggingComponent.position(),
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);

	public static Vector3 directionalAttractionTo(this GameObject targetObject, Vector3 tuggingPosition, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	targetObject.position().directionalAttractionTo
		(
			tuggingPosition,
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	public static Vector3 directionalAttractionTo(this GameObject targetObject, GameObject tuggingObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	targetObject.directionalAttractionTo
		(
			tuggingObject.position(),
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	public static Vector3 directionalAttractionTo(this GameObject targetObject, Component tuggingComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	targetObject.directionalAttractionTo
		(
			tuggingComponent.position(),
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);

	public static Vector3 directionalAttractionTo(this Component targetComponent, Vector3 tuggingPosition, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	targetComponent.position().directionalAttractionTo
		(
			tuggingPosition,
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	public static Vector3 directionalAttractionTo(this Component targetComponent, GameObject tuggingObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	targetComponent.directionalAttractionTo
		(
			tuggingObject.position(),
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	public static Vector3 directionalAttractionTo(this Component targetComponent, Component tuggingComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	targetComponent.directionalAttractionTo
		(
			tuggingComponent.position(),
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	#endregion calculating directional attraction


	#region calculating directional repulsion

	public static Vector3 directionalRepulsionFrom(this Vector3 forcePosition, Vector3 tuggingPosition, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	forcePosition.directionalForceBy
		(
			tuggingPosition,
			Tug.repulsion,
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	public static Vector3 directionalRepulsionFrom(this Vector3 forcePosition, GameObject tuggingObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	forcePosition.directionalRepulsionFrom
		(
			tuggingObject.position(),
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	public static Vector3 directionalRepulsionFrom(this Vector3 forcePosition, Component tuggingComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	forcePosition.directionalRepulsionFrom
		(
			tuggingComponent.position(),
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);

	public static Vector3 directionalRepulsionFrom(this GameObject targetObject, Vector3 tuggingPosition, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	targetObject.position().directionalRepulsionFrom
		(
			tuggingPosition,
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	public static Vector3 directionalRepulsionFrom(this GameObject targetObject, GameObject tuggingObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	targetObject.directionalRepulsionFrom
		(
			tuggingObject.position(),
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	public static Vector3 directionalRepulsionFrom(this GameObject targetObject, Component tuggingComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	targetObject.directionalRepulsionFrom
		(
			tuggingComponent.position(),
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);

	public static Vector3 directionalRepulsionFrom(this Component targetComponent, Vector3 tuggingPosition, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	targetComponent.position().directionalRepulsionFrom
		(
			tuggingPosition,
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	public static Vector3 directionalRepulsionFrom(this Component targetComponent, GameObject tuggingObject, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	targetComponent.directionalRepulsionFrom
		(
			tuggingObject.position(),
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	public static Vector3 directionalRepulsionFrom(this Component targetComponent, Component tuggingComponent, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	=>	targetComponent.directionalRepulsionFrom
		(
			tuggingComponent.position(),
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	#endregion calculating directional repulsion
	#endregion calculating directional force
}