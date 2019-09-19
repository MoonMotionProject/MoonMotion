using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Game Object:
// #auto #gameobject
// • provides this singleton behaviour with static access to its auto behaviour's game object layer
public abstract class	SingletonBehaviourLayerGameObject<SingletonBehaviourT> :
					SingletonBehaviourLayerComponentsMoonMotion<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region existence

	public static new bool destroyed => autoBehaviour.destroyed;

	public static new bool exists => autoBehaviour.exists;
	#endregion existence


	#region creating fresh game objects

	public static new GameObject createChildObject(string name = "New Game Object")
		=> autoBehaviour.createChildObject(name);
	#endregion creating fresh game objects


	#region creating templated game objects

	public static new GameObject createChildObject(GameObject template, string name = "")
		=> autoBehaviour.createChildObject(template, name);
	#endregion creating templated game objects


	#region destruction

	// method: (according to the given boolean:) destroy this behaviour's game object //
	public static new void destroyObject(bool boolean = true)
		=> autoBehaviour.destroyObject(boolean);
	#endregion destruction


	#region activity

	// method: return whether this behaviour's game object is active locally //
	public static new bool activeLocally => autoBehaviour.activeLocally;

	// method: return whether this behaviour's game object is active globally //
	public static new bool activeGlobally => autoBehaviour.activeGlobally;

	// method: set the activity of this behaviour's game object to the given boolean, then return this behaviour //
	public static new AutoBehaviour<SingletonBehaviourT> setActivityTo(bool boolean)
		=> autoBehaviour.setActivityTo(boolean);

	// method: activate this behaviour's game object, then return this behaviour //
	public static new AutoBehaviour<SingletonBehaviourT> activate()
		=> autoBehaviour.activate();

	// method: deactivate this behaviour's game object, then return this behaviour //
	public static new AutoBehaviour<SingletonBehaviourT> deactivate()
		=> autoBehaviour.deactivate();

	// method: toggle the activity of this behaviour's game object using the given toggling, then return this behaviour //
	public static new AutoBehaviour<SingletonBehaviourT> toggleActivityBy(Toggling toggling)
		=> autoBehaviour.toggleActivityBy(toggling);

	// method: toggle the activity of this behaviour's game object, then return this behaviour //
	public static new AutoBehaviour<SingletonBehaviourT> toggleActivity()
		=> autoBehaviour.toggleActivity();
	#endregion activity


	#region layer identification

	public static new string layerName => autoBehaviour.layerName;

	public static new int layerIndex => autoBehaviour.layerIndex;

	public static new bool layerIsDefault => autoBehaviour.layerIsDefault;

	public static new bool layerIsNotDefault => autoBehaviour.layerIsNotDefault;
	#endregion layer identification


	#region hierarchy selection
	#if UNITY_EDITOR

	public static new bool selected => autoBehaviour.selected;
	public static new bool notSelected => autoBehaviour.notSelected;
	#endif
	#endregion hierarchy selection


	#region printing

	// method: have this behaviour's game object print the given string, prefixed with this behaviour's game object's name, then return this behaviour //
	public static new AutoBehaviour<SingletonBehaviourT> printNamely(string string_)
		=> autoBehaviour.printNamely(string_);
	#endregion printing


	#region layer setting

	public static new AutoBehaviour<SingletonBehaviourT> setLayerTo(string layerName, bool boolean = true)
		=> autoBehaviour.setLayerTo(layerName, boolean);

	public static new AutoBehaviour<SingletonBehaviourT> setLayerTo(int layerIndex, bool boolean = true)
		=> autoBehaviour.setLayerTo(layerIndex, boolean);

	public static new AutoBehaviour<SingletonBehaviourT> setChildLayerTo(string layerName, bool boolean = true)
		=> autoBehaviour.setChildLayerTo(layerName, boolean);

	public static new AutoBehaviour<SingletonBehaviourT> setChildLayersTo(int layerIndex, bool boolean = true)
		=> autoBehaviour.setChildLayersTo(layerIndex, boolean);
	#endregion layer setting


	#region calling local methods

	public static new AutoBehaviour<SingletonBehaviourT> callAllLocal(string methodName, SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver, bool boolean = true)
		=> autoBehaviour.callAllLocal(methodName, sendMessageOptions, boolean);

	public static new AutoBehaviour<SingletonBehaviourT> validate_IfInEditor()
		=> autoBehaviour.validate_IfInEditor();
	#endregion calling local methods


	#region validation pending
	#if UNITY_EDITOR

	public static new AutoBehaviour<SingletonBehaviourT> unpendValidation_IfInEditor()
		=> autoBehaviour.unpendValidation_IfInEditor();

	public static new AutoBehaviour<SingletonBehaviourT> pendValidation_IfInEditor()
		=> autoBehaviour.pendValidation_IfInEditor();
	#endif
	#endregion validation pending
}