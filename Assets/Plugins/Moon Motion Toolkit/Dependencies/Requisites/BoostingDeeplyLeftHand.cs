using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Deeply Left Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Deeply Left Hand")]
public class BoostingDeeplyLeftHand : DependencyRequisite
{
	public override bool state => Booster.leftHandIsBoostingDeeply();
}