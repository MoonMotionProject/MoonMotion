using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Drifting Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Boosting Drifting Within One Second Ago")]
public class BoostingDriftingWithinOneSecondAgo : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return BoostingDriftingTracker.playerLastBoostingDriftingWithin(1f);
	}
}