using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Both Hands", menuName = "Moon Motion/Dependency Requisites/Boosting Both Hands")]
public class BoostingBothHands : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Booster.bothHandsAreBoosting();
	}
}