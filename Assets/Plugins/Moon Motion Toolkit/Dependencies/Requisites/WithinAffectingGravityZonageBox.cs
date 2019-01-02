using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Within Affecting Gravity Zonage Box", menuName = "Moon Motion/Dependency Requisites/Within Affecting Gravity Zonage Box")]
public class WithinAffectingGravityZonageBox : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return GravityZone.playerWithinAffectingZonageBox();
	}
}