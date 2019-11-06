using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Behaviour:
// #auto
// • provides this singleton behaviour with static access to its auto behaviour's behaviour layer
public abstract class	SingletonBehaviourLayerBehaviour<SingletonBehaviourT> :
					SingletonBehaviourLayerComponent<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region enablement of this behaviour

	// method: set the enablement of this behaviour to the given boolean, then return this behaviour //
	public static new AutoBehaviour<SingletonBehaviourT> setEnablementTo(bool enablement)
		=> autoBehaviour.setEnablementTo(enablement);

	// method: enable this behaviour, then return it //
	public static new AutoBehaviour<SingletonBehaviourT> enable()
		=> autoBehaviour.enable();

	// method: disable this behaviour, then return it //
	public static new AutoBehaviour<SingletonBehaviourT> disable()
		=> autoBehaviour.disable();
	#endregion enablement of this behaviour
}