using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Raycasting Forcer:
// • at each physics update, raycastedly forces
// #force
public class RaycastingForcer : Forcer<RaycastingForcer>
{
	// variables //

	
	[BoxGroup("Editor Visualization")]
	[Tooltip("whether to visualize the line of the raycast")]
	public bool visualizeLine = true;


	[BoxGroup("Raycastedly Forcing")]
	[Tooltip("the tug of the force")]
	public Tug tug = Default.tug;

	[BoxGroup("Raycastedly Forcing")]
	[Tooltip("the direction of the raycast")]
	public Vector3 raycastingDirection;

	[BoxGroup("Raycastedly Forcing")]
	[Tooltip("whether to only force the first object raycasted")]
	public bool firstHitOnly = Default.raycastingForcingFirstHitOnly;

	[BoxGroup("Raycastedly Forcing")]
	[Tooltip("the distance of the raycast")]
	public float raycastingDistance = Default.raycastingDistance;

	[BoxGroup("Raycastedly Forcing")]
	[Tooltip("the magnitude of the force")]
	public float magnitude = Default.forceMagnitude;

	[BoxGroup("Raycastedly Forcing")]
	[Tooltip("the curve by which to diminish the force's magnitude to zero from the raycasting position to the raycast's distance")]
	public InterpolationCurve raycastingDistanceMagnitudeZeroingCurve = Default.forceCurve;

	[BoxGroup("Raycastedly Forcing")]
	[Tooltip("whether to ensure forcing of colliders at the raycasting position if not only forcing the first object raycasted")]
	public bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders;

	[BoxGroup("Raycastedly Forcing")]
	[Tooltip("the query to use for trigger colliders")]
	public QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery;

	[BoxGroup("Raycastedly Forcing")]
	[Tooltip("the layer mask to use for colliders")]
	public LayerMask layerMask = Default.layerMask;




	// updating //

	
	// upon drawing gizmos: //
	private void OnDrawGizmos()
		=> Visualize.lineFrom(position, position.positionAlong(raycastingDirection, raycastingDistance),
			visualizeLine,
			visualizationColor);

	// at each physics update: //
	private void FixedUpdate()
		=>	forceRaycastedly
			(
				tug,
				raycastingDirection,
				firstHitOnly,
				magnitude,
				raycastingDistance,
				raycastingDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask
			).printListing();
}