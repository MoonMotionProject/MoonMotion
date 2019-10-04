using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Components Unity:
// #auto
// • provides this behaviour with automatically-connected properties to its game object's Unity components and typical state of (and so on) those components
public abstract class	AutoBehaviourLayerComponentsUnity<AutoBehaviourT> :
					AutoBehaviourLayerCachedComponents<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	public new Renderer renderer => cache<Renderer>();
	public     Renderer ensuredRenderer => cache<Renderer>(true);
	public new Rigidbody rigidbody => cache<Rigidbody>();
	public     Rigidbody ensuredRigidbody => cache<Rigidbody>(true);
	public new Collider collider => cache<Collider>();
	public     Collider ensuredCollider => cache<Collider>(true);
	public     MeshCollider meshCollider => cache<MeshCollider>();
	public     MeshCollider ensuredMeshCollider => cache<MeshCollider>(true);
	public     BoxCollider boxCollider => cache<BoxCollider>();
	public     BoxCollider ensuredBoxCollider => cache<BoxCollider>(true);
	public     SphereCollider sphereCollider => cache<SphereCollider>();
	public     SphereCollider ensuredSphereCollider => cache<SphereCollider>(true);
	public     CapsuleCollider capsuleCollider => cache<CapsuleCollider>();
	public     CapsuleCollider ensuredCapsuleCollider => cache<CapsuleCollider>(true);
	public     TerrainCollider terrainCollider => cache<TerrainCollider>();
	public     TerrainCollider ensuredTerrainCollider => cache<TerrainCollider>(true);
	public     WheelCollider wheelCollider => cache<WheelCollider>();
	public     WheelCollider ensuredWheelCollider => cache<WheelCollider>(true);
	public     AudioSource audioSource => cache<AudioSource>();
	public     AudioSource ensuredAudioSource => cache<AudioSource>(true);
	public     LineRenderer lineRenderer => cache<LineRenderer>();
	public     LineRenderer ensuredLineRenderer => cache<LineRenderer>(true);
	public     TrailRenderer trailRenderer => cache<TrailRenderer>();
	public     TrailRenderer ensuredTrailRenderer => cache<TrailRenderer>(true);
	public     ParticleSystem particlesSystem => cache<ParticleSystem>();
	public     ParticleSystem ensuredParticlesSystem => cache<ParticleSystem>(true);
	public     MeshFilter meshFilter => cache<MeshFilter>();
	public     MeshFilter ensuredMeshFilter => cache<MeshFilter>(true);
	public     MeshRenderer meshRenderer => cache<MeshRenderer>();
	public     MeshRenderer ensuredMeshRenderer => cache<MeshRenderer>(true);
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
	public     EdgeCollider2D edgeCollider => cache<EdgeCollider2D>();
}