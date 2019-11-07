using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

// Auto Behaviour Layer Validation Attributes:
// #auto
// • validates this behaviour according to its auto behaviour validation attributes
public abstract class	AutoBehaviourLayerValidationAttributes<AutoBehaviourT> :
					AutoBehaviourLayerProcesses<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	private static bool expandSelfAndChildrenIfSelected_injectedIntoEditorEventYet = false;

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
			if (!expandSelfAndChildrenIfSelected_injectedIntoEditorEventYet)
			{
				Selection.selectionChanged += ()=>
				{
					if (exists && UnityIs.inEditorEditMode && isSelected)
					{
						expand();
						childObjects.expandEach();
					}
				};

				expandSelfAndChildrenIfSelected_injectedIntoEditorEventYet = true;
			}
		}
		#endif
	}
}