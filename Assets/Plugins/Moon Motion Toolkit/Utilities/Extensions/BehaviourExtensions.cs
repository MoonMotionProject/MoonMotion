using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Behaviour Extensions: provides extension methods for handling behaviours //
// #auto
public static class BehaviourExtensions
{
	// methods for: enablement of this behaviour //

	// method: set the enablement of this given behaviour to the given boolean, then return this given behaviour //
	public static BehaviourT setEnablementTo<BehaviourT>(this BehaviourT behaviour, bool enablement) where BehaviourT : Behaviour
		=> behaviour.after(()=>
			behaviour.enabled = enablement);

	// method: set the enablement of these given behaviours to the given boolean, then return these given behaviours //
	public static BehaviourT[] setEnablementTo<BehaviourT>(this BehaviourT[] behaviours, bool enablement) where BehaviourT : Behaviour
		=> behaviours.forEach(behaviour => behaviour.setEnablementTo(enablement));

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


	// methods for: enablement of the specified behaviour //

	// method: set the enablement of the specified behaviour on this given game object to the given boolean, then return the specified behaviour //
	public static BehaviourT setEnablement<BehaviourT>(this GameObject gameObject, bool enablement) where BehaviourT : Behaviour
		=> gameObject.first<BehaviourT>().setEnablementTo(enablement);

	// method: enable the specified behaviour on this given game object, then return the specified behaviour //
	public static BehaviourT enable<BehaviourT>(this GameObject gameObject) where BehaviourT : Behaviour
		=> gameObject.setEnablement<BehaviourT>(true);

	// method: disable the specified behaviour on this given game object, then return the specified behaviour //
	public static BehaviourT disable<BehaviourT>(this GameObject gameObject) where BehaviourT : Behaviour
		=> gameObject.setEnablement<BehaviourT>(false);

	// method: set the enablement of the specified behaviour on this given component's game object to the given boolean, then return the specified behaviour //
	public static BehaviourT setEnablement<BehaviourT>(this Component component, bool enablement) where BehaviourT : Behaviour
		=> component.gameObject.setEnablement<BehaviourT>(enablement);

	// method: enable the specified behaviour on this given component's game object, then return the specified behaviour //
	public static BehaviourT enable<BehaviourT>(this Component component) where BehaviourT : Behaviour
		=> component.gameObject.enable<BehaviourT>();

	// method: disable the specified behaviour on this given component's game object, then return the specified behaviour //
	public static BehaviourT disable<BehaviourT>(this Component component) where BehaviourT : Behaviour
		=> component.gameObject.disable<BehaviourT>();
}