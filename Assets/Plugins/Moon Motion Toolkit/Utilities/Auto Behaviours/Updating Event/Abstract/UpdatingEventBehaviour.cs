#if ODIN_INSPECTOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Updating Event Behaviour:
// • an abstract auto behaviour providing a set Better Event and a method to invoke it, which is to be called by a particular updating event that the derived class is for  //
public abstract class	UpdatingEventBehaviour<UpdatingEventBehaviourT> :
					AutoBehaviour<UpdatingEventBehaviourT>
						where UpdatingEventBehaviourT : AutoBehaviour<UpdatingEventBehaviourT>
{
	// variables //

	
	public BetterEvent betterEvent;




	// methods //

	
	// method: invoke the set Better Event, then return this updating event behaviour //
	public UpdatingEventBehaviourT invokeBetterEvent()
		=> selfAfter(()=> betterEvent.Invoke());
}
#endif