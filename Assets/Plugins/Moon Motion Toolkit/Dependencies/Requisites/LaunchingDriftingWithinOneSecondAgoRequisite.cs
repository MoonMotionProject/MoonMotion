using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Launching Drifting Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Launching Drifting Within One Second Ago")]
public class LaunchingDriftingWithinOneSecondAgoRequisite : DependencyRequisite
{
	public override bool state => LaunchingDriftingTracker.playerLastLaunchingDriftingWithin(1f);
}