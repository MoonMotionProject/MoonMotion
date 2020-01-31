using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scene Faded Within Two Seconds Ago", menuName = "Moon Motion/Dependency Requisites/Scene Faded Within Two Seconds Ago")]
public class SceneFadedWithinTwoSecondsAgoRequisite : DependencyRequisite
{
	public override bool state => UnityIs.playing && ((Time.time - SceneFader.timeOflastSceneFadingCompletion) <= 2f);
}