using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Both Hands", menuName = "Moon Motion/Dependency Requisites/Boosting Both Hands")]
public class BoostingBothHandsRequisite : DependencyRequisite
{
	public override bool state => Booster.bothHandsAreBoosting();
}