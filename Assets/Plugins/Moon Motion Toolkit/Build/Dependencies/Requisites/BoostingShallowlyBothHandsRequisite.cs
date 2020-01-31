using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Shallowly Both Hands", menuName = "Moon Motion/Dependency Requisites/Boosting Shallowly Both Hands")]
public class BoostingShallowlyBothHandsRequisite : DependencyRequisite
{
	public override bool state => Booster.bothHandsAreBoostingShallowly();
}