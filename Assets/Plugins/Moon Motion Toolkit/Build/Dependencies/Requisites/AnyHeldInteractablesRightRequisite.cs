using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Any Held Interactables Right", menuName = "Moon Motion/Dependency Requisites/Any Held Interactables Right")]
public class AnyHeldInteractablesRightRequisite : DependencyRequisite
{
	public override bool state => HandHoldingTracker.anyHeldInteractablesRight();
}