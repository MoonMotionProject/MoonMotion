using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if STEAM_VIRTUALITY
using Valve.VR.InteractionSystem;
#endif

// Auto Behaviour Layer Components Moon Motion:
// #auto #tracking
// • provides this behaviour with automatically-connected properties to its game object's Moon Motion components and typical state of (and so on) those components
public abstract class	AutoBehaviourLayerComponentsMoonMotion<AutoBehaviourT> :
					AutoBehaviourLayerComponentsUnity<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	#if MOON_MOTION_TOOLKIT
	public TerrainResponse terrainResponse => cache<TerrainResponse>();
	public Powerup powerup => cache<Powerup>();
	public PowerupCollider powerupCollider => cache<PowerupCollider>();
	public PowerupObjectsToggler powerupObjectsToggler => cache<PowerupObjectsToggler>();
	public PowerupInstanceMethodsCaller powerupInstanceMethodsCaller => cache<PowerupInstanceMethodsCaller>();
	public StretchScalable stretchScalable => cache<StretchScalable>();
	#endif








	#region Utilities




	#region Auto Behaviours


	public Kinematizer kinematizer => cache<Kinematizer>();
	public Slower slower => cache<Slower>();
	public FaceMainCamera faceMainCamera => cache<FaceMainCamera>();
	public Hovering hovering => cache<Hovering>();
	public BasicSpinning basicSpinning => cache<BasicSpinning>();


	#region Trackings

	#region miscellaneous
	public TrackTimeOfAwake trackTimeOfAwake => cache<TrackTimeOfAwake>();
	public TrackLightIntensityAtAwake trackLightIntensityAtAwake => cache<TrackLightIntensityAtAwake>();
	public TrackAwake trackAwake => cache<TrackAwake>();
	public TrackColorAtAwake trackColorAtAwake => cache<TrackColorAtAwake>();
	#endregion miscellaneous

	#region Collideds
	public TrackCollideds trackCollideds => cache<TrackCollideds>();
	#endregion Collideds

	#region Components
	public TrackCapsuleCollidersAtAwake trackCapsuleCollidersAtAwake => cache<TrackCapsuleCollidersAtAwake>();
	#endregion Components

	#region Transformations
	public TrackLocalScaleAtAwake trackLocalScaleAtAwake => cache<TrackLocalScaleAtAwake>();
	public TrackLocalScaleXAtAwake trackLocalScaleXAtAwake => cache<TrackLocalScaleXAtAwake>();
	public TrackLocalScaleYAtAwake trackLocalScaleYAtAwake => cache<TrackLocalScaleYAtAwake>();
	public TrackLocalScaleZAtAwake trackLocalScaleZAtAwake => cache<TrackLocalScaleZAtAwake>();
	public TrackPositionAtAwake trackPositionAtAwake => cache<TrackPositionAtAwake>();
	public TrackPositionXAtAwake trackPositionXAtAwake => cache<TrackPositionXAtAwake>();
	public TrackPositionYAtAwake trackPositionYAtAwake => cache<TrackPositionYAtAwake>();
	public TrackPositionZAtAwake trackPositionZAtAwake => cache<TrackPositionZAtAwake>();
	public TrackRotationAtAwake trackRotationAtAwake => cache<TrackRotationAtAwake>();
	public TrackLocalPositionZAtAwake trackLocalPositionZAtAwake => cache<TrackLocalPositionZAtAwake>();
	public TrackLocalPositionYAtAwake trackLocalPositionYAtAwake => cache<TrackLocalPositionYAtAwake>();
	public TrackEulerAngleYAtAwake trackEulerAngleYAtAwake => cache<TrackEulerAngleYAtAwake>();
	public TrackLocalPositionXAtAwake trackLocalPositionXAtAwake => cache<TrackLocalPositionXAtAwake>();
	public TrackLocalPositionAtAwake trackLocalPositionAtAwake => cache<TrackLocalPositionAtAwake>();
	public TrackLocalEulerAngleZAtAwake trackLocalEulerAngleZAtAwake => cache<TrackLocalEulerAngleZAtAwake>();
	public TrackLocalEulerAngleYAtAwake trackLocalEulerAngleYAtAwake => cache<TrackLocalEulerAngleYAtAwake>();
	public TrackLocalEulerAngleXAtAwake trackLocalEulerAngleXAtAwake => cache<TrackLocalEulerAngleXAtAwake>();
	public TrackLocalEulerAnglesAtAwake trackLocalEulerAnglesAtAwake => cache<TrackLocalEulerAnglesAtAwake>();
	public TrackEulerAngleZAtAwake trackEulerAngleZAtAwake => cache<TrackEulerAngleZAtAwake>();
	public TrackEulerAngleXAtAwake trackEulerAngleXAtAwake => cache<TrackEulerAngleXAtAwake>();
	public TrackEulerAnglesAtAwake trackEulerAnglesAtAwake => cache<TrackEulerAnglesAtAwake>();
	public TrackLocalRotationAtAwake trackLocalRotationAtAwake => cache<TrackLocalRotationAtAwake>();
	#endregion Transformations
	#endregion Trackings
	#endregion Auto Behaviours
	#endregion Utilities









	#region Plugins




	#if STEAM_VIRTUALITY
	#region Steam Virtuality


	public Player player => cache<Player>();
	public Hand hand => cache<Hand>();
	public Interactable interactable => cache<Interactable>();
	public Throwable throwable => cache<Throwable>();
	public VelocityEstimator velocityEstimator => cache<VelocityEstimator>();
	public ComplexThrowable complexThrowable => cache<ComplexThrowable>();
	public Arrow arrow => cache<Arrow>();
	public ArrowHand arrowHand => cache<ArrowHand>();
	public Balloon balloon => cache<Balloon>();
	public Longbow longbow => cache<Longbow>();
	public ItemPackage itemPackage => cache<ItemPackage>();
	#endregion Steam Virtuality
	#endif
	#endregion Plugins
}