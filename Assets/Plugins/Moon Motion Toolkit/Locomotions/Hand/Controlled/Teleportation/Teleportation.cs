using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Teleportation
// • provides a means of toggling whether the teleportation hand locomotion is enabled (in general, not handwise), according also to a dependencies combination setting
//   · because the 'Teleport' script (which is of the Steam Virtuality plugin's Interaction System, and which is also attached to this object) must be running at the start of each scene to set things up, its (this) object is simply kept enabled at all times, which is why the boolean is provided here instead, to be checked by Teleport
//   · for handwise enablement, that is checked when attempting to teleport (inside of that process in 'Teleport') – this is done by checking which of the Teleporter hand locomotions are enabled
//   · for further understanding of the organization of the teleportation locomotion, see Teleporter
public class Teleportation : MonoBehaviour
{
	// variables //

		
	// variables for: instancing //
	private static Teleportation singleton;		// connection - automatic: the singleton instance of this class
	
	// variables for: locomotion cycling //
	[Header("Locomotion Cycling (tracked instead of actually enabled\\disabled)")]
	public bool locomotionEnabled = true;		// tracking: whether this teleportation locomotion is enabled currently

	// setting: the combination of dependencies by which to condition whether teleportation is allowed //
	public Dependencies.DependenciesCombination dependencies;
	
	
	
	
	// methods //

	
	// method: determine whether the teleportation locomotion is enabled currently //
	public bool enabledLocomotion_()
	{
		return (locomotionEnabled && Dependencies.metFor(dependencies));
	}
	// method: determine whether the teleportation locomotion is enabled currently //
	public static bool enabledLocomotion()
	{
		return (singleton && singleton.enabledLocomotion_());
	}




	// updating //


	// before the start: //
	private void Awake()
	{
		// connect to the singleton instance of this class //
		singleton = this;
	}
}