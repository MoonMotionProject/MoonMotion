using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Singleton Behaviour Layer Components Moon Motion:
// #auto #tracking
// • provides this singleton behaviour with static access to its automatic behaviour's Moon Motion components layer
public abstract class	SingletonBehaviourLayerComponentsMoonMotion<SingletonBehaviourT> :
					SingletonBehaviourLayerComponentsUnity<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	public static new Locomotion locomotion => automaticBehaviour.locomotion;
	public static new TerrainResponse terrainResponse => automaticBehaviour.terrainResponse;
	public static new Powerup powerup => automaticBehaviour.powerup;
	public static new PowerupCollider powerupCollider => automaticBehaviour.powerupCollider;
	public static new PowerupObjectsToggler powerupObjectsToggler => automaticBehaviour.powerupObjectsToggler;
	public static new PowerupInstanceMethodsCaller powerupInstanceMethodsCaller => automaticBehaviour.powerupInstanceMethodsCaller;
	public static new StretchScalable stretchScalable => automaticBehaviour.stretchScalable;








	#region Utilities




	#region Automatic Behaviours


	public static new Kinematizer kinematizer => automaticBehaviour.kinematizer;
	public static new Slower slower => automaticBehaviour.slower;
	public static new FacePlayerCamera facePlayerCamera => automaticBehaviour.facePlayerCamera;
	public static new Hovering hovering => automaticBehaviour.hovering;
	public static new BasicSpinning basicSpinning => automaticBehaviour.basicSpinning;


	#region Tracking

	#region miscellaneous
	public static new TrackTimeOfAwake trackTimeOfAwake => automaticBehaviour.trackTimeOfAwake;
	public static new TrackLightIntensityAtAwake trackLightIntensityAtAwake => automaticBehaviour.trackLightIntensityAtAwake;
	public static new TrackAwake trackAwake => automaticBehaviour.trackAwake;
	#endregion miscellaneous
	
	#region Transformations
	public static new TrackLocalScaleAtAwake trackLocalScaleAtAwake => automaticBehaviour.trackLocalScaleAtAwake;
	public static new TrackLocalScaleXAtAwake trackLocalScaleXAtAwake => automaticBehaviour.trackLocalScaleXAtAwake;
	public static new TrackLocalScaleYAtAwake trackLocalScaleYAtAwake => automaticBehaviour.trackLocalScaleYAtAwake;
	public static new TrackLocalScaleZAtAwake trackLocalScaleZAtAwake => automaticBehaviour.trackLocalScaleZAtAwake;
	public static new TrackPositionAtAwake trackPositionAtAwake => automaticBehaviour.trackPositionAtAwake;
	public static new TrackPositionXAtAwake trackPositionXAtAwake => automaticBehaviour.trackPositionXAtAwake;
	public static new TrackPositionYAtAwake trackPositionYAtAwake => automaticBehaviour.trackPositionYAtAwake;
	public static new TrackPositionZAtAwake trackPositionZAtAwake => automaticBehaviour.trackPositionZAtAwake;
	public static new TrackRotationAtAwake trackRotationAtAwake => automaticBehaviour.trackRotationAtAwake;
	public static new TrackLocalPositionZAtAwake trackLocalPositionZAtAwake => automaticBehaviour.trackLocalPositionZAtAwake;
	public static new TrackLocalPositionYAtAwake trackLocalPositionYAtAwake => automaticBehaviour.trackLocalPositionYAtAwake;
	public static new TrackEulerAngleYAtAwake trackEulerAngleYAtAwake => automaticBehaviour.trackEulerAngleYAtAwake;
	public static new TrackLocalPositionXAtAwake trackLocalPositionXAtAwake => automaticBehaviour.trackLocalPositionXAtAwake;
	public static new TrackLocalPositionAtAwake trackLocalPositionAtAwake => automaticBehaviour.trackLocalPositionAtAwake;
	public static new TrackLocalEulerAngleZAtAwake trackLocalEulerAngleZAtAwake => automaticBehaviour.trackLocalEulerAngleZAtAwake;
	public static new TrackLocalEulerAngleYAtAwake trackLocalEulerAngleYAtAwake => automaticBehaviour.trackLocalEulerAngleYAtAwake;
	public static new TrackLocalEulerAngleXAtAwake trackLocalEulerAngleXAtAwake => automaticBehaviour.trackLocalEulerAngleXAtAwake;
	public static new TrackLocalEulerAnglesAtAwake trackLocalEulerAnglesAtAwake => automaticBehaviour.trackLocalEulerAnglesAtAwake;
	public static new TrackEulerAngleZAtAwake trackEulerAngleZAtAwake => automaticBehaviour.trackEulerAngleZAtAwake;
	public static new TrackEulerAngleXAtAwake trackEulerAngleXAtAwake => automaticBehaviour.trackEulerAngleXAtAwake;
	public static new TrackEulerAnglesAtAwake trackEulerAnglesAtAwake => automaticBehaviour.trackEulerAnglesAtAwake;
	public static new TrackLocalRotationAtAwake trackLocalRotationAtAwake => automaticBehaviour.trackLocalRotationAtAwake;
	#endregion Transformations

	#region Components
	public static new TrackCapsuleCollidersAtAwake trackCapsuleCollidersAtAwake => automaticBehaviour.trackCapsuleCollidersAtAwake;
	#endregion Components
	#endregion Tracking
	#endregion Automatic Behaviours
	#endregion Utilities








	#region Plugins




	#region Steam Virtuality


	public static new Player player => automaticBehaviour.player;
	public static new Hand hand => automaticBehaviour.hand;
	public static new Controller controller => automaticBehaviour.controller;
	public static new Interactable interactable => automaticBehaviour.interactable;
	public static new Throwable throwable => automaticBehaviour.throwable;
	public static new VelocityEstimator velocityEstimator => automaticBehaviour.velocityEstimator;
	public static new ComplexThrowable complexThrowable => automaticBehaviour.complexThrowable;
	public static new Arrow arrow => automaticBehaviour.arrow;
	public static new ArrowHand arrowHand => automaticBehaviour.arrowHand;
	public static new Balloon balloon => automaticBehaviour.balloon;
	public static new Longbow longbow => automaticBehaviour.longbow;
	public static new ItemPackage itemPackage => automaticBehaviour.itemPackage;
	#endregion Steam Virtuality
	#endregion Plugins
}