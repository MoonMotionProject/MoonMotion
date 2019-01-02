using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Moving Slowly", menuName = "Moon Motion/Dependency Requisites/Moving Slowly")]
public class MovingSlowly : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return PlayerVelocityReader.speedIsSlow();
	}
}