using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Moving Slowly On Z", menuName = "Moon Motion/Dependency Requisites/Moving Slowly On Z")]
public class MovingSlowlyOnZ : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return PlayerVelocityReader.speedIsSlowOnZ();
	}
}