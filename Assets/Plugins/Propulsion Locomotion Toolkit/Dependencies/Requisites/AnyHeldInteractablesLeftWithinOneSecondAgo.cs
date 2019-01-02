using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Any Held Interactables Left Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Any Held Interactables Left Within One Second Ago")]
public class AnyHeldInteractablesLeftWithinOneSecondAgo : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return HandHoldingTracker.anyHeldInteractablesLeftWithin(1f);
	}
}