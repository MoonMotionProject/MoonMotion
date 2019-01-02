using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Longbow Arrow Hand Left", menuName = "Moon Motion/Dependency Requisites/Longbow Arrow Hand Left")]
public class LongbowArrowHandLeft : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return HandHoldingTracker.longbowArrowHandLeft();
	}
}