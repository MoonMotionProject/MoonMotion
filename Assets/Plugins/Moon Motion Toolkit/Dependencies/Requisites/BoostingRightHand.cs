using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Right Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Right Hand")]
public class BoostingRightHand : DependencyRequisite
{
	public override bool state => Booster.rightHandIsBoosting();
}