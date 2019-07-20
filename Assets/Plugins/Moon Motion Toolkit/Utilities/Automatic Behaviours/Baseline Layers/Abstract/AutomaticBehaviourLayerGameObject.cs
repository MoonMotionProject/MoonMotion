using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour Layer Game Object:
// #auto #gameobject
// • provides this behaviour with properties and methods for its game object
public abstract class	AutomaticBehaviourLayerGameObject<AutomaticBehaviourT> :
					AutomaticBehaviourLayerAttributeDetection<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
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

	// method: (according to the given boolean:) destroy this behaviour's game object //
	public void destroyObject(bool boolean = true)
		=> gameObject.destroy(boolean);
	#endregion destruction


	#region selection
	#if UNITY_EDITOR

	public bool selected => gameObject.selected();
	public bool notSelected => gameObject.isNotSelected();
	#endif
	#endregion selection


	#region printing

	// method: have this behaviour's game object print the given string, prefixed with this behaviour's game object's name, then return this behaviour's game object //
	public GameObject printNamely(string string_)
		=> gameObject.printNamely(string_);
	#endregion printing


	#region activity

	// method: return whether this behaviour's game object is active locally //
	public bool activeLocally => gameObject.activeLocally();

	// method: return whether this behaviour's game object is active globally //
	public bool activeGlobally => gameObject.activeGlobally();

	// method: set the activity of this behaviour's game object to the given boolean, then return this behaviour's game object //
	public GameObject setActivityTo(bool enablement)
		=> gameObject.setActivityTo(enablement);

	// method: activate this behaviour's game object, then return this behaviour's game object //
	public GameObject activate()
		=> gameObject.activate();

	// method: deactivate this behaviour's game object, then return this behaviour's game object //
	public GameObject deactivate()
		=> gameObject.deactivate();

	// method: toggle the activity of this behaviour's game object using the given toggling, then return this behaviour's game object //
	public GameObject toggleActivityBy(Toggling toggling)
		=> gameObject.toggleActivityBy(toggling);
	#endregion activity
	

	#region layer identification
	
	public string layerName => gameObject.layerName();
	
	public int layerIndex => gameObject.layerIndex();
	
	public bool layerIsDefault => gameObject.isOnDefaultLayer();

	public bool layerIsNotDefault => gameObject.isNotOnDefaultLayer();
	#endregion layer identification


	#region layer setting

	public GameObject setLayerTo(string layerName, bool boolean = true)
		=> gameObject.setLayerTo(layerName, boolean);
	
	public GameObject setLayerTo(int layerIndex, bool boolean = true)
		=> gameObject.setLayerTo(layerIndex, boolean);

	public GameObject setChildLayerTo(string layerName, bool boolean = true)
		=> gameObject.setChildLayersTo(layerName, boolean);

	public GameObject setChildLayersTo(int layerIndex, bool boolean = true)
		=> gameObject.setChildLayersTo(layerIndex, boolean);
	#endregion layer setting


	#region calling local methods

	public GameObject callAllLocal(string methodName, SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver, bool boolean = true)
		=> gameObject.callAllLocal(methodName, sendMessageOptions, boolean);

	public GameObject validate()
		=> gameObject.validate();
	#endregion calling local methods


	#region validation pending
	#if UNITY_EDITOR

	public GameObject unpendValidation()
		=> gameObject.unpendValidation();

	public GameObject pendValidation()
		=> gameObject.pendValidation();
	#endif
	#endregion validation pending


	#region child lights

	public float[] childLightsIntensities => gameObject.childLightsIntensities();

	public GameObject setChildLightsIntensities(float[] targetIntensities)
		=> gameObject.setChildLightsIntensities(targetIntensities);

	public GameObject setChildLightsIntensities(float targetIntensity)
		=> gameObject.setChildLightsIntensities(targetIntensity);

	public GameObject renderChildLightsBy(LightRenderMode lightRenderMode)
		=> gameObject.renderChildLightsBy(lightRenderMode);

	public GameObject renderChildLightsByPixel()
		=> gameObject.renderChildLightsByPixel();

	public GameObject renderChildLightsByVertex()
		=> gameObject.renderChildLightsByVertex();
	#endregion child lights


	#region child particles systems

	public GameObject togglePlayingChildParticlesSystems(bool boolean)
		=> gameObject.togglePlayingChildParticlesSystems(boolean);

	public GameObject playChildParticlesSystems(bool boolean)
		=> gameObject.playChildParticlesSystems(boolean);

	public GameObject stopChildParticlesSystems(bool boolean)
		=> gameObject.stopChildParticlesSystems(boolean);
	#endregion child particles systems
}