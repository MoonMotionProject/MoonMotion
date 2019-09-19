using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Singleton Behaviour Layer Component Shortcuts Moon Motion:
// #auto #shortcuts #tracking
// • provides this singleton behaviour with static access to its automatic behaviour's Moon Motion component shortcuts layer
public abstract class SingletonBehaviourLayerComponentShortcutsMoonMotion<SingletonBehaviourT> :
					SingletonBehaviourLayerComponentShortcutsUnity<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region Utilities




	#region Automatic Behaviours


	#region Tracking

	#region miscellaneous
	public static new float timeAwake => automaticBehaviour.timeAwake;
	public static new float lightIntensityAwake => automaticBehaviour.lightIntensityAwake;
	public static new bool awake => singleton && automaticBehaviour.awake;
	public static new Color colorAwake => automaticBehaviour.colorAwake;
	#endregion miscellaneous

	#region Transformations
	public static new Vector3 localScaleAwake => automaticBehaviour.localScaleAwake;
	public static new float localScaleXAwake => automaticBehaviour.localScaleXAwake;
	public static new float localScaleYAwake => automaticBehaviour.localScaleYAwake;
	public static new float localScaleZAwake => automaticBehaviour.localScaleZAwake;
	public static new Vector3 positionAwake => automaticBehaviour.positionAwake;
	public static new float positionXAwake => automaticBehaviour.positionXAwake;
	public static new float positionYAwake => automaticBehaviour.positionYAwake;
	public static new float positionZAwake => automaticBehaviour.positionZAwake;
	public static new Quaternion rotationAwake => automaticBehaviour.rotationAwake;
	public static new float localPositionZAwake => automaticBehaviour.localPositionZAwake;
	public static new float localPositionYAwake => automaticBehaviour.localPositionYAwake;
	public static new float eulerAngleYAwake => automaticBehaviour.eulerAngleYAwake;
	public static new float localPositionXAwake => automaticBehaviour.localPositionXAwake;
	public static new Vector3 localPositionAwake => automaticBehaviour.localPositionAwake;
	public static new float localEulerAngleZAwake => automaticBehaviour.localEulerAngleZAwake;
	public static new float localEulerAngleYAwake => automaticBehaviour.localEulerAngleYAwake;
	public static new float localEulerAngleXAwake => automaticBehaviour.localEulerAngleXAwake;
	public static new Vector3 localEulerAnglesAwake => automaticBehaviour.localEulerAnglesAwake;
	public static new float eulerAngleZAwake => automaticBehaviour.eulerAngleZAwake;
	public static new float eulerAngleXAwake => automaticBehaviour.eulerAngleXAwake;
	public static new Vector3 eulerAnglesAwake => automaticBehaviour.eulerAnglesAwake;
	public static new Quaternion localRotationAwake => automaticBehaviour.localRotationAwake;
	#endregion Transformations

	#region Components
	public static new List<CapsuleCollider> capsuleCollidersAwake => automaticBehaviour.capsuleCollidersAwake;
	#endregion Components
	#endregion Tracking
	#endregion Automatic Behaviours
	#endregion Utilities
}