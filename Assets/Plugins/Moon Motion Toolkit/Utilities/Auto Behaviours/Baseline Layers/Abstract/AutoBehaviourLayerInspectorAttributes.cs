using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Inspector Attributes:
// #auto
// • validates this behaviour according to its auto behaviour inspector attributes
public abstract class	AutoBehaviourLayerInspectorAttributes<AutoBehaviourT> :
					AutoBehaviourLayerCollisionAndForcing<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	// upon validation: //
	public virtual void OnValidate()
	{
		if (inheritorHasAttribute<UnhideComponentInInspectorAttribute>())
		{
			unhideInInspector();
		}
		else if (inheritorHasAttribute<HideComponentInInspectorAttribute>())
		{
			hideInInspector();
		}
	}
}