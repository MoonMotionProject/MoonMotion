using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Left Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Left Hand")]
public class BoostingLeftHand : DependencyRequisite
{
	public override bool state => Booster.leftHandIsBoosting();
}