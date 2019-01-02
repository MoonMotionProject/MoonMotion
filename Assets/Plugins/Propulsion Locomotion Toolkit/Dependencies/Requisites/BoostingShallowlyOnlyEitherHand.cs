using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Shallowly Only Either Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Shallowly Only Either Hand")]
public class BoostingShallowlyOnlyEitherHand : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Booster.eitherHandIsBoostingShallowlyOnly();
	}
}