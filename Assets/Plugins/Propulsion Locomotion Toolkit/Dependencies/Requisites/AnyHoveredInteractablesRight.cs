using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Any Hovered Interactables Right", menuName = "Moon Motion/Dependency Requisites/Any Hovered Interactables Right")]
public class AnyHoveredInteractablesRight : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return HandHoldingTracker.anyHoveredInteractablesRight();
	}
}