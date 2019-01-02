using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Deeply Both Hands", menuName = "Moon Motion/Dependency Requisites/Boosting Deeply Both Hands")]
public class BoostingDeeplyBothHands : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Booster.bothHandsAreBoostingDeeply();
	}
}