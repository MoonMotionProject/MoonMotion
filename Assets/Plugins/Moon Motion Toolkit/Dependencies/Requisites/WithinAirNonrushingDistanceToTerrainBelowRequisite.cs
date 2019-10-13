using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Within Air Nonrushing Distance To Terrain Below", menuName = "Moon Motion/Dependency Requisites/Within Air Nonrushing Distance To Terrain Below")]
public class WithinAirNonrushingDistanceToTerrainBelowRequisite : DependencyRequisite
{
	public override bool state => TerrainResponse.withinAirNonrushingDistanceToTerrainBelow();
}