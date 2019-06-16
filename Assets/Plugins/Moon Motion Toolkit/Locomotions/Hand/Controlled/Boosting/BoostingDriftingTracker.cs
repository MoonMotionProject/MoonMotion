using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Boosting Drifting Tracker
// • tracks boosting drifting – whether the player's current speed is currently a result, at least in part, of boosting
//   · does this by extension of Player Dependency Tracker
//   · by default, the following dependencies are used for tracking boosting drifting:
//     - whenever the player is not moving slowly (per Player Velocity Reader) and is boosting, this is tracked as true
//     - whenever the player is moving slowly (per Player Velocity Reader) or is treading, this is tracked as false
// • provides methods for determining whether:
//   · the player is currently boosting drifting
//   · the player was last boosting drifting within a given time ago
// • provides tracking for the time the player was last boosting drifting
public class BoostingDriftingTracker : PlayerDependencyTracker<BoostingDriftingTracker>
{
	// variables //

	
	// trackings //
	[Tooltip("the time the player was last boosting drifting – initialized to negative infinity as a flag that the player has never been boosting drifting")]
	[ShowNonSerializedField]
	public static float timePlayerWasLastBoostingDrifting = -Mathf.Infinity;



	
	// methods //


	// method: determine whether the player is currently boosting drifting //
	public static bool boostingDrifting()
		=> singleton.requisiteState;

	// method: determine whether the player was last boosting drifting within the given time ago //
	public static bool playerLastBoostingDriftingWithin(float timeAgo)
		=> timeSince(timePlayerWasLastBoostingDrifting) <= timeAgo;




	// updating //


	// at each update: //
	protected override void Update()
	{
		base.Update();

		// if the player is currently boosting drifting: //
		if (boostingDrifting())
		{
			// track the current time as the last time that the player was boosting drifting //
			timePlayerWasLastBoostingDrifting = time;
		}
	}
}