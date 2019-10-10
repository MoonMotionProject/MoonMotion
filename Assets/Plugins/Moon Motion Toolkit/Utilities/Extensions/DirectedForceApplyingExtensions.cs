using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Directed Force Applying Extensions: provides extension methods for applying directed force
// #force
public static class DirectedForceApplyingExtensions
{
	// methods: apply a directional force to this\these given provided rigidbody\rigidbodies, directed by the given provided forcing position or forcing transform, using the given direction (global, or with the given distinctivity using the given provided forcing transform), magnitude, reach, boolean for whether to apply zero force outside the reach, and clamping boolean, diminishing magnitude from the given forcing position (until the reach) to zero using the given curve, then return this\these given rigidbody provider\providers //
	
	
	
	
	#region applying directed force to this given provided rigidbody
	
	
	public static Rigidbody applyDirectedForceFrom(this Rigidbody rigidbody, object forcingPosition_PositionProvider, Vector3 direction, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		float reachProgression = rigidbody.position().distalProgressionTo(reach, forcingPosition);

		return rigidbody.applyForceAlong
		(
			direction,
			((reachProgression > 1f) && zeroForceOutsideReach) ?
				0f :
				magnitude.interpolateToZero
				(
					reachMagnitudeZeroingCurve,
					clamp,
					reachProgression
				)
		);
	}

	public static GameObject applyDirectedForceFrom(this GameObject gameObject, object forcingPosition_PositionProvider, Vector3 direction, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return gameObject.rigidbody().applyDirectedForceFrom
		(
			forcingPosition,
			direction,
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		).gameObject;
	}

	public static ComponentT applyDirectedForceFrom<ComponentT>(this ComponentT component, object forcingPosition_PositionProvider, Vector3 direction, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping) where ComponentT : Component
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return component.after(()=>
			component.rigidbody().applyDirectedForceFrom
			(
				forcingPosition,
				direction,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			));
	}


	public static Rigidbody applyDirectedForceFrom(this Rigidbody rigidbody, object forcingTransform_TransformProvider, Vector3 direction, Distinctivity distinctivity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		Transform forcingTransform = Provide.transformVia(forcingTransform_TransformProvider);

		return rigidbody.applyDirectedForceFrom
		(
			forcingTransform,
			direction.toGlobalDirectionFromDistinctivityOf(distinctivity, forcingTransform),
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	}

	public static GameObject applyDirectedForceFrom(this GameObject gameObject, object forcingTransform_TransformProvider, Vector3 direction, Distinctivity distinctivity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		Transform forcingTransform = Provide.transformVia(forcingTransform_TransformProvider);

		return gameObject.rigidbody().applyDirectedForceFrom
		(
			forcingTransform,
			direction,
			distinctivity,
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		).gameObject;
	}

	public static ComponentT applyDirectedForceFrom<ComponentT>(this ComponentT component, object forcingTransform_TransformProvider, Vector3 direction, Distinctivity distinctivity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping) where ComponentT : Component
	{
		Transform forcingTransform = Provide.transformVia(forcingTransform_TransformProvider);

		return component.after(()=>
			component.rigidbody().applyDirectedForceFrom
			(
				forcingTransform,
				direction,
				distinctivity,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			));
	}
	#endregion applying directed force to this given provided rigidbody




	#region applying directed force to each of these given provided rigidbodies


	public static List<Rigidbody> applyDirectedForceToEachFrom(this IEnumerable<Rigidbody> rigidbodies, object forcingPosition_PositionProvider, Vector3 direction, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return rigidbodies.forEachManifested(rigidbody =>
			rigidbody.applyDirectedForceFrom
			(
				forcingPosition,
				direction,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			));
	}

	public static List<GameObject> applyDirectedForceToEachFrom(this IEnumerable<GameObject> objects, object forcingPosition_PositionProvider, Vector3 direction, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return objects.forEachManifested(gameObject =>
			gameObject.applyDirectedForceFrom
			(
				forcingPosition,
				direction,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			));
	}

	public static List<ComponentT> applyDirectedForceToEachFrom<ComponentT>(this IEnumerable<ComponentT> components, object forcingPosition_PositionProvider, Vector3 direction, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping) where ComponentT : Component
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return components.forEachManifested(component =>
			component.applyDirectedForceFrom
			(
				forcingPosition,
				direction,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			));
	}


	public static List<Rigidbody> applyDirectedForceToEachFrom(this IEnumerable<Rigidbody> rigidbodies, object forcingTransform_TransformProvider, Vector3 direction, Distinctivity distinctivity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		Transform forcingTransform = Provide.transformVia(forcingTransform_TransformProvider);

		return rigidbodies.forEachManifested(rigidbody =>
			rigidbody.applyDirectedForceFrom
			(
				forcingTransform,
				direction,
				distinctivity,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			));
	}

	public static List<GameObject> applyDirectedForceToEachFrom(this IEnumerable<GameObject> objects, object forcingTransform_TransformProvider, Vector3 direction, Distinctivity distinctivity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		Transform forcingTransform = Provide.transformVia(forcingTransform_TransformProvider);

		return objects.forEachManifested(gameObject =>
			gameObject.applyDirectedForceFrom
			(
				forcingTransform,
				direction,
				distinctivity,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			));
	}

	public static List<ComponentT> applyDirectedForceToEachFrom<ComponentT>(this IEnumerable<ComponentT> components, object forcingTransform_TransformProvider, Vector3 direction, Distinctivity distinctivity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping) where ComponentT : Component
	{
		Transform forcingTransform = Provide.transformVia(forcingTransform_TransformProvider);

		return components.forEachManifested(component =>
			component.applyDirectedForceFrom
			(
				forcingTransform,
				direction,
				distinctivity,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			));
	}
	#endregion applying directed force to these given provided rigidbodies
}