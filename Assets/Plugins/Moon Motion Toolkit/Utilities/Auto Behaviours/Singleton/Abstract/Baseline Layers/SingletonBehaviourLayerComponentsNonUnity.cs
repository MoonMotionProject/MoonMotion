using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if STEAM_VIRTUALITY
using Valve.VR.InteractionSystem;
#endif
#if NAV_MESH_COMPONENTS
using UnityEngine.AI;
#endif

// Singleton Behaviour Layer Components Moon Motion:
// #auto #tracking #unitology
// • provides this singleton behaviour with static access to its auto behaviour's nonUnity components layer
public abstract class	SingletonBehaviourLayerComponentsNonUnity<SingletonBehaviourT> :
					SingletonBehaviourLayerComponentsUnity<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region Moon Motion Toolkit
	#if MOON_MOTION_TOOLKIT
	public static new TerrainResponse terrainResponse => autoBehaviour.terrainResponse;
	public static new Powerup powerup => autoBehaviour.powerup;
	public static new PowerupCollider powerupCollider => autoBehaviour.powerupCollider;
	public static new PowerupObjectsToggler powerupObjectsToggler => autoBehaviour.powerupObjectsToggler;
	public static new PowerupInstanceMethodsCaller powerupInstanceMethodsCaller => autoBehaviour.powerupInstanceMethodsCaller;
	public static new StretchScalable stretchScalable => autoBehaviour.stretchScalable;
	#endif
	#endregion Moon Motion Toolkit








	#region Utilities




	#region Auto Behaviours

	
	public static new DefaultAutoBehaviour defaultAutoBehaviour => autoBehaviour.defaultAutoBehaviour;
	public static new DefaultAutoBehaviour ensuredDefaultAutoBehaviour() => autoBehaviour.ensuredDefaultAutoBehaviour();
	public static new Kinematizer kinematizer => autoBehaviour.kinematizer;
	public static new Slower slower => autoBehaviour.slower;
	public static new FaceMainCamera faceMainCamera => autoBehaviour.faceMainCamera;
	public static new Hovering hovering => autoBehaviour.hovering;
	public static new BasicSpinning basicSpinning => autoBehaviour.basicSpinning;


	#region spawning
	
	#if ODIN_INSPECTOR
	public static new Spawner spawner => autoBehaviour.spawner;
	public static new Spawner correspondingSpawner => autoBehaviour.correspondingSpawner;
	public static new Spawner ensuredCorrespondingSpawner() => autoBehaviour.ensuredCorrespondingSpawner();
	public static new Spawner lodespondingSpawner => autoBehaviour.lodespondingSpawner;
	public static new Spawner ensuredLodespondingSpawner() => autoBehaviour.ensuredLodespondingSpawner();
	#endif
	public static new SpawnPoint spawnPoint => autoBehaviour.spawnPoint;
	public static new SpawnPoint correspondingSpawnPoint => autoBehaviour.correspondingSpawnPoint;
	public static new SpawnPoint ensuredCorrespondingSpawnPoint() => autoBehaviour.ensuredCorrespondingSpawnPoint();
	public static new SpawnPoint lodespondingSpawnPoint => autoBehaviour.lodespondingSpawnPoint;
	public static new SpawnPoint ensuredLodespondingSpawnPoint() => autoBehaviour.ensuredLodespondingSpawnPoint();
	#endregion spawning


	#region Tracking

	#region miscellaneous
	public static new TrackTimeOfAwake trackTimeOfAwake => autoBehaviour.trackTimeOfAwake;
	public static new TrackLightIntensityAtAwake trackLightIntensityAtAwake => autoBehaviour.trackLightIntensityAtAwake;
	public static new TrackAwake trackAwake => autoBehaviour.trackAwake;
	public static new TrackColorAtAwake trackColorAtAwake => autoBehaviour.trackColorAtAwake;
	public static new TrackStart trackStart => autoBehaviour.trackStart;
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







	
	#region Navmesh Components
	#if NAV_MESH_COMPONENTS
	public static new NavMeshAgent navmeshAgent => autoBehaviour.navmeshAgent;
	public static new Bipedation bipedation => autoBehaviour.bipedation;
	#endif
	#endregion Navmesh Components









	#region Unitology
	#if UNITOLOGY
	public static new Unit unit => autoBehaviour.unit;
	public static new Unit correspondingUnit => autoBehaviour.correspondingUnit;
	public static new Unit ensuredCorrespondingUnit() => autoBehaviour.ensuredCorrespondingUnit();
	public static new UnitEffectsPoint unitEffectsPoint => autoBehaviour.unitEffectsPoint;
	public static new UnitEffectsPoint correspondingUnitEffectsPoint => autoBehaviour.correspondingUnitEffectsPoint;
	public static new UnitEffectsPoint ensuredCorrespondingUnitEffectsPoint() => autoBehaviour.ensuredCorrespondingUnitEffectsPoint();
	public static new UnitEffectsPoint lodespondingUnitEffectsPoint => autoBehaviour.lodespondingUnitEffectsPoint;
	public static new UnitEffectsPoint ensuredLodespondingUnitEffectsPoint() => autoBehaviour.ensuredLodespondingUnitEffectsPoint();
	public static new DescendantUnitsAllegior descendantUnitsAllegior => autoBehaviour.descendantUnitsAllegior;
	public static new DescendantUnitsAllegior correspondingDescendantUnitsAllegior => autoBehaviour.correspondingDescendantUnitsAllegior;
	public static new UnitTargetPoint unitTargetPoint => autoBehaviour.unitTargetPoint;
	public static new UnitTargetPoint correspondingUnitTargetPoint => autoBehaviour.correspondingUnitTargetPoint;
	public static new UnitTargetPoint ensuredCorrespondingUnitTargetPoint() => autoBehaviour.ensuredCorrespondingUnitTargetPoint();
	public static new UnitTargetPoint lodespondingUnitTargetPoint => autoBehaviour.lodespondingUnitTargetPoint;
	public static new UnitTargetPoint ensuredLodespondingUnitTargetPoint() => autoBehaviour.ensuredLodespondingUnitTargetPoint();
	public static new UnitTargetCollidance unitTargetCollidance => autoBehaviour.unitTargetCollidance;
	public static new UnitTargetCollidance correspondingUnitTargetCollidance => autoBehaviour.correspondingUnitTargetCollidance;
	public static new UnitTargetCollidance ensuredCorrespondingUnitTargetCollidance() => autoBehaviour.ensuredCorrespondingUnitTargetCollidance();
	public static new UnitTargetCollidance lodespondingUnitTargetCollidance => autoBehaviour.lodespondingUnitTargetCollidance;
	public static new UnitTargetCollidance ensuredLodespondingUnitTargetCollidance() => autoBehaviour.ensuredLodespondingUnitTargetCollidance();
	public static new UnitAwareness unitAwareness
		=> autoBehaviour.unitAwareness;
	public static new UnitAwareness correspondingUnitAwareness
		=> autoBehaviour.correspondingUnitAwareness;
	public static new UnitAwareness ensuredCorrespondingUnitAwareness()
		=> autoBehaviour.ensuredCorrespondingUnitAwareness();
	public static new UnitAwareness lodespondingUnitAwareness
		=> autoBehaviour.lodespondingUnitAwareness;
	public static new UnitAwareness ensuredLodespondingUnitAwareness()
		=> autoBehaviour.ensuredLodespondingUnitAwareness();
	public static new UnitTargetingPoint unitTargetingPoint => autoBehaviour.unitTargetingPoint;
	public static new UnitTargetingPoint correspondingUnitTargetingPoint => autoBehaviour.correspondingUnitTargetingPoint;
	public static new UnitTargetingPoint ensuredCorrespondingUnitTargetingPoint() => autoBehaviour.ensuredCorrespondingUnitTargetingPoint();
	public static new UnitTargetingPoint lodespondingUnitTargetingPoint => autoBehaviour.lodespondingUnitTargetingPoint;
	public static new UnitTargetingPoint ensuredLodespondingUnitTargetingPoint() => autoBehaviour.ensuredLodespondingUnitTargetingPoint();
	#endif
	#endregion Unitology








	#region Steam Virtuality
	#if STEAM_VIRTUALITY
	public static new Player player => autoBehaviour.player;
	public static new Hand hand => autoBehaviour.hand;
	public static new Interactable interactable => autoBehaviour.interactable;
	public static new Throwable throwable => autoBehaviour.throwable;
	public static new VelocityEstimator velocityEstimator => autoBehaviour.velocityEstimator;
	public static new ComplexThrowable complexThrowable => autoBehaviour.complexThrowable;
	public static new Arrow arrow => autoBehaviour.arrow;
	public static new ArrowHand arrowHand => autoBehaviour.arrowHand;
	public static new Balloon balloon => autoBehaviour.balloon;
	public static new Longbow longbow => autoBehaviour.longbow;
	public static new ItemPackage itemPackage => autoBehaviour.itemPackage;
	#endif
	#endregion Steam Virtuality
}