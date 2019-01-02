using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Any Hovered Interactables Left", menuName = "Moon Motion/Dependency Requisites/Any Hovered Interactables Left")]
public class AnyHoveredInteractablesLeft : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return HandHoldingTracker.anyHoveredInteractablesLeft();
	}
}