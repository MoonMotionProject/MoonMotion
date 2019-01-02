using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Within Nonzeroly Affecting Gravity Zonage Sphere", menuName = "Moon Motion/Dependency Requisites/Within Nonzeroly Affecting Gravity Zonage Sphere")]
public class WithinNonzerolyAffectingGravityZonageSphere : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return GravityZone.playerWithinNonzerolyAffectingZonageSphere();
	}
}