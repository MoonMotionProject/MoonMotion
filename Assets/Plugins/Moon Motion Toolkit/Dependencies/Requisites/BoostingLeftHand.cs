using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Left Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Left Hand")]
public class BoostingLeftHand : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Booster.leftHandIsBoosting();
	}
}