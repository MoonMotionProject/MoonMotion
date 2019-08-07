using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Automatic Behaviour Layer Component Shortcuts:
// #auto #shortcuts
// • provides this behaviour with automatically-connected state and methods (recursively) of its game object's and its children game objects' components
public abstract class AutomaticBehaviourLayerComponentShortcuts<AutomaticBehaviourT> :
					AutomaticBehaviourLayerComponents<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	#region Unity


	#region Renderer

	#region enablement
	public bool rendererEnablement => renderer.enablement();
	public Renderer setRendererEnablementTo(bool boolean)
		=> renderer.setEnablementTo(boolean);
	public Renderer enableRenderer()
		=> renderer.enable();
	public Renderer disableRenderer()
		=> renderer.disable();
	public Renderer toggleRendererEnablementBy(Toggling toggling)
		=> renderer.toggleEnablementBy(toggling);
	#endregion enablement

	#region material
	public Material material => renderer.material;
	public Renderer setMaterialTo(Material material)
		=> renderer.setMaterialTo(material);
	public Material sharedMaterial => renderer.sharedMaterial;
	public Renderer setSharedMaterialTo(Material sharedMaterial)
		=> renderer.setSharedMaterialTo(material);
	#endregion material

	#region shadowcasting
	public Renderer setShadowcastingTo(ShadowCastingMode shadowcasting)
		=> renderer.setShadowcastingTo(shadowcasting);
	public Renderer shadowcast()
		=> renderer.shadowcast();
	public Renderer nonshadowcast()
		=> renderer.nonshadowcast();
	#endregion shadowcasting

	#region shadowability
	public Renderer setShadowabilityTo(bool shadowability)
		=> renderer.setShadowabilityTo(shadowability);
	public Renderer shadowable()
		=> renderer.shadowable();
	public Renderer nonshadowable()
		=> renderer.nonshadowable();
	#endregion shadowability
	#endregion Renderer


	#region Rigidbody

	#region kinematicity
	public bool kinematicity => rigidbody.kinematicity();
	public Rigidbody setKinematicityTo(bool kinematicity, bool boolean = true)
		=> rigidbody.setKinematicityTo(kinematicity, boolean);
	public Rigidbody kinematize(bool boolean = true)
		=> rigidbody.kinematize(boolean);
	public Rigidbody nonkinematize(bool boolean = true)
		=> rigidbody.nonkinematize(boolean);
	#endregion kinematicity

	#region gravitization
	public bool gravitization => rigidbody.gravitization();
	public Rigidbody setGravitizationTo(bool gravitization, bool boolean = true)
		=> rigidbody.setGravitizationTo(gravitization, boolean);
	public Rigidbody gravitize(bool boolean = true)
		=> rigidbody.gravitize(boolean);
	public Rigidbody nongravitize(bool boolean = true)
		=> rigidbody.nongravitize(boolean);
	#endregion gravitization

	#region velocity vectrals
	public Vector3 velocityDirection => rigidbody.velocityDirection();
	public Rigidbody setVelocityDirectionTo(Vector3 direction, bool boolean = true)
		=> rigidbody.setVelocityDirectionTo(direction, boolean);
	public Vector3 angularVelocityAngling => rigidbody.angularVelocityAngling();
	public Rigidbody setAngularVelocityAnglingTo(Vector3 angling, bool boolean = true)
		=> rigidbody.setAngularVelocityAnglingTo(angling, boolean);
	#endregion velocity vectrals

	#region speeds
	public float speed => rigidbody.speed();
	public Rigidbody setSpeedTo(float speed, bool boolean = true)
		=> rigidbody.setSpeedTo(speed, boolean);
	public Rigidbody honeSpeed(float honingTarget, float honingAmount, bool boolean = true)
		=> rigidbody.honeSpeed(honingTarget, honingAmount, boolean);
	public Rigidbody slowSpeedBy(float speedReduction, bool boolean = true)
		=> rigidbody.slowSpeedBy(speedReduction, boolean);
	public float angularSpeed => rigidbody.angularSpeed();
	public Rigidbody setAngularSpeedTo(float angularSpeed, bool boolean = true)
		=> rigidbody.setAngularSpeedTo(angularSpeed, boolean);
	#endregion speed

	#region velocities
	public Vector3 velocity => rigidbody.velocity;
	public Vector3 angularVelocity => rigidbody.angularVelocity;
	public Rigidbody setVelocityTo(Vector3 velocity, bool boolean = true)
		=> rigidbody.setVelocityTo(velocity, boolean);
	public Rigidbody setAngularVelocityTo(Vector3 angularVelocity, bool boolean = true)
		=> rigidbody.setAngularVelocityTo(angularVelocity, boolean);
	public Rigidbody setVelocitiesTo(Vector3 directionalVelocity, Vector3 angularVelocity, bool boolean = true)
		=> rigidbody.setVelocitiesTo(directionalVelocity, angularVelocity, boolean);
	public Rigidbody setVelocitiesTo(Vector3 velocity, bool boolean = true)
		=> rigidbody.setVelocitiesTo(velocity, boolean);
	public Rigidbody zeroVelocity(bool boolean = true)
		=> rigidbody.zeroVelocity(boolean);
	public Rigidbody zeroAngularVelocity(bool boolean = true)
		=> rigidbody.zeroAngularVelocity(boolean);
	public Rigidbody zeroVelocities(bool boolean = true)
		=> rigidbody.zeroVelocities(boolean);
	#endregion velocities
	#endregion Rigidbody


	#region AudioSource

	#region audio
	public new AudioClip audio => audioSource.audio();
	public AudioSource setAudioTo(AudioClip targetAudio, bool boolean = true)
		=> audioSource.setAudioTo(targetAudio, boolean);
	public float audioDuration => audioSource.duration();
	public float audioVolume => audioSource.volume;
	public AudioSource setAudioVolumeTo(float targetVolume, bool boolean = true)
		=> audioSource.setVolumeTo(targetVolume, boolean);
	#endregion audio

	#region playing
	public bool audioPlaying => audioSource.playing();
	public AudioSource audioPlay()
		=> audioSource.play();
	public AudioSource audioStop()
		=> audioSource.stop();
	public float audioTime => audioSource.time;
	public AudioSource setAudioTimeTo(float targetTime, bool boolean = true)
		=> audioSource.setTimeTo(targetTime, boolean);
	#endregion playing

	#region child audio sources
	public List<float> childAudioVolumes => gameObject.childAudioVolumes();
	public GameObject setChildAudioVolumesTo(IList<float> targetVolumes)
		=> gameObject.setChildAudioVolumesTo(targetVolumes);
	#endregion child audio sources
	#endregion AudioSource


	#region ParticleSystem

	#region child particles systems

	public GameObject togglePlayingChildParticlesSystems(bool boolean)
		=> gameObject.togglePlayingChildParticlesSystems(boolean);

	public GameObject playChildParticlesSystems(bool boolean)
		=> gameObject.playChildParticlesSystems(boolean);

	public GameObject stopChildParticlesSystems(bool boolean)
		=> gameObject.stopChildParticlesSystems(boolean);
	#endregion child particles systems
	#endregion ParticleSystem


	#region MeshFilter
	public Mesh mesh => meshFilter.mesh;
	public MeshFilter setMeshTo(Mesh mesh, bool boolean = true)
		=> meshFilter.setMeshTo(mesh, boolean);
	public Mesh sharedMesh => meshFilter.sharedMesh;
	public MeshFilter setSharedMeshTo(Mesh mesh, bool boolean = true)
		=> meshFilter.setSharedMeshTo(mesh, boolean);
	public Mesh sharedMeshOtherwiseMesh => sharedMesh ?? mesh;
	#endregion MeshFilter


	#region Light

	#region intensities
	public float lightIntensity => light.intensity;
	public Light setLightIntensityTo(float targetIntensity)
		=> light.setIntensityTo(targetIntensity);
	#endregion intensities
	
	#region child lights
	public List<float> childLightIntensities => gameObject.childLightIntensities();
	public GameObject setChildLightIntensitiesTo(IList<float> targetIntensities)
		=> gameObject.setChildLightIntensitiesTo(targetIntensities);
	public GameObject setChildLightIntensitiesTo(float targetIntensity)
		=> gameObject.setChildLightIntensitiesTo(targetIntensity);
	public GameObject renderChildLightsBy(LightRenderMode lightRenderMode)
		=> gameObject.renderChildLightsBy(lightRenderMode);
	public GameObject renderChildLightsByPixel()
		=> gameObject.renderChildLightsByPixel();
	public GameObject renderChildLightsByVertex()
		=> gameObject.renderChildLightsByVertex();
	#endregion child lights
	#endregion Light
	#endregion Unity




	#region Moon Motion - Moon Motion Toolkit - Utilities - Automatic Behaviours - Trackings
	public Vector3 localScaleAwake => trackLocalScaleAtAwake.localScaleAwake;
	public float localScaleXAwake => trackLocalScaleXAtAwake.localScaleXAwake;
	public float localScaleYAwake => trackLocalScaleYAtAwake.localScaleYAwake;
	public float localScaleZAwake => trackLocalScaleZAtAwake.localScaleZAwake;
	public Vector3 positionAwake => trackPositionAtAwake.positionAwake;
	public float positionXAwake => trackPositionXAtAwake.positionXAwake;
	public float positionYAwake => trackPositionYAtAwake.positionYAwake;
	public float positionZAwake => trackPositionZAtAwake.positionZAwake;
	public Quaternion rotationAwake => trackRotationAtAwake.rotationAwake;
	public float localPositionZAwake => trackLocalPositionZAtAwake.localPositionZAwake;
	public float localPositionYAwake => trackLocalPositionYAtAwake.localPositionYAwake;
	public float eulerAngleYAwake => trackEulerAngleYAtAwake.eulerAngleYAwake;
	public float localPositionXAwake => trackLocalPositionXAtAwake.localPositionXAwake;
	public Vector3 localPositionAwake => trackLocalPositionAtAwake.localPositionAwake;
	public float localEulerAngleZAwake => trackLocalEulerAngleZAtAwake.localEulerAngleZAwake;
	public float localEulerAngleYAwake => trackLocalEulerAngleYAtAwake.localEulerAngleYAwake;
	public float localEulerAngleXAwake => trackLocalEulerAngleXAtAwake.localEulerAngleXAwake;
	public Vector3 localEulerAnglesAwake => trackLocalEulerAnglesAtAwake.localEulerAnglesAwake;
	public float eulerAngleZAwake => trackEulerAngleZAtAwake.eulerAngleZAwake;
	public float eulerAngleXAwake => trackEulerAngleXAtAwake.eulerAngleXAwake;
	public Vector3 eulerAnglesAwake => trackEulerAnglesAtAwake.eulerAnglesAwake;
	public float timeAwake => trackTimeOfAwake.timeAwake;
	public float lightIntensityAwake => trackLightIntensityAtAwake.lightIntensityAwake;
	public bool awake => trackAwake.awake;
	public Quaternion localRotationAwake => trackLocalRotationAtAwake.localRotationAwake;
	#endregion Moon Motion - Moon Motion Toolkit - Utilities - Automatic Behaviours - Trackings
}