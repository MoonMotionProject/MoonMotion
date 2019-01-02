using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Running In Editor", menuName = "Moon Motion/Dependency Requisites/Running In Editor")]
public class RunningInEditor : DependencyRequisite
{
	// methods //

	
	// method: determine the (boolean) state of this Dependency Requisite //
	public override bool state()
	{
		return Application.isEditor;
	}
}