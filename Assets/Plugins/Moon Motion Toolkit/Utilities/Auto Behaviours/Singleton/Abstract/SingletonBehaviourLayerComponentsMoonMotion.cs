using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if STEAM_VIRTUALITY
using Valve.VR.InteractionSystem;
#endif

// Singleton Behaviour Layer Components Moon Motion:
// #auto #tracking
// • provides this singleton behaviour with static access to its auto behaviour's Moon Motion components layer
public abstract class	SingletonBehaviourLayerComponentsMoonMotion<SingletonBehaviourT> :
					SingletonBehaviourLayerComponentsUnity<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#if MOON_MOTION_TOOLKIT
	public static new TerrainResponse terrainResponse => autoBehaviour.terrainResponse;
	public static new Powerup powerup => autoBehaviour.powerup;
	public static new PowerupCollider powerupCollider => autoBehaviour.powerupCollider;
	public static new PowerupObjectsToggler powerupObjectsToggler => autoBehaviour.powerupObjectsToggler;
	public static new PowerupInstanceMethodsCaller powerupInstanceMethodsCaller => autoBehaviour.powerupInstanceMethodsCaller;
	public static new StretchScalable stretchScalable => autoBehaviour.stretchScalable;
	#endif








	#region Utilities




	#region Auto Behaviours


	public static new Kinematizer kinematizer => autoBehaviour.kinematizer;
	public static new Slower slower => autoBehaviour.slower;
	public static new FaceMainCamera faceMainCamera => autoBehaviour.faceMainCamera;
	public static new Hovering hovering => autoBehaviour.hovering;
	public static new BasicSpinning basicSpinning => autoBehaviour.basicSpinning;


	#region Tracking

	#region miscellaneous
	public static new TrackTimeOfAwake trackTimeOfAwake => autoBehaviour.trackTimeOfAwake;
	public static new TrackLightIntensityAtAwake trackLightIntensityAtAwake => autoBehaviour.trackLightIntensityAtAwake;
	public static new TrackAwake trackAwake => autoBehaviour.trackAwake;
	public static new TrackColorAtAwake trackColorAtAwake => autoBehaviour.trackColorAtAwake;
	#endregion miscellaneous

	#region Collideds
	public static new TrackCollideds trackCollideds => autoBehaviour.trackCollideds;
	#endregion Collideds

	#region Components
	public static new TrackCapsuleCollidersAtAwake trackCapsuleCollidersAtAwake => autoBehaviour.trackCapsuleCollidersAtAwake;
	#endregion Components

	#region Transformations
	public static new TrackLocalScaleAtAwake trackLocalScaleAtAwake => autoBehaviour.trackLocalScaleAtAwake;
	public static new TrackLocalScaleXAtAwake trackLocalScaleXAtAwake => autoBehaviour.trackLocalScaleXAtAwake;
	public static new TrackLocalScaleYAtAwake trackLocalScaleYAtAwake => autoBehaviour.trackLocalScaleYAtAwake;
	public static new TrackLocalScaleZAtAwake trackLocalScaleZAtAwake => autoBehaviour.trackLocalScaleZAtAwake;
	public static new TrackPositionAtAwake trackPositionAtAwake => autoBehaviour.trackPositionAtAwake;
	public static new TrackPositionXAtAwake trackPositionXAtAwake => autoBehaviour.trackPositionXAtAwake;
	public static new TrackPositionYAtAwake trackPositionYAtAwake => autoBehaviour.trackPositionYAtAwake;
	public static new TrackPositionZAtAwake trackPositionZAtAwake => autoBehaviour.trackPositionZAtAwake;
	public static new TrackRotationAtAwake trackRotationAtAwake => autoBehaviour.trackRotationAtAwake;
	public static new TrackLocalPositionZAtAwake trackLocalPositionZAtAwake => autoBehaviour.trackLocalPositionZAtAwake;
	public static new TrackLocalPositionYAtAwake trackLocalPositionYAtAwake => autoBehaviour.trackLocalPositionYAtAwake;
	public static new TrackEulerAngleYAtAwake trackEulerAngleYAtAwake => autoBehaviour.trackEulerAngleYAtAwake;
	public static new TrackLocalPositionXAtAwake trackLocalPositionXAtAwake => autoBehaviour.trackLocalPositionXAtAwake;
	public static new TrackLocalPositionAtAwake trackLocalPositionAtAwake => autoBehaviour.trackLocalPositionAtAwake;
	public static new TrackLocalEulerAngleZAtAwake trackLocalEulerAngleZAtAwake => autoBehaviour.trackLocalEulerAngleZAtAwake;
	public static new TrackLocalEulerAngleYAtAwake trackLocalEulerAngleYAtAwake => autoBehaviour.trackLocalEulerAngleYAtAwake;
	public static new TrackLocalEulerAngleXAtAwake trackLocalEulerAngleXAtAwake => autoBehaviour.trackLocalEulerAngleXAtAwake;
	public static new TrackLocalEulerAnglesAtAwake trackLocalEulerAnglesAtAwake => autoBehaviour.trackLocalEulerAnglesAtAwake;
	public static new TrackEulerAngleZAtAwake trackEulerAngleZAtAwake => autoBehaviour.trackEulerAngleZAtAwake;
	public static new TrackEulerAngleXAtAwake trackEulerAngleXAtAwake => autoBehaviour.trackEulerAngleXAtAwake;
	public static new TrackEulerAnglesAtAwake trackEulerAnglesAtAwake => autoBehaviour.trackEulerAnglesAtAwake;
	public static new TrackLocalRotationAtAwake trackLocalRotationAtAwake => autoBehaviour.trackLocalRotationAtAwake;
	#endregion Transformations
	#endregion Tracking
	#endregion Auto Behaviours
	#endregion Utilities








	#region Plugins




	#if STEAM_VIRTUALITY
	#region Steam Virtuality


	public static new Player player => autoBehaviour.player;
	public static new Hand hand => autoBehaviour.hand;
	public static new Controller controller => autoBehaviour.controller;
	public static new Interactable interactable => autoBehaviour.interactable;
	public static new Throwable throwable => autoBehaviour.throwable;
	public static new VelocityEstimator velocityEstimator => autoBehaviour.velocityEstimator;
	public static new ComplexThrowable complexThrowable => autoBehaviour.complexThrowable;
	public static new Arrow arrow => autoBehaviour.arrow;
	public static new ArrowHand arrowHand => autoBehaviour.arrowHand;
	public static new Balloon balloon => autoBehaviour.balloon;
	public static new Longbow longbow => autoBehaviour.longbow;
	public static new ItemPackage itemPackage => autoBehaviour.itemPackage;
	#endregion Steam Virtuality
	#endif
	#endregion Plugins
}