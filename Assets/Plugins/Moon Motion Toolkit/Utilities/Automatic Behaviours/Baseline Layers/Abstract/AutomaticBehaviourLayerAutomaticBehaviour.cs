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

	// this instance as an instance of the particular derived class specializing AutomaticBehaviour //
	public AutomaticBehaviourT automaticBehaviour => this.castTo<AutomaticBehaviourT>();

	// this instance as a component //
	public Component component => this.castTo<Component>();

	// this instance as a mono behaviour //
	public MonoBehaviour monoBehaviour => this.castTo<MonoBehaviour>();
	#endregion casted instances




	#region self returning after acting

	public AutomaticBehaviourT selfAfter(Action action)
		=> automaticBehaviour.after(action);
	#endregion self returning after acting




	#region names

	public string className => GetType().FullName;

	public string nameQuoted => gameObject.nameQuoted();
	#endregion names




	#region printing

	#region printing this automatic behaviour's name
	public string printClassName()
		=> className.print();
	public string printName()
		=> gameObject.printName();
	#endregion printing this automatic behaviour's name

	#region printing what is given
	public static ObjectT print<ObjectT>(ObjectT object_)
		=> object_.print();
	public static IEnumerable<TItem> printListingOf<TItem>(IEnumerable<TItem> enumerable, string separator = Default.listingSeparator)
		=> enumerable.printListing();
	public static ObjectT log<ObjectT>(ObjectT object_, string prefix, string loggingSeparator = Default.loggingSeparator)
		=> object_.logAs(prefix, loggingSeparator);
	#endregion printing what is given

	#region printing this automatic behaviour
	public AutomaticBehaviourT print()
		=> print(automaticBehaviour);
	public AutomaticBehaviourT logAs(string prefix, string loggingSeparator = Default.loggingSeparator)
		=> automaticBehaviour.logAs<AutomaticBehaviourT>(prefix, loggingSeparator);
	#endregion printing this automatic behaviour
	#endregion printing




	#region game object


	#region existence

	public bool destroyed => gameObject.destroyed();

	public bool exists => gameObject.exists();
	#endregion existence
	#endregion game object
}