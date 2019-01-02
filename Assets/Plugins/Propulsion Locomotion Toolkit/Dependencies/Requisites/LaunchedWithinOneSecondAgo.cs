using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Launched Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Launched Within One Second Ago")]
public class LaunchedWithinOneSecondAgo : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Launcher.playerLastLaunchedWithin(1f);
	}
}