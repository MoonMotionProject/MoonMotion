using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Behaviour Extensions: provides extension methods for handling behaviours //
// #auto
public static class BehaviourExtensions
{
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