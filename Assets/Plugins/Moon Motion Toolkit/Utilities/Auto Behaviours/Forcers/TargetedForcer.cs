using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using NaughtyAttributes;
#endif

// Radial Forcer:
// • at each physics update, targetedly forces
// #force
public class TargetedForcer : EnabledsBehaviour<TargetedForcer>
{
	#region variables


	#region editor visualization

	#if ODIN_INSPECTOR
	[TabGroup("Editor Visualization")]
	#else
	[BoxGroup("Editor Visualization")]
	#endif
	[Tooltip("whether to visualize a line to the forced object")]
	public bool visualizeLine = Default.choiceToVisualizeInEditor;

	#if ODIN_INSPECTOR
	[TabGroup("Editor Visualization")]
	#else
	[BoxGroup("Editor Visualization")]
	#endif
	[Tooltip("whether to visualize a sphere for the reach")]
	public bool visualizeSphere = Default.choiceToVisualizeInEditor;

	#if ODIN_INSPECTOR
	[TabGroup("Editor Visualization")]
	[ShowIf("@visualizeLine || visualizeSphere")]
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
	private string targetObject_TitleSubtitle
		=>	targetObject.isYull() ?
				targetObject.name :
				"null";
	[TabGroup("Forcing")]
	[Title("What:", "$targetObject_TitleSubtitle", horizontalLine: false)]
	[PreviewField(Alignment = ObjectFieldAlignment.Left, AlignmentHasValue = true, Height = 80)]
	#else
	[BoxGroup("Forcing")]
	[ShowAssetPreview]
	#endif
	[Tooltip("the object to force")]
	public GameObject targetObject;

	#if ODIN_INSPECTOR
	[TabGroup("Forcing")]
	[PropertySpace]
	[EnumToggleButtons]
	#else
	[BoxGroup("Forcing")]
	#endif
	[Tooltip("the affinity of the force")]
	public Affinity affinity = Default.affinity;

	#if ODIN_INSPECTOR
	[TabGroup("Forcing")]
	[PropertySpace]
	#else
	[BoxGroup("Forcing")]
	#endif
	[Tooltip("the reach of the force")]
	public float reach = Default.forceReach;

	#if ODIN_INSPECTOR
	[TabGroup("Forcing")]
	[PropertySpace]
	#else
	[BoxGroup("Forcing")]
	#endif
	[Tooltip("the magnitude of the force")]
	public float magnitude = Default.forceMagnitude;

	#if ODIN_INSPECTOR
	[TabGroup("Forcing")]
	[PropertySpace]
	[LabelText("Interpolation Curve")]
	#else
	[BoxGroup("Forcing")]
	#endif
	[Tooltip("the curve by which to diminish the force's magnitude to zero from the forcing position to the force's reach")]
	public InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve;

	#if ODIN_INSPECTOR
	[TabGroup("Forcing")]
	[PropertySpace]
	#else
	[BoxGroup("Forcing")]
	#endif
	[Tooltip("whether to use zero magnitude for the force when the target is outside the reach")]
	public bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach;

	#if ODIN_INSPECTOR
	[TabGroup("Forcing")]
	[PropertySpace]
	#else
	[BoxGroup("Forcing")]
	#endif
	[Tooltip("whether to clamp the reach magnitude zeroing curve interpolation")]
	public bool clamp = Default.directedForceClamping;
	#endregion forcing
	#endregion variables




	#region updating


	// upon editor visualization: //
	private void OnDrawGizmos()
	{
		Visualize.nextColorToBe(visualizationColor);
		if (targetObject.isYull())
		{
			Visualize.lineFrom(position, targetObject.position(),
				visualizeLine);
		}
		Visualize.sphereAt(position, reach,
			visualizeSphere);
	}

	// at each physics update: //
	public override void physicsUpdate()
		=>	forceTarget
			(
				targetObject,
				affinity,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			);
	#endregion updating
}