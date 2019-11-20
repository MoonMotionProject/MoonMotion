using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Validation Attributes:
// #auto #attributes #validation
// • validates this behaviour according to its auto behaviour validation attributes
public abstract class	AutoBehaviourLayerValidationAttributes<AutoBehaviourT> :
					AutoBehaviourLayerProcesses<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	// upon validation: //
	public virtual void OnValidate()
	{
		#if UNITY_EDITOR
		if (inheritorHasAttribute_ViaReflection<UnhideComponentInInspectorAttribute>())
		{
			unhideInInspector();
		}
		else if (inheritorHasAttribute_ViaReflection<HideComponentInInspectorAttribute>())
		{
			hideInInspector();
		}
		
		if (isNotPartOfPrefabAsset)
		{
			if (inheritorHasAttribute_ViaReflection<UseClassNameForObjectUponValidationAttribute>())
			{
				setNameToSpacedSimpleClassName_ViaReflection();
			}
		
			if (inheritorHasAttribute_ViaReflection<ExpandSelfIfSelectedAttribute>())
			{
				ExpandSelfIfSelectedGameObjects.include(gameObject);
			}

			if (inheritorHasAttribute_ViaReflection<ExpandSelfAndChildrenUponValidationAttribute>())
			{
				Execute.atNextCheck_IfInEditor(()=>
					expandSelfAndChildrenInHierarchy(),
					false);
			}
		
			if (inheritorHasAttribute_ViaReflection<ExpandSelfAndChildrenIfSelectedAttribute>())
			{
				ExpandSelfAndChildrenIfSelectedGameObjects.include(gameObject);
			}
		}

		if (inheritorHasAttribute_ViaReflection<ErrorInEditorIfNotSolitarilyLodalToCorrespondingAttribute>())
		{
			Type correspondingType_ViaReflection
				=	firstAttributeOnInheritorOfType_ViaReflection<ErrorInEditorIfNotSolitarilyLodalToCorrespondingAttribute>()
						.correspondingType;
			if (hasNoCoral_ViaReflection(correspondingType_ViaReflection))
			{
				string correspondingTypeSpacedSimpleClassName_ViaReflection
					= correspondingType_ViaReflection.spacedSimpleClassName_ViaReflection();
				logError("has no corresponding "+correspondingTypeSpacedSimpleClassName_ViaReflection+" (which is not intended since "+spacedSimpleClassName_ViaReflection+" is intended to be (solitarily) lodal to a corresponding "+correspondingTypeSpacedSimpleClassName_ViaReflection+")");
			}
			else if (self != corresponding_ViaReflection(correspondingType_ViaReflection).lodesponding<AutoBehaviourT>())
			{
				string correspondingTypeSpacedSimpleClassName_ViaReflection
					= correspondingType_ViaReflection.spacedSimpleClassName_ViaReflection();
				logError("is not the lodesponding "+spacedSimpleClassName_ViaReflection+" of its corresponding "+correspondingTypeSpacedSimpleClassName_ViaReflection+" (which is not intended since "+spacedSimpleClassName_ViaReflection+" is intended to be solitarily lodal to its corresponding "+correspondingTypeSpacedSimpleClassName_ViaReflection+")");
			}
		}
		#endif
	}
}