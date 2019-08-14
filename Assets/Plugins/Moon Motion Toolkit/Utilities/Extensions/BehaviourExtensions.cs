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


	#region enablement of the first behaviour of the specified type - and returning the given this

	public static GameObject setEnablementOfFirst<BehaviourT>(this GameObject gameObject, bool enablement) where BehaviourT : Behaviour
		=> gameObject.after(()=>
			gameObject.setEnablementOfFirst<BehaviourT>(enablement));

	public static GameObject enableFirst<BehaviourT>(this GameObject gameObject) where BehaviourT : Behaviour
		=> gameObject.after(()=>
			gameObject.enableFirst<BehaviourT>());

	public static GameObject disableFirst<BehaviourT>(this GameObject gameObject) where BehaviourT : Behaviour
		=> gameObject.after(()=>
			gameObject.disableFirst<BehaviourT>());
	#endregion enablement of the first behaviour of the specified type - and returning the given this


	#region enablement of the first behaviour of the specified type - and returning of that behaviour

	public static BehaviourT setEnablementOfFirstGet<BehaviourT>(this GameObject gameObject, bool enablement) where BehaviourT : Behaviour
		=> gameObject.first<BehaviourT>().setEnablementTo(enablement);
	public static BehaviourT setEnablementOfFirstGet<BehaviourT>(this Component component, bool enablement) where BehaviourT : Behaviour
		=> component.gameObject.setEnablementOfFirstGet<BehaviourT>(enablement);

	public static BehaviourT enableFirstGet<BehaviourT>(this GameObject gameObject) where BehaviourT : Behaviour
		=> gameObject.setEnablementOfFirstGet<BehaviourT>(true);
	public static BehaviourT enableFirstGet<BehaviourT>(this Component component) where BehaviourT : Behaviour
		=> component.gameObject.enableFirstGet<BehaviourT>();

	public static BehaviourT disableFirstGet<BehaviourT>(this GameObject gameObject) where BehaviourT : Behaviour
		=> gameObject.setEnablementOfFirstGet<BehaviourT>(false);
	public static BehaviourT disableFirstGet<BehaviourT>(this Component component) where BehaviourT : Behaviour
		=> component.gameObject.disableFirstGet<BehaviourT>();
	#endregion enablement of the first behaviour of the specified type - and returning of that behaviour
}