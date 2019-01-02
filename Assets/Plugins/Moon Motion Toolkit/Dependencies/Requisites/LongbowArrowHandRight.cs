using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Longbow Arrow Hand Right", menuName = "Moon Motion/Dependency Requisites/Longbow Arrow Hand Right")]
public class LongbowArrowHandRight : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return HandHoldingTracker.longbowArrowHandRight();
	}
}