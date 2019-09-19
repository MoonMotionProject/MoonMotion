using UnityEngine;
using System.Collections;

// Kinematize When Thrown:
// • kinematizes this object's rigidbody as soon as it is thrown
namespace Valve.VR.InteractionSystem
{
	[RequireComponent(typeof(Interactable))]
	[RequireComponent(typeof(Rigidbody))]
	public class KinematizeWhenThrown : AutoBehaviour<KinematizeWhenThrown>
	{
		// updating //

		
		// Interactable events //
		private void OnDetachedFromHand(Hand hand)        // "Called every Update() while this GameObject is attached to the hand"
			=> kinematize();
	}
}
