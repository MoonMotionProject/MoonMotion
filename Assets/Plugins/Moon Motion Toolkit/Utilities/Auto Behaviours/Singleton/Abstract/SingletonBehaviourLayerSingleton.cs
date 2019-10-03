using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Singleton:
// #auto
// • provides this singleton behaviour with static access to its auto behaviour's auto behaviour layer
// • provides this singleton behaviour with singleton features
public abstract class SingletonBehaviourLayerSingleton<SingletonBehaviourT> :
					AutoBehaviour<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region layer auto behaviour




	#region casted instances

	// the singleton instance of this class as a component //
	public static new Component component => autoBehaviour.component;

	// the singleton instance of this class as a mono behaviour //
	public static new MonoBehaviour monoBehaviour => autoBehaviour.monoBehaviour;
	#endregion casted instances




	#region names

	public static new string nameQuoted => autoBehaviour.nameQuoted;
	#endregion names




	#region printing

	#region printing this auto behaviour
	public static new SingletonBehaviourT print()
		=> autoBehaviour.print();
	public static new SingletonBehaviourT logAs(string prefix, string loggingSeparator = Default.loggingSeparator)
		=> autoBehaviour.logAs(prefix, loggingSeparator);
	#endregion printing this auto behaviour

	#region printing this auto behaviour's names
	public static new SingletonBehaviourT printName()
		=> autoBehaviour.printName();
	#endregion printing this auto behaviour's names
	#endregion printing
	#endregion layer auto behaviour








	#region singleton
	#region properties


	// the singleton instance of this class //
	public static SingletonBehaviourT singleton {get; private set;} = null;

	// the singleton instance of this class as an auto behaviour //
	public static AutoBehaviour<SingletonBehaviourT> autoBehaviour => singleton.castTo<AutoBehaviour<SingletonBehaviourT>>();

	// this class's singleton game object //
	public static new GameObject gameObject => autoBehaviour.gameObject;

	// this class's singleton transform //
	public static new Transform transform => autoBehaviour.transform;
	#endregion properties




	#region updating


	// before the start: connect to the singleton instance of this inheritor  //
	public virtual void Awake()
		=> singleton = this.castTo<SingletonBehaviourT>();
	/*(print("Singleton found for: "+className);*/
	#endregion updating
	#endregion singleton
}