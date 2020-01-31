using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Launched Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Launched Within One Second Ago")]
public class LaunchedWithinOneSecondAgoRequisite : DependencyRequisite
{
	public override bool state => Launcher.playerLastLaunchedWithin(1f);
}