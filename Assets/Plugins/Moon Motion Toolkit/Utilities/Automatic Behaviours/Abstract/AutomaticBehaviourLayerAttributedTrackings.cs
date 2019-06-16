using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour Layer Attributed Trackings:
// #auto
// • provides this behaviour with automatically-connected properties to trackings attributed to it via tracking attributes
public abstract class	AutomaticBehaviourLayerAttributedTrackings<AutomaticBehaviourT> :
					AutomaticBehaviourLayerComponentShortcuts<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	// variables //

	
	// set of cached trackings – of booleans – for this object – attributed to this object by tracking attributes; presence of a string of a particular name indicates that the boolean with that name is true (otherwise false) //
	protected HashSet<string> cachedAttributedTrackingBooleans = new HashSet<string>();

	// dictionary of cached trackings – nonbooleans (so objects, assumed not to be booleans) – for this object – attributed to this object by tracking attributes – each keyed by the string that is their corresponding property name //
	private Dictionary<string, object> cachedAttributedTrackingNonbooleans = new Dictionary<string, object>();
	/* in this current implentation, the objects referenced by this dictionary's stored values are not being manually destroyed, but rather destroyed automatically after this object is destroyed, via garbage collection, because none of them are referenced anywhere else */

	
	
	
	// properties (some with methods to set, either to also return or to have the setter be private) //

	
	// properties for: awakeness //
	
	public bool awake
	{
		get {return cachedAttributedTrackingBooleans.Contains("awake");}
	}
	private void setAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingBooleans.add("awake");
		}
	}

	public float timeAwake
	{
		get {return (float) cachedAttributedTrackingNonbooleans["timeAwake"];}
	}
	private void setTimeAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("timeAwake", time);
		}
	}


	// properties for: transformations at awake //

	// local position //
	public Vector3 localPositionAwake
	{
		get {return (Vector3) cachedAttributedTrackingNonbooleans["localPositionAwake"];}
	}
	private void setLocalPositionAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("localPositionAwake", localPosition);
		}
	}
	public float localPositionXAwake
	{
		get {return (float) cachedAttributedTrackingNonbooleans["localPositionXAwake"];}
	}
	private void setLocalPositionXAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("localPositionXAwake", localPositionX);
		}
	}
	public float localPositionYAwake
	{
		get {return (float) cachedAttributedTrackingNonbooleans["localPositionYAwake"];}
	}
	private void setLocalPositionYAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("localPositionYAwake", localPositionY);
		}
	}
	public Vector3 localPositionZAwake
	{
		get {return (Vector3) cachedAttributedTrackingNonbooleans["localPositionZAwake"];}
	}
	private void setLocalPositionZAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("localPositionZAwake", localPositionZ);
		}
	}

	// local rotation //
	public Quaternion localRotationAwake
	{
		get {return (Quaternion) cachedAttributedTrackingNonbooleans["localRotationAwake"];}
	}
	private void setLocalRotationAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("localRotationAwake", localRotation);
		}
	}

	// local euler angles //
	public Vector3 localEulerAnglesAwake
	{
		get {return (Vector3) cachedAttributedTrackingNonbooleans["localEulerAnglesAwake"];}
	}
	private void setLocalEulerAnglesAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("localEulerAnglesAwake", localEulerAngles);
		}
	}
	public float localEulerAngleXAwake
	{
		get {return (float) cachedAttributedTrackingNonbooleans["localEulerAngleXAwake"];}
	}
	private void setLocalEulerAngleXAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("localEulerAngleXAwake", localEulerAngleX);
		}
	}
	public float localEulerAngleYAwake
	{
		get {return (float) cachedAttributedTrackingNonbooleans["localEulerAngleYAwake"];}
	}
	private void setLocalEulerAngleYAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("localEulerAngleYAwake", localEulerAngleY);
		}
	}
	public float localEulerAngleZAwake
	{
		get {return (float) cachedAttributedTrackingNonbooleans["localEulerAngleZAwake"];}
	}
	private void setLocalEulerAngleZAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("localEulerAngleZAwake", localEulerAngleZ);
		}
	}

	// local scale //
	public Vector3 localScaleAwake
	{
		get {return (Vector3) cachedAttributedTrackingNonbooleans["localScaleAwake"];}
	}
	private void setLocalScaleAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("localScaleAwake", localScale);
		}
	}
	public float localScaleXAwake
	{
		get {return (float) cachedAttributedTrackingNonbooleans["localScaleXAwake"];}
	}
	private void setLocalScaleXAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("localScaleXAwake", localScaleX);
		}
	}
	public float localScaleYAwake
	{
		get {return (float) cachedAttributedTrackingNonbooleans["localScaleYAwake"];}
	}
	private void setLocalScaleYAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("localScaleYAwake", localScaleY);
		}
	}
	public float localScaleZAwake
	{
		get {return (float) cachedAttributedTrackingNonbooleans["localScaleZAwake"];}
	}
	private void setLocalScaleZAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("localScaleZAwake", localScaleZ);
		}
	}

	// position //
	public Vector3 positionAwake
	{
		get {return (Vector3) cachedAttributedTrackingNonbooleans["positionAwake"];}
	}
	private void setPositionAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("positionAwake", position);
		}
	}
	public float positionXAwake
	{
		get {return (float) cachedAttributedTrackingNonbooleans["positionXAwake"];}
	}
	private void setPositionXAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("positionXAwake", positionX);
		}
	}
	public float positionYAwake
	{
		get {return (float) cachedAttributedTrackingNonbooleans["positionYAwake"];}
	}
	private void setPositionYAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("positionYAwake", positionY);
		}
	}
	public float positionZAwake
	{
		get {return (float) cachedAttributedTrackingNonbooleans["positionZAwake"];}
	}
	private void setPositionZAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("positionZAwake", positionZ);
		}
	}

	// rotation //
	public Quaternion rotationAwake
	{
		get {return (Quaternion) cachedAttributedTrackingNonbooleans["rotationAwake"];}
	}
	private void setRotationAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("rotationAwake", rotation);
		}
	}

	// euler angles //
	public Vector3 eulerAnglesAwake
	{
		get {return (Vector3) cachedAttributedTrackingNonbooleans["eulerAnglesAwake"];}
	}
	private void setEulerAnglesAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("eulerAnglesAwake", eulerAngles);
		}
	}
	public float eulerAngleXAwake
	{
		get {return (float) cachedAttributedTrackingNonbooleans["eulerAngleXAwake"];}
	}
	private void setEulerAngleXAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("eulerAngleXAwake", eulerAngleX);
		}
	}
	public float eulerAngleYAwake
	{
		get {return (float) cachedAttributedTrackingNonbooleans["eulerAngleYAwake"];}
	}
	private void setEulerAngleYAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("eulerAngleYAwake", eulerAngleY);
		}
	}
	public float eulerAngleZAwake
	{
		get {return (float) cachedAttributedTrackingNonbooleans["eulerAngleZAwake"];}
	}
	private void setEulerAngleZAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("eulerAngleZAwake", eulerAngleZ);
		}
	}


	// properties for: component shortcuts at awake //

	// light //
	public float lightIntensityAwake
	{
		get {return (float) cachedAttributedTrackingNonbooleans["lightIntensityAwake"];}
	}
	private void setlightIntensityAwake_If(bool boolean)
	{
		if (boolean)
		{
			cachedAttributedTrackingNonbooleans.add("lightIntensityAwake", lightIntensity);
		}
	}




	// updating //


	// before the start: //
	protected virtual void Awake()
	{
		// awakeness //

		// awake //
		setAwake_If(inheritorHasAttribute<TrackAwakeAttribute>());

		// time awake //
		setTimeAwake_If(inheritorHasAttribute<TrackTimeOfAwakeAttribute>());


		// transformations //

		// local position //
		setLocalPositionAwake_If(inheritorHasAttribute<TrackLocalPositionAtAwakeAttribute>());
		setLocalPositionXAwake_If(inheritorHasAttribute<TrackLocalPositionXAtAwakeAttribute>());
		setLocalPositionYAwake_If(inheritorHasAttribute<TrackLocalPositionYAtAwakeAttribute>());
		setLocalPositionZAwake_If(inheritorHasAttribute<TrackLocalPositionZAtAwakeAttribute>());

		// local rotation //
		setLocalRotationAwake_If(inheritorHasAttribute<TrackLocalRotationAtAwakeAttribute>());
		
		// local euler angles //
		setLocalEulerAnglesAwake_If(inheritorHasAttribute<TrackLocalEulerAnglesAtAwakeAttribute>());
		setLocalEulerAngleXAwake_If(inheritorHasAttribute<TrackLocalEulerAngleXAtAwakeAttribute>());
		setLocalEulerAngleYAwake_If(inheritorHasAttribute<TrackLocalEulerAngleYAtAwakeAttribute>());
		setLocalEulerAngleZAwake_If(inheritorHasAttribute<TrackLocalEulerAngleZAtAwakeAttribute>());

		// local scale //
		setLocalScaleAwake_If(inheritorHasAttribute<TrackLocalScaleAtAwakeAttribute>());
		setLocalScaleXAwake_If(inheritorHasAttribute<TrackLocalScaleXAtAwakeAttribute>());
		setLocalScaleYAwake_If(inheritorHasAttribute<TrackLocalScaleYAtAwakeAttribute>());
		setLocalScaleZAwake_If(inheritorHasAttribute<TrackLocalScaleZAtAwakeAttribute>());
		
		// position //
		setPositionAwake_If(inheritorHasAttribute<TrackPositionAtAwakeAttribute>());
		setPositionXAwake_If(inheritorHasAttribute<TrackPositionXAtAwakeAttribute>());
		setPositionYAwake_If(inheritorHasAttribute<TrackPositionYAtAwakeAttribute>());
		setPositionZAwake_If(inheritorHasAttribute<TrackPositionZAtAwakeAttribute>());

		// rotation //
		setRotationAwake_If(inheritorHasAttribute<TrackRotationAtAwakeAttribute>());

		// euler angles //
		setEulerAnglesAwake_If(inheritorHasAttribute<TrackEulerAnglesAtAwakeAttribute>());
		setEulerAngleXAwake_If(inheritorHasAttribute<TrackEulerAngleXAtAwakeAttribute>());
		setEulerAngleYAwake_If(inheritorHasAttribute<TrackEulerAngleYAtAwakeAttribute>());
		setEulerAngleZAwake_If(inheritorHasAttribute<TrackEulerAngleZAtAwakeAttribute>());


		// component shortcuts //
		
		// light //
		setlightIntensityAwake_If(inheritorHasAttribute<TrackLightIntensityAtAwakeAttribute>());
	}
}