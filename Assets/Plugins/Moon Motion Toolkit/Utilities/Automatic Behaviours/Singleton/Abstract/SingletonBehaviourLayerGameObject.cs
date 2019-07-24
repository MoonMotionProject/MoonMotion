using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Game Object:
// #auto #gameobject
// • provides this singleton behaviour with static access to its automatic behaviour's game object layer
public abstract class	SingletonBehaviourLayerGameObject<SingletonBehaviourT> :
					SingletonBehaviourLayerAttributeDetection<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region existence

	public static new bool destroyed => automaticBehaviour.destroyed;

	public static new bool exists => automaticBehaviour.exists;
	#endregion existence


	#region creating fresh game objects

	public static new GameObject createChildObject(string name = "New Game Object")
		=> automaticBehaviour.createChildObject(name);
	#endregion creating fresh game objects


	#region creating templated game objects

	public static new GameObject createChildObject(GameObject template, string name = "")
		=> automaticBehaviour.createChildObject(template, name);
	#endregion creating templated game objects


	#region destruction

	// method: (according to the given boolean:) destroy this behaviour's game object //
	public static new void destroyObject(bool boolean = true)
		=> automaticBehaviour.destroyObject(boolean);
	#endregion destruction


	#region activity

	// method: return whether this behaviour's game object is active locally //
	public static new bool activeLocally => automaticBehaviour.activeLocally;

	// method: return whether this behaviour's game object is active globally //
	public static new bool activeGlobally => automaticBehaviour.activeGlobally;

	// method: set the activity of this behaviour's game object to the given boolean, then return this behaviour's game object //
	public static new GameObject setActivityTo(bool boolean)
		=> automaticBehaviour.setActivityTo(boolean);

	// method: activate this behaviour's game object, then return this behaviour's game object //
	public static new GameObject activate()
		=> automaticBehaviour.activate();

	// method: deactivate this behaviour's game object, then return this behaviour's game object //
	public static new GameObject deactivate()
		=> automaticBehaviour.deactivate();

	// method: toggle the activity of this behaviour's game object using the given toggling, then return this behaviour's game object //
	public static new GameObject toggleActivityBy(Toggling toggling)
		=> automaticBehaviour.toggleActivityBy(toggling);
	#endregion activity


	#region layer identification

	public static new string layerName => automaticBehaviour.layerName;

	public static new int layerIndex => automaticBehaviour.layerIndex;

	public static new bool layerIsDefault => automaticBehaviour.layerIsDefault;

	public static new bool layerIsNotDefault => automaticBehaviour.layerIsNotDefault;
	#endregion layer identification


	#region hierarchy selection
	#if UNITY_EDITOR

	public static new bool selected => automaticBehaviour.selected;
	public static new bool notSelected => automaticBehaviour.notSelected;
	#endif
	#endregion hierarchy selection


	#region printing

	// method: have this behaviour's game object print the given string, prefixed with this behaviour's game object's name, then return this behaviour's game object //
	public static new GameObject printNamely(string string_)
		=> automaticBehaviour.printNamely(string_);
	#endregion printing


	#region layer setting

	public static new GameObject setLayerTo(string layerName, bool boolean = true)
		=> automaticBehaviour.setLayerTo(layerName, boolean);

	public static new GameObject setLayerTo(int layerIndex, bool boolean = true)
		=> automaticBehaviour.setLayerTo(layerIndex, boolean);

	public static new GameObject setChildLayerTo(string layerName, bool boolean = true)
		=> automaticBehaviour.setChildLayerTo(layerName, boolean);

	public static new GameObject setChildLayersTo(int layerIndex, bool boolean = true)
		=> automaticBehaviour.setChildLayersTo(layerIndex, boolean);
	#endregion layer setting


	#region calling local methods

	public static new GameObject callAllLocal(string methodName, SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver, bool boolean = true)
		=> automaticBehaviour.callAllLocal(methodName, sendMessageOptions, boolean);

	public static new GameObject validate()
		=> automaticBehaviour.validate();
	#endregion calling local methods


	#region validation pending
	#if UNITY_EDITOR

	public static new GameObject unpendValidation()
		=> automaticBehaviour.unpendValidation();

	public static new GameObject pendValidation()
		=> automaticBehaviour.pendValidation();
	#endif
	#endregion validation pending


	#region child lights

	public static new float[] childLightsIntensities => automaticBehaviour.childLightsIntensities;

	public static new GameObject setChildLightsIntensitiesTo(float[] targetIntensities)
		=> automaticBehaviour.setChildLightsIntensitiesTo(targetIntensities);

	public static new GameObject setChildLightsIntensitiesTo(float targetIntensity)
		=> automaticBehaviour.setChildLightsIntensitiesTo(targetIntensity);

	public static new GameObject renderChildLightsBy(LightRenderMode lightRenderMode)
		=> automaticBehaviour.renderChildLightsBy(lightRenderMode);

	public static new GameObject renderChildLightsByPixel()
		=> automaticBehaviour.renderChildLightsByPixel();

	public static new GameObject renderChildLightsByVertex()
		=> automaticBehaviour.renderChildLightsByVertex();
	#endregion child lights


	#region child particles systems

	public static new GameObject togglePlayingChildParticlesSystems(bool boolean)
		=> automaticBehaviour.togglePlayingChildParticlesSystems(boolean);

	public static new GameObject playChildParticlesSystems(bool boolean)
		=> automaticBehaviour.playChildParticlesSystems(boolean);

	public static new GameObject stopChildParticlesSystems(bool boolean)
		=> automaticBehaviour.stopChildParticlesSystems(boolean);
	#endregion child particles systems
}