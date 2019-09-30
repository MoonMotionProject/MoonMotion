using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Components Unity:
// #auto
// • provides this singleton behaviour with static access to its auto behaviour's Unity components layer
public abstract class	SingletonBehaviourLayerComponentsUnity<SingletonBehaviourT> :
					SingletonBehaviourLayerCachedComponents<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	public static new Renderer renderer => autoBehaviour.renderer;
	public static new Rigidbody rigidbody => autoBehaviour.rigidbody;
	public static new Collider collider => autoBehaviour.collider;
	public static new MeshCollider meshCollider => autoBehaviour.meshCollider;
	public static new BoxCollider boxCollider => autoBehaviour.boxCollider;
	public static new SphereCollider sphereCollider => autoBehaviour.sphereCollider;
	public static new CapsuleCollider capsuleCollider => autoBehaviour.capsuleCollider;
	public static new TerrainCollider terrainCollider => autoBehaviour.terrainCollider;
	public static new WheelCollider wheelCollider => autoBehaviour.wheelCollider;
	public static new AudioSource audioSource => autoBehaviour.audioSource;
	public static new LineRenderer lineRenderer => autoBehaviour.lineRenderer;
	public static new TrailRenderer trailRenderer => autoBehaviour.trailRenderer;
	public static new ParticleSystem particlesSystem => autoBehaviour.particlesSystem;
	public static new MeshFilter meshFilter => autoBehaviour.meshFilter;
	public static new MeshRenderer meshRenderer => autoBehaviour.meshRenderer;
	public static new SkinnedMeshRenderer skinnedMeshRenderer => autoBehaviour.skinnedMeshRenderer;
	public static new TextMesh textMesh => autoBehaviour.textMesh;
	public static new Animation animation => autoBehaviour.animation;
	public static new Animator animator => autoBehaviour.animator;
	public static new Terrain terrain => autoBehaviour.terrain;
	public static new WindZone windZone => autoBehaviour.windZone;
	public static new Light light => autoBehaviour.light;
	public static new Cloth cloth => autoBehaviour.cloth;
	public static new ConstantForce constantForce => autoBehaviour.constantForce;
	public static new FixedJoint fixedJoint => autoBehaviour.fixedJoint;
	public static new SpringJoint springJoint => autoBehaviour.springJoint;
	public static new HingeJoint hingeJoint => autoBehaviour.hingeJoint;
	public static new ConfigurableJoint configurableJoint => autoBehaviour.configurableJoint;
	public static new Camera camera => autoBehaviour.camera;
	public static new FlareLayer flareLayer => autoBehaviour.flareLayer;
	public static new OcclusionArea occlusionArea => autoBehaviour.occlusionArea;
	public static new OcclusionPortal occlusionPortal => autoBehaviour.occlusionPortal;
	public static new EdgeCollider2D edgeCollider => autoBehaviour.edgeCollider;
}