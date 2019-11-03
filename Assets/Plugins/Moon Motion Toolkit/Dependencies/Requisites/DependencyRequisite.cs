using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dependency Requisite: a Moon Motion feature (represented as a scriptable object) upon which its state may be depended
public abstract class DependencyRequisite : ResetFixedScriptableObject
{
	// the (boolean) state of this Dependency Requisite, to be overriden by the derived class (false by default) //
	public virtual bool state => false;
}