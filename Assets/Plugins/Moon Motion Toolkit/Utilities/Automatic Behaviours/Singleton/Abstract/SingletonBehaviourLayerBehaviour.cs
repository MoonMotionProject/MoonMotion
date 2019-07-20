using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Behaviour:
// #auto
// • provides this singleton behaviour with static access to its automatic behaviour's behaviour layer
public abstract class	SingletonBehaviourLayerBehaviour<SingletonBehaviourT> :
					SingletonBehaviourLayerComponent<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	// methods for: enablement of this behaviour //

	// method: set the enablement of this behaviour to the given boolean, then return this behaviour //
	public static new SingletonBehaviourT setEnablementTo(bool enablement)
		=> automaticBehaviour.setEnablementTo(enablement);

	// method: enable this behaviour, then return it //
	public static new SingletonBehaviourT enable()
		=> automaticBehaviour.enable();

	// method: disable this behaviour, then return it //
	public static new SingletonBehaviourT disable()
		=> automaticBehaviour.disable();
}