using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Longbow Arrow Hand Either", menuName = "Moon Motion/Dependency Requisites/Longbow Arrow Hand Either")]
public class LongbowArrowHandEither : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return HandHoldingTracker.longbowArrowHandEither();
	}
}