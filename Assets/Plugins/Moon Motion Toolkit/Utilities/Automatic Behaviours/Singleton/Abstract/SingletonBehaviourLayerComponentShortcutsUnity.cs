using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Singleton Behaviour Layer Component Shortcuts Unity:
// #auto #shortcuts #force
// • provides this singleton behaviour with static access to its automatic behaviour's Unity component shortcuts layer
public abstract class SingletonBehaviourLayerComponentShortcutsUnity<SingletonBehaviourT> :
					SingletonBehaviourLayerComponentsMoonMotion<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
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
	public static new AutomaticBehaviour<SingletonBehaviourT> randomizeColor()
		=> automaticBehaviour.randomizeColor();
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

	#region moving position
	public static new AutomaticBehaviour<SingletonBehaviourT> movePositionTo(Vector3 position, bool boolean = true)
		=> automaticBehaviour.movePositionTo(position, boolean);
	#endregion moving position

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

	#region accelerating
	public static new AutomaticBehaviour<SingletonBehaviourT> accelerateBy(Vector3 acceleration, bool boolean = true)
		=> automaticBehaviour.accelerateBy(acceleration, boolean);
	#endregion accelerating

	#region applying force
	public static new AutomaticBehaviour<SingletonBehaviourT> applyForceOf(Vector3 force, bool boolean = true)
		=> automaticBehaviour.applyForceOf(force, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> applyForceOf(float forceX, float forceY, float forceZ, bool boolean = true)
		=> automaticBehaviour.applyForceOf(forceX, forceY, forceZ, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> applyForceAlong(Vector3 direction, float magnitude, bool boolean = true)
		=> automaticBehaviour.applyForceAlong(direction, magnitude, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> applyForceAlongLocal(BasicDirection basicDirection, float magnitude, bool boolean = true)
		=> automaticBehaviour.applyForceAlongLocal(basicDirection, magnitude, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> applyForceAlongGlobal(BasicDirection basicDirection, float magnitude, bool boolean = true)
		=> automaticBehaviour.applyForceAlongGlobal(basicDirection, magnitude, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> applyForceAlong(BasicDirection basicDirection, Distinctivity distinctivity, float magnitude, bool boolean = true)
		=> automaticBehaviour.applyForceAlong(basicDirection, distinctivity, magnitude, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> applyForwardForceOf(float magnitude, bool boolean = true)
		=> automaticBehaviour.applyForwardForceOf(magnitude, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> applyBackwardForceOf(float magnitude, bool boolean = true)
		=> automaticBehaviour.applyBackwardForceOf(magnitude, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> applyRightwardForceOf(float magnitude, bool boolean = true)
		=> automaticBehaviour.applyRightwardForceOf(magnitude, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> applyLeftwardForceOf(float magnitude, bool boolean = true)
		=> automaticBehaviour.applyLeftwardForceOf(magnitude, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> applyUpwardForceOf(float magnitude, bool boolean = true)
		=> automaticBehaviour.applyUpwardForceOf(magnitude, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> applyDownwardForceOf(float magnitude, bool boolean = true)
		=> automaticBehaviour.applyDownwardForceOf(magnitude, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> applyGlobalForwardForceOf(float magnitude, bool boolean = true)
		=> automaticBehaviour.applyGlobalForwardForceOf(magnitude, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> applyGlobalBackwardForceOf(float magnitude, bool boolean = true)
		=> automaticBehaviour.applyGlobalBackwardForceOf(magnitude, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> applyGlobalRightwardForceOf(float magnitude, bool boolean = true)
		=> automaticBehaviour.applyGlobalRightwardForceOf(magnitude, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> applyGlobalLeftwardForceOf(float magnitude, bool boolean = true)
		=> automaticBehaviour.applyGlobalLeftwardForceOf(magnitude, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> applyGlobalUpwardForceOf(float magnitude, bool boolean = true)
		=> automaticBehaviour.applyGlobalUpwardForceOf(magnitude, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> applyGlobalDownwardForceOf(float magnitude, bool boolean = true)
		=> automaticBehaviour.applyGlobalDownwardForceOf(magnitude, boolean);
	#endregion applying force
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
}