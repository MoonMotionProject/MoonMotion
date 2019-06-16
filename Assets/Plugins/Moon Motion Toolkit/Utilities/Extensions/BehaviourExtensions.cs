using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Behaviour Extensions: provides extension methods for handling behaviours //
public static class BehaviourExtensions
{
	// methods for: enablement //

	// method: set the enablement of this given behaviour to the given boolean, then return this given behaviour //
	public static BehaviourT setEnablementTo<BehaviourT>(this BehaviourT behaviour, bool boolean) where BehaviourT : Behaviour
	{
		behaviour.enabled = boolean;

		return behaviour;
	}

	// method: set the enablement of these given behaviours to the given boolean, then return these given behaviours //
	public static BehaviourT[] setEnablementTo<BehaviourT>(this BehaviourT[] behaviours, bool boolean) where BehaviourT : Behaviour
	{
		behaviours.forEach(behaviour => behaviour.setEnablementTo(boolean));

		return behaviours;
	}
	
	// method: enable this given behaviour, then return it //
	public static BehaviourT enable<BehaviourT>(this BehaviourT behaviour) where BehaviourT : Behaviour
		=> behaviour.setEnablementTo(true);

	// method: enable these given behaviours, then return them //
	public static BehaviourT[] enable<BehaviourT>(this BehaviourT[] behaviours) where BehaviourT : Behaviour
		=> behaviours.setEnablementTo(true);

	// method: disable this given behaviour, then return it //
	public static BehaviourT disable<BehaviourT>(this BehaviourT behaviour) where BehaviourT : Behaviour
		=> behaviour.setEnablementTo(false);

	// method: disable these given mono behaviours, then return them //
	public static BehaviourT[] disable<BehaviourT>(this BehaviourT[] behaviours) where BehaviourT : Behaviour
		=> behaviours.setEnablementTo(false);
}