using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Deeply Both Hands", menuName = "Moon Motion/Dependency Requisites/Boosting Deeply Both Hands")]
public class BoostingDeeplyBothHands : DependencyRequisite
{
	public override bool state => Booster.bothHandsAreBoostingDeeply();
}