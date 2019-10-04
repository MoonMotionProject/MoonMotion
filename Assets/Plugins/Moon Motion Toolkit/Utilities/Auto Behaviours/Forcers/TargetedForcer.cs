using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Radial Forcer:
// • at each physics update, targetedly forces
// #force
public class TargetedForcer : EnabledsEditorVisualized<TargetedForcer>
{
	// variables //

	
	[BoxGroup("Editor Visualization")]
	[Tooltip("whether to visualize a line to the forced object")]
	public bool visualizeLine = Default.choiceToVisualizeInEditor;

	[BoxGroup("Editor Visualization")]
	[Tooltip("whether to visualize a sphere for the reach")]
	public bool visualizeSphere = Default.choiceToVisualizeInEditor;


	[BoxGroup("Targetedly Forcing")]
	[Tooltip("the object to force")]
	[ShowAssetPreview]
	public GameObject targetObject;

	[BoxGroup("Targetedly Forcing")]
	[Tooltip("the affinity of the force")]
	public Affinity affinity = Default.affinity;

	[BoxGroup("Targetedly Forcing")]
	[Tooltip("the reach of the force")]
	public float reach = Default.forceReach;

	[BoxGroup("Targetedly Forcing")]
	[Tooltip("the magnitude of the force")]
	public float magnitude = Default.forceMagnitude;

	[BoxGroup("Targetedly Forcing")]
	[Tooltip("the curve by which to diminish the force's magnitude to zero from the forcing position to the force's reach")]
	public InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve;

	[BoxGroup("Targetedly Forcing")]
	[Tooltip("whether to use zero magnitude for the force when the target is outside the reach")]
	public bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach;

	[BoxGroup("Targetedly Forcing")]
	[Tooltip("whether to clamp the reach magnitude zeroing curve interpolation")]
	public bool clamp = Default.directedForceClamping;




	// updating //


	// upon editor visualization: //
	private void OnDrawGizmos()
	{
		Visualize.nextColorToBe(visualizationColor);
		Visualize.lineFrom(position, targetObject.position(),
			visualizeLine);
		Visualize.sphereAt(position, reach,
			visualizeSphere);
	}

	// at each physics update: //
	private void FixedUpdate()
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
}