using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scene Faded Within Two Seconds Ago", menuName = "Moon Motion/Dependency Requisites/Scene Faded Within Two Seconds Ago")]
public class SceneFadedWithinTwoSecondsAgo : DependencyRequisite
{
	public override bool state => (Time.time - SceneFader.timeOflastSceneFadingCompletion) <= 2f;
}