using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Moving Slowly On X", menuName = "Moon Motion/Dependency Requisites/Moving Slowly On X")]
public class MovingSlowlyOnX : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return PlayerVelocityReader.speedIsSlowOnX();
	}
}