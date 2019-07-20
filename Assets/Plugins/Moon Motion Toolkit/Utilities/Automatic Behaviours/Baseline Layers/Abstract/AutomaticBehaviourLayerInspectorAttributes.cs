using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour Layer Inspector Attributes:
// #auto
// • validates this behaviour according to its automatic behaviour inspector attributes
public abstract class	AutomaticBehaviourLayerInspectorAttributes<AutomaticBehaviourT> :
					AutomaticBehaviourLayerComponentShortcuts<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
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