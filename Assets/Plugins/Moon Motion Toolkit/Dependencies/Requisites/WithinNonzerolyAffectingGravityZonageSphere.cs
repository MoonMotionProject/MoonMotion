using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Within Nonzeroly Affecting Gravity Zonage Sphere", menuName = "Moon Motion/Dependency Requisites/Within Nonzeroly Affecting Gravity Zonage Sphere")]
public class WithinNonzerolyAffectingGravityZonageSphere : DependencyRequisite
{
	public override bool state => GravityZone.playerWithinNonzerolyAffectingZonageSphere();
}