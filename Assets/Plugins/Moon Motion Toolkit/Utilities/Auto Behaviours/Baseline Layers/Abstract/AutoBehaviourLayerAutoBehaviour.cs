using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Auto Behaviour:
// #auto
// • provides this behaviour with functionality baseline to all auto behaviour layers
public abstract class	AutoBehaviourLayerAutoBehaviour<AutoBehaviourT> :
					AutoBehaviourLayerInterface
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	#region casted instances

	// this instance as an instance of the particular derived class specializing AutoBehaviour //
	public AutoBehaviourT self
	{
		get
		{
			try
			{
				return this.castTo<AutoBehaviourT>();
			}
			catch (InvalidCastException)
			{
				#if UNITY_EDITOR
				if (UnityIs.inEditor)
				{
					return assetPath.thenNewlineAnd("is being extended like AutoBehaviour<"+simpleClassName+"> in a class that should actually be generically passing itself").printAsErrorAndReturnDefault<AutoBehaviourT>();
				}
				#endif
				return default(AutoBehaviourT);		// should be unreachable
			}
		}
	}

	// this instance as a component //
	public Component component => this.castTo<Component>();

	// this instance as a mono behaviour //
	public MonoBehaviour monoBehaviour => this.castTo<MonoBehaviour>();
	#endregion casted instances




	#region self returning after acting

	public AutoBehaviourT selfAfter(Action action)
		=> self.after(action);
	#endregion self returning after acting




	#if UNITY_EDITOR
	#region asset path

	public static string assetPath => typeof(AutoBehaviourT).assetPath();
	#endregion asset path
	#endif



	
	#region names

	public static Type type => typeof(AutoBehaviourT);

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

	#region printing this auto behaviour
	public AutoBehaviourT print()
		=> print(self);
	public AutoBehaviourT logAs(string prefix, string loggingSeparator = Default.loggingSeparator)
		=> self.logAs<AutoBehaviourT>(prefix, loggingSeparator);
	#endregion printing this auto behaviour

	#if UNITY_EDITOR
	#region printing this auto behaviour's asset path
	public static string printAssetPath()
		=> print(assetPath);
	#endregion printing this auto behaviour's asset path
	#endif

	#region printing this auto behaviour's class names
	public static string printClassName()
		=> print(className);
	public static string printSimpleClassName()
		=> print(simpleClassName);
	#endregion printing this auto behaviour's class names

	#region printing this auto behaviour's (game object) name
	public AutoBehaviourT printName()
		=> selfAfter(()=> gameObject.printName());
	#endregion printing this auto behaviour's (game object) name
	#endregion printing




	#region game object


	#region existence

	public bool destroyed => gameObject.destroyed();

	public bool exists => gameObject.exists();
	#endregion existence
	#endregion game object
}