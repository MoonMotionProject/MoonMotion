using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;

// Basic Directing Forcer:
// • at each physics update, directs
//   · unlike a Directing Forcer, uses a basic direction
// #force #raycasting
public class BasicDirectingForcer : Forcer<BasicDirectingForcer>
{
	// variables //

	
	[BoxGroup("Editor Visualization")]
	[Tooltip("whether to visualize the line of the raycast")]
	public bool visualizeLine = true;


	[BoxGroup("Directing")]
	[Tooltip("the affinity of the force")]
	public Affinity affinity = Default.affinity;

	[BoxGroup("Directing")]
	[Tooltip("the direction of the raycast")]
	public BasicDirection raycastingBasicDirection = Default.raycastingBasicDirection;

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
		=> Visualize.raycastLineFrom(transform, raycastingBasicDirection, raycastingDistinctivity, raycastingDistance,
			visualizeLine,
			visualizationColor);

	// at each physics update: //
	private void FixedUpdate()
		=>	direct
			(
				affinity,
				raycastingBasicDirection,
				raycastingDistinctivity,
				magnitude,
				raycastingDistance,
				raycastingDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask
			);
}