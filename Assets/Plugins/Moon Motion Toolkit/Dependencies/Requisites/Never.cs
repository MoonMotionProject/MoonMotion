using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Never", menuName = "Moon Motion/Dependency Requisites/Never")]
public class Never : DependencyRequisite
{
	public override bool state => false;
}