using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Drifting Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Drifting Within One Second Ago")]
public class DriftingWithinOneSecondAgo : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return (BoostingDriftingTracker.playerLastBoostingDriftingWithin(1f) || LaunchingDriftingTracker.playerLastLaunchingDriftingWithin(1f));
	}
}