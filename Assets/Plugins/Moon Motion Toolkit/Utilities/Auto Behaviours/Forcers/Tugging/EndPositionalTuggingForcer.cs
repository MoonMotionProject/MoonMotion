using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;

// End Positional Tugging Forcer:
// • at each physics update, tugs
//   · uses an end position for raycasting
// #force #raycasting
public class EndPositionalTuggingForcer : EnabledsEditorVisualized<EndPositionalTuggingForcer>
{
	// variables //

	
	[BoxGroup("Editor Visualization")]
	[Tooltip("whether to visualize the line of the raycast")]
	public bool visualizeLine = Default.choiceToVisualizeInEditor;


	[BoxGroup("Tugging")]
	[Tooltip("the affinity of the force")]
	public Affinity affinity = Default.affinity;

	[BoxGroup("Tugging")]
	[Tooltip("the end position of the raycast")]
	public Vector3 raycastEndPosition;

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
		=>	Visualize.lineFrom(position, raycastEndPosition,
				visualizeLine,
				visualizationColor);

	// at each physics update: //
	private void FixedUpdate()
		=>	tug
			(
				affinity,
				raycastEndPosition,
				magnitude,
				raycastingDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask
			);
}