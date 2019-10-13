using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Within Affecting Gravity Zonage Box", menuName = "Moon Motion/Dependency Requisites/Within Affecting Gravity Zonage Box")]
public class WithinAffectingGravityZonageBoxRequisite : DependencyRequisite
{
	public override bool state => GravityZone.playerWithinAffectingZonageBox();
}