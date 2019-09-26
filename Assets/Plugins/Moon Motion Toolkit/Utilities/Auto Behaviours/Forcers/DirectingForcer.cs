using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;

// Directing Forcer:
// • at each physics update, directs
// #force #raycasting
public class DirectingForcer : Forcer<DirectingForcer>
{
	// variables //

	
	[BoxGroup("Editor Visualization")]
	[Tooltip("whether to visualize the line of the raycast")]
	public bool visualizeLine = true;


	[BoxGroup("Directing")]
	[Tooltip("the tug of the force")]
	public Tug tug = Default.tug;

	[BoxGroup("Directing")]
	[Tooltip("the direction of the raycast")]
	public Vector3 raycastingDirection = Default.raycastingDirection;

	[BoxGroup("Directing")]
	[Tooltip("the distinctivity of the direction of the raycast")]
	public Distinctivity raycastingDistinctivity = Default.raycastingDistinctivity;

	[BoxGroup("Directing")]
	[Tooltip("the distance of the raycast")]
	public float raycastingDistance = Default.raycastingDistance;

	[BoxGroup("Directing")]
	[Tooltip("the magnitude of the force")]
	public float magnitude = Default.forceMagnitude;

	[BoxGroup("Directing")]
	[Tooltip("the curve by which to diminish the force's magnitude to zero from the raycasting position to the raycast's distance")]
	public InterpolationCurve raycastingDistanceMagnitudeZeroingCurve = Default.forceCurve;

	[BoxGroup("Directing")]
	[Tooltip("the raycast query to use for raycast collision")]
	public RaycastQuery raycastQuery = Default.raycastQuery;

	[BoxGroup("Directing")]
	[Tooltip("the query to use for trigger colliders")]
	public QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery;

	[BoxGroup("Directing")]
	[Tooltip("the layer mask to use for colliders")]
	public LayerMask layerMask = Default.layerMask;




	// updating //


	// upon drawing gizmos: //
	private void OnDrawGizmos()
		=> Visualize.raycastLineFrom(transform, raycastingDirection, raycastingDistinctivity, raycastingDistance,
			visualizeLine,
			visualizationColor);

	// at each physics update: //
	private void FixedUpdate()
		=>	direct
			(
				tug,
				raycastingDirection,
				raycastingDistinctivity,
				magnitude,
				raycastingDistance,
				raycastingDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask
			);
}