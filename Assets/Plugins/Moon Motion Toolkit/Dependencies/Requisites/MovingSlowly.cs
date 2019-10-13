using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Moving Slowly", menuName = "Moon Motion/Dependency Requisites/Moving Slowly")]
public class MovingSlowly : DependencyRequisite
{
	public override bool state => PlayerVelocityReader.speedIsSlow();
}