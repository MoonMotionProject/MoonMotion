using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Any Hovered Interactables Left", menuName = "Moon Motion/Dependency Requisites/Any Hovered Interactables Left")]
public class AnyHoveredInteractablesLeftRequisite : DependencyRequisite
{
	public override bool state => HandHoldingTracker.anyHoveredInteractablesLeft();
}