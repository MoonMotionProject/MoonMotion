using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Attribute Detection:
// #auto
// • provides this singleton behaviour with static access to its auto behaviour's attribute detection layer
public abstract class	SingletonBehaviourLayerAttributeDetection<SingletonBehaviourT> :
					SingletonBehaviourLayerSingleton<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	// method: return whether the inheritor's class has the specified attribute, including inherited attributes according to the given boolean //
	public static new bool inheritorHasAttribute_ViaReflection<AttributeT>(bool includeInheritedAttributes = true)
		where AttributeT : Attribute
		=> autoBehaviour.inheritorHasAttribute_ViaReflection<AttributeT>(includeInheritedAttributes);

	public static new AttributeT firstAttributeOnInheritorOfType_ViaReflection<AttributeT>(bool includeInheritedAttributes = true)
		where AttributeT : Attribute
		=> autoBehaviour.firstAttributeOnInheritorOfType_ViaReflection<AttributeT>(includeInheritedAttributes);
}