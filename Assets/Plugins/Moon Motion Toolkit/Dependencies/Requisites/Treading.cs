using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Treading", menuName = "Moon Motion/Dependency Requisites/Treading")]
public class Treading : DependencyRequisite
{
	public override bool state => Treader.treading();
}