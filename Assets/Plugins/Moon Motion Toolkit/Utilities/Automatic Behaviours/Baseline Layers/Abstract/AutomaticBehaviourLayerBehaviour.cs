using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour Layer Behaviour:
// #auto
// • provides this behaviour with direct access to its extension methods for being a behaviour
public abstract class	AutomaticBehaviourLayerBehaviour<AutomaticBehaviourT> :
					AutomaticBehaviourLayerComponent<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	// methods for: enablement of this behaviour //

	// method: set the enablement of this behaviour to the given boolean, then return this behaviour //
	public AutomaticBehaviourT setEnablementTo(bool enablement)
		=> automaticBehaviour.setEnablementTo<AutomaticBehaviourT>(enablement);

	// method: enable this behaviour, then return it //
	public AutomaticBehaviourT enable()
		=> automaticBehaviour.enable<AutomaticBehaviourT>();

	// method: disable this behaviour, then return it //
	public AutomaticBehaviourT disable()
		=> automaticBehaviour.disable<AutomaticBehaviourT>();


	// methods for: enablement of the specified behaviour //

	// method: set the enablement of the specified behaviour on this given game object to the given boolean, then return the specified behaviour //
	public BehaviourT setEnablement<BehaviourT>(bool enablement) where BehaviourT : Behaviour
		=> gameObject.first<BehaviourT>().setEnablementTo(enablement);

	// method: enable the specified behaviour on this given game object, then return the specified behaviour //
	public BehaviourT enable<BehaviourT>() where BehaviourT : Behaviour
		=> gameObject.setEnablement<BehaviourT>(true);

	// method: disable the specified behaviour on this given game object, then return the specified behaviour //
	public BehaviourT disable<BehaviourT>() where BehaviourT : Behaviour
		=> gameObject.setEnablement<BehaviourT>(false);
}