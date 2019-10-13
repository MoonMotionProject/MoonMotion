using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Shallowly Either Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Shallowly Either Hand")]
public class BoostingShallowlyEitherHand : DependencyRequisite
{
	public override bool state => Booster.eitherHandIsBoostingShallowly();
}