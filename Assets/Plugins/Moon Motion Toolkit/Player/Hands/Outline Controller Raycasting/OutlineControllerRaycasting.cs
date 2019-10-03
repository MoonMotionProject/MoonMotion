using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Valve.VR.InteractionSystem;

// Outline Controller Raycasting:
// • only when the controller operation is operated, outlines the first nonpositionally raycasted object from the first operating controller – if the raycasted object has a mesh filter
//   · does this by maintaining a child object with the set outline material that matches the raycasted object's transformations
public class OutlineControllerRaycasting : EnabledsEditorVisualized<OutlineControllerRaycasting>
{
	// variables //

	
	[BoxGroup("Editor Visualization")]
	[Tooltip("whether to visualize the line of the raycast")]
	public bool visualizeLine = true;


	[BoxGroup("Control")]
	[Tooltip("the controller operations by which to raycast and so outline")]
	[ReorderableList]
	public ControllerOperation[] operations;


	[BoxGroup("Raycasting")]
	public Vector3 direction = Default.raycastingDirection;

	[BoxGroup("Raycasting")]
	public Distinctivity distinctivity = Default.raycastingDistinctivity;

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
	

	[BoxGroup("Outlining")]
	[Tooltip("the outline material to use for the outline shading object; will be set to the default outline material at the start if null")]
	public Material outlineMaterial = null;
	
	[BoxGroup("Outlining")]
	[Tooltip("the outline object (reused between raycasted objects) for shading an outline of the outlined object")]
	private GameObject outlineShadingObject;




	// methods //

	
	// method: return the first nonpositionally raycasted object from the given controller and for the raycasting settings – if it has a mesh filter (otherwise returning null) //
	public GameObject potentialObjectCastedBy(Controller controller)
		=>	controller.firstNonpositionallyRaycastedObjectAlong
			(
				direction,
				distinctivity,
				distance,
				triggerColliderQuery,
				layerMask
			).nullIfNullOr(newlyCastedObject_ =>
				newlyCastedObject_.hasNo<MeshFilter>());




	// updating //

	
	// upon editor visualization: //
	private void OnDrawGizmos()
	{
		if (raycastingController)
		{
			Visualize.lineFrom(raycastingController, direction, distinctivity, distance,
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
										potentialObjectCastedBy(raycastingController = operations.firstOperatedController()) :
										null;
		
		if (newlyOutlinedObject != outlinedObject)
		{
			outlinedObject = newlyOutlinedObject;

			if (outlinedObject)
			{
				outlineShadingObject
					.setMeshTo(outlinedObject)
					.ensureMatchTransformationsTo(outlinedObject)
					.activate();
			}
			else
			{
				outlineShadingObject
					.deactivate()
					.ensureMatchTransformationsToNull()
					.removeMeshIfAny();
			}
		}
	}
}