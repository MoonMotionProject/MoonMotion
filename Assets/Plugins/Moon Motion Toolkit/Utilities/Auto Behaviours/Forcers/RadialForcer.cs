using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Radial Forcer:
// • at each physics update, radially forces
// #force
public class RadialForcer : EnabledsEditorVisualized<RadialForcer>
{
	// variables //


	[BoxGroup("Editor Visualization")]
	[Tooltip("whether to visualize a sphere for the radius")]
	public bool visualizeSphere = Default.choiceToVisualizeInEditor;

	[BoxGroup("Editor Visualization")]
	[Tooltip("whether to visualize lines to each object to be forced")]
	public bool visualizeLines = Default.choiceToVisualizeInEditor;

	[Tooltip("the objects being forced")]
	[ReadOnly]
	public HashSet<GameObject> forcedObjects = new HashSet<GameObject>();


	[BoxGroup("Radially Forcing")]
	[Tooltip("the affinity of the force")]
	public Affinity affinity = Default.affinity;

	[BoxGroup("Radially Forcing")]
	[Tooltip("the radius of the force")]
	public float radius = Default.forceRadius;

	[BoxGroup("Radially Forcing")]
	[Tooltip("the magnitude of the force")]
	public float magnitude = Default.forceMagnitude;

	[BoxGroup("Radially Forcing")]
	[Tooltip("the curve by which to diminish the force's magnitude to zero from the center position to the force's radius")]
	public InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve;

	[BoxGroup("Radially Forcing")]
	[Tooltip("the query to use for trigger colliders")]
	public QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery;

	[BoxGroup("Radially Forcing")]
	[Tooltip("the layer mask to use for colliders")]
	public LayerMask layerMask = Default.layerMask;




	// updating //

	
	// upon editor visualization: //
	private void OnDrawGizmos()
	{
		Visualize.nextColorToBe(visualizationColor);
		Visualize.sphereAt(position, radius,
			visualizeSphere);
		if (visualizeLines)
		{
			HashSet<GameObject> objectsToVisualizeLinesFor = new HashSet<GameObject>();
			if (UnityIs.playing)
			{
				objectsToVisualizeLinesFor = forcedObjects;
			}
			else
			{
				objectsToVisualizeLinesFor = objectsWithin(radius, triggerColliderQuery, layerMask);
			}
			objectsToVisualizeLinesFor.forEach(forcedObject =>
				Visualize.lineFrom(position, forcedObject.position()));
		}
	}

	// at each physics update: //
	private void FixedUpdate()
		=>	forcedObjects = forceRadially
			(
				affinity,
				magnitude,
				radius,
				radiusDistanceMagnitudeZeroingCurve,
				triggerColliderQuery,
				layerMask
			);
}