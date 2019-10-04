using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Valve.VR.InteractionSystem;
using UnityEditor;

// Outlining Controller Raycasting:
// • while any of the controller operations is operated, outlines the first nonpositionally (not at this position) raycasted object from the first (otherwise left) operating controller that has a mesh filter and is not static
//   · does this by maintaining a child object with the set outline material that matches the raycasted object's transformations
public class OutliningControllerRaycasting : EnabledsEditorVisualized<OutliningControllerRaycasting>
{
	#region variables


	[BoxGroup("Editor Visualization")]
	[Tooltip("whether to visualize the line of the raycast")]
	public bool visualizeLine = Default.choiceToVisualizeInEditor;


	[BoxGroup("Control")]
	[Tooltip("the controller operations by which to raycast and so outline")]
	[ReorderableList]
	public ControllerOperation[] operations;

	
	[InfoBox("Raycasting is nonpositional (does not include colliders overlapping this position) and is from the first (otherwise left) operating controller. It will detect the first raycasted object that has a mesh filter and is not static. (Objects without mesh filters or that are static will not obscure raycasting.)")]

	[BoxGroup("Raycasting")]
	public Vector3 localDirection = Default.raycastingDirection;

	[BoxGroup("Raycasting")]
	public float distance = Default.outlineRaycastingDistance;

	[BoxGroup("Raycasting")]
	public QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery;

	[BoxGroup("Raycasting")]
	public LayerMask layerMask = Default.layerMask;
	
	[BoxGroup("Raycasting")]
	[Tooltip("the currently raycasted object to outline")]
	private GameObject outlinedObject;
	
	[BoxGroup("Raycasting")]
	[Tooltip("the controller that last did the raycasting")]
	private Controller raycastingController;
	

	[InfoBox("While any of the controller operations is operated, the first raycasted object will be outlined.")]

	[BoxGroup("Outlining")]
	[Tooltip("the outline material to use for the outline shading object; will be set to the default outline material at the start if null")]
	public Material outlineMaterial = null;
	
	[BoxGroup("Outlining")]
	[Tooltip("the outline object (reused between raycasted objects) for shading an outline of the outlined object")]
	private GameObject outlineShadingObject;


	[BoxGroup("Line Rendering")]
	[Tooltip("whether to render a line representing the raycast")]
	public bool renderLine = Default.choiceToRenderRaycastLine;

	[BoxGroup("Line Rendering")]
	[Tooltip("the material with which to render the line representing the raycast")]
	public Material lineMaterial;

	[BoxGroup("Line Rendering")]
	[Tooltip("the width at which to render the line representing the raycast")]
	public float lineWidth = Default.lineRendererWidth;


	[BoxGroup("Feedback")]
	[Tooltip("the intensity at which to vibrate the raycasting controller when outlining and unoutlining an object")]
	public ushort vibrationIntensity = Default.vibrationIntensity;
	#endregion variables




	#region methods


	// method: return the first nonpositionally raycasted object from the given controller and for the raycasting settings – if it has a mesh filter and is not static (otherwise returning null); render a line to represent the raycast while doing so, if set to //
	public GameObject potentialObjectRaycastingBy(Controller controller)
	{
		setupLineRendererAsLineOfLightLocallyDirectedFrom(controller, localDirection, distance,
				lineMaterial);

		return controller.firstNonpositionallyRaycastedObjectLocallyWhere
		(
			newlyCastedObject_ =>
				newlyCastedObject_.hasAny<MeshFilter>() && newlyCastedObject_.isNotStatic(),
			localDirection,
			distance,
			triggerColliderQuery,
			layerMask
		);
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

	// at each update: //
	private void Update()
	{
		GameObject newlyOutlinedObject = operations.operated() ?
										potentialObjectRaycastingBy(raycastingController = operations.firstOperatedControllerOtherwiseLeft()) :
										null;
		
		if (newlyOutlinedObject != outlinedObject)
		{
			outlinedObject = newlyOutlinedObject;

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