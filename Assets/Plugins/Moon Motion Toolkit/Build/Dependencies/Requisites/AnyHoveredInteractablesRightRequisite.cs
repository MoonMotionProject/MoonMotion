using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Any Hovered Interactables Right", menuName = "Moon Motion/Dependency Requisites/Any Hovered Interactables Right")]
public class AnyHoveredInteractablesRightRequisite : DependencyRequisite
{
	public override bool state => HandHoldingTracker.anyHoveredInteractablesRight();
}