using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Auto Behaviour:
// #auto #console
// • provides this behaviour with functionality baseline to all auto behaviour layers
public abstract class	AutoBehaviourLayerAutoBehaviour<AutoBehaviourT> :
					AutoBehaviourLayerImplementation
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

	// this instance as an auto behaviour //
	public AutoBehaviour<AutoBehaviourT> autoBehaviour => this.castTo<AutoBehaviour<AutoBehaviourT>>();
	#endregion casted instances




	#region self returning after acting

	public AutoBehaviourT selfAfter(Action action, bool boolean = true)
		=> self.after(action, boolean);
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
	public static ObjectT print<ObjectT>(ObjectT object_, GameObject contextGameObject = null)
		=> object_.print(contextGameObject);
	public static GameObject print(GameObject gameObject)
		=> gameObject.print();
	public static ObjectT log<ObjectT>(ObjectT object_, string prefix, string loggingSeparator = Default.loggingSeparator, GameObject contextGameObject = null)
		=> object_.logAs(prefix, contextGameObject, loggingSeparator);
	public static GameObject log(GameObject gameObject, string prefix, string loggingSeparator = Default.loggingSeparator)
		=> gameObject.logAs(prefix, loggingSeparator);
	public AutoBehaviourT asSelfLog<ObjectT>(ObjectT object_, string loggingSeparator = Default.loggingSeparator)
		=> selfAfter(()=> object_.logAs(""+self, gameObject, loggingSeparator));
	#endregion printing what is given

	#region printing listings
	public static IEnumerable<TItem> printListingOf<TItem>(IEnumerable<TItem> enumerable, string separator = Default.listingSeparator, GameObject contextGameObject = null)
		=> enumerable.printListing(separator, contextGameObject);
	#endregion printing listings

	#region printing this auto behaviour
	public AutoBehaviourT print()
		=> print(self, gameObject);
	public AutoBehaviourT logAs(string prefix, string loggingSeparator = Default.loggingSeparator)
		=> self.logAs(prefix, gameObject, loggingSeparator);
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




	#region erroring
	
	public AutoBehaviourT logError(string errorString, string prefix, GameObject contextGameObject = null, string loggingSeparator = Default.loggingSeparator)
		=> selfAfter(()=> errorString.logAsError(prefix, contextGameObject, loggingSeparator));
	
	public AutoBehaviourT asSelfLogError(string errorString, string loggingSeparator = Default.loggingSeparator)
		=> logError(errorString, ""+self, gameObject, loggingSeparator);
	
	public ObjectT asSelfLogErrorAndReturn<ObjectT>(ObjectT object_, string errorString, string loggingSeparator = Default.loggingSeparator)
	{
		asSelfLogError(errorString+"; returning "+object_, loggingSeparator);
		return object_;
	}
	#endregion erroring




	#region game object


	#region existence

	public bool destroyed => gameObject.destroyed();

	public bool exists => gameObject.exists();
	#endregion existence
	#endregion game object
}