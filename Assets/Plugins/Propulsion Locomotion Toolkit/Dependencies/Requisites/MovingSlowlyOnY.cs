using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Moving Slowly On Y", menuName = "Moon Motion/Dependency Requisites/Moving Slowly On Y")]
public class MovingSlowlyOnY : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return PlayerVelocityReader.speedIsSlowOnY();
	}
}