using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Right Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Right Hand")]
public class BoostingRightHand : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Booster.rightHandIsBoosting();
	}
}