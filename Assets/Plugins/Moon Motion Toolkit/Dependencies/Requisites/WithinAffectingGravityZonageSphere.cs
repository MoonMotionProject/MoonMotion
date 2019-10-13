using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Within Affecting Gravity Zonage Sphere", menuName = "Moon Motion/Dependency Requisites/Within Affecting Gravity Zonage Sphere")]
public class WithinAffectingGravityZonageSphere : DependencyRequisite
{
	public override bool state => GravityZone.playerWithinAffectingZonageSphere();
}