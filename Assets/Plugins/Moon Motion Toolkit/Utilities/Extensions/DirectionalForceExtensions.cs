using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Directional Force Extensions: provides extension methods for handling directional force
// #force
public static class DirectionalForceExtensions
{
	#region calculating directional force
	// methods: return the directional force with the given or respective tug upon this given declared provider of a force position, tugged by the given provided forcing position and for the given magnitude, reach, boolean for whether to return zero force outside the reach, and clamping boolean, diminishing magnitude from the given tugging position (until the reach) to zero using the given curve //


	#region calculating directional force with the given tug
	
	public static Vector3 directionalForceBy(this Vector3 forcePosition, dynamic forcingPosition_PositionProvider, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);
		
		float reachProgression = forcePosition.distalProgressionTo(reach, forcingPosition);

		return ((reachProgression > 1f) && zeroForceOutsideReach) ?
					FloatsVector.zeroes :
					(magnitude * forcingPosition.directionForTugUpon(forcePosition, tug))
						.interpolateToZeroes
						(
							reachMagnitudeZeroingCurve,
							clamp,
							reachProgression
						);
	}

	public static Vector3 directionalForceBy(this GameObject targetObject, dynamic forcingPosition_PositionProvider, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	Pass.positionVia(forcingPosition_PositionProvider, new Func<Vector3, Vector3>(forcingPosition =>
					targetObject.position().directionalForceBy
					(
						forcingPosition,
						tug,
						magnitude,
						reach,
						reachMagnitudeZeroingCurve,
						zeroForceOutsideReach,
						clamp
					)));

	public static Vector3 directionalForceBy(this Component targetComponent, dynamic forcingPosition_PositionProvider, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=> Pass.positionVia(forcingPosition_PositionProvider, new Func<Vector3, Vector3>(forcingPosition =>
				   targetComponent.position().directionalForceBy
				   (
					   forcingPosition,
					   tug,
					   magnitude,
					   reach,
					   reachMagnitudeZeroingCurve,
					   zeroForceOutsideReach,
					   clamp
				   )));
	#endregion calculating directional force with the given tug


	#region calculating directional attraction

	public static Vector3 directionalAttractionTo(this Vector3 forcePosition, dynamic forcingPosition_PositionProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=> Pass.positionVia(forcingPosition_PositionProvider, new Func<Vector3, Vector3>(forcingPosition =>
				   forcePosition.directionalForceBy
				   (
					   forcingPosition,
					   Tug.attraction,
					   magnitude,
					   reach,
					   reachMagnitudeZeroingCurve,
					   zeroForceOutsideReach,
					   clamp
				   )));

	public static Vector3 directionalAttractionTo(this GameObject targetObject, dynamic forcingPosition_PositionProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=> Pass.positionVia(forcingPosition_PositionProvider, new Func<Vector3, Vector3>(forcingPosition =>
				   targetObject.position().directionalAttractionTo
				   (
					   forcingPosition,
					   magnitude,
					   reach,
					   reachMagnitudeZeroingCurve,
					   zeroForceOutsideReach,
					   clamp
				   )));

	public static Vector3 directionalAttractionTo(this Component targetComponent, dynamic forcingPosition_PositionProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=> Pass.positionVia(forcingPosition_PositionProvider, new Func<Vector3, Vector3>(forcingPosition =>
				   targetComponent.position().directionalAttractionTo
				   (
					   forcingPosition,
					   magnitude,
					   reach,
					   reachMagnitudeZeroingCurve,
					   zeroForceOutsideReach,
					   clamp
				   )));
	#endregion calculating directional attraction


	#region calculating directional repulsion

	public static Vector3 directionalRepulsionFrom(this Vector3 forcePosition, dynamic forcingPosition_PositionProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=> Pass.positionVia(forcingPosition_PositionProvider, new Func<Vector3, Vector3>(forcingPosition =>
				   forcePosition.directionalForceBy
				   (
					   forcingPosition,
					   Tug.repulsion,
					   magnitude,
					   reach,
					   reachMagnitudeZeroingCurve,
					   zeroForceOutsideReach,
					   clamp
				   )));

	public static Vector3 directionalRepulsionFrom(this GameObject targetObject, dynamic forcingPosition_PositionProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=> Pass.positionVia(forcingPosition_PositionProvider, new Func<Vector3, Vector3>(forcingPosition =>
				   targetObject.position().directionalRepulsionFrom
				   (
					   forcingPosition,
					   magnitude,
					   reach,
					   reachMagnitudeZeroingCurve,
					   zeroForceOutsideReach,
					   clamp
				   )));

	public static Vector3 directionalRepulsionFrom(this Component targetComponent, dynamic forcingPosition_PositionProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=> Pass.positionVia(forcingPosition_PositionProvider, new Func<Vector3, Vector3>(forcingPosition =>
				   targetComponent.position().directionalRepulsionFrom
				   (
					   forcingPosition,
					   magnitude,
					   reach,
					   reachMagnitudeZeroingCurve,
					   zeroForceOutsideReach,
					   clamp
				   )));
	#endregion calculating directional repulsion
	#endregion calculating directional force
}