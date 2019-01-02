using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Shallowly Only Right Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Shallowly Only Right Hand")]
public class BoostingShallowlyOnlyRightHand : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Booster.rightHandIsBoostingShallowlyOnly();
	}
}