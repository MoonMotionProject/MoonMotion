using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour Layer External Layer:
// #auto
// • has this behaviour require the automatic behaviour external layer component
[RequireComponent(typeof(AutomaticBehaviourExternalLayer))]
public abstract class	AutomaticBehaviourLayerExternalLayer<AutomaticBehaviourT> :
					AutomaticBehaviourLayerInspectorAttributes<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	
}