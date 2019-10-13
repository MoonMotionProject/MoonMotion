using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Started Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Started Within One Second Ago")]
public class StartedWithinOneSecondAgo : DependencyRequisite
{
	public override bool state => Time.time <= 1f;
}