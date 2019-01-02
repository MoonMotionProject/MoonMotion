using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Flipped", menuName = "Moon Motion/Dependency Requisites/Flipped")]
public class Flipped : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Flipper.flipped;
	}
}