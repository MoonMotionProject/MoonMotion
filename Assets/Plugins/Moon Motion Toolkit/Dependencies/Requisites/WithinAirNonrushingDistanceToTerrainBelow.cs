using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Within Air Nonrushing Distance To Terrain Below", menuName = "Moon Motion/Dependency Requisites/Within Air Nonrushing Distance To Terrain Below")]
public class WithinAirNonrushingDistanceToTerrainBelow : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return TerrainResponse.withinAirNonrushingDistanceToTerrainBelow();
	}
}