using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Jumped Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Jumped Within One Second Ago")]
public class JumpedWithinOneSecondAgo : DependencyRequisite
{
	public override bool state => JumpingSettings.lastJumpedWithin(1f);
}