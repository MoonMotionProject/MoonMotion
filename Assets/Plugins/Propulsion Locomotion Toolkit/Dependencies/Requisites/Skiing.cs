using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skiing", menuName = "Moon Motion/Dependency Requisites/Skiing")]
public class Skiing : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Skier.skiing;
	}
}