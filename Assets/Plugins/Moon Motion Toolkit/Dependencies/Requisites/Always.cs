using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Always", menuName = "Moon Motion/Dependency Requisites/Always")]
public class Always : DependencyRequisite
{
	public override bool state => true;
}