using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collided With Ground", menuName = "Moon Motion/Dependency Requisites/Collided With Ground")]
public class CollidedWithGroundRequisite : DependencyRequisite
{
	public override bool state => TerrainResponse.collidedWithGround();
}