using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour Layer Attribute Detection:
// #auto
// • provides the inheritor with detection of its class attributes (which are properly inherited, by the way)
public abstract class	AutomaticBehaviourLayerAttributeDetection<AutomaticBehaviourT> :
					AutomaticBehaviourLayerCachedComponents<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	// method: determine whether the inheritor's class has the specified attribute //
	public bool inheritorHasAttribute<AttributeT>() where AttributeT : Attribute
		=> Attribute.IsDefined(typeof(AutomaticBehaviourT), typeof(AttributeT));
}