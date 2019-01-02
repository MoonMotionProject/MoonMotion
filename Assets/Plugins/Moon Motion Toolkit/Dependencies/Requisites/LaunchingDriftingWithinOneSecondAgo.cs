using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Launching Drifting Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Launching Drifting Within One Second Ago")]
public class LaunchingDriftingWithinOneSecondAgo : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return LaunchingDriftingTracker.playerLastLaunchingDriftingWithin(1f);
	}
}