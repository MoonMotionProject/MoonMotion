using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour: provides this behaviour with functionality assimilated from previous solutions to implementation goals, especially those solutions in #auto //
// #auto
public abstract class	AutomaticBehaviour<AutomaticBehaviourT> :
					AutomaticBehaviourLayerExternalLayer<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	
}