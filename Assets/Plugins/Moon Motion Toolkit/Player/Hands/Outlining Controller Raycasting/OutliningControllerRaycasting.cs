using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Valve.VR.InteractionSystem;
using UnityEditor;

// Outlining Controller Raycasting:
// • while any of the controller operations is operated, outlines the raycasted object (∗) if any
//   · does this by maintaining a child object with the set outline material that matches the raycasted object's transformations
public abstract class	OutliningControllerRaycasting<OutliningControllerRaycastingT> :
					SingletonEditorVisualized<OutliningControllerRaycastingT>
						where OutliningControllerRaycastingT : OutliningControllerRaycasting<OutliningControllerRaycastingT>
					
{
	#region variables


	#region editor visualization

	[BoxGroup("Editor Visualization")]
	[Tooltip("whether to visualize the line of the raycast")]
	public bool visualizeLine = Default.choiceToVisualizeInEditor;
	#endregion editor visualization


	#region control

	[BoxGroup("Control")]
	[Tooltip("the controller operations by which to raycast and so outline")]
	[ReorderableList]
	public ControllerOperation[] operations;
	#endregion control


	#region raycasting
	[InfoBox("Raycasting is nonpositional (does not include colliders overlapping this position) and is from the first operating controller (otherwise the fallback controller for the first operated operation). It will detect the first raycasted object that has a local\\descendant mesh filter or otherwise capsule collider, and is not static. (Objects without mesh filters or that are static will not obscure raycasting.)")]		// ∗

	[BoxGroup("Raycasting")]
	public Vector3 localDirection = Default.raycastingDirection;

	[BoxGroup("Raycasting")]
	public float distance = Default.outlineRaycastingDistance;

	[BoxGroup("Raycasting")]
	public QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery;

	[BoxGroup("Raycasting")]
	public LayerMask layerMask = Default.layerMask;
	
	// the controller that last did the raycasting //
	public static Controller raycastingController {get; private set;}
	
	// the current raycast hit //
	public static RaycastHit? outliningRaycastHit {get; private set;}
	
	// the currently raycasted object to outline //
	public static GameObject outlinedObject {get; private set;}

	// whether the last outlined object had a mesh filter upon being raycasted (otherwise true by default) //
	public static bool raycastFoundAMeshFilter = true;
	
	// the offset of the outlined object's primitive collider from the outlined object, by which to also offset the outline shading object – outlining via a found primitive collider instead of a found mesh – otherwise the zeroes floats vector //
	public static Vector3 offsetNecessaryForPotentiallyUsedPrimitiveCollider
		=>	raycastFoundAMeshFilter ?
				FloatsVector.zeroes :
				outlinedObject.providePrimitiveColliderLocalCenterPosition().multiplyBy(outlinedObject.localScale());
	#endregion raycasting


	#region outlining
	[InfoBox("While any of the controller operations is operated, the first raycasted object will be outlined.")]

	[BoxGroup("Outlining")]
	[Tooltip("the outline material to use for the outline shading object; will be set to the default outline material at the start if null")]
	public Material outlineMaterial = null;
	
	// the outline object (reused between raycasted objects) for shading an outline of the outlined object //
	public static GameObject outlineShadingObject {get; private set;}
	#endregion outlining


	#region line rendering

	[BoxGroup("Line Rendering")]
	[Tooltip("whether to render a line representing the raycast")]
	public bool renderLine = Default.choiceToRenderRaycastLine;

	[BoxGroup("Line Rendering")]
	[Tooltip("the material with which to render the line representing the raycast")]
	public Material lineMaterial;

	[BoxGroup("Line Rendering")]
	[Tooltip("the width at which to render the line representing the raycast")]
	public float lineWidth = Default.lineRendererWidth;

	[BoxGroup("Line Rendering")]
	[Tooltip("whether to render the line only to the raycast hit versus for the set distance")]
	public bool renderLineOnlyToHit = Default.choiceToRenderRaycastLineOnlyToHit;
	#endregion line rendering


	#region feedback

	[BoxGroup("Feedback")]
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
				(
					(raycastFoundAMeshFilter = raycastHitToEvaluate.hasAnyLocalOrDescendant<MeshFilter>()) ||
					raycastHitToEvaluate.hasAnyLocalOrDescendant<CapsuleCollider>()
				) &&
				raycastHitToEvaluate.objectIsNotStatic(),
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
		=>	outlineShadingObject = createChildObject("Outline Controller Raycasting - Outline")
				.deactivate()
				.setMaterialTo(outlineMaterial.ifYullOtherwise(()=>
					outlineMaterial = Default.outlineMaterial_IfInAwakeOrStart));

	// at each late update: //
	private void LateUpdate()		// Late Update instead of Update so that the line renderer isn't seen in two places for a frame when turning via the turning locomotion, and probably other situations too
	{
		bool operationsOperated = operations.operated();
		outliningRaycastHit = operationsOperated ?
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
				outlineShadingObject
					.setMeshTo(outlinedObject)
					.ensuredlyMatchTransformationsTo
					(
						outlinedObject,
						offsetNecessaryForPotentiallyUsedPrimitiveCollider
					)
					.activate();
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