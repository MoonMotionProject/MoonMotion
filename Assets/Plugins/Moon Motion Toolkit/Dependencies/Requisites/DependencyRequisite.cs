using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dependency Requisite: a Moon Motion feature (represented as a scriptable object) upon which its state may be depended
public abstract class DependencyRequisite : ScriptableObject
{
	// methods //


	// method: determine the (boolean) state of this Dependency Requisite //
	public abstract bool state();
}