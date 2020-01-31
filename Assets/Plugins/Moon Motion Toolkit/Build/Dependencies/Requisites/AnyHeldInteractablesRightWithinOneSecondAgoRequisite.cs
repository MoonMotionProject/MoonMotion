using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Any Held Interactables Right Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Any Held Interactables Right Within One Second Ago")]
public class AnyHeldInteractablesRightWithinOneSecondAgoRequisite : DependencyRequisite
{
	public override bool state => HandHoldingTracker.anyHeldInteractablesRightWithin(1f);
}