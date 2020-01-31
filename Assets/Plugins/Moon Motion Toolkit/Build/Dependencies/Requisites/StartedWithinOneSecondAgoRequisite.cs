using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Started Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Started Within One Second Ago")]
public class StartedWithinOneSecondAgoRequisite : DependencyRequisite
{
	public override bool state => UnityIs.playing && (Time.time <= 1f);
}