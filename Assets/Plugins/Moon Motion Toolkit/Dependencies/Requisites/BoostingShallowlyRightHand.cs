using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Shallowly Right Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Shallowly Right Hand")]
public class BoostingShallowlyRightHand : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Booster.rightHandIsBoostingShallowly();
	}
}