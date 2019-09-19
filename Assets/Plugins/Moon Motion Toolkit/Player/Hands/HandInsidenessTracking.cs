using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hand Insideness Tracking: tracks for both hands individually (both for the left hand and for right hand) any nontrigger collider objects that hand is inside of, so as to help recognize cases of "VR cheating" via the player's hand being inside of a normally collision-inducing object 
// • expects this object to be a hand's trigger collider child (expects this object to be an eventual child of a player's hand, used for the purpose of providing a trigger collider for the hand, potentially one of multiple (not necessarily the only one))
// • tracks all objects of nontrigger colliders that this hand trigger collider is currently trigger collided with
//   · has a toggle setting for being for either the left hand or the right, by which to determine which hand this tracking is for
// • global methods are provided for determining, for either the left or right hand, all objects that any of that hand's trigger colliders (only those with this script) are currently trigger collided with via a nontrigger collider of such objects – also removing any outdated objects (that no longer exist or no longer have an immediate collider that is nontrigger)
public class HandInsidenessTracking : MonoBehaviour
{
	// variables //

	
	// variables for: instancing //
	private static HashSet<HandInsidenessTracking> insidenessTrackingsLeft = new HashSet<HandInsidenessTracking>(), insidenessTrackingsRight = new HashSet<HandInsidenessTracking>();		// connections - auto: all insideness trackings for either hand (left or right), respectively
	
	// variables for: insideness tracking //
	public bool leftInstance = true;		// setting: this hand insideness tracking's handedness (whether this insideness tracking is for the left hand (versus the right))
	private HashSet<GameObject> collidedObjects = new HashSet<GameObject>();		// tracking: all objects this hand trigger collider is currently trigger collided with via a nontrigger collider of such objects
	private Dictionary<Collider, float> collisionTrackingTimes = new Dictionary<Collider, float>();		// tracking: the last time for each collider of the collided objects that that collider was known to be still colliding (if any of these becomes longer ago than the duration of the last physics update, then the corresponding object will be untracked as being collided)



	// methods //

	
	// methods for: insideness tracking //

	// method: clean this insideness tracking (remove any outdated tracked objects (that no longer exist or no longer have an immediate collider that is nontrigger)) //
	private void clean()
	{
		// remove any tracked objects that no longer exist or no longer have an immediate collider that is nontrigger //
		/* this must be done the hard way, because of: https://issuetracker.unity3d.com/issues/hashset-dot-removewhere-does-not-correctly-evaluate-null-for-gameobjects-in-builds */
		bool continueCheckingToRemoveObjects = true;
		while (continueCheckingToRemoveObjects)
		{
			continueCheckingToRemoveObjects = false;

			foreach (GameObject triggerCollidedObject in collidedObjects)
			{
				Collider[] collidersOnObjectOrItsChildren = triggerCollidedObject.GetComponentsInChildren<Collider>();
				HashSet<Collider> nontriggerCollidersOnObjectOnly = new HashSet<Collider>();
				foreach (Collider colliderOnObjectOrItsChildren in collidersOnObjectOrItsChildren)
				{
					if (!colliderOnObjectOrItsChildren.isTrigger && (colliderOnObjectOrItsChildren.gameObject == triggerCollidedObject))
					{
						nontriggerCollidersOnObjectOnly.Add(colliderOnObjectOrItsChildren);
					}
				}
				
				if (!triggerCollidedObject || (nontriggerCollidersOnObjectOnly.Count <= 0))
				{
					collidedObjects.Remove(triggerCollidedObject);
					continueCheckingToRemoveObjects = true;
					break;
				}
			}
		}
	}

	// method: determine all objects that any of the left hand's insideness trackers are tracking – also removing any outdated objects //
	public static HashSet<GameObject> allCollidedObjectsForLeftHand()
	{
		HashSet<GameObject> allUniqueCollidedObjectsLeftHand = new HashSet<GameObject>();

		foreach (HandInsidenessTracking insidenessTrackingLeft in insidenessTrackingsLeft)
		{
			insidenessTrackingLeft.clean();

			foreach (GameObject collidedObject in insidenessTrackingLeft.collidedObjects)
			{
				if (!allUniqueCollidedObjectsLeftHand.Contains(collidedObject))
				{
					allUniqueCollidedObjectsLeftHand.Add(collidedObject);
				}
			}
		}

		return allUniqueCollidedObjectsLeftHand;
	}
	// method: determine all objects that any of the right hand's insideness trackers are tracking – also removing any outdated objects //
	public static HashSet<GameObject> allCollidedObjectsForRightHand()
	{
		HashSet<GameObject> allUniqueCollidedObjectsRightHand = new HashSet<GameObject>();

		foreach (HandInsidenessTracking insidenessTrackingRight in insidenessTrackingsRight)
		{
			insidenessTrackingRight.clean();

			foreach (GameObject collidedObject in insidenessTrackingRight.collidedObjects)
			{
				if (!allUniqueCollidedObjectsRightHand.Contains(collidedObject))
				{
					allUniqueCollidedObjectsRightHand.Add(collidedObject);
				}
			}
		}

		return allUniqueCollidedObjectsRightHand;
	}
	
	
	
	
	// updating //

	
	// upon being enabled: //
	private void OnEnable()
	{
		// track this instance of this class according to its handedness //
		if (leftInstance)
		{
			insidenessTrackingsLeft.Add(this);
		}
		else
		{
			insidenessTrackingsRight.Add(this);
		}
	}

	// upon being disabled: //
	private void OnDisable()
	{
		// untrack this instance of this class according to its handedness //
		if (leftInstance)
		{
			insidenessTrackingsLeft.Remove(this);
		}
		else
		{
			insidenessTrackingsRight.Remove(this);
		}
	}
	
	// upon trigger entry: //
	private void OnTriggerEnter(Collider collider)
	{
		// connect to the collided object //
		GameObject collidedObject = collider.gameObject;
		
		// if the collider is nontrigger: //
		if (!collider.isTrigger)
		{
			// if the object/collider is somehow already tracked for this insideness tracking: //
			if (collidedObjects.Contains(collidedObject))
			{
				// update the collision tracking time of this collider for this insideness tracking //
				collisionTrackingTimes[collider] = Time.time;
			}
			// otherwise (if the object/collider is not tracked for this insideness tracking yet): //
			else
			{
				// add the collided object to the tracking for this insideness tracking //
				collidedObjects.Add(collidedObject);
				collisionTrackingTimes.Add(collider, Time.time);
			}
		}
	}

	// upon trigger staying: //
	private void OnTriggerStay(Collider collider)
	{
		// connect to the collided object //
		GameObject collidedObject = collider.gameObject;
		
		// if the object/collider is tracked for this insideness tracking: //
		if (collidedObjects.Contains(collidedObject))
		{
			// if the collider is still nontrigger: //
			if (!collider.isTrigger)
			{
				// update the collision tracking time of this collider for this insideness tracking //
				collisionTrackingTimes[collider] = Time.time;
			}
			// otherwise (if the collider is no longer nontrigger): //
			else
			{
				// untrack the object/collider for this insideness tracking //
				collidedObjects.Remove(collidedObject);
				collisionTrackingTimes.Remove(collider);
			}
		}
		// otherwise: if the collider is nontrigger: //
		else if (!collider.isTrigger)
		{
			// add the collided object to the tracking for this insideness tracking //
			collidedObjects.Add(collidedObject);
			collisionTrackingTimes.Add(collider, Time.time);
		}
	}

	// upon trigger exit: //
	private void OnTriggerExit(Collider collider)
	{
		// remove the uncollided object from the tracking for this insideness tracking //
		collidedObjects.Remove(collider.gameObject);
		collisionTrackingTimes.Remove(collider);
	}

	// at each physics update: //
	private void FixedUpdate()
	{
		// if any of the collision tracking times for this insideness tracking are longer ago than the current fixed update time, untrack the corresponding collider/object //
		Dictionary<Collider, float> collisionTrackingTimesDuplicateForIteration = new Dictionary<Collider, float>(collisionTrackingTimes);
		foreach (KeyValuePair<Collider, float> collisionTrackingTime in collisionTrackingTimesDuplicateForIteration)
		{
			if ((Time.time - collisionTrackingTime.Value) > Time.fixedDeltaTime)
			{
				Collider collider = collisionTrackingTime.Key;

				collisionTrackingTimes.Remove(collider);
				collidedObjects.Remove(collider.gameObject);
			}
		}
	}
}