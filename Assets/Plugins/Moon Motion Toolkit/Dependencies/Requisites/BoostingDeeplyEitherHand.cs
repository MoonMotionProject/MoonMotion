using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Deeply Either Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Deeply Either Hand")]
public class BoostingDeeplyEitherHand : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Booster.eitherHandIsBoostingDeeply();
	}
}