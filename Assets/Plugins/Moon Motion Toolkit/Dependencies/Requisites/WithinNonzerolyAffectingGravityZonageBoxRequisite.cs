using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Within Nonzeroly Affecting Gravity Zonage Box", menuName = "Moon Motion/Dependency Requisites/Within Nonzeroly Affecting Gravity Zonage Box")]
public class WithinNonzerolyAffectingGravityZonageBoxRequisite : DependencyRequisite
{
	public override bool state => GravityZone.playerWithinNonzerolyAffectingZonageBox();
}