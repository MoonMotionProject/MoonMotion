using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using NaughtyAttributes;
#endif
#if HIGHLIGHT_PLUS
using HighlightPlus;
#endif

// Controller Raycasting Targeting:
// • while any of the controller operations is operated, raycasts from the first relevant controller, targets the raycasted object (∗) if any, tracking and highlighting it
//   · if Highlight Plus is not available, will not highlight the target
public abstract class	ControllerRaycastingTargeting<ControllerRaycastingTargetingT> :
					SingletonBehaviour<ControllerRaycastingTargetingT>
						where ControllerRaycastingTargetingT : ControllerRaycastingTargeting<ControllerRaycastingTargetingT>
					
{
	#region variables


	#region editor visualization

	#if ODIN_INSPECTOR
	[TabGroup("Visualization")]
	#else
	[BoxGroup("Visualization")]
	#endif
	[Tooltip("whether to visualize the line of the raycast")]
	public bool visualizeLine = Default.choiceToVisualizeInEditor;

	#if ODIN_INSPECTOR
	[TabGroup("Visualization")]
	[Indent]
	[ShowIf("visualizeLine")]
	[HideLabel]
	#else
	[BoxGroup("Visualization")]
	#endif
	[Tooltip("the color to use for editor visualization")]
	public Color visualizationColor = Default.visualizationColor;
	#endregion editor visualization


	#region control

	#if ODIN_INSPECTOR
	[TabGroup("Control")]
	#else
	[BoxGroup("Control")]
	#endif
	[Tooltip("the controller operations by which to raycast")]
	#if ODIN_INSPECTOR
	#if UNITY_EDITOR
    [ListItemSelector("operations_SetSelected")]
	#endif
	#else
	[ReorderableList]
	#endif
	public ControllerOperation[] operations;
	#region selected operation
	#if ODIN_INSPECTOR
	#if UNITY_EDITOR
	[TabGroup("Control")]
	[InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden, Expanded = true)]
	[HideLabel]
    [ShowInInspector]
	#pragma warning disable 0414
    private ControllerOperation operations_ListItemSelected;
	#pragma warning restore 0414
	public void operations_SetSelected(int index)
		=> operations_ListItemSelected = operations.itemOtherwiseDefault(index);
	#endif
	#endif
	#endregion selected operation
	#endregion control


	#region raycasting
	[InfoBox("Raycasting is nonpositional (does not include colliders overlapping this position) and is from the first relevant controller. It will detect the first raycasted object that is not static and has a lodal mesh filter or, otherwise, skinned mesh renderer. (Objects not meeting those requirements will not obscure raycasting.)")]		// ∗

	#if ODIN_INSPECTOR
	[TabGroup("Raycasting")]
	#else
	[BoxGroup("Raycasting")]
	#endif
	public Vector3 localDirection = Default.raycastingDirection;

	#if ODIN_INSPECTOR
	[TabGroup("Raycasting")]
	#else
	[BoxGroup("Raycasting")]
	#endif
	public float distance = Default.targetingRaycastingDistance;

	#if ODIN_INSPECTOR
	[TabGroup("Raycasting")]
	[EnumToggleButtons]
	#else
	[BoxGroup("Raycasting")]
	#endif
	public QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery;

	#if ODIN_INSPECTOR
	[TabGroup("Raycasting")]
	#else
	[BoxGroup("Raycasting")]
	#endif
	public LayerMask layerMask = Default.layerMask;
	
	// the controller that last did the raycasting //
	public static Controller raycastingController {get; private set;}
	
	// the current raycast hit //
	public static RaycastHit? targetingRaycastHit {get; private set;}
	
	// the currently raycasted/targeted object //
	public static GameObject targetedObject {get; private set;}
	#endregion raycasting


	#region highlighting
	#if HIGHLIGHT_PLUS
	[InfoBox("While any of the controller operations is operated, the first raycasted object will be highlighted.")]

	#if ODIN_INSPECTOR
	[TabGroup("Highlighting")]
	[InlineEditor(InlineEditorObjectFieldModes.Foldout)]
	#else
	[BoxGroup("Highlighting")]
	#endif
	public HighlightProfile highlighting = null;
	
	private bool highlightingTrackings_ShowIf => couldBeAwakeRightNow;

	#if ODIN_INSPECTOR
	[TabGroup("Highlighting")]
	[ShowIf("highlightingTrackings_ShowIf")]
	[LabelText("Highlightable Target Compo.")]
	[ReadOnly]
	[ShowInInspector]
	#endif
	public Component highlightableComponentOfTargetObject {get; private set;} = null;
	
	#if ODIN_INSPECTOR
	[TabGroup("Highlighting")]
	[ShowIf("highlightingTrackings_ShowIf")]
	[ReadOnly]
	[ShowInInspector]
	#endif
	public HighlightEffect targetHighlight {get; private set;} = null;
	#endif
	#endregion highlighting


	#region line rendering

	#if ODIN_INSPECTOR
	[TabGroup("Line Rendering")]
	#else
	[BoxGroup("Line Rendering")]
	#endif
	[Tooltip("whether to render a line representing the raycast")]
	public bool renderLine = Default.choiceToRenderRaycastLine;

	#if ODIN_INSPECTOR
	[TabGroup("Line Rendering")]
	[Indent]
	[PreviewField(Alignment = ObjectFieldAlignment.Center, AlignmentHasValue = true, Height = 60)]
	[ShowIf("renderLine")]
	[HideLabel]
	#else
	[BoxGroup("Line Rendering")]
	#endif
	[Tooltip("the material with which to render the line representing the raycast")]
	public Material lineMaterial;

	#if ODIN_INSPECTOR
	[TabGroup("Line Rendering")]
	[Indent]
	[SuffixLabel("Width", Overlay = true)]
	[ShowIf("renderLine")]
	[HideLabel]
	#else
	[BoxGroup("Line Rendering")]
	#endif
	[Tooltip("the width at which to render the line representing the raycast")]
	public float lineWidth = Default.lineRendererWidth;

	#if ODIN_INSPECTOR
	[TabGroup("Line Rendering")]
	[Indent]
	[LabelText("Render Only To Raycast Hit")]
	[ShowIf("renderLine")]
	#else
	[BoxGroup("Line Rendering")]
	#endif
	[Tooltip("whether to render the line only to the raycast hit versus for the set distance")]
	public bool renderLineOnlyToHit = Default.choiceToRenderRaycastLineOnlyToHit;
	#endregion line rendering


	#region feedback

	#if ODIN_INSPECTOR
	private void defaultVibrationIntensity()
		=> vibrationIntensity = Default.targetingVibrationIntensity;
	[TabGroup("Feedback")]
	[InlineButton("defaultVibrationIntensity", "Default")]
	#else
	[BoxGroup("Feedback")]
	#endif
	[Tooltip("the intensity at which to vibrate the raycasting controller when highlighting and unoutlining an object")]
	public ushort vibrationIntensity = Default.targetingVibrationIntensity;
	#endregion feedback
	#endregion variables




	#region methods


	// method: return the potential raycast hit (∗), potentially track the highlightable component of the target object, and render a line to represent the raycast while doing so, if set to //
	public RaycastHit? potentialHitRaycastingBy(Controller controller)
	{
		RaycastHit? potentialRaycastHit = controller.firstNonpositionallyRaycastedHitLocallyWhere
		(
			raycastHitToEvaluate =>
			{
				#if HIGHLIGHT_PLUS
				highlightableComponentOfTargetObject = null;
				#endif
				
				#if HIGHLIGHT_PLUS
				bool firstFoundAMeshFilter_IfFoundAnyHighlightableComponent = false;
				#endif

				bool raycastHitIsValid
					=	raycastHitToEvaluate.objectIsNotStatic() &&
						(
							(
								#if HIGHLIGHT_PLUS
								firstFoundAMeshFilter_IfFoundAnyHighlightableComponent = 
								#endif
								raycastHitToEvaluate.hasAnyLodal<MeshFilter>()
							) ||
							raycastHitToEvaluate.hasAnyLodal<SkinnedMeshRenderer>()
						);
				
				#if HIGHLIGHT_PLUS
				highlightableComponentOfTargetObject
					=	firstFoundAMeshFilter_IfFoundAnyHighlightableComponent ?
							raycastHitToEvaluate.firstLodal<MeshFilter>().castTo<Component>() :
							raycastHitToEvaluate.firstLodal<SkinnedMeshRenderer>().castTo<Component>();
				#endif

				return raycastHitIsValid;
			},
			localDirection,
			distance,
			triggerColliderQuery,
			layerMask
		);

		if (renderLineOnlyToHit && potentialRaycastHit.isYull())
		{
			setupLineRendererAsLineOfLightLocallyDirectedFrom
			(
				controller,
				localDirection,
				controller.distanceWith(potentialRaycastHit.GetValueOrDefault()),
				lineMaterial
			);
		}
		else
		{
			setupLineRendererAsLineOfLightLocallyDirectedFrom
			(
				controller,
				localDirection,
				distance,
				lineMaterial
			);
		}

		return potentialRaycastHit;
	}
	#endregion methods




	#region updating


	// upon editor visualization: //
	private void OnDrawGizmos()
	{
		if (!raycastingController && UnityIs.inEditorEditMode)
		{
			raycastingController = Controller.left;
		}

		if (raycastingController)
		{
			Visualize.localLineFrom(raycastingController, localDirection, distance,
				visualizeLine,
				visualizationColor);
		}
	}

	// at each late update: //
	public override void lateUpdate()		// Late Update instead of Update so that the line renderer isn't seen in two places for a frame when turning via the turning locomotion, and probably other situations too
	{
		bool operationsOperated = operations.isOperated();
		targetingRaycastHit =	operationsOperated ?
									potentialHitRaycastingBy
									(
										raycastingController = operations.firstRelevantController()
									) :
									null;
		lineRenderer.setEnablementTo(operationsOperated);
		
		GameObject objectRaycasted = targetingRaycastHit.gameObjectIfYull();

		if (targetedObject != objectRaycasted)
		{
			#if HIGHLIGHT_PLUS
			if (targetHighlight.isYull())
			{
				targetHighlight.finishHighlighting();
				targetHighlight = null;
			}
			#endif

			targetedObject = objectRaycasted;

			#if HIGHLIGHT_PLUS
			if (targetedObject)
			{
				targetHighlight = highlightableComponentOfTargetObject.beginGetHighlight(highlighting);
			}
			#endif

			raycastingController.vibrate(vibrationIntensity);
		}
	}
	#endregion updating
}