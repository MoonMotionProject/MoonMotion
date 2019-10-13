using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Shallowly Left Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Shallowly Left Hand")]
public class BoostingShallowlyLeftHand : DependencyRequisite
{
	public override bool state => Booster.leftHandIsBoostingShallowly();
}