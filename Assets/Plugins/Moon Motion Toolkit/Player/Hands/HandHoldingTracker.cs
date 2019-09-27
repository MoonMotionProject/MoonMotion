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
public class HandHoldingTracker : AutoBehaviour<HandHoldingTracker>
{
	// variables //

	
	// variables for: instancing, hand holding tracking\determination //
	private Transform parentHandTransform;		// connection - auto: the transform of this hand holding tracker's parent hand
	private Hand parentHand;		// connection - auto: this hand holding tracker's hand
	[HideInInspector] public bool leftInstance = true;		// tracking: this hand holding tracker's handedness (whether this hand holding tracker is for the left hand (versus the right))
	public static HandHoldingTracker left, right;		// connections - auto: the left and right instances of this class, respectively
	[HideInInspector] public float timeOfLastHoldingAnyInteractables = -Mathf.Infinity;		// tracking: the time this hand holding tracker's hand was last holding any interactables – defaulted to negative infinity by default as a flag that this hand holding tracker's hand has never held any interactables
	private bool handHoveringWithNonheldInteractable = false;		// tracking: whether the parent hand is currently hovering with a nonheld interactable




	// methods //

	
	// methods for: hand holding tracking\determination //

	// method: get all interactables held by this hand holding tracker's hand //
	public List<GameObject> heldInteractables()
	{
		List<GameObject> heldInteractablesList = new List<GameObject>();

		foreach (Transform handChildTransform in parentHandTransform)
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
		=> left.heldInteractables();

	// method: get all interactables held by the right hand //
	public static List<GameObject> heldInteractablesRight()
		=> right.heldInteractables();

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
		=> Any.itemsIn(heldInteractables());

	// method: determine whether any interactables are held by the left hand //
	public static bool anyHeldInteractablesLeft()
		=> Any.itemsIn(heldInteractablesLeft());

	// method: determine whether any interactables are held by the right hand //
	public static bool anyHeldInteractablesRight()
		=> Any.itemsIn(heldInteractablesRight());

	// method: determine whether any interactables are held by the both of the hands //
	public static bool anyHeldInteractablesEither()
		=> Any.itemsIn(heldInteractablesBoth());

	// method: determine whether any interactables were held within the given time ago by this hand holding tracker's hand //
	public bool anyHeldInteractablesWithin(float timeAgo)
		=> timeSince(timeOfLastHoldingAnyInteractables) <= timeAgo;

	// method: determine whether any interactables were held within the given time ago by the left hand //
	public static bool anyHeldInteractablesLeftWithin(float timeAgo)
		=> left.anyHeldInteractablesWithin(timeAgo);

	// method: determine whether any interactables were held within the given time ago by the right hand //
	public static bool anyHeldInteractablesRightWithin(float timeAgo)
		=> right.anyHeldInteractablesWithin(timeAgo);

	// method: determine whether any interactables were held within the given time ago by the both of the hands //
	public static bool anyHeldInteractablesEitherWithin(float timeAgo)
		=> anyHeldInteractablesLeftWithin(timeAgo) || anyHeldInteractablesRightWithin(timeAgo);

	// method: determine whether any interactables are being hovered by this hand holding tracker's hand //
	public bool anyHoveredInteractables()
		=> handHoveringWithNonheldInteractable;

	// method: determine whether any interactables are being hovered by the left hand //
	public static bool anyHoveredInteractablesLeft()
		=> left.anyHoveredInteractables();

	// method: determine whether any interactables are being hovered by the right hand //
	public static bool anyHoveredInteractablesRight()
		=> right.anyHoveredInteractables();

	// method: determine whether any interactables are being hovered by the both of the hands //
	public static bool anyHoveredInteractablesEither()
		=> anyHoveredInteractablesLeft() || anyHoveredInteractablesRight();

	// method: determine whether being a Longbow Arrow Hand is the current state of this hand holding tracker's hand //
	public bool longbowArrowHand()
		=> parentHandTransform.hasAnyChildren<ArrowHand>();

	// method: determine whether being a Longbow Arrow Hand is the current state of the left hand //
	public static bool longbowArrowHandLeft()
		=> left.longbowArrowHand();

	// method: determine whether being a Longbow Arrow Hand is the current state of the right hand //
	public static bool longbowArrowHandRight()
		=> right.longbowArrowHand();

	// method: determine whether being a Longbow Arrow Hand is the current state of either of the hands //
	public static bool longbowArrowHandEither()
		=> longbowArrowHandLeft() || longbowArrowHandRight();




	// updating //


	// before the start: //
	private void Awake()
    {
		// connect to the transform of this hand holding tracker's parent hand //
		parentHandTransform = transform.parent;

		// connect to this hand holding tracker's hand //
		parentHand = parentHandTransform.first<Hand>();
		
		// track whether this hand holding tracker is for the left hand //
		leftInstance = (parentHand.startingHandType == Hand.HandType.Left);
    }

	// upon being enabled: //
	private void OnEnable()
	{
		// connect the corresponding instance of this class //
		if (leftInstance)
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
			timeOfLastHoldingAnyInteractables = time;
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
	// upon the parent hand ending hovering (not via nullification of the interactable): //
	private void OnParentHandHoverEnd(Interactable interactable)
	{
		// track that the parent hand is not currently hovering with a nonheld interactable //
		handHoveringWithNonheldInteractable = false;
	}
	// upon the parent hand ending hovering via nullification of the interactable: //
	private void OnParentHandHoverEndViaInteractableNullification()
	{
		// track that the parent hand is not currently hovering with a nonheld interactable //
		handHoveringWithNonheldInteractable = false;
	}
}