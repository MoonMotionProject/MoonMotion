using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using NaughtyAttributes;
#endif
using Valve.VR.InteractionSystem;
using UnityEditor;

// Outlining Controller Raycasting:
// • while any of the controller operations is operated, outlines the raycasted object (∗) if any
//   · does this by maintaining a child object with the set outline material that matches the raycasted object's shape and transformations
public abstract class	OutliningControllerRaycasting<OutliningControllerRaycastingT> :
					SingletonBehaviour<OutliningControllerRaycastingT>
						where OutliningControllerRaycastingT : OutliningControllerRaycasting<OutliningControllerRaycastingT>
					
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


	#region control

	#if ODIN_INSPECTOR
	[TabGroup("Control")]
	#else
	[BoxGroup("Control")]
	#endif
	[Tooltip("the controller operations by which to raycast and so outline")]
	#if ODIN_INSPECTOR
    [ListItemSelector("operations_SetSelected")]
	#else
	[ReorderableList]
	#endif
	public ControllerOperation[] operations;
	#region selected operation
	#if ODIN_INSPECTOR
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
	#endregion selected operation
	#endregion control


	#region raycasting
	[InfoBox("Raycasting is nonpositional (does not include colliders overlapping this position) and is from the first operating controller (otherwise the fallback controller for the first operated operation). It will detect the first raycasted object that has a local\\descendant mesh filter or otherwise skinned mesh renderer or otherwise capsule collider, and is not static. (Objects not meeting those requirements will not obscure raycasting.)")]		// ∗

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
	public float distance = Default.outlineRaycastingDistance;

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
	public static RaycastHit? outliningRaycastHit {get; private set;}
	
	// the currently raycasted object to outline //
	public static GameObject outlinedObject {get; private set;}
	
	// the kind of shape provider found (first) on the last outlined object upon being raycasted (mesh filter, by default) //
	public static ShapeProviderKind shapeProviderKindFound = ShapeProviderKind.meshFilter;
	// whether the kind of shape provider found is mesh filter //
	public static bool foundMeshFilter => shapeProviderKindFound.isMeshFilter();
	// whether the kind of shape provider found is skinned mesh renderer //
	public static bool foundSkinnedMeshRenderer => shapeProviderKindFound.isSkinnedMeshRenderer();
	// whether the kind of shape provider found is primitive collider //
	public static bool foundPrimitiveCollider => shapeProviderKindFound.isPrimitiveCollider();
	
	// the offset of the outlined object's primitive collider from the outlined object, by which to also offset the outline shading object – outlining via a found primitive collider – otherwise the zeroes floats vector //
	public static Vector3 offsetNecessaryForPotentiallyUsedPrimitiveCollider
		=>	foundPrimitiveCollider ?
				outlinedObject.providePrimitiveColliderLocalCenterPosition().multiplyBy(outlinedObject.localScale()) :
				FloatsVector.zeroes;
	#endregion raycasting


	#region outlining
	[InfoBox("While any of the controller operations is operated, the first raycasted object will be outlined.")]

	public static readonly string outlineShadingObjectName = "Outline Controller Raycasting - Outline";

	#if ODIN_INSPECTOR
	[TabGroup("Outlining")]
	[PreviewField(Alignment = ObjectFieldAlignment.Left, AlignmentHasValue = true, Height = 100)]
	[HideLabel]
	#else
	[BoxGroup("Outlining")]
	#endif
	[Tooltip("the outline material to use for the outline shading object; will be set to the default outline material at the start if null")]
	public Material outlineMaterial = null;
	
	// the outline object (reused between raycasted objects) for shading an outline of the outlined object //
	public static GameObject outlineShadingObject {get; private set;}
	#endregion outlining


	#region line rendering

	#if ODIN_INSPECTOR
	[TabGroup("Line Rendering")]
	#else
	[BoxGroup("Line Rendering")]
	#endif
	[Tooltip("whether to render a line representing the raycast")]
	#if ODIN_INSPECTOR
	[ToggleLeft]
	#endif
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
	[ToggleLeft]
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
	[TabGroup("Feedback")]
	#else
	[BoxGroup("Feedback")]
	#endif
	[Tooltip("the intensity at which to vibrate the raycasting controller when outlining and unoutlining an object")]
	public ushort vibrationIntensity = Default.vibrationIntensity;
	#endregion feedback
	#endregion variables




	#region methods


	// method: return the potential raycast hit (∗), track some variables related to the raycast accordingly, and render a line to represent the raycast while doing so, if set to //
	public RaycastHit? potentialHitRaycastingBy(Controller controller)
	{
		RaycastHit? potentialRaycastHit = controller.firstNonpositionallyRaycastedHitLocallyWhere
		(
			raycastHitToEvaluate =>
			{
				bool firstFoundAMeshFilter = false;
				bool firstFoundASkinnedMeshRenderer = false;

				bool raycastHitIsValid
					=	(
							(firstFoundAMeshFilter = raycastHitToEvaluate.hasAnyLocalOrDescendant<MeshFilter>()) ||
							(firstFoundASkinnedMeshRenderer = raycastHitToEvaluate.hasAnyLocalOrDescendant<SkinnedMeshRenderer>()) ||
							raycastHitToEvaluate.hasAnyLocalOrDescendant<CapsuleCollider>()
						) &&
						raycastHitToEvaluate.objectIsNotStatic();

				shapeProviderKindFound = ShapeProvider.kindFor(firstFoundAMeshFilter, firstFoundASkinnedMeshRenderer);

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

	// at the start: //
	private void Start()
		=>	outlineShadingObject = createChildObject(outlineShadingObjectName)
				.deactivate()
				.setMaterialTo(outlineMaterial.ifYullOtherwise(()=>
					outlineMaterial = Default.outlineMaterial_IfInAwakeOrStart));

	// at each late update: //
	private void LateUpdate()		// Late Update instead of Update so that the line renderer isn't seen in two places for a frame when turning via the turning locomotion, and probably other situations too
	{
		bool operationsOperated = operations.operated();
		outliningRaycastHit =	operationsOperated ?
									potentialHitRaycastingBy
									(
										raycastingController = operations.firstOperatedControllerOtherwiseFallback()
									) :
									null;
		lineRenderer.setEnablementTo(operationsOperated);
		
		GameObject objectRaycasted = outliningRaycastHit.gameObjectIfYull();

		if (outlinedObject != objectRaycasted)
		{
			outlinedObject = objectRaycasted;

			if (outlinedObject)
			{
				if (foundMeshFilter || foundPrimitiveCollider)
				{
					outlineShadingObject
						.destroyFirstIfAny<SkinnedMeshRenderer>(true)
						.setMeshTo(outlinedObject)
						.ensuredlyMatchTransformationsTo
						(
							outlinedObject,
							offsetNecessaryForPotentiallyUsedPrimitiveCollider
						);

					atNextCheckExecute(()=>		// this delay is necessary in order for any skinned mesh renderer to finish being destroyed, so that a mesh renderer can actually be created
					{
						outlineShadingObject.setMaterialTo(outlineMaterial);
					});
				}
				else	// if 'foundSkinnedMeshRenderer'
				{
					GameObject skinnedMeshRendererObject
						= outlinedObject.firstLocalOrDescendantObjectWith<SkinnedMeshRenderer>();
					outlineShadingObject.destroy();
					outlineShadingObject
						= skinnedMeshRendererObject
							.createDuplicateWithOnly<SkinnedMeshRenderer>(outlineShadingObjectName)
							.setParentTo(this)
							.setLabelsTo(this)
							.setMaterialTo(outlineMaterial)
							.ensuredlyMatchTransformationsTo(skinnedMeshRendererObject);
				}
				outlineShadingObject.activate();
			}
			else
			{
				outlineShadingObject
					.deactivate()
					.ensuredlyMatchTransformationsToNull()
					.removeMeshIfAny();
			}

			raycastingController.vibrate(vibrationIntensity);
		}
	}
	#endregion updating
}