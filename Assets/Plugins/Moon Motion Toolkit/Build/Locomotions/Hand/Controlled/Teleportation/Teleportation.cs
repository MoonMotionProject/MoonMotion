using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Teleportation
// • provides a means of toggling whether the teleportation hand locomotion is enabled (in general, not handwise), according also to a dependencies setting
//   · because the 'Teleport' script (which is of the Steam Virtuality plugin's Interaction System, and which is also attached to this object) must be running at the start of each scene to set things up, its (this) object is simply kept enabled at all times, which is why the boolean is provided here instead, to be checked by Teleport
//   · for handwise enablement, that is checked when attempting to teleport (inside of that process in 'Teleport') – this is done by checking which of the Teleporter hand locomotions are enabled
//   · for further understanding of the organization of the teleportation locomotion, see Teleporter
public class Teleportation : SingletonBehaviour<Teleportation>
{
	// variables //

	
	// variables for: locomotion cycling //
	[BoxGroup("Locomotion Cycling (tracked instead of actually enabled\\disabled)")]
	public bool locomotionEnabled = true;       // tracking: whether this teleportation locomotion is enabled currently

	// setting: the dependencies by which to condition whether teleportation is allowed //
	[BoxGroup("Allowance")]
	[ReorderableList]
	public Dependency[] dependencies;
	
	
	
	
	// methods //

	
	// method: determine whether the teleportation locomotion is enabled currently //
	public bool enabledLocomotion_()
		=> (locomotionEnabled && dependencies.areMet());

	// method: determine whether the teleportation locomotion is enabled currently //
	public static bool enabledLocomotion()
		=> (singleton && singleton.enabledLocomotion_());
}