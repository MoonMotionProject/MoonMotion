using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Any Held Interactables Left", menuName = "Moon Motion/Dependency Requisites/Any Held Interactables Left")]
public class AnyHeldInteractablesLeft : DependencyRequisite
{
	public override bool state => HandHoldingTracker.anyHeldInteractablesLeft();
}