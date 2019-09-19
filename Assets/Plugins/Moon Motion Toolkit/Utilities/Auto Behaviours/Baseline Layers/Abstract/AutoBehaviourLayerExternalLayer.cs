using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer External Layer:
// #auto
// • has this behaviour require the auto behaviour external layer component
[RequireComponent(typeof(AutoBehaviourExternalLayer))]
public abstract class	AutoBehaviourLayerExternalLayer<AutoBehaviourT> :
					AutoBehaviourLayerInspectorAttributes<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	
}