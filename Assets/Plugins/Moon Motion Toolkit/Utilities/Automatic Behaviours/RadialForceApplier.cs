using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// RadialForceApplier:
// • at each physics update, applies radial force
public class RadialForceApplier : AutomaticBehaviour<RadialForceApplier>
{
	// variables //


	// settings //

	public Tug tug = Default.tug;
	public float radius = Default.forceRadius;
	public float magnitude = Default.forceMagnitude;
	public InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve;
	public QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery;
	public LayerMask layerMask = Default.layerMask;




	// updating //


	// upon drawing gizmos: //
	private void OnDrawGizmos()
		=> Gizmos.DrawWireSphere(position, radius);

	// at each physics update: //
	private void FixedUpdate()
		=> forceRadially(tug, magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask);
}