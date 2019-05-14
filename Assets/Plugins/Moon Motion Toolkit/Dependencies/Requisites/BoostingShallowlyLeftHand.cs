using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Shallowly Left Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Shallowly Left Hand")]
public class BoostingShallowlyLeftHand : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Booster.leftHandIsBoostingShallowly();
	}
}