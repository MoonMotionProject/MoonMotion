using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Valve.VR.InteractionSystem;
using UnityEditor;

// Outlining Controller Raycasting:
// • while any of the controller operations is operated, outlines the first nonpositionally (not at this position) raycasted object from the first operating controller (otherwise the fallback controller for the first operated operation) that has a mesh filter and is not static
//   · does this by maintaining a child object with the set outline material that matches the raycasted object's transformations
public abstract class	OutliningControllerRaycasting<OutliningControllerRaycastingT> :
					SingletonEditorVisualized<OutliningControllerRaycastingT>
						where OutliningControllerRaycastingT : OutliningControllerRaycasting<OutliningControllerRaycastingT>
					
{
	#region variables


	[BoxGroup("Editor Visualization")]
	[Tooltip("whether to visualize the line of the raycast")]
	public bool visualizeLine = Default.choiceToVisualizeInEditor;


	[BoxGroup("Control")]
	[Tooltip("the controller operations by which to raycast and so outline")]
	[ReorderableList]
	public ControllerOperation[] operations;

	
	[InfoBox("Raycasting is nonpositional (does not include colliders overlapping this position) and is from the first operating controller (otherwise the fallback controller for the first operated operation). It will detect the first raycasted object that has a mesh filter and is not static. (Objects without mesh filters or that are static will not obscure raycasting.)")]

	[BoxGroup("Raycasting")]
	public Vector3 localDirection = Default.raycastingDirection;

	[BoxGroup("Raycasting")]
	public float distance = Default.outlineRaycastingDistance;

	[BoxGroup("Raycasting")]
	public QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery;

	[BoxGroup("Raycasting")]
	public LayerMask layerMask = Default.layerMask;
	
	//[BoxGroup("Raycasting")]
	//[Tooltip("the controller that last did the raycasting")]
	public static Controller raycastingController {get; private set;}
	
	//[BoxGroup("Raycasting")]
	//[Tooltip("the current raycast hit")]
	public static RaycastHit? outliningRaycastHit {get; private set;}
	
	//[BoxGroup("Raycasting")]
	//[Tooltip("the currently raycasted object to outline")]
	public static GameObject outlinedObject {get; private set;}
	

	[InfoBox("While any of the controller operations is operated, the first raycasted object will be outlined.")]

	[BoxGroup("Outlining")]
	[Tooltip("the outline material to use for the outline shading object; will be set to the default outline material at the start if null")]
	public Material outlineMaterial = null;
	
	//[BoxGroup("Outlining")]
	//[Tooltip("the outline object (reused between raycasted objects) for shading an outline of the outlined object")]
	public static GameObject outlineShadingObject {get; private set;}


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


	[BoxGroup("Feedback")]
	[Tooltip("the intensity at which to vibrate the raycasting controller when outlining and unoutlining an object")]
	public ushort vibrationIntensity = Default.vibrationIntensity;
	#endregion variables




	#region methods


	// method: return the first nonpositionally raycasted object from the given controller and for the raycasting settings – if it has a mesh filter and is not static (otherwise returning null); render a line to represent the raycast while doing so, if set to //
	public RaycastHit? potentialHitRaycastingBy(Controller controller)
	{
		RaycastHit? potentialRaycastHit = controller.firstNonpositionallyRaycastedHitLocallyWhere
		(
			raycastHitToEvaluate =>
				raycastHitToEvaluate.hasAny<MeshFilter>() && raycastHitToEvaluate.objectIsNotStatic(),
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
		outliningRaycastHit = operations.operated() ?
								potentialHitRaycastingBy
								(
									raycastingController = operations.firstOperatedControllerOtherwiseFallback()
								) :
								null;
		
		GameObject objectRaycasted = outliningRaycastHit.gameObjectIfYull();

		if (outlinedObject != objectRaycasted)
		{
			outlinedObject = objectRaycasted;

			if (outlinedObject)
			{
				outlineShadingObject
					.setMeshTo(outlinedObject)
					.ensuredlyMatchTransformationsTo(outlinedObject)
					.activate();
			}
			else
			{
				outlineShadingObject
					.deactivate()
					.ensuredlyMatchTransformationsToNull()
					.removeMeshIfAny();
			}

			raycastingController.vibrate(500);
		}
	}
	#endregion updating
}