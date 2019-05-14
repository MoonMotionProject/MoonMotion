using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Shallowly Either Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Shallowly Either Hand")]
public class BoostingShallowlyEitherHand : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Booster.eitherHandIsBoostingShallowly();
	}
}