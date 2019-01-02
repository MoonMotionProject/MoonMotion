using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Any Hovered Interactables Either", menuName = "Moon Motion/Dependency Requisites/Any Hovered Interactables Either")]
public class AnyHoveredInteractablesEither : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return HandHoldingTracker.anyHoveredInteractablesEither();
	}
}