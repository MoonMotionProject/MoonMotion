using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Hands:
// • provides connections to the left and right hands of the player
// • provides extension methods for handling hands
public static class Hands
{
	// variables //

	
	// auto connections //
	private static Hand left_, right_;     // the left and right hand instances




	// properties //


	// the left hand instance //
	public static Hand left
	{
		get {return left_ ? left_ : (left_ = Controller.left.hand);}
	}
	// the right hand instance //
	public static Hand right
	{
		get {return right_ ? right_ : (right_ = Controller.right.hand);}
	}




	// methods //


	// methods for: determining the hand (null if none) by which this given thing is held //

	public static Hand handHolding(this Transform transform)
	{
		Transform transformAtCurrentLevel = transform;
		while (transformAtCurrentLevel.parent)
		{
			Transform parentTransform = transformAtCurrentLevel.parent;
			if (parentTransform.GetComponent<Hand>())
			{
				return parentTransform.GetComponent<Hand>();
			}
			transformAtCurrentLevel = parentTransform;
		}
		return null;
	}
	public static Hand handHolding(this GameObject gameObject)
	{
		return gameObject.transform.handHolding();
	}
	public static Hand handHolding(this Collider collider)
	{
		return collider.transform.handHolding();
	}
	public static Hand handHolding(this Collision collision)
	{
		return collision.transform.handHolding();
	}
	public static Hand handHolding(this Rigidbody rigidbody)
	{
		return rigidbody.transform.handHolding();
	}
	public static Hand handHolding(this Component component)
	{
		return component.transform.handHolding();
	}
}