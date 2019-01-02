using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Moving Slowly Or Moving Slowly On Y", menuName = "Moon Motion/Dependency Requisites/MovingSlowlyOrMovingSlowlyOnY")]
public class MovingSlowlyOrMovingSlowlyOnY : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return (PlayerVelocityReader.speedIsSlow() || PlayerVelocityReader.speedIsSlowOnY());
	}
}