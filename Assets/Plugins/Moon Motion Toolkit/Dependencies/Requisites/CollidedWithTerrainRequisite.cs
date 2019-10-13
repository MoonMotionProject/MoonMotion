using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collided With Terrain", menuName = "Moon Motion/Dependency Requisites/Collided With Terrain")]
public class CollidedWithTerrainRequisite : DependencyRequisite
{
	public override bool state => TerrainResponse.collidedWithTerrain();
}