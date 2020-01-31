using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Any Hovered Interactables Either", menuName = "Moon Motion/Dependency Requisites/Any Hovered Interactables Either")]
public class AnyHoveredInteractablesEitherRequisite : DependencyRequisite
{
	public override bool state => HandHoldingTracker.anyHoveredInteractablesEither();
}