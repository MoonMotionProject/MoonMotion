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
	#region enablement of this behaviour

	// method: set the enablement of this behaviour to the given boolean, then return this behaviour //
	public static new AutomaticBehaviour<SingletonBehaviourT> setEnablementTo(bool enablement)
		=> automaticBehaviour.setEnablementTo(enablement);

	// method: enable this behaviour, then return it //
	public static new AutomaticBehaviour<SingletonBehaviourT> enable()
		=> automaticBehaviour.enable();

	// method: disable this behaviour, then return it //
	public static new AutomaticBehaviour<SingletonBehaviourT> disable()
		=> automaticBehaviour.disable();
	#endregion enablement of this behaviour
}