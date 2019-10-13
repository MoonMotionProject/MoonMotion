using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Longbow Arrow Hand Either", menuName = "Moon Motion/Dependency Requisites/Longbow Arrow Hand Either")]
public class LongbowArrowHandEitherRequisite : DependencyRequisite
{
	public override bool state => HandHoldingTracker.longbowArrowHandEither();
}