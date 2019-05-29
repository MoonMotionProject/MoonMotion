using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Stretch Scalable:
// • while this interactable object is held by one controller and the set controller operation is operated (traditionally being a stretching operation involving both controllers), the other controller's movement away or toward the first controller is applied as an axis-normalized scale change to this object
namespace Valve.VR.InteractionSystem
{
	[RequireComponent(typeof(Interactable))]
	public class StretchScalable : MonoBehaviour
	{
		// variables //

		
		// settings //
		[Tooltip("the controller operation during which to consider this object stretched (if it is already held)")]
		public ControllerOperation stretchingOperation;
		[Tooltip("the min world scale for each axis (other than the hard minimum of zero for each axis) that this object can be stretched to by this component")]
		public Vector3 worldScaleMin = new Vector3(.1f, .1f, .1f);
		[Tooltip("the max world scale for each axis that this object can be stretched to by this component")]
		public Vector3 worldScaleMax = new Vector3(100f, 100f, 100f);

		// trackings //
		private Controller stretchingController;        // the last controller to be used for stretching
		private Vector3 previousWorldScale;        // the previous world scale of this object, tracked before starting to stretch
		private Vector3 stretchingControllerStartPosition;     // the position upon starting the last stretch of the last controller to be used for stretching
		private float startingControllersDistance;		// the distance between the controllers upon last starting stretching
		[HideInInspector] public bool stretchScaling = false;       // whether stretch scaling is currently occurring via this component




		// updating //


		// upon validation: //
		private void OnValidate()
		{
			if (GetComponent<Throwable>())
			{
				GetComponent<Throwable>().swappingEnabled = false;
			}
		}

		// Interactable events //
		private void OnAttachedToHand(Hand hand)       // "Called when this GameObject becomes attached to the hand"
		{
			stretchingController = hand.GetComponent<Controller>().otherController;
		}
		private void OnDetachedFromHand(Hand hand)        // "Called every Update() while this GameObject is attached to the hand"
		{
			stretchScaling = false;
		}
		private void HandAttachedUpdate(Hand hand)        // "Called every Update() while this GameObject is attached to the hand"
		{
			if (stretchingOperation.operated(StatesOfBeing.Beingness.becoming))
			{
				stretchScaling = true;

				transform.parent = null;
				previousWorldScale = transform.localScale;
				transform.parent = hand.transform;

				stretchingControllerStartPosition = stretchingController.transform.position;
				startingControllersDistance = Vector3.Distance(stretchingControllerStartPosition, hand.transform.position);
			}
			if (stretchingOperation.operated(StatesOfBeing.Beingness.being))
			{
				stretchScaling = true;

				float controllersDistance = Vector3.Distance(stretchingController.transform.position, hand.transform.position);
				float stretchDistance = controllersDistance - startingControllersDistance;

				float addedWorldScaleOnEachAxis = stretchDistance;
				Vector3 addedWorldScale = new Vector3(addedWorldScaleOnEachAxis, addedWorldScaleOnEachAxis, addedWorldScaleOnEachAxis);

				Vector3 targetWorldScale = previousWorldScale + addedWorldScale;

				transform.parent = null;
				transform.localScale = Vector3.Max(Vector3.zero, Vector3.Max(worldScaleMin, Vector3.Min(worldScaleMax, targetWorldScale)));
				transform.parent = hand.transform;
			}
			if (stretchingOperation.operated(StatesOfBeing.Beingness.unbecoming))
			{
				stretchScaling = false;
			}
		}
	}
}