using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Running In Editor", menuName = "Moon Motion/Dependency Requisites/Running In Editor")]
public class RunningInEditor : DependencyRequisite
{
	public override bool state => UnityIs.inEditor;
}