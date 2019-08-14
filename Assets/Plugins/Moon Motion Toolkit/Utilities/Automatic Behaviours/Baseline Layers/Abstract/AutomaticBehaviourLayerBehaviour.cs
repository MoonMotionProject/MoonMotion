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
	#region enablement of this behaviour

	// method: set the enablement of this behaviour to the given boolean, then return this behaviour //
	public AutomaticBehaviourT setEnablementTo(bool enablement)
		=> automaticBehaviour.setEnablementTo<AutomaticBehaviourT>(enablement);

	// method: enable this behaviour, then return it //
	public AutomaticBehaviourT enable()
		=> automaticBehaviour.enable<AutomaticBehaviourT>();

	// method: disable this behaviour, then return it //
	public AutomaticBehaviourT disable()
		=> automaticBehaviour.disable<AutomaticBehaviourT>();
	#endregion enablement of this behaviour


	#region enablement of the first behaviour of the specified type - and returning the given this

	// method: set the enablement of the specified behaviour on this given game object to the given boolean, then return the specified behaviour //
	public AutomaticBehaviourT setEnablementOfFirst<BehaviourT>(bool enablement) where BehaviourT : Behaviour
		=> selfAfter(()=> gameObject.setEnablementOfFirst<BehaviourT>(enablement));

	// method: enable the specified behaviour on this given game object, then return the specified behaviour //
	public AutomaticBehaviourT enableFirst<BehaviourT>() where BehaviourT : Behaviour
		=> selfAfter(()=> gameObject.enableFirst<BehaviourT>());

	// method: disable the specified behaviour on this given game object, then return the specified behaviour //
	public AutomaticBehaviourT disableFirst<BehaviourT>() where BehaviourT : Behaviour
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