using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Longbow Arrow Hand Left", menuName = "Moon Motion/Dependency Requisites/Longbow Arrow Hand Left")]
public class LongbowArrowHandLeftRequisite : DependencyRequisite
{
	public override bool state => HandHoldingTracker.longbowArrowHandLeft();
}