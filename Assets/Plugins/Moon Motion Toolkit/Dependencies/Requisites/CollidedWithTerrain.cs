using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collided With Terrain", menuName = "Moon Motion/Dependency Requisites/Collided With Terrain")]
public class CollidedWithTerrain : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return TerrainResponse.collidedWithTerrain();
	}
}