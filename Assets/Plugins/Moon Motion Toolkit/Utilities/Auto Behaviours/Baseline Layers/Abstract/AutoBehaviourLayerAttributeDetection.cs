using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Attribute Detection:
// #auto
// • provides the inheritor with detection of its class attributes (which are properly inherited, by the way)
public abstract class	AutoBehaviourLayerAttributeDetection<AutoBehaviourT> :
					AutoBehaviourLayerStaticShortcuts<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	// method: return whether the inheritor's class has the specified attribute, including inherited attributes according to the given boolean //
	public bool inheritorHasAttribute<AttributeT>(bool includeInheritedAttributes = true) where AttributeT : Attribute
		=> self.attributed<AutoBehaviourT, AttributeT>(includeInheritedAttributes);
}