using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Singleton Behaviour Layer Components:
// #auto
// • provides this singleton behaviour with static access to its automatic behaviour's components layer
public abstract class	SingletonBehaviourLayerComponents<SingletonBehaviourT> :
					SingletonBehaviourLayerMonoBehaviour<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	// Unity //

	public static new Renderer renderer => automaticBehaviour.renderer;
	public static new Rigidbody rigidbody => automaticBehaviour.rigidbody;
	public static new Collider collider => automaticBehaviour.collider;
	public static new MeshCollider meshCollider => automaticBehaviour.meshCollider;
	public static new BoxCollider boxCollider => automaticBehaviour.boxCollider;
	public static new SphereCollider sphereCollider => automaticBehaviour.sphereCollider;
	public static new CapsuleCollider capsuleCollider => automaticBehaviour.capsuleCollider;
	public static new TerrainCollider terrainCollider => automaticBehaviour.terrainCollider;
	public static new WheelCollider wheelCollider => automaticBehaviour.wheelCollider;
	public static new AudioSource audioSource => automaticBehaviour.audioSource;
	public static new LineRenderer lineRenderer => automaticBehaviour.lineRenderer;
	public static new TrailRenderer trailRenderer => automaticBehaviour.trailRenderer;
	public static new ParticleSystem particlesSystem => automaticBehaviour.particlesSystem;
	public static new MeshFilter meshFilter => automaticBehaviour.meshFilter;
	public static new MeshRenderer meshRenderer => automaticBehaviour.meshRenderer;
	public static new SkinnedMeshRenderer skinnedMeshRenderer => automaticBehaviour.skinnedMeshRenderer;
	public static new TextMesh textMesh => automaticBehaviour.textMesh;
	public static new Animation animation => automaticBehaviour.animation;
	public static new Animator animator => automaticBehaviour.animator;
	public static new Terrain terrain => automaticBehaviour.terrain;
	public static new WindZone windZone => automaticBehaviour.windZone;
	public static new Light light => automaticBehaviour.light;
	public static new Cloth cloth => automaticBehaviour.cloth;
	public static new ConstantForce constantForce => automaticBehaviour.constantForce;
	public static new FixedJoint fixedJoint => automaticBehaviour.fixedJoint;
	public static new SpringJoint springJoint => automaticBehaviour.springJoint;
	public static new HingeJoint hingeJoint => automaticBehaviour.hingeJoint;
	public static new ConfigurableJoint configurableJoint => automaticBehaviour.configurableJoint;
	public static new Camera camera => automaticBehaviour.camera;
	public static new FlareLayer flareLayer => automaticBehaviour.flareLayer;
	public static new OcclusionArea occlusionArea => automaticBehaviour.occlusionArea;
	public static new OcclusionPortal occlusionPortal => automaticBehaviour.occlusionPortal;


	// Moon Motion - Moon Motion Toolkit - Utilities - Automatic Behaviours //

	public static new Kinematizer kinematizer => automaticBehaviour.kinematizer;
	public static new Slower slower => automaticBehaviour.slower;
	public static new FacePlayerCamera facePlayerCamera => automaticBehaviour.facePlayerCamera;
	public static new Hovering hovering => automaticBehaviour.hovering;
	public static new Spinning spinning => automaticBehaviour.spinning;


	// Moon Motion - Moon Motion Toolkit - Utilities - Automatic Behaviours - Trackings //

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
	public static new TrackTimeOfAwake trackTimeOfAwake => automaticBehaviour.trackTimeOfAwake;
	public static new TrackLightIntensityAtAwake trackLightIntensityAtAwake => automaticBehaviour.trackLightIntensityAtAwake;
	public static new TrackAwake trackAwake => automaticBehaviour.trackAwake;
	public static new TrackLocalRotationAtAwake trackLocalRotationAtAwake => automaticBehaviour.trackLocalRotationAtAwake;


	// Moon Motion - Moon Motion Toolkit - nonUtilities //

	public static new Locomotion locomotion => automaticBehaviour.locomotion;
	public static new TerrainResponse terrainResponse => automaticBehaviour.terrainResponse;
	public static new Powerup powerup => automaticBehaviour.powerup;
	public static new PowerupCollider powerupCollider => automaticBehaviour.powerupCollider;
	public static new PowerupObjectsToggler powerupObjectsToggler => automaticBehaviour.powerupObjectsToggler;
	public static new PowerupInstanceMethodsCaller powerupInstanceMethodsCaller => automaticBehaviour.powerupInstanceMethodsCaller;
	public static new StretchScalable stretchScalable => automaticBehaviour.stretchScalable;


	// Moon Motion - Steam Virtuality //

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
}