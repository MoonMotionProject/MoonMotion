using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Moving Slowly On Y", menuName = "Moon Motion/Dependency Requisites/Moving Slowly On Y")]
public class MovingSlowlyOnYRequisite : DependencyRequisite
{
	public override bool state => PlayerVelocityReader.speedIsSlowOnY;
}