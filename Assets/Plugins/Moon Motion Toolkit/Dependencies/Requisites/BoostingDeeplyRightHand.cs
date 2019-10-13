using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Deeply Right Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Deeply Right Hand")]
public class BoostingDeeplyRightHand : DependencyRequisite
{
	public override bool state => Booster.rightHandIsBoostingDeeply();
}