using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Any Held Interactables Left Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Any Held Interactables Left Within One Second Ago")]
public class AnyHeldInteractablesLeftWithinOneSecondAgo : DependencyRequisite
{
	public override bool state => HandHoldingTracker.anyHeldInteractablesLeftWithin(1f);
}