using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skiing Or Sweeping", menuName = "Moon Motion/Dependency Requisites/Skiing Or Sweeping")]
public class SkiingOrSweepingRequisite : DependencyRequisite
{
	public override bool state => Skier.skiing || Sweeping.currentlySweeping;
}