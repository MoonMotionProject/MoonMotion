using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WithinAffectingGravityZonage", menuName = "Moon Motion/Dependency Requisites/WithinAffectingGravityZonage")]
public class WithinAffectingGravityZonage : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return GravityZone.playerWithinAffectingZonage();
	}
}