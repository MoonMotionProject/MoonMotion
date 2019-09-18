using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Components Unity:
// #auto #tracking
// • provides this singleton behaviour with static access to its automatic behaviour's Unity components layer
public abstract class	SingletonBehaviourLayerComponentsUnity<SingletonBehaviourT> :
					SingletonBehaviourLayerCachedComponents<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
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
	public static new EdgeCollider2D edgeCollider => automaticBehaviour.edgeCollider;
}