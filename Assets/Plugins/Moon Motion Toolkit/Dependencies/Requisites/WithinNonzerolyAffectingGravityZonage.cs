using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Within Nonzeroly Affecting Gravity Zonage", menuName = "Moon Motion/Dependency Requisites/Within Nonzeroly Affecting Gravity Zonage")]
public class WithinNonzerolyAffectingGravityZonage : DependencyRequisite
{
	public override bool state => GravityZone.playerWithinNonzerolyAffectingZonage();
}