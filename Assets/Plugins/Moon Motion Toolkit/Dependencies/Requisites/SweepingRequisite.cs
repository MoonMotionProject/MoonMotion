using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sweeping", menuName = "Moon Motion/Dependency Requisites/Sweeping")]
public class SweepingRequisite : DependencyRequisite
{
	public override bool state => Sweeping.currentlySweeping;
}