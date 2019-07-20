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

	// the singleton instance of this class as an automatic behaviour //
	public static new AutomaticBehaviour<SingletonBehaviourT> automaticBehaviour => singleton.castTo<AutomaticBehaviour<SingletonBehaviourT>>();

	// the singleton instance of this class as a component //
	public static new Component component => automaticBehaviour.component;

	// the singleton instance of this class as a mono behaviour //
	public static new MonoBehaviour monoBehaviour => automaticBehaviour.monoBehaviour;
	#endregion casted instances




	#region names

	public static new string printClassName()
		=> automaticBehaviour.printClassName();

	public static new string printName()
		=> automaticBehaviour.printName();

	public static new string nameQuoted => automaticBehaviour.nameQuoted;
	#endregion names
	#endregion layer automatic behaviour








	#region singleton
	// properties //


	// the singleton instance of this class //
	private static SingletonBehaviourT singleton_ = null;
	public static SingletonBehaviourT singleton => singleton_;

	// this class's singleton game object //
	public static new GameObject gameObject => automaticBehaviour.gameObject;

	// this class's singleton transform //
	public static new Transform transform => automaticBehaviour.transform;




	// updating //


	// before the start: //
	public virtual void Awake()
	{
		// connect to the singleton instance of this inheritor //
		singleton_ = this.castTo<SingletonBehaviourT>();
		/*(print("Singleton found for: "+className);*/
	}
	#endregion singleton
}