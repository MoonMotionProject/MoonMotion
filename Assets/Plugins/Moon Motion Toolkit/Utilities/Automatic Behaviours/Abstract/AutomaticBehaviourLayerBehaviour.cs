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
	// methods for: enablement //

	// method: set the enablement of this behaviour to the given boolean, then return this behaviour //
	public AutomaticBehaviourT setBehaviourEnablementTo(bool boolean)
		=> ((AutomaticBehaviourT) this).setEnablementTo<AutomaticBehaviourT>(boolean);

	// method: enable this behaviour, then return it //
	public AutomaticBehaviourT enableBehaviour()
		=> ((AutomaticBehaviourT) this).enable<AutomaticBehaviourT>();

	// method: disable this behaviour, then return it //
	public AutomaticBehaviourT disableBehaviour()
		=> ((AutomaticBehaviourT) this).disable<AutomaticBehaviourT>();
}