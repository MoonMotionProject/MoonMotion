using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Any Held Interactables Right", menuName = "Moon Motion/Dependency Requisites/Any Held Interactables Right")]
public class AnyHeldInteractablesRight : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return HandHoldingTracker.anyHeldInteractablesRight();
	}
}