using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour Layer Automatic Behaviour:
// #auto
// • provides this behaviour with functionality baseline to all automatic behaviour layers
public abstract class	AutomaticBehaviourLayerAutomaticBehaviour<AutomaticBehaviourT> :
					AutomaticBehaviourLayerInterface
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	#region casted instances

	// this instance as an instance of a particular class specializing AutomaticBehaviour //
	public AutomaticBehaviourT automaticBehaviour => this.castTo<AutomaticBehaviourT>();

	// this instance as a component //
	public Component component => this.castTo<Component>();

	// this instance as a mono behaviour //
	public MonoBehaviour monoBehaviour => this.castTo<MonoBehaviour>();
	#endregion casted instances




	#region names

	public static string className => typeof(AutomaticBehaviourT).FullName;

	public string printClassName()
		=> className.print();

	public string printName()
		=> gameObject.printName();

	public string nameQuoted => gameObject.nameQuoted();
	#endregion names




	#region printing

	public static ObjectT print<ObjectT>(ObjectT object_)
		=> object_.print();
	#endregion printing




	#region game object


	#region existence

	public bool destroyed => gameObject.destroyed();

	public bool exists => gameObject.exists();
	#endregion existence
	#endregion game object
}