using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WithinAffectingGravityZonage", menuName = "Moon Motion/Dependency Requisites/WithinAffectingGravityZonage")]
public class WithinAffectingGravityZonage : DependencyRequisite
{
	public override bool state => GravityZone.playerWithinAffectingZonage();
}