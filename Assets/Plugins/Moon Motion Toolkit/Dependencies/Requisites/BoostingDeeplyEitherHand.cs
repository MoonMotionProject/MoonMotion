using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Deeply Either Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Deeply Either Hand")]
public class BoostingDeeplyEitherHand : DependencyRequisite
{
	public override bool state => Booster.eitherHandIsBoostingDeeply();
}