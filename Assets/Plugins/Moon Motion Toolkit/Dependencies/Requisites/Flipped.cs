using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Flipped", menuName = "Moon Motion/Dependency Requisites/Flipped")]
public class Flipped : DependencyRequisite
{
	public override bool state => Flipper.flipped;
}