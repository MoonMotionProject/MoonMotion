using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Jumped Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Jumped Within One Second Ago")]
public class JumpedWithinOneSecondAgo : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return JumpingSettings.lastJumpedWithin(1f);
	}
}