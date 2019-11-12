using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using NaughtyAttributes;
#endif

// Radial Forcer:
// • at each physics update, radially forces
// #force
public class RadialForcer : EnabledsBehaviour<RadialForcer>
{
	#region variables


	#region editor visualization

	#if ODIN_INSPECTOR
	[TabGroup("Editor Visualization")]
	#else
	[BoxGroup("Editor Visualization")]
	#endif
	[Tooltip("whether to visualize a sphere for the radius")]
	public bool visualizeSphere = Default.choiceToVisualizeInEditor;

	#if ODIN_INSPECTOR
	[TabGroup("Editor Visualization")]
	#else
	[BoxGroup("Editor Visualization")]
	#endif
	[Tooltip("whether to visualize lines to each object to be forced")]
	public bool visualizeLines = Default.choiceToVisualizeInEditor;

	#if ODIN_INSPECTOR
	[TabGroup("Editor Visualization")]
	[ShowIf("@visualizeSphere || visualizeLines")]
	[HideLabel]
	#else
	[BoxGroup("Editor Visualization")]
	#endif
	[Tooltip("the color to use for editor visualization")]
	public Color visualizationColor = Default.visualizationColor;
	#endregion editor visualization
	

	#region forcing

	#if ODIN_INSPECTOR
	[TabGroup("Forcing")]
	#else
	[BoxGroup("Forcing")]
	#endif
	[Tooltip("the objects being forced")]
	[ReadOnly]
	public HashSet<GameObject> forcedObjects = New.setOf<GameObject>();

	#if ODIN_INSPECTOR
	[TabGroup("Forcing")]
	[EnumToggleButtons]
	#else
	[BoxGroup("Forcing")]
	#endif
	[Tooltip("the affinity of the force")]
	public Affinity affinity = Default.affinity;

	#if ODIN_INSPECTOR
	[TabGroup("Forcing")]
	#else
	[BoxGroup("Forcing")]
	#endif
	[Tooltip("the radius of the force")]
	public float radius = Default.forceRadius;

	#if ODIN_INSPECTOR
	[TabGroup("Forcing")]
	#else
	[BoxGroup("Forcing")]
	#endif
	[Tooltip("the magnitude of the force")]
	public float magnitude = Default.forceMagnitude;

	#if ODIN_INSPECTOR
	[TabGroup("Forcing")]
	[LabelText("Interpolation Curve")]
	#else
	[BoxGroup("Forcing")]
	#endif
	[Tooltip("the curve by which to diminish the force's magnitude to zero from the center position to the force's radius")]
	public InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve;

	#if ODIN_INSPECTOR
	[TabGroup("Forcing")]
	[EnumToggleButtons]
	#else
	[BoxGroup("Forcing")]
	#endif
	[Tooltip("the query to use for trigger colliders")]
	public QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery;

	#if ODIN_INSPECTOR
	[TabGroup("Forcing")]
	#else
	[BoxGroup("Forcing")]
	#endif
	[Tooltip("the layer mask to use for colliders")]
	public LayerMask layerMask = Default.layerMask;
	#endregion forcing
	#endregion variables




	#region updating


	// upon editor visualization: //
	private void OnDrawGizmos()
	{
		Visualize.nextColorToBe(visualizationColor);
		Visualize.sphereAt(position, radius,
			visualizeSphere);
		if (visualizeLines)
		{
			HashSet<GameObject> objectsToVisualizeLinesFor = New.setOf<GameObject>();
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
	public override void physicsUpdate()
		=>	forcedObjects = forceRadially
			(
				affinity,
				magnitude,
				radius,
				radiusDistanceMagnitudeZeroingCurve,
				triggerColliderQuery,
				layerMask
			);
	#endregion updating
}