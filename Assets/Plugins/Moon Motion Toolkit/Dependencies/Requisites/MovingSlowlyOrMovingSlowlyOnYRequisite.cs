using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Moving Slowly Or Moving Slowly On Y", menuName = "Moon Motion/Dependency Requisites/MovingSlowlyOrMovingSlowlyOnY")]
public class MovingSlowlyOrMovingSlowlyOnYRequisite : DependencyRequisite
{
	public override bool state => PlayerVelocityReader.speedIsSlow() || PlayerVelocityReader.speedIsSlowOnY();
}