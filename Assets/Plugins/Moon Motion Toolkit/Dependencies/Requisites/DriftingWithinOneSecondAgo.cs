using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Drifting Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Drifting Within One Second Ago")]
public class DriftingWithinOneSecondAgo : DependencyRequisite
{
	public override bool state => BoostingDriftingTracker.playerLastBoostingDriftingWithin(1f) || LaunchingDriftingTracker.playerLastLaunchingDriftingWithin(1f);
}