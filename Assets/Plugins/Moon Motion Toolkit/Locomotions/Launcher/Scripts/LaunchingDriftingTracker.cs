using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Launching Drifting Tracker
// • tracks launching drifting – whether the player's current speed is currently a result, at least in part, of launching
//   · does this by extension of Player Dependency Tracker
//   · by default, the following dependencies are used for tracking launching drifting:
//     - whenever the player is not moving slowly (per Player Velocity Reader) and is launching, this is tracked as true
//     - whenever the player is moving slowly (per Player Velocity Reader) or is treading, this is tracked as false
// • provides methods for determining whether:
//   · the player is currently launching drifting
//   · the player was last launching drifting within a given time ago
// • provides tracking for the time the player was last launching drifting
public class LaunchingDriftingTracker : PlayerDependencyTracker<LaunchingDriftingTracker>
{
	// variables //

	
	// trackings //

	[Tooltip("the time the player was last launching drifting – initialized to negative infinity as a flag that the player has never been launching drifting")]
	[ShowNonSerializedField]
	public static float timePlayerWasLastLaunchingDrifting = -Mathf.Infinity;



	
	// methods //


	// method: determine whether the player is currently launching drifting //
	public static bool launchingDrifting()
		=> singleton.requisiteState;

	// method: determine whether the player was last launching drifting within the given time ago //
	public static bool playerLastLaunchingDriftingWithin(float timeAgo)
		=> timeSince(timePlayerWasLastLaunchingDrifting) <= timeAgo;




	// updating //


	// at each update: //
	protected override void Update()
	{
		base.Update();

		// if the player is currently launching drifting: //
		if (launchingDrifting())
		{
			// track the current time as the last time that the player was launching drifting //
			timePlayerWasLastLaunchingDrifting = time;
		}
	}
}