using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Behaviour:
// #auto
// • provides this behaviour with direct access to its extension methods for being a behaviour
public abstract class	AutoBehaviourLayerBehaviour<AutoBehaviourT> :
					AutoBehaviourLayerComponent<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	#region enablement of this behaviour

	// method: set the enablement of this behaviour to the given boolean, then return this behaviour //
	public AutoBehaviourT setEnablementTo(bool enablement)
		=> self.setEnablementTo<AutoBehaviourT>(enablement);

	// method: enable this behaviour, then return it //
	public AutoBehaviourT enable()
		=> self.enable<AutoBehaviourT>();

	// method: disable this behaviour, then return it //
	public AutoBehaviourT disable()
		=> self.disable<AutoBehaviourT>();
	#endregion enablement of this behaviour


	#region enablement of the first behaviour of the specified type - and returning the given this

	// method: set the enablement of the specified behaviour on this given game object to the given boolean, then return the specified behaviour //
	public AutoBehaviourT setEnablementOfFirst<BehaviourT>(bool enablement) where BehaviourT : Behaviour
		=> selfAfter(()=> gameObject.setEnablementOfFirst<BehaviourT>(enablement));

	// method: enable the specified behaviour on this given game object, then return the specified behaviour //
	public AutoBehaviourT enableFirst<BehaviourT>() where BehaviourT : Behaviour
		=> selfAfter(()=> gameObject.enableFirst<BehaviourT>());

	// method: disable the specified behaviour on this given game object, then return the specified behaviour //
	public AutoBehaviourT disableFirst<BehaviourT>() where BehaviourT : Behaviour
		=> selfAfter(()=> gameObject.disableFirst<BehaviourT>());
	#endregion enablement of the first behaviour of the specified type - and returning the given this


	#region enablement of the first behaviour of the specified type - and returning of that behaviour

	public BehaviourT setEnablementOfFirstGet<BehaviourT>(bool enablement) where BehaviourT : Behaviour
		=> gameObject.setEnablementOfFirstGet<BehaviourT>(enablement);

	public BehaviourT enableFirstGet<BehaviourT>() where BehaviourT : Behaviour
		=> gameObject.enableFirstGet<BehaviourT>();

	public BehaviourT disableFirstGet<BehaviourT>() where BehaviourT : Behaviour
		=> gameObject.disableFirstGet<BehaviourT>();
	#endregion enablement of the first behaviour of the specified type - and returning of that behaviour
}