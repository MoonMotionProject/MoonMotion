using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour: provides this behaviour with typical automatic connections to potentially make //
// #auto
public abstract class	AutomaticBehaviour<AutomaticBehaviourT> :
					AutomaticBehaviourLayerExternalLayer<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	
}