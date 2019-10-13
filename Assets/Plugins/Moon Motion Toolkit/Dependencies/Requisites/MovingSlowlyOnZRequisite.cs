using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Moving Slowly On Z", menuName = "Moon Motion/Dependency Requisites/Moving Slowly On Z")]
public class MovingSlowlyOnZRequisite : DependencyRequisite
{
	public override bool state => PlayerVelocityReader.speedIsSlowOnZ();
}