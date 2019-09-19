using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enableds Behaviour: an abstract auto behaviour providing enabled instance tracking functionality for all derived behaviours //
// #auto
public abstract class	EnabledsBehaviour<EnabledsBehaviourT> :
					EnabledsBehaviourLayerComponent<EnabledsBehaviourT>
						where EnabledsBehaviourT : EnabledsBehaviour<EnabledsBehaviourT>
{
	
}