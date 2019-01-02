using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Treading", menuName = "Moon Motion/Dependency Requisites/Treading")]
public class Treading : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Treader.treading();
	}
}