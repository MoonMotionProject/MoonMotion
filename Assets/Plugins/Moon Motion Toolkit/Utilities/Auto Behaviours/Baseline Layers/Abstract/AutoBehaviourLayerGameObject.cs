using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Game Object:
// #auto #gameobject
// • provides this behaviour with properties and methods for its game object
public abstract class	AutoBehaviourLayerGameObject<AutoBehaviourT> :
					AutoBehaviourLayerComponentsMoonMotion<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	#region creating fresh game objects

	public GameObject createChildObject(string name = "New Game Object")
		=> transform.createChildObject(name);
	#endregion creating fresh game objects


	#region creating templated game objects

	public GameObject createChildObject(GameObject template, string name = "")
		=> transform.createChildObject(template, name);
	#endregion creating templated game objects


	#region destruction

	#region of this object
	public void destroyThisObject(Func<GameObject, bool> function)
		=> gameObject.destroy(function);
	public void destroyThisObject(bool boolean = true)
		=> gameObject.destroy(boolean);
	#endregion of this object
	
	#region of the other given object
	public void destroy(GameObject otherGameObject, Func<GameObject, bool> function)
		=> otherGameObject.destroy(function);
	public void destroy(GameObject otherGameObject, bool boolean = true)
		=> otherGameObject.destroy(boolean);
	#endregion of the other given object
	#endregion destruction


	#region hierarchy selection
	#if UNITY_EDITOR

	public bool selected => gameObject.selected();
	public bool notSelected => gameObject.isNotSelected();
	#endif
	#endregion hierarchy selection


	#region printing

	// method: have this behaviour's game object print the given string, prefixed with this behaviour's game object's name, then return this behaviour //
	public AutoBehaviourT printNamely(string string_)
		=> selfAfter(()=> gameObject.printNamely(string_));
	#endregion printing


	#region activity

	// method: return whether this behaviour's game object is active locally //
	public bool activeLocally => gameObject.activeLocally();

	// method: return whether this behaviour's game object is active globally //
	public bool activeGlobally => gameObject.activeGlobally();

	// method: set the activity of this behaviour's game object to the given boolean, then return this behaviour //
	public AutoBehaviourT setActivityTo(bool enablement)
		=> selfAfter(()=> gameObject.setActivityTo(enablement));

	// method: activate this behaviour's game object, then return this behaviour //
	public AutoBehaviourT activate()
		=> selfAfter(()=> gameObject.activate());

	// method: deactivate this behaviour's game object, then return this behaviour //
	public AutoBehaviourT deactivate()
		=> selfAfter(()=> gameObject.deactivate());

	// method: toggle the activity of this behaviour's game object using the given toggling, then return this behaviour //
	public AutoBehaviourT toggleActivityBy(Toggling toggling)
		=> selfAfter(()=> gameObject.toggleActivityBy(toggling));

	// method: toggle the activity of this behaviour's game object, then return this behaviour //
	public AutoBehaviourT toggleActivity()
		=> selfAfter(()=> gameObject.toggleActivity());
	#endregion activity


	#region layer identification

	public string layerName => gameObject.layerName();
	
	public int layerIndex => gameObject.layerIndex();
	
	public bool layerIsDefault => gameObject.isOnDefaultLayer();

	public bool layerIsNotDefault => gameObject.isNotOnDefaultLayer();
	#endregion layer identification


	#region layer setting

	public AutoBehaviourT setLayerTo(string layerName, bool boolean = true)
		=> selfAfter(()=> gameObject.setLayerTo(layerName, boolean));
	
	public AutoBehaviourT setLayerTo(int layerIndex, bool boolean = true)
		=> selfAfter(()=> gameObject.setLayerTo(layerIndex, boolean));

	public AutoBehaviourT setChildLayerTo(string layerName, bool boolean = true)
		=> selfAfter(()=> gameObject.setChildLayersTo(layerName, boolean));

	public AutoBehaviourT setChildLayersTo(int layerIndex, bool boolean = true)
		=> selfAfter(()=> gameObject.setChildLayersTo(layerIndex, boolean));
	#endregion layer setting


	#region calling local methods

	public AutoBehaviourT callAllLocal(string methodName, SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver, bool boolean = true)
		=> selfAfter(()=> gameObject.callAllLocal(methodName, sendMessageOptions, boolean));

	public AutoBehaviourT validate_IfInEditor()
		=> selfAfter(()=> gameObject.validate_IfInEditor());
	#endregion calling local methods


	#region validation pending
	#if UNITY_EDITOR

	public AutoBehaviourT unpendValidation_IfInEditor()
		=> selfAfter(()=> gameObject.unpendValidation_IfInEditor());

	public AutoBehaviourT pendValidation_IfInEditor()
		=> selfAfter(()=> gameObject.pendValidation_IfInEditor());
	#endif
	#endregion validation pending
}