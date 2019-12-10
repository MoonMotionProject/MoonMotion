using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using NaughtyAttributes;
#endif

// Sole Behaviour:
// #auto
// • inherits auto behaviour functionality
// • prevents multiple of the same kind of sole behaviour from being added to the same object
[DisallowMultipleComponent]
public abstract class	SoleBehaviour<SoleBehaviourT> :
					AutoBehaviour<SoleBehaviourT>
						where SoleBehaviourT : SoleBehaviour<SoleBehaviourT>
{
	
}