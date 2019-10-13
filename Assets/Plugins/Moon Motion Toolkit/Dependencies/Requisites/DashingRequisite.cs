using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dashing", menuName = "Moon Motion/Dependency Requisites/Dashing")]
public class DashingRequisite : DependencyRequisite
{
	public override bool state => Dashing.currentlyDashing;
}