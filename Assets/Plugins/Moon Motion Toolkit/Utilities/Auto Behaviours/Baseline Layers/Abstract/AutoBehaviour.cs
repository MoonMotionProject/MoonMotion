using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour: provides this behaviour with functionality assimilated from previous solutions to implementation goals, especially those solutions in #auto //
// #auto
public abstract class	AutoBehaviour<AutoBehaviourT> :
					AutoBehaviourLayerExternalLayer<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	
}