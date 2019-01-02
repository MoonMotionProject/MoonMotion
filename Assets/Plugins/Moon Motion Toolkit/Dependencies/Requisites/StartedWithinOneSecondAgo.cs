using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Started Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Started Within One Second Ago")]
public class StartedWithinOneSecondAgo : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return (Time.time <= 1f);
	}
}