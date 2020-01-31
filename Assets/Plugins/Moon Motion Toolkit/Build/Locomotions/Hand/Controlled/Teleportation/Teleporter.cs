using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Teleporter
// • classifies this hand locomotion as the "teleportation" locomotion
// • all this script does is provide instancing references by which Teleport can determine which hands' teleporters are active (referencing the activity of this teleporter as well as whether its locomotion dependencies are met)
// • teleportation is unique from the usual hand locomotions in that most of its functionality resides outside of the hands, in the massive Teleport script derivative of the Steam Virtuality plugin's Interaction System
//   - the Teleport script is a customization from the Interaction System as detailed by 'Custom Changes.txt' (found in the Steam Virtuality plugin)
//   - that script handling input is why an input setting is not provided for this hand locomotion (to avoid making more changes to the Teleport script)
// • another script, Teleportation, provides control over whether teleportation is allowed in general
// • the Player's child object, 'Teleportation', has both the Teleport script and the Teleportation script on it; these are the only other scripts involved with the teleportation locomotion
public class Teleporter : HandLocomotion
{
	// variables //

	
	// variables for: instancing //
	public static Teleporter left, right;		// connections - auto: the left and right instances of this class




	// updating //

	
	// before the start: //
	protected override void Awake()
	{
		base.Awake();

		// connect to the left and right instances of this class //
		if (leftInstance)
		{
			left = this;
		}
		else
		{
			right = this;
		}
	}
}