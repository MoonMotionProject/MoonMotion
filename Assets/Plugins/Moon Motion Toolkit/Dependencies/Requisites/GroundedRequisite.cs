using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Grounded", menuName = "Moon Motion/Dependency Requisites/Grounded")]
public class GroundedRequisite : DependencyRequisite
{
	public override bool state => TerrainResponse.grounded();
}