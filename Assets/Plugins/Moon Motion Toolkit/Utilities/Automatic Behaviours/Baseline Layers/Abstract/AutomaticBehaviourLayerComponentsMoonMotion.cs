using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Automatic Behaviour Layer Components Moon Motion:
// #auto #tracking
// • provides this behaviour with automatically-connected properties to its game object's Moon Motion components and typical state of (and so on) those components
public abstract class	AutomaticBehaviourLayerComponentsMoonMotion<AutomaticBehaviourT> :
					AutomaticBehaviourLayerComponentsUnity<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	public Locomotion locomotion => cache<Locomotion>();
	public TerrainResponse terrainResponse => cache<TerrainResponse>();
	public Powerup powerup => cache<Powerup>();
	public PowerupCollider powerupCollider => cache<PowerupCollider>();
	public PowerupObjectsToggler powerupObjectsToggler => cache<PowerupObjectsToggler>();
	public PowerupInstanceMethodsCaller powerupInstanceMethodsCaller => cache<PowerupInstanceMethodsCaller>();
	public StretchScalable stretchScalable => cache<StretchScalable>();








	#region Utilities




	#region Automatic Behaviours


	public Kinematizer kinematizer => cache<Kinematizer>();
	public Slower slower => cache<Slower>();
	public FacePlayerCamera facePlayerCamera => cache<FacePlayerCamera>();
	public Hovering hovering => cache<Hovering>();
	public Spinning spinning => cache<Spinning>();


	#region Trackings

	#region miscellaneous
	public TrackTimeOfAwake trackTimeOfAwake => cache<TrackTimeOfAwake>();
	public TrackLightIntensityAtAwake trackLightIntensityAtAwake => cache<TrackLightIntensityAtAwake>();
	public TrackAwake trackAwake => cache<TrackAwake>();
	#endregion miscellaneous

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

	#region Components
	public TrackCapsuleCollidersAtAwake trackCapsuleCollidersAtAwake => cache<TrackCapsuleCollidersAtAwake>();
	#endregion Components
	#endregion Trackings
	#endregion Automatic Behaviours
	#endregion Utilities









	#region Plugins




	#region Steam Virtuality


	public Player player => cache<Player>();
	public Hand hand => cache<Hand>();
	public Controller controller => cache<Controller>();
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
	#endregion Plugins
}