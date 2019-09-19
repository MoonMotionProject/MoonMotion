using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Events;

// Updating Event Behaviour: an abstract auto behaviour providing a set Unity event and a method to invoke it, which is to be called by a particular updating event that the derived class is for  //
public abstract class	UpdatingEventBehaviour<UpdatingEventBehaviourT> :
					AutoBehaviour<UpdatingEventBehaviourT>
						where UpdatingEventBehaviourT : AutoBehaviour<UpdatingEventBehaviourT>
{
	// variables //


	// settings //
	
	public UnityEvent unityEvent;




	// methods //


	// method: invoke the set Unity event, then return this updating event behaviour //
	public UpdatingEventBehaviourT invokeUnityEvent()
		=> selfAfter(()=> unityEvent.Invoke());
}