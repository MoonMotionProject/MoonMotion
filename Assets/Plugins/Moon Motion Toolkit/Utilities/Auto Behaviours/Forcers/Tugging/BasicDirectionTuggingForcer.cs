using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using NaughtyAttributes;
#endif

// Basic Direction Tugging Forcer:
// • at each physics update, tugs
//   · uses a basic direction for raycasting
// #force #raycasting
public class BasicDirectionTuggingForcer : EnabledsBehaviour<BasicDirectionTuggingForcer>
{
	#region variables


	#region editor visualization

	#if ODIN_INSPECTOR
	[TabGroup("Editor Visualization")]
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
	#else
	[BoxGroup("Tugging")]
	#endif
	[Tooltip("the magnitude of the force")]
	public float magnitude = Default.forceMagnitude;

	#if ODIN_INSPECTOR
	[TabGroup("Tugging")]
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
	[EnumToggleButtons]
	[LabelText("Direction")]
	#else
	[BoxGroup("Raycasting")]
	#endif
	[Tooltip("the direction of the raycast")]
	public BasicDirection raycastBasicDirection = Default.raycastingBasicDirection;

	#if ODIN_INSPECTOR
	[TabGroup("Raycasting")]
	[PropertySpace]
	[EnumToggleButtons]
	[LabelText("Distinctivity")]
	#else
	[BoxGroup("Raycasting")]
	#endif
	[Tooltip("the distinctivity of the direction of the raycast")]
	public Distinctivity raycastDistinctivity = Default.raycastingDistinctivity;

	#if ODIN_INSPECTOR
	[TabGroup("Raycasting")]
	[PropertySpace]
	[LabelText("Distance")]
	#else
	[BoxGroup("Raycasting")]
	#endif
	[Tooltip("the distance of the raycast")]
	public float raycastDistance = Default.raycastingDistance;

	#if ODIN_INSPECTOR
	[TabGroup("Raycasting")]
	[PropertySpace]
	[EnumToggleButtons]
	[LabelText("Raycast Query")]
	#else
	[BoxGroup("Raycasting")]
	#endif
	[Tooltip("the raycast query to use for raycast collision")]
	public RaycastQuery raycastQuery = Default.raycastQuery;

	#if ODIN_INSPECTOR
	[TabGroup("Raycasting")]
	[PropertySpace]
	[EnumToggleButtons]
	[LabelText("Trigger Collider Query")]
	#else
	[BoxGroup("Raycasting")]
	#endif
	[Tooltip("the query to use for trigger colliders")]
	public QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery;

	#if ODIN_INSPECTOR
	[TabGroup("Raycasting")]
	[PropertySpace]
	[LabelText("Layer Mask")]
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
		=>	Visualize.lineFrom(transform, raycastBasicDirection, raycastDistinctivity, raycastDistance,
				visualizeLine,
				visualizationColor);

	// at each physics update: //
	public void FixedUpdate()
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
	#endregion updating
}