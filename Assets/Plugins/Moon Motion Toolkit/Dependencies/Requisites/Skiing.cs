using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skiing", menuName = "Moon Motion/Dependency Requisites/Skiing")]
public class Skiing : DependencyRequisite
{
	public override bool state => Skier.skiing;
}