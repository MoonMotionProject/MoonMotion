using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Terrained", menuName = "Moon Motion/Dependency Requisites/Terrained")]
public class Terrained : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return TerrainResponse.terrained();
	}
}