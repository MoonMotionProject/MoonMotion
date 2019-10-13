using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Drifting Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Boosting Drifting Within One Second Ago")]
public class BoostingDriftingWithinOneSecondAgoRequisite : DependencyRequisite
{
	public override bool state => BoostingDriftingTracker.playerLastBoostingDriftingWithin(1f);
}