using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Stretch Scalable:
// • while this throwable object is held by one controller and the set controller operation is operated (traditionally being a stretching operation involving both controllers), the other controller's movement away or toward the first controller is applied as an axis-normalized scale change to this object
namespace Valve.VR.InteractionSystem
{
	[RequireComponent(typeof(Throwable))]
	public class StretchScalable : AutoBehaviour<StretchScalable>
	{
		// variables //

		
		// settings //

		[Tooltip("the controller operation during which to consider this object stretched (if it is already held)")]
		public ControllerOperation stretchingOperation;

		[Tooltip("the min world scale for each axis that this object can be stretched to by this component (when being set, the scale is also clamped to be a valid scale)")]
		public Vector3 worldScaleMin = new Vector3(.1f, .1f, .1f);

		[Tooltip("the max world scale for each axis that this object can be stretched to by this component (when being set, the scale is also clamped to be a valid scale)")]
		public Vector3 worldScaleMax = new Vector3(100f, 100f, 100f);


		// trackings //

		private Controller stretchingController;        // the last controller to be used for stretching

		private Vector3 previousWorldScale;        // the previous world scale of this object, tracked before starting to stretch

		private Vector3 stretchingControllerStartPosition;     // the position upon starting the last stretch of the last controller to be used for stretching

		private float startingControllersDistance;		// the distance with the controllers upon last starting stretching

		[HideInInspector] public bool stretchScaling = false;       // whether stretch scaling is currently occurring via this component




		// updating //

		
		// upon validation: //
		public override void OnValidate()
		{
			base.OnValidate();

			throwable.disableSwapping();
		}

		// Interactable events //
		private void OnAttachedToHand(Hand hand)       // "Called when this GameObject becomes attached to the hand"
			=> stretchingController = hand.GetComponent<Controller>().otherController;

		private void OnDetachedFromHand(Hand hand)        // "Called every Update() while this GameObject is attached to the hand"
			=> stretchScaling = false;

		private void HandAttachedUpdate(Hand hand)        // "Called every Update() while this GameObject is attached to the hand"
		{
			if (stretchingOperation.operatedBecomingly())
			{
				stretchScaling = true;

				unparent();
				previousWorldScale = localScale;
				setParentTo(hand);

				stretchingControllerStartPosition = stretchingController.position();
				startingControllersDistance = stretchingControllerStartPosition.distanceWith(hand);
			}
			if (stretchingOperation.operatedBeingly())
			{
				stretchScaling = true;

				float controllersDistance = stretchingController.position().distanceWith(hand);
				float stretchDistance = controllersDistance - startingControllersDistance;

				Vector3 targetWorldScale = previousWorldScale + stretchDistance.asVector();

				unparent();
				setLocalScaleTo(targetWorldScale.atLeast(worldScaleMin).atMost(worldScaleMax).clampedToBeValidScale());
				setParentTo(hand);
			}
			if (stretchingOperation.operatedUnbecomingly())
			{
				stretchScaling = false;
			}
		}
	}
}