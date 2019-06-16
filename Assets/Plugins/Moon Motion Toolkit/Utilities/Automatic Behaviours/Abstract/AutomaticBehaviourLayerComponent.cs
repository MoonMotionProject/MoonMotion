using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour Layer Component:
// #auto
// • provides this behaviour with direct access to its extension methods for being a component
public abstract class	AutomaticBehaviourLayerComponent<AutomaticBehaviourT> :
					AutomaticBehaviourLayerTransform<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	// methods for: destruction //
	
	// method: destroy this component //
	public void destroy()
		=> ((Component) this).destroy();
}