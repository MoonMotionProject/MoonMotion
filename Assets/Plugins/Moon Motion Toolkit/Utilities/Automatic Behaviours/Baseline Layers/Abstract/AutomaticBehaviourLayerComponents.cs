using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Automatic Behaviour Layer Components:
// #auto
// • provides this behaviour with automatically-connected properties to its game object's components and typical state of (and so on) those components
public abstract class	AutomaticBehaviourLayerComponents<AutomaticBehaviourT> :
					AutomaticBehaviourLayerMonoBehaviour<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	// Unity //

	public new Renderer renderer => cache<Renderer>();
	public new Rigidbody rigidbody => cache<Rigidbody>();
	public new Collider collider => cache<Collider>();
	public     MeshCollider meshCollider => cache<MeshCollider>();
	public     BoxCollider boxCollider => cache<BoxCollider>();
	public     SphereCollider sphereCollider => cache<SphereCollider>();
	public     CapsuleCollider capsuleCollider => cache<CapsuleCollider>();
	public     TerrainCollider terrainCollider => cache<TerrainCollider>();
	public     WheelCollider wheelCollider => cache<WheelCollider>();
	public     AudioSource audioSource => cache<AudioSource>();
	public     LineRenderer lineRenderer => cache<LineRenderer>();
	public     TrailRenderer trailRenderer => cache<TrailRenderer>();
	public     ParticleSystem particlesSystem => cache<ParticleSystem>();
	public     MeshFilter meshFilter => cache<MeshFilter>();
	public     MeshRenderer meshRenderer => cache<MeshRenderer>();
	public     SkinnedMeshRenderer skinnedMeshRenderer => cache<SkinnedMeshRenderer>();
	public     TextMesh textMesh => cache<TextMesh>();
	public new Animation animation => cache<Animation>();
	public     Animator animator => cache<Animator>();
	public     Terrain terrain => cache<Terrain>();
	public     WindZone windZone => cache<WindZone>();
	public new Light light => cache<Light>();
	public     Cloth cloth => cache<Cloth>();
	public new ConstantForce constantForce => cache<ConstantForce>();
	public     FixedJoint fixedJoint => cache<FixedJoint>();
	public     SpringJoint springJoint => cache<SpringJoint>();
	public new HingeJoint hingeJoint => cache<HingeJoint>();
	public     ConfigurableJoint configurableJoint => cache<ConfigurableJoint>();
	public new Camera camera => cache<Camera>();
	public     FlareLayer flareLayer => cache<FlareLayer>();
	public     OcclusionArea occlusionArea => cache<OcclusionArea>();
	public     OcclusionPortal occlusionPortal => cache<OcclusionPortal>();


	// Moon Motion - Moon Motion Toolkit - Utilities - Automatic Behaviours //

	public Kinematizer kinematizer => cache<Kinematizer>();
	public Slower slower => cache<Slower>();
	public FacePlayerCamera facePlayerCamera => cache<FacePlayerCamera>();
	public Hovering hovering => cache<Hovering>();
	public Spinning spinning => cache<Spinning>();


	// Moon Motion - Moon Motion Toolkit - Utilities - Automatic Behaviours - Trackings //

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
	public TrackTimeOfAwake trackTimeOfAwake => cache<TrackTimeOfAwake>();
	public TrackLightIntensityAtAwake trackLightIntensityAtAwake => cache<TrackLightIntensityAtAwake>();
	public TrackAwake trackAwake => cache<TrackAwake>();
	public TrackLocalRotationAtAwake trackLocalRotationAtAwake => cache<TrackLocalRotationAtAwake>();


	// Moon Motion - Moon Motion Toolkit - nonUtilities //

	public Locomotion locomotion => cache<Locomotion>();
	public TerrainResponse terrainResponse => cache<TerrainResponse>();
	public Powerup powerup => cache<Powerup>();
	public PowerupCollider powerupCollider => cache<PowerupCollider>();
	public PowerupObjectsToggler powerupObjectsToggler => cache<PowerupObjectsToggler>();
	public PowerupInstanceMethodsCaller powerupInstanceMethodsCaller => cache<PowerupInstanceMethodsCaller>();
	public StretchScalable stretchScalable => cache<StretchScalable>();


	// Moon Motion - Steam Virtuality //

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
}