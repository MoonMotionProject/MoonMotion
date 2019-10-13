using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Terrained", menuName = "Moon Motion/Dependency Requisites/Terrained")]
public class TerrainedRequisite : DependencyRequisite
{
	public override bool state => TerrainResponse.terrained();
}