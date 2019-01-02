using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Shallowly Only Left Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Shallowly Only Left Hand")]
public class BoostingShallowlyOnlyLeftHand : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Booster.leftHandIsBoostingShallowlyOnly();
	}
}