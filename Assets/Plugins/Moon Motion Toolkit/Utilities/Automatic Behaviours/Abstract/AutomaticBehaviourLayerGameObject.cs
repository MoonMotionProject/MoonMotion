using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour Layer Game Object:
// #auto
// • provides this behaviour with methods for its game object
public abstract class	AutomaticBehaviourLayerGameObject<AutomaticBehaviourT> :
					AutomaticBehaviourLayerAttributeDetection<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	// methods for: destruction //

	// method: destroy this behaviour's game object //
	public void destroyObject()
		=> gameObject.destroy();


	// methods for: enablement //

	// method: set the enablement of this behaviour's game object to the given boolean, then return this behaviour's game object //
	public GameObject setEnablementTo(bool boolean)
		=> gameObject.setEnablementTo(boolean);

	// method: enable this behaviour's game object, then return this behaviour's game object //
	public GameObject enable()
		=> gameObject.enable();

	// method: disable this behaviour's game object, then return this behaviour's game object //
	public GameObject disable()
		=> gameObject.disable();


	// methods for: layer setting //

	public GameObject setLayerTo(string layerName, bool boolean = true)
		=> gameObject.setLayerTo(layerName, boolean);
	
	public GameObject setLayerTo(int layerIndex, bool boolean = true)
		=> gameObject.setLayerTo(layerIndex, boolean);

	public GameObject setChildLayerTo(string layerName, bool boolean = true)
		=> gameObject.setChildLayersTo(layerName, boolean);

	public GameObject setChildLayersTo(int layerIndex, bool boolean = true)
		=> gameObject.setChildLayersTo(layerIndex, boolean);


	// methods for: printing //

	// method: have this behaviour's game object print the given string, prefixed with this behaviour's game object's name, then return this behaviour's game object //
	public GameObject printNamely(string string_)
		=> gameObject.printNamely(string_);


	// methods for: child lights //

	public float[] getChildLightsIntensities()
		=> gameObject.getChildLightsIntensities();

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


	// methods for: child particles systems //

	public GameObject togglePlayingChildParticlesSystems(bool boolean)
		=> gameObject.togglePlayingChildParticlesSystems(boolean);

	public GameObject playChildParticlesSystems(bool boolean)
		=> gameObject.playChildParticlesSystems(boolean);

	public GameObject stopChildParticlesSystems(bool boolean)
		=> gameObject.stopChildParticlesSystems(boolean);
}