using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Shallowly Only Both Hands", menuName = "Moon Motion/Dependency Requisites/Boosting Shallowly Only Both Hands")]
public class BoostingShallowlyOnlyBothHands : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Booster.bothHandsAreBoostingShallowlyOnly();
	}
}