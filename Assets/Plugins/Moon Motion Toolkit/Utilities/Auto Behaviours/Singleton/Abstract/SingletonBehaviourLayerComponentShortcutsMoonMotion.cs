using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Singleton Behaviour Layer Component Shortcuts Moon Motion:
// #auto #shortcuts #tracking
// • provides this singleton behaviour with static access to its auto behaviour's Moon Motion component shortcuts layer
public abstract class SingletonBehaviourLayerComponentShortcutsMoonMotion<SingletonBehaviourT> :
					SingletonBehaviourLayerComponentShortcutsUnity<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region Utilities




	#region Auto Behaviours


	#region Tracking

	#region miscellaneous
	public static new float timeAwake => autoBehaviour.timeAwake;
	public static new float lightIntensityAwake => autoBehaviour.lightIntensityAwake;
	public static new bool awake => singleton && autoBehaviour.awake;
	public static new Color colorAwake => autoBehaviour.colorAwake;
	#endregion miscellaneous

	#region Transformations
	public static new Vector3 localScaleAwake => autoBehaviour.localScaleAwake;
	public static new float localScaleXAwake => autoBehaviour.localScaleXAwake;
	public static new float localScaleYAwake => autoBehaviour.localScaleYAwake;
	public static new float localScaleZAwake => autoBehaviour.localScaleZAwake;
	public static new Vector3 positionAwake => autoBehaviour.positionAwake;
	public static new float positionXAwake => autoBehaviour.positionXAwake;
	public static new float positionYAwake => autoBehaviour.positionYAwake;
	public static new float positionZAwake => autoBehaviour.positionZAwake;
	public static new Quaternion rotationAwake => autoBehaviour.rotationAwake;
	public static new float localPositionZAwake => autoBehaviour.localPositionZAwake;
	public static new float localPositionYAwake => autoBehaviour.localPositionYAwake;
	public static new float eulerAngleYAwake => autoBehaviour.eulerAngleYAwake;
	public static new float localPositionXAwake => autoBehaviour.localPositionXAwake;
	public static new Vector3 localPositionAwake => autoBehaviour.localPositionAwake;
	public static new float localEulerAngleZAwake => autoBehaviour.localEulerAngleZAwake;
	public static new float localEulerAngleYAwake => autoBehaviour.localEulerAngleYAwake;
	public static new float localEulerAngleXAwake => autoBehaviour.localEulerAngleXAwake;
	public static new Vector3 localEulerAnglesAwake => autoBehaviour.localEulerAnglesAwake;
	public static new float eulerAngleZAwake => autoBehaviour.eulerAngleZAwake;
	public static new float eulerAngleXAwake => autoBehaviour.eulerAngleXAwake;
	public static new Vector3 eulerAnglesAwake => autoBehaviour.eulerAnglesAwake;
	public static new Quaternion localRotationAwake => autoBehaviour.localRotationAwake;
	#endregion Transformations

	#region Components
	public static new List<CapsuleCollider> capsuleCollidersAwake => autoBehaviour.capsuleCollidersAwake;
	#endregion Components
	#endregion Tracking
	#endregion Auto Behaviours
	#endregion Utilities
}