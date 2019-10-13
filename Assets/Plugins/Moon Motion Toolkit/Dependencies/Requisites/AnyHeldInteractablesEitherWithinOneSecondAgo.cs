using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Any Held Interactables Either Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Any Held Interactables Either Within One Second Ago")]
public class AnyHeldInteractablesEitherWithinOneSecondAgo : DependencyRequisite
{
	public override bool state => HandHoldingTracker.anyHeldInteractablesEitherWithin(1f);
}