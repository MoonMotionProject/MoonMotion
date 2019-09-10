using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Automatic Behaviour Layer Component Shortcuts Unity:
// #auto #shortcuts #force
// • provides this behaviour with automatically-connected state and methods (recursively) of its game object's and its children game objects' Unity components
public abstract class AutomaticBehaviourLayerComponentShortcutsUnity<AutomaticBehaviourT> :
					AutomaticBehaviourLayerComponentsMoonMotion<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	#region Renderer

	#region enablement
	public bool rendererEnablement => renderer.enablement();
	public AutomaticBehaviourT setRendererEnablementTo(bool boolean)
		=> selfAfter(()=> renderer.setEnablementTo(boolean));
	public AutomaticBehaviourT enableRenderer()
		=> selfAfter(()=> renderer.enable());
	public AutomaticBehaviourT disableRenderer()
		=> selfAfter(()=> renderer.disable());
	public AutomaticBehaviourT toggleRendererEnablementBy(Toggling toggling)
		=> selfAfter(()=> renderer.toggleEnablementBy(toggling));
	#endregion enablement

	#region material
	public Material material => renderer.material;
	public AutomaticBehaviourT setMaterialTo(Material material)
		=> selfAfter(()=> renderer.setMaterialTo(material));
	public Material sharedMaterial => renderer.sharedMaterial;
	public AutomaticBehaviourT setSharedMaterialTo(Material sharedMaterial)
		=> selfAfter(()=> renderer.setSharedMaterialTo(material));
	#endregion material

	#region color
	public Color color => material.color;
	public AutomaticBehaviourT setColorTo(Color targetColor)
		=> selfAfter(()=> material.setColorTo(targetColor));
	public AutomaticBehaviourT setChildrenColorTo(Color targetColor)
		=> selfAfter(()=> gameObject.setChildrenColorTo(targetColor));
	public AutomaticBehaviourT setChildrenEmissionColorTo(Color targetColor, bool boolean = true)
		=> selfAfter(()=> gameObject.setChildrenEmissionColorTo(targetColor, boolean));
	#endregion color

	#region shadowcasting
	public AutomaticBehaviourT setShadowcastingTo(ShadowCastingMode shadowcasting)
		=> selfAfter(()=> renderer.setShadowcastingTo(shadowcasting));
	public AutomaticBehaviourT shadowcast()
		=> selfAfter(()=> renderer.shadowcast());
	public AutomaticBehaviourT nonshadowcast()
		=> selfAfter(()=> renderer.nonshadowcast());
	#endregion shadowcasting

	#region shadowability
	public AutomaticBehaviourT setShadowabilityTo(bool shadowability)
		=> selfAfter(()=> renderer.setShadowabilityTo(shadowability));
	public AutomaticBehaviourT shadowable()
		=> selfAfter(()=> renderer.shadowable());
	public AutomaticBehaviourT nonshadowable()
		=> selfAfter(()=> renderer.nonshadowable());
	#endregion shadowability
	#endregion Renderer


	#region Rigidbody

	#region kinematicity
	public bool kinematicity => rigidbody.kinematicity();
	public AutomaticBehaviourT setKinematicityTo(bool kinematicity, bool boolean = true)
		=> selfAfter(()=> rigidbody.setKinematicityTo(kinematicity, boolean));
	public AutomaticBehaviourT kinematize(bool boolean = true)
		=> selfAfter(()=> rigidbody.kinematize(boolean));
	public AutomaticBehaviourT nonkinematize(bool boolean = true)
		=> selfAfter(()=> rigidbody.nonkinematize(boolean));
	#endregion kinematicity

	#region gravitization
	public bool gravitization => rigidbody.gravitization();
	public AutomaticBehaviourT setGravitizationTo(bool gravitization, bool boolean = true)
		=> selfAfter(()=> rigidbody.setGravitizationTo(gravitization, boolean));
	public AutomaticBehaviourT gravitize(bool boolean = true)
		=> selfAfter(()=> rigidbody.gravitize(boolean));
	public AutomaticBehaviourT nongravitize(bool boolean = true)
		=> selfAfter(()=> rigidbody.nongravitize(boolean));
	#endregion gravitization

	#region moving position
	public AutomaticBehaviourT movePositionTo(Vector3 position, bool boolean = true)
		=> selfAfter(()=> rigidbody.movePositionTo(position, boolean));
	#endregion moving position

	#region velocity vectrals
	public Vector3 velocityDirection => rigidbody.velocityDirection();
	public AutomaticBehaviourT setVelocityDirectionTo(Vector3 direction, bool boolean = true)
		=> selfAfter(()=> rigidbody.setVelocityDirectionTo(direction, boolean));
	public Vector3 angularVelocityAngling => rigidbody.angularVelocityAngling();
	public AutomaticBehaviourT setAngularVelocityAnglingTo(Vector3 angling, bool boolean = true)
		=> selfAfter(()=> rigidbody.setAngularVelocityAnglingTo(angling, boolean));
	#endregion velocity vectrals

	#region speeds
	public float speed => rigidbody.speed();
	public AutomaticBehaviourT setSpeedTo(float speed, bool boolean = true)
		=> selfAfter(()=> rigidbody.setSpeedTo(speed, boolean));
	public AutomaticBehaviourT honeSpeed(float honingTarget, float honingAmount, bool boolean = true)
		=> selfAfter(()=> rigidbody.honeSpeed(honingTarget, honingAmount, boolean));
	public AutomaticBehaviourT slowSpeedBy(float speedReduction, bool boolean = true)
		=> selfAfter(()=> rigidbody.slowSpeedBy(speedReduction, boolean));
	public float angularSpeed => rigidbody.angularSpeed();
	public AutomaticBehaviourT setAngularSpeedTo(float angularSpeed, bool boolean = true)
		=> selfAfter(()=> rigidbody.setAngularSpeedTo(angularSpeed, boolean));
	#endregion speed

	#region velocities
	public Vector3 velocity => rigidbody.velocity;
	public Vector3 angularVelocity => rigidbody.angularVelocity;
	public AutomaticBehaviourT setVelocityTo(Vector3 velocity, bool boolean = true)
		=> selfAfter(()=> rigidbody.setVelocityTo(velocity, boolean));
	public AutomaticBehaviourT setAngularVelocityTo(Vector3 angularVelocity, bool boolean = true)
		=> selfAfter(()=> rigidbody.setAngularVelocityTo(angularVelocity, boolean));
	public AutomaticBehaviourT setVelocitiesTo(Vector3 directionalVelocity, Vector3 angularVelocity, bool boolean = true)
		=> selfAfter(()=> rigidbody.setVelocitiesTo(directionalVelocity, angularVelocity, boolean));
	public AutomaticBehaviourT setVelocitiesTo(Vector3 velocity, bool boolean = true)
		=> selfAfter(()=> rigidbody.setVelocitiesTo(velocity, boolean));
	public AutomaticBehaviourT zeroVelocity(bool boolean = true)
		=> selfAfter(()=> rigidbody.zeroVelocity(boolean));
	public AutomaticBehaviourT zeroAngularVelocity(bool boolean = true)
		=> selfAfter(()=> rigidbody.zeroAngularVelocity(boolean));
	public AutomaticBehaviourT zeroVelocities(bool boolean = true)
		=> selfAfter(()=> rigidbody.zeroVelocities(boolean));
	#endregion velocities

	#region accelerating
	public AutomaticBehaviourT accelerateBy(Vector3 acceleration, bool boolean = true)
		=> selfAfter(()=> rigidbody.accelerateBy(acceleration, boolean));
	#endregion accelerating

	#region applying force
	public AutomaticBehaviourT applyForceOf(Vector3 force, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyForceOf(force, boolean));
	public AutomaticBehaviourT applyForceOf(float forceX, float forceY, float forceZ, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyForceOf(forceX, forceY, forceZ, boolean));
	public AutomaticBehaviourT applyForceAlong(Vector3 direction, float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyForceAlong(direction, magnitude, boolean));
	public AutomaticBehaviourT applyForceAlongLocal(BasicDirection basicDirection, float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyForceAlongLocal(basicDirection, magnitude, boolean));
	public AutomaticBehaviourT applyForceAlongGlobal(BasicDirection basicDirection, float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyForceAlongGlobal(basicDirection, magnitude, boolean));
	public AutomaticBehaviourT applyForceAlong(BasicDirection basicDirection, Distinctivity distinctivity, float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyForceAlong(basicDirection, distinctivity, magnitude, boolean));
	public AutomaticBehaviourT applyForwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyForwardForceOf(magnitude, boolean));
	public AutomaticBehaviourT applyBackwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyBackwardForceOf(magnitude, boolean));
	public AutomaticBehaviourT applyRightwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyRightwardForceOf(magnitude, boolean));
	public AutomaticBehaviourT applyLeftwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyLeftwardForceOf(magnitude, boolean));
	public AutomaticBehaviourT applyUpwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyUpwardForceOf(magnitude, boolean));
	public AutomaticBehaviourT applyDownwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyDownwardForceOf(magnitude, boolean));
	public AutomaticBehaviourT applyGlobalForwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyGlobalForwardForceOf(magnitude, boolean));
	public AutomaticBehaviourT applyGlobalBackwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyGlobalBackwardForceOf(magnitude, boolean));
	public AutomaticBehaviourT applyGlobalRightwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyGlobalRightwardForceOf(magnitude, boolean));
	public AutomaticBehaviourT applyGlobalLeftwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyGlobalLeftwardForceOf(magnitude, boolean));
	public AutomaticBehaviourT applyGlobalUpwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyGlobalUpwardForceOf(magnitude, boolean));
	public AutomaticBehaviourT applyGlobalDownwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyGlobalDownwardForceOf(magnitude, boolean));
	#endregion applying force
	#endregion Rigidbody


	#region AudioSource

	#region audio
	public new AudioClip audio => audioSource.audio();
	public AutomaticBehaviourT setAudioTo(AudioClip targetAudio, bool boolean = true)
		=> selfAfter(()=> audioSource.setAudioTo(targetAudio, boolean));
	public float audioDuration => audioSource.duration();
	#endregion audio

	#region volume
	public float audioVolume => audioSource.volume;
	public List<float> childAudioVolumes => gameObject.childAudioVolumes();
	public AutomaticBehaviourT setAudioVolumeTo(float targetVolume, bool boolean = true)
		=> selfAfter(()=> audioSource.setVolumeTo(targetVolume, boolean));
	public AutomaticBehaviourT setChildAudioVolumesTo(IList<float> targetVolumes)
		=> selfAfter(()=> gameObject.setChildAudioVolumesTo(targetVolumes));
	#endregion volume

	#region playing
	public bool audioPlaying => audioSource.playing();
	public AutomaticBehaviourT playAudio()
		=> selfAfter(()=> audioSource.play());
	public AutomaticBehaviourT playChildAudios()
		=> selfAfter(()=> gameObject.playChildAudios());
	public AutomaticBehaviourT stopAudio()
		=> selfAfter(()=> audioSource.stop());
	public AutomaticBehaviourT stopChildAudios()
		=> selfAfter(()=> gameObject.stopChildAudios());
	public float audioTime => audioSource.time;
	public AutomaticBehaviourT setAudioTimeTo(float targetTime, bool boolean = true)
		=> selfAfter(()=> audioSource.setTimeTo(targetTime, boolean));
	#endregion playing

	#region acting upon child audio
	public AutomaticBehaviourT actUponChildAudioSources(Action<List<AudioSource>> action)
		=> selfAfter(()=> gameObject.actUponChildAudioSources(action));
	#endregion acting upon child audio
	#endregion AudioSource


	#region ParticleSystem

	#region playing
	public AutomaticBehaviourT togglePlayingChildParticlesSystems(bool boolean)
		=> selfAfter(()=> gameObject.togglePlayingChildParticlesSystems(boolean));
	public AutomaticBehaviourT playChildParticlesSystems(bool boolean = true)
		=> selfAfter(()=> gameObject.playChildParticlesSystems(boolean));
	public AutomaticBehaviourT stopChildParticlesSystems(bool boolean = true)
		=> selfAfter(()=> gameObject.stopChildParticlesSystems(boolean));
	#endregion playing

	#region acting upon child particles systems
	public AutomaticBehaviourT actUponChildParticlesSystems(Action<List<ParticleSystem>> action)
		=> selfAfter(()=> gameObject.actUponChildParticlesSystems(action));
	#endregion acting upon child particles systems
	#endregion ParticleSystem


	#region MeshFilter
	public Mesh mesh => meshFilter.mesh;
	public AutomaticBehaviourT setMeshTo(Mesh mesh, bool boolean = true)
		=> selfAfter(()=> meshFilter.setMeshTo(mesh, boolean));
	public Mesh sharedMesh => meshFilter.sharedMesh;
	public AutomaticBehaviourT setSharedMeshTo(Mesh mesh, bool boolean = true)
		=> selfAfter(()=> meshFilter.setSharedMeshTo(mesh, boolean));
	public Mesh sharedMeshOtherwiseMesh => sharedMesh ?? mesh;
	#endregion MeshFilter


	#region Light

	#region intensities
	public float lightIntensity => light.intensity;
	public List<float> childLightIntensities => gameObject.childLightIntensities();
	public AutomaticBehaviourT setLightIntensityTo(float targetIntensity)
		=> selfAfter(()=> light.setIntensityTo(targetIntensity));
	public AutomaticBehaviourT setChildLightIntensitiesTo(float targetIntensity)
		=> selfAfter(()=> gameObject.setChildLightIntensitiesTo(targetIntensity));
	public AutomaticBehaviourT setChildLightIntensitiesTo(IList<float> targetIntensities)
		=> selfAfter(()=> gameObject.setChildLightIntensitiesTo(targetIntensities));
	#endregion intensities

	#region setting render mode
	public AutomaticBehaviourT renderChildLightsBy(LightRenderMode lightRenderMode)
		=> selfAfter(()=> gameObject.renderChildLightsBy(lightRenderMode));
	public AutomaticBehaviourT renderChildLightsByPixel()
		=> selfAfter(()=> gameObject.renderChildLightsByPixel());
	public AutomaticBehaviourT renderChildLightsByVertex()
		=> selfAfter(()=> gameObject.renderChildLightsByVertex());
	#endregion setting render mode

	#region acting upon child lights
	public AutomaticBehaviourT actUponChildLights(Action<List<Light>> action)
		=> selfAfter(()=> gameObject.actUponChildLights(action));
	#endregion acting upon child lights
	#endregion Light
}