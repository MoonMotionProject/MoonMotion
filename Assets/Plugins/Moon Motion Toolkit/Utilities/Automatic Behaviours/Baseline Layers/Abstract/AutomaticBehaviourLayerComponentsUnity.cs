using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Automatic Behaviour Layer Components Unity:
// #auto
// • provides this behaviour with automatically-connected properties to its game object's Unity components and typical state of (and so on) those components
public abstract class	AutomaticBehaviourLayerComponentsUnity<AutomaticBehaviourT> :
					AutomaticBehaviourLayerMonoBehaviour<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
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
}