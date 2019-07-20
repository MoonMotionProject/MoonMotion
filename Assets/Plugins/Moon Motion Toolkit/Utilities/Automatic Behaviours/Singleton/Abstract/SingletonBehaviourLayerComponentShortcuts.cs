using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Singleton Behaviour Layer Component Shortcuts:
// #auto #shortcuts
// • provides this singleton behaviour with static access to its automatic behaviour's component shortcuts layer
public abstract class SingletonBehaviourLayerComponentShortcuts<SingletonBehaviourT> :
					SingletonBehaviourLayerComponents<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region Unity


	#region Renderer

	#region enablement
	public static new bool rendererEnablement => automaticBehaviour.rendererEnablement;
	public static new Renderer setRendererEnablementTo(bool boolean)
		=> automaticBehaviour.setRendererEnablementTo(boolean);
	public static new Renderer enableRenderer()
		=> automaticBehaviour.enableRenderer();
	public static new Renderer disableRenderer()
		=> automaticBehaviour.disableRenderer();
	public static new Renderer toggleRendererEnablementBy(Toggling toggling)
		=> automaticBehaviour.toggleRendererEnablementBy(toggling);
	#endregion enablement

	#region material
	public static new Material material => automaticBehaviour.material;
	public static new Renderer setMaterialTo(Material material)
		=> automaticBehaviour.setMaterialTo(material);
	public static new Material sharedMaterial => automaticBehaviour.sharedMaterial;
	public static new Renderer setSharedMaterialTo(Material sharedMaterial)
		=> automaticBehaviour.setSharedMaterialTo(material);
	#endregion material

	#region shadowcasting
	public static new Renderer setShadowcastingTo(ShadowCastingMode shadowcasting)
		=> automaticBehaviour.setShadowcastingTo(shadowcasting);
	public static new Renderer shadowcast()
		=> automaticBehaviour.shadowcast();
	public static new Renderer nonshadowcast()
		=> automaticBehaviour.nonshadowcast();
	#endregion shadowcasting

	#region shadowability
	public static new Renderer setShadowabilityTo(bool shadowability)
		=> automaticBehaviour.setShadowabilityTo(shadowability);
	public static new Renderer shadowable()
		=> automaticBehaviour.shadowable();
	public static new Renderer nonshadowable()
		=> automaticBehaviour.nonshadowable();
	#endregion shadowability
	#endregion Renderer


	#region Rigidbody

	#region kinematicity
	public static new bool kinematicity => automaticBehaviour.kinematicity;
	public static new Rigidbody setKinematicityTo(bool kinematicity, bool boolean = true)
		=> automaticBehaviour.setKinematicityTo(kinematicity, boolean);
	public static new Rigidbody kinematize(bool boolean = true)
		=> automaticBehaviour.kinematize(boolean);
	public static new Rigidbody nonkinematize(bool boolean = true)
		=> automaticBehaviour.nonkinematize(boolean);
	#endregion kinematicity

	#region gravitization
	public static new bool gravitization => automaticBehaviour.gravitization;
	public static new Rigidbody setGravitizationTo(bool gravitization, bool boolean = true)
		=> automaticBehaviour.setGravitizationTo(gravitization, boolean);
	public static new Rigidbody gravitize(bool boolean = true)
		=> automaticBehaviour.gravitize(boolean);
	public static new Rigidbody nongravitize(bool boolean = true)
		=> automaticBehaviour.nongravitize(boolean);
	#endregion gravitization

	#region velocity vectrals
	public static new Vector3 velocityDirection => automaticBehaviour.velocityDirection;
	public static new Rigidbody setVelocityDirectionTo(Vector3 direction, bool boolean = true)
		=> automaticBehaviour.setVelocityDirectionTo(direction, boolean);
	public static new Vector3 angularVelocityAngling => automaticBehaviour.angularVelocityAngling;
	public static new Rigidbody setAngularVelocityAnglingTo(Vector3 angling, bool boolean = true)
		=> automaticBehaviour.setAngularVelocityAnglingTo(angling, boolean);
	#endregion velocity vectrals

	#region speeds
	public static new float speed => automaticBehaviour.speed;
	public static new Rigidbody setSpeedTo(float speed, bool boolean = true)
		=> automaticBehaviour.setSpeedTo(speed, boolean);
	public static new Rigidbody honeSpeed(float honingTarget, float honingAmount, bool boolean = true)
		=> automaticBehaviour.honeSpeed(honingTarget, honingAmount, boolean);
	public static new Rigidbody slowSpeedBy(float speedReduction, bool boolean = true)
		=> automaticBehaviour.slowSpeedBy(speedReduction, boolean);
	public static new float angularSpeed => automaticBehaviour.angularSpeed;
	public static new Rigidbody setAngularSpeedTo(float angularSpeed, bool boolean = true)
		=> automaticBehaviour.setAngularSpeedTo(angularSpeed, boolean);
	#endregion speed

	#region velocities
	public static new Vector3 velocity => automaticBehaviour.velocity;
	public static new Vector3 angularVelocity => automaticBehaviour.angularVelocity;
	public static new Rigidbody setVelocityTo(Vector3 velocity, bool boolean = true)
		=> automaticBehaviour.setVelocityTo(velocity, boolean);
	public static new Rigidbody setAngularVelocityTo(Vector3 angularVelocity, bool boolean = true)
		=> automaticBehaviour.setAngularVelocityTo(angularVelocity, boolean);
	public static new Rigidbody setVelocitiesTo(Vector3 directionalVelocity, Vector3 angularVelocity, bool boolean = true)
		=> automaticBehaviour.setVelocitiesTo(directionalVelocity, angularVelocity, boolean);
	public static new Rigidbody setVelocitiesTo(Vector3 velocity, bool boolean = true)
		=> automaticBehaviour.setVelocitiesTo(velocity, boolean);
	public static new Rigidbody zeroVelocity(bool boolean = true)
		=> automaticBehaviour.zeroVelocity(boolean);
	public static new Rigidbody zeroAngularVelocity(bool boolean = true)
		=> automaticBehaviour.zeroAngularVelocity(boolean);
	public static new Rigidbody zeroVelocities(bool boolean = true)
		=> automaticBehaviour.zeroVelocities(boolean);
	#endregion velocities
	#endregion Rigidbody


	#region AudioSource

	#region audio
	public static new AudioClip audio => automaticBehaviour.audio;
	public static new AudioSource setAudioTo(AudioClip targetAudio, bool boolean = true)
		=> automaticBehaviour.setAudioTo(targetAudio, boolean);
	public static new float audioDuration => automaticBehaviour.audioDuration;
	public static new float audioVolume => automaticBehaviour.audioVolume;
	public static new AudioSource setAudioVolumeTo(float targetVolume, bool boolean = true)
		=> automaticBehaviour.setAudioVolumeTo(targetVolume, boolean);
	#endregion audio

	#region playing
	public static new bool audioPlaying => automaticBehaviour.audioPlaying;
	public static new AudioSource audioPlay()
		=> automaticBehaviour.audioPlay();
	public static new AudioSource audioStop()
		=> automaticBehaviour.audioStop();
	public static new float audioTime => automaticBehaviour.audioTime;
	public static new AudioSource setAudioTimeTo(float targetTime, bool boolean = true)
		=> automaticBehaviour.setAudioTimeTo(targetTime, boolean);
	#endregion playing
	#endregion AudioSource


	#region MeshFilter
	public static new Mesh mesh => automaticBehaviour.mesh;
	public static new MeshFilter setMeshTo(Mesh mesh, bool boolean = true)
		=> automaticBehaviour.setMeshTo(mesh, boolean);
	public static new Mesh sharedMesh => automaticBehaviour.sharedMesh;
	public static new MeshFilter setSharedMeshTo(Mesh mesh, bool boolean = true)
		=> automaticBehaviour.setSharedMeshTo(mesh, boolean);
	public static new Mesh sharedMeshOtherwiseMesh => sharedMesh ?? mesh;
	#endregion MeshFilter


	#region Light

	#region intensities
	public static new float lightIntensity => automaticBehaviour.lightIntensity;
	public static new Light setLightIntensityTo(float targetIntensity)
		=> automaticBehaviour.setLightIntensityTo(targetIntensity);
	#endregion intensities
	#endregion Light
	#endregion Unity




	#region Moon Motion - Moon Motion Toolkit - Utilities - Automatic Behaviours - Trackings
	public static new Vector3 localScaleAwake => automaticBehaviour.localScaleAwake;
	public static new float localScaleXAwake => automaticBehaviour.localScaleXAwake;
	public static new float localScaleYAwake => automaticBehaviour.localScaleYAwake;
	public static new float localScaleZAwake => automaticBehaviour.localScaleZAwake;
	public static new Vector3 positionAwake => automaticBehaviour.positionAwake;
	public static new float positionXAwake => automaticBehaviour.positionXAwake;
	public static new float positionYAwake => automaticBehaviour.positionYAwake;
	public static new float positionZAwake => automaticBehaviour.positionZAwake;
	public static new Quaternion rotationAwake => automaticBehaviour.rotationAwake;
	public static new float localPositionZAwake => automaticBehaviour.localPositionZAwake;
	public static new float localPositionYAwake => automaticBehaviour.localPositionYAwake;
	public static new float eulerAngleYAwake => automaticBehaviour.eulerAngleYAwake;
	public static new float localPositionXAwake => automaticBehaviour.localPositionXAwake;
	public static new Vector3 localPositionAwake => automaticBehaviour.localPositionAwake;
	public static new float localEulerAngleZAwake => automaticBehaviour.localEulerAngleZAwake;
	public static new float localEulerAngleYAwake => automaticBehaviour.localEulerAngleYAwake;
	public static new float localEulerAngleXAwake => automaticBehaviour.localEulerAngleXAwake;
	public static new Vector3 localEulerAnglesAwake => automaticBehaviour.localEulerAnglesAwake;
	public static new float eulerAngleZAwake => automaticBehaviour.eulerAngleZAwake;
	public static new float eulerAngleXAwake => automaticBehaviour.eulerAngleXAwake;
	public static new Vector3 eulerAnglesAwake => automaticBehaviour.eulerAnglesAwake;
	public static new float timeAwake => automaticBehaviour.timeAwake;
	public static new float lightIntensityAwake => automaticBehaviour.lightIntensityAwake;
	public static new bool awake => automaticBehaviour.awake;
	public static new Quaternion localRotationAwake => automaticBehaviour.localRotationAwake;
	#endregion Moon Motion - Moon Motion Toolkit - Utilities - Automatic Behaviours - Trackings
}