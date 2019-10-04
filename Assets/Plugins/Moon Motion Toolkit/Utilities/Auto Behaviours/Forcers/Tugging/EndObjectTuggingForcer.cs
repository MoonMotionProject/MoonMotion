using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;

// End Object Tugging Forcer:
// • at each physics update, tugs
//   · uses an end object for raycasting
// #force #raycasting
public class EndObjectTuggingForcer : EnabledsEditorVisualized<EndObjectTuggingForcer>
{
	// variables //

	
	[BoxGroup("Editor Visualization")]
	[Tooltip("whether to visualize the line of the raycast")]
	public bool visualizeLine = Default.choiceToVisualizeInEditor;


	[BoxGroup("Tugging")]
	[Tooltip("the affinity of the force")]
	public Affinity affinity = Default.affinity;

	[BoxGroup("Tugging")]
	[Tooltip("the end object of the raycast (providing the raycast end position)")]
	[ShowAssetPreview]
	public GameObject raycastEndObject;

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
	{
		if (raycastEndObject)
		{
			Visualize.lineFrom(position, raycastEndObject,
				visualizeLine,
				visualizationColor);
		}
	}

	// at each physics update: //
	private void FixedUpdate()
	{
		if (raycastEndObject)
		{
			tug
			(
				affinity,
				raycastEndObject,
				magnitude,
				raycastingDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask
			);
		}
	}
}