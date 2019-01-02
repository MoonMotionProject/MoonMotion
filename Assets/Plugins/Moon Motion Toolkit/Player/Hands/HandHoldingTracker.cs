using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Hand Holding Tracker:
// • provides hand holding tracking\determination:
//   · tracks the last time that the parent hand was holding any interactables
//   · provides methods for determining what interactables the player's hands are holding:
//     - provides methods to: get all interactables held by, determine whether any interactables are held by, determine whether any interactables were held within a given amount of time ago by, determine whether being a Longbow Arrow Hand is the current state of: a particular hand
// • provides hand hovering tracking\determination:
//   · provides methods to determine whether any interactables are being hovered by a particular hand
//   · this is only for interactables not already being held – the same interactables that have caused a vibration of the hand hovering over them
public class HandHoldingTracker : MonoBehaviour
{
	// variables //

	
	// variables for: instancing, hand holding tracking\determination //
	private Transform handTransform;		// connection - automatic: the transform of this hand holding tracker's parent hand
	private Hand hand;		// connection - automatic: this hand holding tracker's hand
	[HideInInspector] public bool leftHand = true;		// tracking: whether this hand holding tracker is for the left hand (versus the right)
	public static HandHoldingTracker left, right;		// connections - automatic: the left and right instances of this class, respectively
	[HideInInspector] public float timeOfLastHoldingAnyInteractables = -Mathf.Infinity;		// tracking: the time this hand holding tracker's hand was last holding any interactables – defaulted to negative infinity by default as a flag that this hand holding tracker's hand has never held any interactables
	private bool handHoveringWithNonheldInteractable = false;		// tracking: whether the parent hand is currently hovering with a nonheld interactable




	// methods //

	
	// methods for: hand holding tracking\determination //

	// method: get all interactables held by this hand holding tracker's hand //
	public List<GameObject> heldInteractables()
	{
		List<GameObject> heldInteractablesList = new List<GameObject>();

		foreach (Transform handChildTransform in handTransform)
		{
			if (handChildTransform.GetComponent<Interactable>() && !handChildTransform.GetComponent<SpawnRenderModel>())
			{
				heldInteractablesList.Add(handChildTransform.gameObject);
			}
		}

		return heldInteractablesList;
	}
	// method: get all interactables held by the left hand //
	public static List<GameObject> heldInteractablesLeft()
	{
		return left.heldInteractables();
	}
	// method: get all interactables held by the right hand //
	public static List<GameObject> heldInteractablesRight()
	{
		return right.heldInteractables();
	}
	// method: get all interactables held by the both of the hands //
	public static List<GameObject> heldInteractablesBoth()
	{
		List<GameObject> heldInteractablesListLeftThenLaterBoth = heldInteractablesLeft();
		List<GameObject> heldInteractablesListRight = heldInteractablesRight();

		heldInteractablesListLeftThenLaterBoth.AddRange(heldInteractablesListRight);

		return heldInteractablesListLeftThenLaterBoth;
	}
	// method: determine whether any interactables are held by this hand holding tracker's hand //
	public bool anyHeldInteractables()
	{
		return (heldInteractables().Count > 0);
	}
	// method: determine whether any interactables are held by the left hand //
	public static bool anyHeldInteractablesLeft()
	{
		return (heldInteractablesLeft().Count > 0);
	}
	// method: determine whether any interactables are held by the right hand //
	public static bool anyHeldInteractablesRight()
	{
		return (heldInteractablesRight().Count > 0);
	}
	// method: determine whether any interactables are held by the both of the hands //
	public static bool anyHeldInteractablesEither()
	{
		return (heldInteractablesBoth().Count > 0);
	}
	// method: determine whether any interactables were held within the given time ago by this hand holding tracker's hand //
	public bool anyHeldInteractablesWithin(float timeAgo)
	{
		return ((Time.time - timeOfLastHoldingAnyInteractables) <= timeAgo);
	}
	// method: determine whether any interactables were held within the given time ago by the left hand //
	public static bool anyHeldInteractablesLeftWithin(float timeAgo)
	{
		return left.anyHeldInteractablesWithin(timeAgo);
	}
	// method: determine whether any interactables were held within the given time ago by the right hand //
	public static bool anyHeldInteractablesRightWithin(float timeAgo)
	{
		return right.anyHeldInteractablesWithin(timeAgo);
	}
	// method: determine whether any interactables were held within the given time ago by the both of the hands //
	public static bool anyHeldInteractablesEitherWithin(float timeAgo)
	{
		return (anyHeldInteractablesLeftWithin(timeAgo) || anyHeldInteractablesRightWithin(timeAgo));
	}
	// method: determine whether any interactables are being hovered by this hand holding tracker's hand //
	public bool anyHoveredInteractables()
	{
		return handHoveringWithNonheldInteractable;
	}
	// method: determine whether any interactables are being hovered by the left hand //
	public static bool anyHoveredInteractablesLeft()
	{
		return left.anyHoveredInteractables();
	}
	// method: determine whether any interactables are being hovered by the right hand //
	public static bool anyHoveredInteractablesRight()
	{
		return right.anyHoveredInteractables();
	}
	// method: determine whether any interactables are being hovered by the both of the hands //
	public static bool anyHoveredInteractablesEither()
	{
		return (anyHoveredInteractablesLeft() || anyHoveredInteractablesRight());
	}
	// method: determine whether being a Longbow Arrow Hand is the current state of this hand holding tracker's hand //
	public bool longbowArrowHand()
	{
		return handTransform.GetComponentInChildren<ArrowHand>();
	}
	// method: determine whether being a Longbow Arrow Hand is the current state of the left hand //
	public static bool longbowArrowHandLeft()
	{
		return left.longbowArrowHand();
	}
	// method: determine whether being a Longbow Arrow Hand is the current state of the right hand //
	public static bool longbowArrowHandRight()
	{
		return right.longbowArrowHand();
	}
	// method: determine whether being a Longbow Arrow Hand is the current state of either of the hands //
	public static bool longbowArrowHandEither()
	{
		return (longbowArrowHandLeft() || longbowArrowHandRight());
	}




	// updating //

	
	// before the start: //
    private void Awake()
    {
		// connect to the transform of this hand holding tracker's parent hand //
		handTransform = transform.parent;

		// connect to this hand holding tracker's hand //
		hand = handTransform.GetComponent<Hand>();
		
		// track whether this hand holding tracker is for the left hand //
		leftHand = (hand.startingHandType == Hand.HandType.Left);
    }

	// upon being enabled: //
	private void OnEnable()
	{
		// connect the corresponding instance of this class //
		if (leftHand)
		{
			left = this;
		}
		else
		{
			right = this;
		}
	}

	// at each update: //
	private void Update()
	{
		// if this hand holding tracker's hand is currently holding any interactables: //
		if (anyHeldInteractables())
		{
			// track the current time as the last time that this hand holding tracker's hand was last holding any interactables //
			timeOfLastHoldingAnyInteractables = Time.time;
		}
	}

	// upon the parent hand beginning hovering: //
	private void OnParentHandHoverBegin(Interactable interactable)
	{
		if (interactable.transform.parent != transform.parent)		// if the parent hand is hovering with something not already held by the parent hand
		{
			// track that the parent hand is currently hovering with a nonheld interactable //
			handHoveringWithNonheldInteractable = true;
		}
	}
	// upon the parent hand ending hovering: //
	private void OnParentHandHoverEnd(Interactable interactable)
	{
		// track that the parent hand is not currently hovering with a nonheld interactable //
		handHoveringWithNonheldInteractable = false;
	}
}