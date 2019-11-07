using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Validation Attributes:
// #auto
// • validates this behaviour according to its auto behaviour validation attributes
public abstract class	AutoBehaviourLayerValidationAttributes<AutoBehaviourT> :
					AutoBehaviourLayerProcesses<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	// upon validation: //
	public virtual void OnValidate()
	{
		#if UNITY_EDITOR
		if (inheritorHasAttribute<UnhideComponentInInspectorAttribute>())
		{
			unhideInInspector();
		}
		else if (inheritorHasAttribute<HideComponentInInspectorAttribute>())
		{
			hideInInspector();
		}
		
		if (inheritorHasAttribute<UseClassNameForObjectAttribute>())
		{
			setNameToSimpleClassName();
		}
		
		if (inheritorHasAttribute<ExpandSelfAndChildrenIfSelectedAttribute>())
		{
			ExpandSelfAndChildrenIfSelectedGameObjects.include(gameObject);
		}
		#endif
	}
}