using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Singleton:
// #auto
// • provides this singleton behaviour with static access to its automatic behaviour's automatic behaviour layer
// • provides this singleton behaviour with singleton features
public abstract class SingletonBehaviourLayerSingleton<SingletonBehaviourT> :
					AutomaticBehaviour<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region layer automatic behaviour




	#region casted instances

	// the singleton instance of this class as a component //
	public static new Component component => automaticBehaviour.component;

	// the singleton instance of this class as a mono behaviour //
	public static new MonoBehaviour monoBehaviour => automaticBehaviour.monoBehaviour;
	#endregion casted instances




	#region names

	public static new string nameQuoted => automaticBehaviour.nameQuoted;
	#endregion names




	#region printing

	#region printing this automatic behaviour
	public static new SingletonBehaviourT print()
		=> automaticBehaviour.print();
	public static new SingletonBehaviourT logAs(string prefix, string loggingSeparator = Default.loggingSeparator)
		=> automaticBehaviour.logAs(prefix, loggingSeparator);
	#endregion printing this automatic behaviour

	#region printing this automatic behaviour's names
	public static new SingletonBehaviourT printName()
		=> automaticBehaviour.printName();
	#endregion printing this automatic behaviour's names
	#endregion printing
	#endregion layer automatic behaviour








	#region singleton
	#region properties


	// the singleton instance of this class //
	public static SingletonBehaviourT singleton {get; private set;} = null;

	// the singleton instance of this class as an automatic behaviour //
	public static new AutomaticBehaviour<SingletonBehaviourT> automaticBehaviour => singleton.castTo<AutomaticBehaviour<SingletonBehaviourT>>();

	// this class's singleton game object //
	public static new GameObject gameObject => automaticBehaviour.gameObject;

	// this class's singleton transform //
	public static new Transform transform => automaticBehaviour.transform;
	#endregion properties




	#region updating


	// before the start: connect to the singleton instance of this inheritor  //
	public virtual void Awake()
		=> singleton = this.castTo<SingletonBehaviourT>();
	/*(print("Singleton found for: "+className);*/
	#endregion updating
	#endregion singleton
}