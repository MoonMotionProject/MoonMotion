using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton: an abstract singleton behaviour providing singleton features for all derived behaviours //
// #auto
public abstract class SingletonBehaviour<SingletonBehaviourT> : AutomaticBehaviour<SingletonBehaviourT> where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	// properties //

	
	// the singleton instance of this class //
	public static SingletonBehaviourT singleton {get; set;} = null;




	// updating //

	
	// before the start: //
	protected override void Awake()
	{
		base.Awake();

		// connect to the singleton instance of this inheritor //
		singleton = (SingletonBehaviourT) this;
		/*print("Singleton found for: "+typeof(SingletonBehaviourT).FullName);*/
	}
}