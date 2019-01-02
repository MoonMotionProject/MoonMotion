using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Any Held Interactables Either", menuName = "Moon Motion/Dependency Requisites/Any Held Interactables Either")]
public class AnyHeldInteractablesEither : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return HandHoldingTracker.anyHeldInteractablesEither();
	}
}