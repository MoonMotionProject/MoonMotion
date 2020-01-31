using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Never", menuName = "Moon Motion/Dependency Requisites/Never")]
public class NeverRequisite : DependencyRequisite
{
	public override bool state => false;
}