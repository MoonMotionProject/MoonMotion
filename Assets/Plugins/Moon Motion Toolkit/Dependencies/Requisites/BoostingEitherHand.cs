using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Either Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Either Hand")]
public class BoostingEitherHand : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Booster.eitherHandIsBoosting();
	}
}