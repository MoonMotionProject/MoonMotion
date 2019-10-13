using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collided With Terrain", menuName = "Moon Motion/Dependency Requisites/Collided With Terrain")]
public class CollidedWithTerrain : DependencyRequisite
{
	public override bool state => TerrainResponse.collidedWithTerrain();
}