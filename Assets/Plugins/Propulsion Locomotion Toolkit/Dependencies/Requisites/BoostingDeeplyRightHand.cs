using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Deeply Right Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Deeply Right Hand")]
public class BoostingDeeplyRightHand : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Booster.rightHandIsBoostingDeeply();
	}
}