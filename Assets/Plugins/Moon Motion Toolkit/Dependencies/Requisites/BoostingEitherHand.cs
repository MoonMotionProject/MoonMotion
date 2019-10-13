using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Either Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Either Hand")]
public class BoostingEitherHand : DependencyRequisite
{
	public override bool state => Booster.eitherHandIsBoosting();
}