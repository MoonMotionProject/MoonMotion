using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Shallowly Both Hands", menuName = "Moon Motion/Dependency Requisites/Boosting Shallowly Both Hands")]
public class BoostingShallowlyBothHands : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Booster.bothHandsAreBoostingShallowly();
	}
}