using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Powerup Objects Toggler
// • adds the following pickup functionality to this powerup:
//   · toggles the activity of each of the objects given by the objects to toggle connections, by the toggling setting
// • provides methods to toggle (the connected objects to toggle) on or off explicitly
public class PowerupObjectsToggler : Powerup
{
	// variables //

	
	// variables for: toggling objects //
	[Header("Toggling Objects")]
	[Tooltip("the objects to toggle the activity of")]
	public GameObject[] objectsToToggle = new GameObject[] {};		// connections - manual: the objects to toggle the active state of
	[Tooltip("the toggling by which to toggle the objects")]
	public Toggling objectToggling = Toggling.invertToggle;		// setting: the toggling by which to toggle the objects




	// methods //

	
	// method: cast this powerup //
	public override void cast()
		=> objectsToToggle.toggleActivityBy(objectToggling);

	// method: toggle the objects off //
	public void toggleOff()
		=> objectsToToggle.deactivate();

	// method: toggle the objects on //
	public void toggleOn()
		=> objectsToToggle.activate();
}