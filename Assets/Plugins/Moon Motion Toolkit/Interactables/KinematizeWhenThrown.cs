using UnityEngine;
using System.Collections;

// Kinematize When Thrown:
// • kinematizes this object's rigidbody as soon as it is thrown
namespace Valve.VR.InteractionSystem
{
	[RequireComponent(typeof(Interactable))]
	[RequireComponent(typeof(Rigidbody))]
	public class KinematizeWhenThrown : MonoBehaviour
	{
		// variables //


		private new Rigidbody rigidbody;        // connection - automatic: this object's rigidbody




		// updating //

		
		// before the start: //
		private void Awake()
		{
			// connect to this object's rigidbody //
			rigidbody = GetComponent<Rigidbody>();
		}

		// Interactable events //
		private void OnDetachedFromHand(Hand hand)        // "Called every Update() while this GameObject is attached to the hand"
		{
			rigidbody.isKinematic = true;
		}
	}
}
