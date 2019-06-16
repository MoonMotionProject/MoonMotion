using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Automatic Behaviour Layer Components:
// #auto
// • provides this behaviour with automatically-connected properties to its game object's components and commonly-used state of (and so on) those components
public abstract class	AutomaticBehaviourLayerComponents<AutomaticBehaviourT> :
					AutomaticBehaviourLayerBehaviour<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	// Unity components //

	public new Renderer renderer
	{
		get {return cachedComponent<Renderer>();}
	}
	public new Rigidbody rigidbody
	{
		get {return cachedComponent<Rigidbody>();}
	}
	public new Collider collider
	{
		get {return cachedComponent<Collider>();}
	}
	public MeshCollider meshCollider
	{
		get {return cachedComponent<MeshCollider>();}
	}
	public BoxCollider boxCollider
	{
		get {return cachedComponent<BoxCollider>();}
	}
	public SphereCollider sphereCollider
	{
		get {return cachedComponent<SphereCollider>();}
	}
	public CapsuleCollider capsuleCollider
	{
		get {return cachedComponent<CapsuleCollider>();}
	}
	public TerrainCollider terrainCollider
	{
		get {return cachedComponent<TerrainCollider>();}
	}
	public WheelCollider wheelCollider
	{
		get {return cachedComponent<WheelCollider>();}
	}
	public AudioSource audioSource
	{
		get {return cachedComponent<AudioSource>();}
	}
	public LineRenderer lineRenderer
	{
		get {return cachedComponent<LineRenderer>();}
	}
	public TrailRenderer trailRenderer
	{
		get {return cachedComponent<TrailRenderer>();}
	}
	public ParticleSystem particlesSystem
	{
		get {return cachedComponent<ParticleSystem>();}
	}
	public MeshFilter meshFilter
	{
		get {return cachedComponent<MeshFilter>();}
	}
	public MeshRenderer meshRenderer
	{
		get {return cachedComponent<MeshRenderer>();}
	}
	public SkinnedMeshRenderer skinnedMeshRenderer
	{
		get {return cachedComponent<SkinnedMeshRenderer>();}
	}
	public TextMesh textMesh
	{
		get {return cachedComponent<TextMesh>();}
	}
	public new Animation animation
	{
		get {return cachedComponent<Animation>();}
	}
	public Animator animator
	{
		get {return cachedComponent<Animator>();}
	}
	public Terrain terrain
	{
		get {return cachedComponent<Terrain>();}
	}
	public WindZone windZone
	{
		get {return cachedComponent<WindZone>();}
	}
	public new Light light
	{
		get {return cachedComponent<Light>();}
	}
	public Cloth cloth
	{
		get {return cachedComponent<Cloth>();}
	}
	public new ConstantForce constantForce
	{
		get {return cachedComponent<ConstantForce>();}
	}
	public FixedJoint fixedJoint
	{
		get {return cachedComponent<FixedJoint>();}
	}
	public SpringJoint springJoint
	{
		get {return cachedComponent<SpringJoint>();}
	}
	public new HingeJoint hingeJoint
	{
		get {return cachedComponent<HingeJoint>();}
	}
	public ConfigurableJoint configurableJoint
	{
		get {return cachedComponent<ConfigurableJoint>();}
	}
	public new Camera camera
	{
		get {return cachedComponent<Camera>();}
	}
	public FlareLayer flareLayer
	{
		get {return cachedComponent<FlareLayer>();}
	}
	public OcclusionArea occlusionArea
	{
		get {return cachedComponent<OcclusionArea>();}
	}
	public OcclusionPortal occlusionPortal
	{
		get {return cachedComponent<OcclusionPortal>();}
	}


	// Moon Motion components - Moon Motion Toolkit - Utilities //

	public Kinematizer kinematizer
	{
		get {return cachedComponent<Kinematizer>();}
	}
	public Slower slower
	{
		get {return cachedComponent<Slower>();}
	}
	public FacePlayerCamera facePlayerCamera
	{
		get {return cachedComponent<FacePlayerCamera>();}
	}
	public Hovering hovering
	{
		get {return cachedComponent<Hovering>();}
	}
	public Spinning spinning
	{
		get {return cachedComponent<Spinning>();}
	}


	// Moon Motion components - Moon Motion Toolkit //

	public Locomotion locomotion
	{
		get {return cachedComponent<Locomotion>();}
	}
	public TerrainResponse terrainResponse
	{
		get {return cachedComponent<TerrainResponse>();}
	}
	public Powerup powerup
	{
		get {return cachedComponent<Powerup>();}
	}
	public PowerupCollider powerupCollider
	{
		get {return cachedComponent<PowerupCollider>();}
	}
	public PowerupObjectsToggler powerupObjectsToggler
	{
		get {return cachedComponent<PowerupObjectsToggler>();}
	}
	public PowerupInstanceMethodsCaller powerupInstanceMethodsCaller
	{
		get {return cachedComponent<PowerupInstanceMethodsCaller>();}
	}
	public StretchScalable stretchScalable
	{
		get {return cachedComponent<StretchScalable>();}
	}


	// Moon Motion components - Steam Virtuality //

	public Player player
	{
		get {return cachedComponent<Player>();}
	}
	public Hand hand
	{
		get {return cachedComponent<Hand>();}
	}
	public Controller controller
	{
		get {return cachedComponent<Controller>();}
	}
	public Interactable interactable
	{
		get {return cachedComponent<Interactable>();}
	}
	public Throwable throwable
	{
		get {return cachedComponent<Throwable>();}
	}
	public VelocityEstimator velocityEstimator
	{
		get {return cachedComponent<VelocityEstimator>();}
	}
	public ComplexThrowable complexThrowable
	{
		get {return cachedComponent<ComplexThrowable>();}
	}
	public Arrow arrow
	{
		get {return cachedComponent<Arrow>();}
	}
	public ArrowHand arrowHand
	{
		get {return cachedComponent<ArrowHand>();}
	}
	public Balloon balloon
	{
		get {return cachedComponent<Balloon>();}
	}
	public Longbow longbow
	{
		get {return cachedComponent<Longbow>();}
	}
	public ItemPackage itemPackage
	{
		get {return cachedComponent<ItemPackage>();}
	}
}