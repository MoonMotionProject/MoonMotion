using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Behaviour Extensions: provides extension methods for handling behaviours //
// #auto
public static class BehaviourExtensions
{
	// methods for: enablement of this given behaviour //

	// method: set the enablement of this given behaviour to the given boolean, then return this given behaviour //
	public static BehaviourT setEnablementTo<BehaviourT>(this BehaviourT behaviour, bool enablement) where BehaviourT : Behaviour
		=> behaviour.after(()=>
			behaviour.enabled = enablement);

	// method: enable this given behaviour, then return it //
	public static BehaviourT enable<BehaviourT>(this BehaviourT behaviour) where BehaviourT : Behaviour
		=> behaviour.setEnablementTo(true);

	// method: disable this given behaviour, then return it //
	public static BehaviourT disable<BehaviourT>(this BehaviourT behaviour) where BehaviourT : Behaviour
		=> behaviour.setEnablementTo(false);


	// methods for: enablement of these given behaviours //

	public static BehaviourT[] setEnablementTo<BehaviourT>(this BehaviourT[] behaviours, bool enablement) where BehaviourT : Behaviour
		=> behaviours.forEach(behaviour => behaviour.setEnablementTo(enablement));
	public static List<BehaviourT> setEnablementTo<BehaviourT>(this List<BehaviourT> behaviours, bool enablement) where BehaviourT : Behaviour
		=> behaviours.forEach(behaviour => behaviour.setEnablementTo(enablement));
	
	public static BehaviourT[] enable<BehaviourT>(this BehaviourT[] behaviours) where BehaviourT : Behaviour
		=> behaviours.setEnablementTo(true);
	public static List<BehaviourT> enable<BehaviourT>(this List<BehaviourT> behaviours) where BehaviourT : Behaviour
		=> behaviours.setEnablementTo(true);
	
	public static BehaviourT[] disable<BehaviourT>(this BehaviourT[] behaviours) where BehaviourT : Behaviour
		=> behaviours.setEnablementTo(false);
	public static List<BehaviourT> disable<BehaviourT>(this List<BehaviourT> behaviours) where BehaviourT : Behaviour
		=> behaviours.setEnablementTo(false);


	// methods for: enablement of the first behaviour of the specified type //

	// method: set the enablement of the first behaviour of the specified type on this given game object to the given boolean, then return the specified behaviour //
	public static BehaviourT setEnablementOfFirst<BehaviourT>(this GameObject gameObject, bool enablement) where BehaviourT : Behaviour
		=> gameObject.first<BehaviourT>().setEnablementTo(enablement);

	// method: enable the first behaviour of the specified type on this given game object, then return the specified behaviour //
	public static BehaviourT enableFirst<BehaviourT>(this GameObject gameObject) where BehaviourT : Behaviour
		=> gameObject.setEnablementOfFirst<BehaviourT>(true);

	// method: disable the first behaviour of the specified type on this given game object, then return the specified behaviour //
	public static BehaviourT disableFirst<BehaviourT>(this GameObject gameObject) where BehaviourT : Behaviour
		=> gameObject.setEnablementOfFirst<BehaviourT>(false);

	// method: set the enablement of the first behaviour of the specified type on this given component's game object to the given boolean, then return the specified behaviour //
	public static BehaviourT setEnablementOfFirst<BehaviourT>(this Component component, bool enablement) where BehaviourT : Behaviour
		=> component.gameObject.setEnablementOfFirst<BehaviourT>(enablement);

	// method: enable the first behaviour of the specified type on this given component's game object, then return the specified behaviour //
	public static BehaviourT enableFirst<BehaviourT>(this Component component) where BehaviourT : Behaviour
		=> component.gameObject.enableFirst<BehaviourT>();

	// method: disable the first behaviour of the specified type on this given component's game object, then return the specified behaviour //
	public static BehaviourT disableFirst<BehaviourT>(this Component component) where BehaviourT : Behaviour
		=> component.gameObject.disableFirst<BehaviourT>();
}