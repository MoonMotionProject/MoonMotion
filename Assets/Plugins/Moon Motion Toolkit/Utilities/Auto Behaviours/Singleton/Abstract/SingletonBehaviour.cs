using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton: an abstract singleton behaviour providing singleton features for all derived behaviours //
// #auto
public abstract class	SingletonBehaviour<SingletonBehaviourT> :
					SingletonBehaviourLayerCollisionAndForcing<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	
}