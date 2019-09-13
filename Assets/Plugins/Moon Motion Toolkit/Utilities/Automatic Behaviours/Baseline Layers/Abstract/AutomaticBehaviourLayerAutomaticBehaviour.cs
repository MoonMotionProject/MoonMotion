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




	#if UNITY_EDITOR
	#region asset path

	public static string assetPath => typeof(AutomaticBehaviourT).assetPath();
	#endregion asset path
	#endif



	
	#region names

	public static Type type => typeof(AutomaticBehaviourT);

	public static string className => type.className();

	public static string simpleClassName => type.simpleClassName();

	public string nameQuoted => gameObject.nameQuoted();
	#endregion names




	#region printing

	#region printing what is given
	public static ObjectT print<ObjectT>(ObjectT object_)
		=> object_.print();
	public static ObjectT log<ObjectT>(ObjectT object_, string prefix, string loggingSeparator = Default.loggingSeparator)
		=> object_.logAs(prefix, loggingSeparator);
	#endregion printing what is given

	#region printing listings
	public static IEnumerable<TItem> printListingOf<TItem>(IEnumerable<TItem> enumerable, string separator = Default.listingSeparator)
		=> enumerable.printListing();
	#endregion printing listings

	#region printing this automatic behaviour
	public AutomaticBehaviourT print()
		=> print(automaticBehaviour);
	public AutomaticBehaviourT logAs(string prefix, string loggingSeparator = Default.loggingSeparator)
		=> automaticBehaviour.logAs<AutomaticBehaviourT>(prefix, loggingSeparator);
	#endregion printing this automatic behaviour

	#if UNITY_EDITOR
	#region printing this automatic behaviour's asset path
	public static string printAssetPath()
		=> print(assetPath);
	#endregion printing this automatic behaviour's asset path
	#endif

	#region printing this automatic behaviour's class names
	public static string printClassName()
		=> print(className);
	public static string printSimpleClassName()
		=> print(simpleClassName);
	#endregion printing this automatic behaviour's class names

	#region printing this automatic behaviour's (game object) name
	public AutomaticBehaviourT printName()
		=> selfAfter(()=> gameObject.printName());
	#endregion printing this automatic behaviour's (game object) name
	#endregion printing




	#region game object


	#region existence

	public bool destroyed => gameObject.destroyed();

	public bool exists => gameObject.exists();
	#endregion existence
	#endregion game object
}