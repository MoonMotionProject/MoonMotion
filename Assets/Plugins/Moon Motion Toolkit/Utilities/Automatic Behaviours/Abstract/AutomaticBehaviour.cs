using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour: provides this behaviour with common automatic connections to potentially make //
// #auto
public abstract class	AutomaticBehaviour<AutomaticBehaviourT> :
					AutomaticBehaviourLayerAttributedTrackings<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	
}