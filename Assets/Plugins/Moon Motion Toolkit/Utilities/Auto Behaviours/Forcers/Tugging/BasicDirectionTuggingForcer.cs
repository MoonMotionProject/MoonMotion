using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;

// Basic Direction Tugging Forcer:
// • at each physics update, tugs
//   · uses a basic direction for raycasting
// #force #raycasting
public class BasicDirectionTuggingForcer : EnabledsEditorVisualized<BasicDirectionTuggingForcer>
{
	// variables //

	
	[BoxGroup("Editor Visualization")]
	[Tooltip("whether to visualize the line of the raycast")]
	public bool visualizeLine = Default.choiceToVisualizeInEditor;


	[BoxGroup("Tugging")]
	[Tooltip("the affinity of the force")]
	public Affinity affinity = Default.affinity;

	[BoxGroup("Tugging")]
	[Tooltip("the direction of the raycast")]
	public BasicDirection raycastBasicDirection = Default.raycastingBasicDirection;

	[BoxGroup("Tugging")]
	[Tooltip("the distinctivity of the direction of the raycast")]
	public Distinctivity raycastDistinctivity = Default.raycastingDistinctivity;

	[BoxGroup("Tugging")]
	[Tooltip("the distance of the raycast")]
	public float raycastDistance = Default.raycastingDistance;

	[BoxGroup("Tugging")]
	[Tooltip("the magnitude of the force")]
	public float magnitude = Default.forceMagnitude;

	[BoxGroup("Tugging")]
	[Tooltip("the curve by which to diminish the force's magnitude to zero from the raycasting position to the raycast's distance")]
	public InterpolationCurve raycastingDistanceMagnitudeZeroingCurve = Default.forceCurve;

	[BoxGroup("Tugging")]
	[Tooltip("the raycast query to use for raycast collision")]
	public RaycastQuery raycastQuery = Default.raycastQuery;

	[BoxGroup("Tugging")]
	[Tooltip("the query to use for trigger colliders")]
	public QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery;

	[BoxGroup("Tugging")]
	[Tooltip("the layer mask to use for colliders")]
	public LayerMask layerMask = Default.layerMask;




	// updating //


	// upon editor visualization: //
	private void OnDrawGizmos()
		=>	Visualize.lineFrom(transform, raycastBasicDirection, raycastDistinctivity, raycastDistance,
				visualizeLine,
				visualizationColor);

	// at each physics update: //
	private void FixedUpdate()
		=>	tug
			(
				affinity,
				raycastBasicDirection,
				raycastDistinctivity,
				magnitude,
				raycastDistance,
				raycastingDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask
			);
}