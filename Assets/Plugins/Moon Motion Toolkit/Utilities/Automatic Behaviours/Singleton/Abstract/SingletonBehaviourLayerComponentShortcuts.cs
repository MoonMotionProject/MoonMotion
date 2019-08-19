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
	public static new AutomaticBehaviour<SingletonBehaviourT> setRendererEnablementTo(bool boolean)
		=> automaticBehaviour.setRendererEnablementTo(boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> enableRenderer()
		=> automaticBehaviour.enableRenderer();
	public static new AutomaticBehaviour<SingletonBehaviourT> disableRenderer()
		=> automaticBehaviour.disableRenderer();
	public static new AutomaticBehaviour<SingletonBehaviourT> toggleRendererEnablementBy(Toggling toggling)
		=> automaticBehaviour.toggleRendererEnablementBy(toggling);
	#endregion enablement

	#region material
	public static new Material material => automaticBehaviour.material;
	public static new AutomaticBehaviour<SingletonBehaviourT> setMaterialTo(Material material)
		=> automaticBehaviour.setMaterialTo(material);
	public static new Material sharedMaterial => automaticBehaviour.sharedMaterial;
	public static new AutomaticBehaviour<SingletonBehaviourT> setSharedMaterialTo(Material sharedMaterial)
		=> automaticBehaviour.setSharedMaterialTo(material);
	#endregion material

	#region color
	public static new Color color => material.color;
	public static new AutomaticBehaviour<SingletonBehaviourT> setColorTo(Color targetColor)
		=> automaticBehaviour.setColorTo(targetColor);
	public static new AutomaticBehaviour<SingletonBehaviourT> setChildrenColorTo(Color targetColor)
		=> automaticBehaviour.setChildrenColorTo(targetColor);
	public static new AutomaticBehaviour<SingletonBehaviourT> setChildrenEmissionColorTo(Color targetColor, bool boolean = true)
		=> automaticBehaviour.setChildrenEmissionColorTo(targetColor, boolean);
	#endregion color

	#region shadowcasting
	public static new AutomaticBehaviour<SingletonBehaviourT> setShadowcastingTo(ShadowCastingMode shadowcasting)
		=> automaticBehaviour.setShadowcastingTo(shadowcasting);
	public static new AutomaticBehaviour<SingletonBehaviourT> shadowcast()
		=> automaticBehaviour.shadowcast();
	public static new AutomaticBehaviour<SingletonBehaviourT> nonshadowcast()
		=> automaticBehaviour.nonshadowcast();
	#endregion shadowcasting

	#region shadowability
	public static new AutomaticBehaviour<SingletonBehaviourT> setShadowabilityTo(bool shadowability)
		=> automaticBehaviour.setShadowabilityTo(shadowability);
	public static new AutomaticBehaviour<SingletonBehaviourT> shadowable()
		=> automaticBehaviour.shadowable();
	public static new AutomaticBehaviour<SingletonBehaviourT> nonshadowable()
		=> automaticBehaviour.nonshadowable();
	#endregion shadowability
	#endregion Renderer


	#region Rigidbody

	#region kinematicity
	public static new bool kinematicity => automaticBehaviour.kinematicity;
	public static new AutomaticBehaviour<SingletonBehaviourT> setKinematicityTo(bool kinematicity, bool boolean = true)
		=> automaticBehaviour.setKinematicityTo(kinematicity, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> kinematize(bool boolean = true)
		=> automaticBehaviour.kinematize(boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> nonkinematize(bool boolean = true)
		=> automaticBehaviour.nonkinematize(boolean);
	#endregion kinematicity

	#region gravitization
	public static new bool gravitization => automaticBehaviour.gravitization;
	public static new AutomaticBehaviour<SingletonBehaviourT> setGravitizationTo(bool gravitization, bool boolean = true)
		=> automaticBehaviour.setGravitizationTo(gravitization, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> gravitize(bool boolean = true)
		=> automaticBehaviour.gravitize(boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> nongravitize(bool boolean = true)
		=> automaticBehaviour.nongravitize(boolean);
	#endregion gravitization

	#region velocity vectrals
	public static new Vector3 velocityDirection => automaticBehaviour.velocityDirection;
	public static new AutomaticBehaviour<SingletonBehaviourT> setVelocityDirectionTo(Vector3 direction, bool boolean = true)
		=> automaticBehaviour.setVelocityDirectionTo(direction, boolean);
	public static new Vector3 angularVelocityAngling => automaticBehaviour.angularVelocityAngling;
	public static new AutomaticBehaviour<SingletonBehaviourT> setAngularVelocityAnglingTo(Vector3 angling, bool boolean = true)
		=> automaticBehaviour.setAngularVelocityAnglingTo(angling, boolean);
	#endregion velocity vectrals

	#region speeds
	public static new float speed => automaticBehaviour.speed;
	public static new AutomaticBehaviour<SingletonBehaviourT> setSpeedTo(float speed, bool boolean = true)
		=> automaticBehaviour.setSpeedTo(speed, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> honeSpeed(float honingTarget, float honingAmount, bool boolean = true)
		=> automaticBehaviour.honeSpeed(honingTarget, honingAmount, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> slowSpeedBy(float speedReduction, bool boolean = true)
		=> automaticBehaviour.slowSpeedBy(speedReduction, boolean);
	public static new float angularSpeed => automaticBehaviour.angularSpeed;
	public static new AutomaticBehaviour<SingletonBehaviourT> setAngularSpeedTo(float angularSpeed, bool boolean = true)
		=> automaticBehaviour.setAngularSpeedTo(angularSpeed, boolean);
	#endregion speed

	#region velocities
	public static new Vector3 velocity => automaticBehaviour.velocity;
	public static new Vector3 angularVelocity => automaticBehaviour.angularVelocity;
	public static new AutomaticBehaviour<SingletonBehaviourT> setVelocityTo(Vector3 velocity, bool boolean = true)
		=> automaticBehaviour.setVelocityTo(velocity, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setAngularVelocityTo(Vector3 angularVelocity, bool boolean = true)
		=> automaticBehaviour.setAngularVelocityTo(angularVelocity, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setVelocitiesTo(Vector3 directionalVelocity, Vector3 angularVelocity, bool boolean = true)
		=> automaticBehaviour.setVelocitiesTo(directionalVelocity, angularVelocity, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setVelocitiesTo(Vector3 velocity, bool boolean = true)
		=> automaticBehaviour.setVelocitiesTo(velocity, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> zeroVelocity(bool boolean = true)
		=> automaticBehaviour.zeroVelocity(boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> zeroAngularVelocity(bool boolean = true)
		=> automaticBehaviour.zeroAngularVelocity(boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> zeroVelocities(bool boolean = true)
		=> automaticBehaviour.zeroVelocities(boolean);
	#endregion velocities
	#endregion Rigidbody


	#region AudioSource

	#region audio
	public static new AudioClip audio => automaticBehaviour.audio;
	public static new AutomaticBehaviour<SingletonBehaviourT> setAudioTo(AudioClip targetAudio, bool boolean = true)
		=> automaticBehaviour.setAudioTo(targetAudio, boolean);
	public static new float audioDuration => automaticBehaviour.audioDuration;
	#endregion audio

	#region volume
	public static new float audioVolume => automaticBehaviour.audioVolume;
	public static new List<float> childAudioVolumes => automaticBehaviour.childAudioVolumes;
	public static new AutomaticBehaviour<SingletonBehaviourT> setAudioVolumeTo(float targetVolume, bool boolean = true)
		=> automaticBehaviour.setAudioVolumeTo(targetVolume, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setChildAudioVolumesTo(IList<float> targetVolumes)
		=> automaticBehaviour.setChildAudioVolumesTo(targetVolumes);
	#endregion volume

	#region playing
	public static new bool audioPlaying => automaticBehaviour.audioPlaying;
	public static new AutomaticBehaviour<SingletonBehaviourT> playAudio()
		=> automaticBehaviour.playAudio();
	public static new AutomaticBehaviour<SingletonBehaviourT> playChildAudios()
		=> automaticBehaviour.playChildAudios();
	public static new AutomaticBehaviour<SingletonBehaviourT> stopAudio()
		=> automaticBehaviour.stopAudio();
	public static new AutomaticBehaviour<SingletonBehaviourT> stopChildAudios()
		=> automaticBehaviour.stopChildAudios();
	public static new float audioTime => automaticBehaviour.audioTime;
	public static new AutomaticBehaviour<SingletonBehaviourT> setAudioTimeTo(float targetTime, bool boolean = true)
		=> automaticBehaviour.setAudioTimeTo(targetTime, boolean);
	#endregion playing

	#region acting upon child audio
	public static new AutomaticBehaviour<SingletonBehaviourT> actUponChildAudioSources(Action<List<AudioSource>> action)
		=> automaticBehaviour.actUponChildAudioSources(action);
	#endregion acting upon child audio
	#endregion AudioSource


	#region ParticleSystem

	#region playing
	public static new AutomaticBehaviour<SingletonBehaviourT> togglePlayingChildParticlesSystems(bool boolean)
		=> automaticBehaviour.togglePlayingChildParticlesSystems(boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> playChildParticlesSystems(bool boolean = true)
		=> automaticBehaviour.playChildParticlesSystems(boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> stopChildParticlesSystems(bool boolean = true)
		=> automaticBehaviour.stopChildParticlesSystems(boolean);
	#endregion playing

	#region acting upon child particles systems
	public static new AutomaticBehaviour<SingletonBehaviourT> actUponChildParticlesSystems(Action<List<ParticleSystem>> action)
		=> automaticBehaviour.actUponChildParticlesSystems(action);
	#endregion acting upon child particles systems
	#endregion ParticleSystem


	#region MeshFilter
	public static new Mesh mesh => automaticBehaviour.mesh;
	public static new AutomaticBehaviour<SingletonBehaviourT> setMeshTo(Mesh mesh, bool boolean = true)
		=> automaticBehaviour.setMeshTo(mesh, boolean);
	public static new Mesh sharedMesh => automaticBehaviour.sharedMesh;
	public static new AutomaticBehaviour<SingletonBehaviourT> setSharedMeshTo(Mesh mesh, bool boolean = true)
		=> automaticBehaviour.setSharedMeshTo(mesh, boolean);
	public static new Mesh sharedMeshOtherwiseMesh => sharedMesh ?? mesh;
	#endregion MeshFilter


	#region Light

	#region intensities
	public static new float lightIntensity => automaticBehaviour.lightIntensity;
	public static new List<float> childLightIntensities => automaticBehaviour.childLightIntensities;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLightIntensityTo(float targetIntensity)
		=> automaticBehaviour.setLightIntensityTo(targetIntensity);
	public static new AutomaticBehaviour<SingletonBehaviourT> setChildLightIntensitiesTo(float targetIntensity)
		=> automaticBehaviour.setChildLightIntensitiesTo(targetIntensity);
	public static new AutomaticBehaviour<SingletonBehaviourT> setChildLightIntensitiesTo(IList<float> targetIntensities)
		=> automaticBehaviour.setChildLightIntensitiesTo(targetIntensities);
	#endregion intensities

	#region setting render mode
	public static new AutomaticBehaviour<SingletonBehaviourT> renderChildLightsBy(LightRenderMode lightRenderMode)
		=> automaticBehaviour.renderChildLightsBy(lightRenderMode);
	public static new AutomaticBehaviour<SingletonBehaviourT> renderChildLightsByPixel()
		=> automaticBehaviour.renderChildLightsByPixel();
	public static new AutomaticBehaviour<SingletonBehaviourT> renderChildLightsByVertex()
		=> automaticBehaviour.renderChildLightsByVertex();
	#endregion setting render mode

	#region acting upon child lights
	public static new AutomaticBehaviour<SingletonBehaviourT> actUponChildLights(Action<List<Light>> action)
		=> automaticBehaviour.actUponChildLights(action);
	#endregion acting upon child lights
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
	public static new bool awake => singleton && automaticBehaviour.awake;
	public static new Quaternion localRotationAwake => automaticBehaviour.localRotationAwake;
	#endregion Moon Motion - Moon Motion Toolkit - Utilities - Automatic Behaviours - Trackings
}