using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using NaughtyAttributes;
#endif

// End Object Tugging Forcer:
// • at each physics update, tugs
//   · uses an end object for raycasting
// #force #raycasting
public class EndObjectTuggingForcer : EnabledsBehaviour<EndObjectTuggingForcer>
{
	#region variables


	#region editor visualization

#if ODIN_INSPECTOR
	[TabGroup("Editor Visualization")]
	[ToggleLeft]
	#else
	[BoxGroup("Editor Visualization")]
	#endif
	[Tooltip("whether to visualize the line of the raycast")]
	public bool visualizeLine = Default.choiceToVisualizeInEditor;

	#if ODIN_INSPECTOR
	[TabGroup("Editor Visualization")]
	[Indent]
	[ShowIf("visualizeLine")]
	[HideLabel]
	#else
	[BoxGroup("Editor Visualization")]
	#endif
	[Tooltip("the color to use for editor visualization")]
	public Color visualizationColor = Default.visualizationColor;
	#endregion editor visualization


	#region tugging
	
	#if ODIN_INSPECTOR
	[TabGroup("Tugging")]
	[EnumToggleButtons]
	#else
	[BoxGroup("Tugging")]
	#endif
	[Tooltip("the affinity of the force")]
	public Affinity affinity = Default.affinity;

	#if ODIN_INSPECTOR
	[TabGroup("Tugging")]
	[Space]
	#else
	[BoxGroup("Tugging")]
	#endif
	[Tooltip("the magnitude of the force")]
	public float magnitude = Default.forceMagnitude;

	#if ODIN_INSPECTOR
	[TabGroup("Tugging")]
	[Space]
	[HideLabel]
	[LabelText("Interpolation Curve")]
	#else
	[BoxGroup("Tugging")]
	#endif
	[Tooltip("the curve by which to diminish the force's magnitude to zero from the raycasting position to the raycast's distance")]
	public InterpolationCurve raycastingDistanceMagnitudeZeroingCurve = Default.forceCurve;
	#endregion tugging
	

	#region raycasting

	#if ODIN_INSPECTOR
	[TabGroup("Raycasting")]
	[PreviewField(Alignment = ObjectFieldAlignment.Left, AlignmentHasValue = true, Height = 80)]
	[LabelText("End Object")]
	[Required("End Object is required")]
	#else
	[BoxGroup("Raycasting")]
	[ShowAssetPreview]
	#endif
	[Tooltip("the end object of the raycast (providing the raycast end position)")]
	public GameObject raycastEndObject;

	#if ODIN_INSPECTOR
	[TabGroup("Raycasting")]
	[Space]
	[EnumToggleButtons]
	#else
	[BoxGroup("Raycasting")]
	#endif
	[Tooltip("the raycast query to use for raycast collision")]
	public RaycastQuery raycastQuery = Default.raycastQuery;

	#if ODIN_INSPECTOR
	[TabGroup("Raycasting")]
	[Space]
	[EnumToggleButtons]
	#else
	[BoxGroup("Raycasting")]
	#endif
	[Tooltip("the query to use for trigger colliders")]
	public QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery;

	#if ODIN_INSPECTOR
	[TabGroup("Raycasting")]
	#else
	[BoxGroup("Raycasting")]
	#endif
	[Tooltip("the layer mask to use for colliders")]
	public LayerMask layerMask = Default.layerMask;
	#endregion raycasting
	#endregion variables




	#region updating


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
	#endregion updating
}