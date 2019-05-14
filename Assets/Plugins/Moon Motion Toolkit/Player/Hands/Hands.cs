using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Hands: provides connections to the left and right hands of the player //
public class Hands : MonoBehaviour
{
	// variables //

	
	public static Hand left, right;		// connections - automatic: the left and right hand instances of the player




	// updating //

	
	// at the start: //
	private void Start()
	{
		// connect to the left hand //
		left = Controller.left.hand;

		// connect to the right hand //
		right = Controller.right.hand;
	}
}