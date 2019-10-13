using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boosting Shallowly Right Hand", menuName = "Moon Motion/Dependency Requisites/Boosting Shallowly Right Hand")]
public class BoostingShallowlyRightHandRequisite : DependencyRequisite
{
	public override bool state => Booster.rightHandIsBoostingShallowly();
}