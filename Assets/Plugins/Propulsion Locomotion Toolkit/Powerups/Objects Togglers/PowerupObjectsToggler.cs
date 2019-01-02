using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Powerup Objects Toggler
// • adds the following pickup functionality to this powerup:
//   · toggles the active state of each of the objects given by the objects to toggle connections, by the toggling setting
public class PowerupObjectsToggler : Powerup
{
	// variables //

	
	// variables for: toggling objects //
	[Header("Toggling Objects")]
	[Tooltip("the objects to toggle the active state of")]
	public GameObject[] objectsToToggle = new GameObject[] {};		// connections - manual: the objects to toggle the active state of
	[Tooltip("the toggling by which to toggle the objects")]
	public Toggles.Toggling objectToggling = Toggles.Toggling.invertToggle;		// setting: the toggling by which to toggle the objects




	// methods //

	
	// method: cast this powerup //
	public override void cast()
	{
		// toggle the active state of each of the objects given by the objects to toggle connections //
		foreach (GameObject objectToToggle in objectsToToggle)
		{
			objectToToggle.SetActive(Toggles.toggleToggle(objectToToggle.activeSelf, objectToggling));
		}
	}
}