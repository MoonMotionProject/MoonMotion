using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Always", menuName = "Moon Motion/Dependency Requisites/Always")]
public class Always : DependencyRequisite
{
	// methods //


	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return true;
	}
}