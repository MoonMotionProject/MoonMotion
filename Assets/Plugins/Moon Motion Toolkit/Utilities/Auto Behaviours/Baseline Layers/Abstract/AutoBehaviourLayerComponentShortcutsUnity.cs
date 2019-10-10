using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Auto Behaviour Layer Component Shortcuts Unity:
// #auto #shortcuts #component #force
// • provides this behaviour with automatically-connected state and methods (recursively) of its game object's and its children game objects' Unity components
public abstract class	AutoBehaviourLayerComponentShortcutsUnity<AutoBehaviourT> :
					AutoBehaviourLayerMonoBehaviour<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	#region Renderer

	#region enablement
	public bool rendererEnablement => renderer.enablement();
	public AutoBehaviourT setRendererEnablementTo(bool boolean)
		=> selfAfter(()=> renderer.setEnablementTo(boolean));
	public AutoBehaviourT enableRenderer()
		=> selfAfter(()=> renderer.enable());
	public AutoBehaviourT disableRenderer()
		=> selfAfter(()=> renderer.disable());
	public AutoBehaviourT toggleRendererEnablementBy(Toggling toggling)
		=> selfAfter(()=> renderer.toggleEnablementBy(toggling));
	#endregion enablement

	#region material
	public Material material => renderer.material;
	public AutoBehaviourT setMaterialTo(Material material)
		=> selfAfter(()=> renderer.setMaterialTo(material));
	public Material sharedMaterial => renderer.sharedMaterial;
	public AutoBehaviourT setSharedMaterialTo(Material sharedMaterial)
		=> selfAfter(()=> renderer.setSharedMaterialTo(material));
	#endregion material

	#region color
	public Color color => material.color;
	public AutoBehaviourT setColorTo(Color targetColor)
		=> selfAfter(()=> material.setColorTo(targetColor));
	public AutoBehaviourT setChildrenColorTo(Color targetColor)
		=> selfAfter(()=> gameObject.setChildrenColorTo(targetColor));
	public AutoBehaviourT randomizeColor()
		=> selfAfter(()=> material.randomizeColor());
	public AutoBehaviourT setChildrenEmissionColorTo(Color targetColor, bool boolean = true)
		=> selfAfter(()=> gameObject.setChildrenEmissionColorTo(targetColor, boolean));
	#endregion color

	#region shadowcasting
	public AutoBehaviourT setShadowcastingTo(ShadowCastingMode shadowcasting)
		=> selfAfter(()=> renderer.setShadowcastingTo(shadowcasting));
	public AutoBehaviourT shadowcast()
		=> selfAfter(()=> renderer.shadowcast());
	public AutoBehaviourT nonshadowcast()
		=> selfAfter(()=> renderer.nonshadowcast());
	#endregion shadowcasting

	#region shadowability
	public AutoBehaviourT setShadowabilityTo(bool shadowability)
		=> selfAfter(()=> renderer.setShadowabilityTo(shadowability));
	public AutoBehaviourT shadowable()
		=> selfAfter(()=> renderer.shadowable());
	public AutoBehaviourT nonshadowable()
		=> selfAfter(()=> renderer.nonshadowable());
	#endregion shadowability

	#region reflection source
	public AutoBehaviourT setReflectionSourceTo(ReflectionSource reflectionSource)
		=> selfAfter(()=> renderer.setReflectionSourceTo(reflectionSource));
	public AutoBehaviourT setReflectionSourceToSkybox()
		=> selfAfter(()=> renderer.setReflectionSourceToSkybox());
	public AutoBehaviourT setReflectionSourceToBlendedReflectionProbesOtherwiseSkybox()
		=> selfAfter(()=> renderer.setReflectionSourceToBlendedReflectionProbesOtherwiseSkybox());
	public AutoBehaviourT setReflectionSourceToBlendedReflectionProbesAndSkybox()
		=> selfAfter(()=> renderer.setReflectionSourceToBlendedReflectionProbesAndSkybox());
	public AutoBehaviourT setReflectionSourceToSingleMostRelevantProbeOrSkybox()
		=> selfAfter(()=> renderer.setReflectionSourceToSingleMostRelevantProbeOrSkybox());
	#endregion reflection source

	#region light probe usage
	public AutoBehaviourT setLightProbeUsageTo(LightProbeUsage lightProbeUsage)
		=> selfAfter(()=> renderer.setLightProbeUsageTo(lightProbeUsage));
	public AutoBehaviourT setLightProbeUsageToOff()
		=> selfAfter(()=> renderer.setLightProbeUsageToOff());
	public AutoBehaviourT setLightProbeUsageToBlendProbes()
		=> selfAfter(()=> renderer.setLightProbeUsageToBlendProbes());
	public AutoBehaviourT setRLightProbeUsageToUseProxyVolume()
		=> selfAfter(()=> renderer.setRLightProbeUsageToUseProxyVolume());
	public AutoBehaviourT setReflectionSourceToCustomProvided()
		=> selfAfter(()=> renderer.setReflectionSourceToCustomProvided());
	#endregion light probe usage
	#endregion Renderer


	#region Rigidbody

	#region kinematicity
	public bool kinematicity => rigidbody.kinematicity();
	public AutoBehaviourT setKinematicityTo(bool kinematicity, bool boolean = true)
		=> selfAfter(()=> rigidbody.setKinematicityTo(kinematicity, boolean));
	public AutoBehaviourT kinematize(bool boolean = true)
		=> selfAfter(()=> rigidbody.kinematize(boolean));
	public AutoBehaviourT nonkinematize(bool boolean = true)
		=> selfAfter(()=> rigidbody.nonkinematize(boolean));
	#endregion kinematicity

	#region gravitization
	public bool gravitization => rigidbody.gravitization();
	public AutoBehaviourT setGravitizationTo(bool gravitization, bool boolean = true)
		=> selfAfter(()=> rigidbody.setGravitizationTo(gravitization, boolean));
	public AutoBehaviourT gravitize(bool boolean = true)
		=> selfAfter(()=> rigidbody.gravitize(boolean));
	public AutoBehaviourT nongravitize(bool boolean = true)
		=> selfAfter(()=> rigidbody.nongravitize(boolean));
	#endregion gravitization

	#region velocity vectrals
	public Vector3 velocityDirection => rigidbody.velocityDirection();
	public AutoBehaviourT setVelocityDirectionTo(Vector3 direction, bool boolean = true)
		=> selfAfter(()=> rigidbody.setVelocityDirectionTo(direction, boolean));
	public Vector3 angularVelocityAngling => rigidbody.angularVelocityAngling();
	public AutoBehaviourT setAngularVelocityAnglingTo(Vector3 angling, bool boolean = true)
		=> selfAfter(()=> rigidbody.setAngularVelocityAnglingTo(angling, boolean));
	#endregion velocity vectrals

	#region speeds
	public float speed => rigidbody.speed();
	public AutoBehaviourT setSpeedTo(float speed, bool boolean = true)
		=> selfAfter(()=> rigidbody.setSpeedTo(speed, boolean));
	public AutoBehaviourT honeSpeed(float honingTarget, float honingAmount, bool boolean = true)
		=> selfAfter(()=> rigidbody.honeSpeed(honingTarget, honingAmount, boolean));
	public AutoBehaviourT slowSpeedBy(float speedReduction, bool boolean = true)
		=> selfAfter(()=> rigidbody.slowSpeedBy(speedReduction, boolean));
	public float angularSpeed => rigidbody.angularSpeed();
	public AutoBehaviourT setAngularSpeedTo(float angularSpeed, bool boolean = true)
		=> selfAfter(()=> rigidbody.setAngularSpeedTo(angularSpeed, boolean));
	#endregion speed

	#region velocities
	public Vector3 velocity => rigidbody.velocity;
	public Vector3 angularVelocity => rigidbody.angularVelocity;
	public AutoBehaviourT setVelocityTo(Vector3 velocity, bool boolean = true)
		=> selfAfter(()=> rigidbody.setVelocityTo(velocity, boolean));
	public AutoBehaviourT setAngularVelocityTo(Vector3 angularVelocity, bool boolean = true)
		=> selfAfter(()=> rigidbody.setAngularVelocityTo(angularVelocity, boolean));
	public AutoBehaviourT setVelocitiesTo(Vector3 directionalVelocity, Vector3 angularVelocity, bool boolean = true)
		=> selfAfter(()=> rigidbody.setVelocitiesTo(directionalVelocity, angularVelocity, boolean));
	public AutoBehaviourT setVelocitiesTo(Vector3 velocity, bool boolean = true)
		=> selfAfter(()=> rigidbody.setVelocitiesTo(velocity, boolean));
	public AutoBehaviourT zeroVelocity(bool boolean = true)
		=> selfAfter(()=> rigidbody.zeroVelocity(boolean));
	public AutoBehaviourT zeroAngularVelocity(bool boolean = true)
		=> selfAfter(()=> rigidbody.zeroAngularVelocity(boolean));
	public AutoBehaviourT zeroVelocities(bool boolean = true)
		=> selfAfter(()=> rigidbody.zeroVelocities(boolean));
	#endregion velocities

	#region accelerating
	public AutoBehaviourT accelerateBy(Vector3 acceleration, bool boolean = true)
		=> selfAfter(()=> rigidbody.accelerateBy(acceleration, boolean));
	#endregion accelerating

	#region applying force
	public AutoBehaviourT applyForceOf(Vector3 force, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyForceOf(force, boolean));
	public AutoBehaviourT applyForceOf(float forceX, float forceY, float forceZ, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyForceOf(forceX, forceY, forceZ, boolean));
	public AutoBehaviourT applyForceAlong(Vector3 direction, float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyForceAlong(direction, magnitude, boolean));
	public AutoBehaviourT applyForceAlong(Vector3 direction, Distinctivity distinctivity, object potentialTransform_TransformProvider, float magnitude, bool boolean = true)
	{
		Transform potentialTransform = Provide.transformVia(potentialTransform_TransformProvider);

		return selfAfter(()=> rigidbody.applyForceAlong(direction, distinctivity, potentialTransform, magnitude, boolean));
	}
	public AutoBehaviourT applyForceAlongLocal(Vector3 localDirection, object transform_TransformProvider, float magnitude, bool boolean = true)
	{
		Transform transform = Provide.transformVia(transform_TransformProvider);

		return selfAfter(()=> rigidbody.applyForceAlongLocal(localDirection, transform, magnitude, boolean));
	}
	public AutoBehaviourT applyForceAlong(BasicDirection localBasicDirection, float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyForceAlong(localBasicDirection, magnitude, boolean));
	public AutoBehaviourT applyForceAlongGlobal(BasicDirection basicDirection, float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyForceAlongGlobal(basicDirection, magnitude, boolean));
	public AutoBehaviourT applyForceAlong(BasicDirection basicDirection, Distinctivity distinctivity, float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyForceAlong(basicDirection, distinctivity, magnitude, boolean));
	public AutoBehaviourT applyForwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyForwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyBackwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyBackwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyRightwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyRightwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyLeftwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyLeftwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyUpwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyUpwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyDownwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyDownwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyGlobalForwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyGlobalForwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyGlobalBackwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyGlobalBackwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyGlobalRightwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyGlobalRightwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyGlobalLeftwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyGlobalLeftwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyGlobalUpwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyGlobalUpwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyGlobalDownwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> rigidbody.applyGlobalDownwardForceOf(magnitude, boolean));
	#endregion applying force

	#region applying directed force
	public AutoBehaviourT applyDirectedForceFrom(object forcingPosition_PositionProvider, Vector3 direction, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return selfAfter(()=> rigidbody.applyDirectedForceFrom
		(
			forcingPosition,
			direction,
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		));
	}
	public AutoBehaviourT applyDirectedForceFrom(object forcingTransform_TransformProvider, Vector3 direction, Distinctivity distinctivity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		Transform forcingTransform = Provide.transformVia(forcingTransform_TransformProvider);

		return selfAfter(()=> rigidbody.applyDirectedForceFrom
		(
			forcingTransform,
			direction,
			distinctivity,
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		));
	}
	#endregion applying directed force
	#endregion Rigidbody


	#region AudioSource

	#region audio
	public new AudioClip audio => audioSource.audio();
	public AutoBehaviourT setAudioTo(AudioClip targetAudio, bool boolean = true)
		=> selfAfter(()=> audioSource.setAudioTo(targetAudio, boolean));
	public float audioDuration => audioSource.duration();
	#endregion audio

	#region volume
	public float audioVolume => audioSource.volume;
	public List<float> childAudioVolumes => gameObject.childAudioVolumes();
	public AutoBehaviourT setAudioVolumeTo(float targetVolume, bool boolean = true)
		=> selfAfter(()=> audioSource.setVolumeTo(targetVolume, boolean));
	public AutoBehaviourT setChildAudioVolumesTo(IList<float> targetVolumes)
		=> selfAfter(()=> gameObject.setChildAudioVolumesTo(targetVolumes));
	#endregion volume

	#region playing
	public bool audioPlaying => audioSource.playing();
	public AutoBehaviourT playAudio()
		=> selfAfter(()=> audioSource.play());
	public AutoBehaviourT playChildAudios()
		=> selfAfter(()=> gameObject.playChildAudios());
	public AutoBehaviourT stopAudio()
		=> selfAfter(()=> audioSource.stop());
	public AutoBehaviourT stopChildAudios()
		=> selfAfter(()=> gameObject.stopChildAudios());
	public float audioTime => audioSource.time;
	public AutoBehaviourT setAudioTimeTo(float targetTime, bool boolean = true)
		=> selfAfter(()=> audioSource.setTimeTo(targetTime, boolean));
	#endregion playing

	#region acting upon child audio
	public AutoBehaviourT actUponChildAudioSources(Action<List<AudioSource>> action)
		=> selfAfter(()=> gameObject.actUponChildAudioSources(action));
	#endregion acting upon child audio
	#endregion AudioSource


	#region LineRenderer

	#region setting starting and ending widths
	public AutoBehaviourT setLineRendererStartingWidthTo(float targetStartingWidth)
		=> selfAfter(()=> lineRenderer.setStartingWidthTo(targetStartingWidth));
	public AutoBehaviourT setLineRendererEndingWidthTo(float targetEndingWidth)
		=> selfAfter(()=> lineRenderer.setEndingWidthTo(targetEndingWidth));
	public AutoBehaviourT setLineRendererStartingAndEndingWidthsTo(float targetStartingWidth, float targetEndingWidth)
		=> selfAfter(()=> lineRenderer.setStartingAndEndingWidthsTo(targetStartingWidth, targetEndingWidth));
	public AutoBehaviourT setLineRendererStartingAndEndingWidthsTo(float targetWidth)
		=> selfAfter(()=> lineRenderer.setStartingAndEndingWidthsTo(targetWidth));
	#endregion setting starting and ending widths

	#region setting number of points
	public AutoBehaviourT setLineRendererNumberOfPointsTo(int numberOfPoints)
		=> selfAfter(()=> lineRenderer.setNumberOfPointsTo(numberOfPoints));
	#endregion setting number of points

	#region setting points
	public AutoBehaviourT setLineRendererPointAtIndex(int index, Vector2 point)
		=> selfAfter(()=> lineRenderer.setPointAtIndex(index, point));
	public AutoBehaviourT setLineRendererPointAtIndex(int index, Vector3 position)
		=> selfAfter(()=> lineRenderer.setPointAtIndex(index, position));
	public AutoBehaviourT setLineRendererFirstPointTo(Vector3 position)
		=> selfAfter(()=> lineRenderer.setFirstPointTo(position));
	public AutoBehaviourT setLineRendererSecondPointTo(Vector3 position)
		=> selfAfter(()=> lineRenderer.setSecondPointTo(position));
	public AutoBehaviourT setLineRendererFirstTwoPointsTo(Vector3 firstPosition, Vector3 secondPosition)
		=> selfAfter(()=> lineRenderer.setFirstTwoPointsTo(firstPosition, secondPosition));
	public AutoBehaviourT setLineRendererFirstTwoPointsTo(object firstPosition_PositionProvider, object secondPosition_PositionProvider)
	{
		Vector3 firstPosition = Provide.positionVia(firstPosition_PositionProvider);
		Vector3 secondPosition = Provide.positionVia(secondPosition_PositionProvider);

		return selfAfter(()=> lineRenderer.setFirstTwoPointsTo(firstPosition, secondPosition));
	}
	public AutoBehaviourT setLineRendererFirstTwoPointsForLineLocallyDirectedFrom(object startingTransform_TransformProvider, Vector3 localDirection, float distance)
	{
		Transform startingTransform = Provide.transformVia(startingTransform_TransformProvider);

		return selfAfter(()=> lineRenderer.setFirstTwoPointsForLineLocallyDirectedFrom
		(
			startingTransform,
			localDirection,
			distance
		));
	}
	#endregion setting points
	
	#region setting distinctivity
	public AutoBehaviourT setLineRendererDistinctivityTo(Distinctivity distinctivity)
		=> selfAfter(()=> lineRenderer.setDistinctivityTo(distinctivity));
	public AutoBehaviourT positionLineRendererGlobally()
		=> selfAfter(()=> lineRenderer.positionGlobally());
	public AutoBehaviourT positionLineRendererLocally()
		=> selfAfter(()=> lineRenderer.positionLocally());
	#endregion setting distinctivity
	
	#region setting starting and ending colors
	public AutoBehaviourT setLineRendererStartingColorTo(Color color)
		=> selfAfter(()=> lineRenderer.setStartingColorTo(color));
	public AutoBehaviourT setLineRendererEndingColorTo(Color color)
		=> selfAfter(()=> lineRenderer.setEndingColorTo(color));
	public AutoBehaviourT setLineRendererColorTo(Color color)
		=> selfAfter(()=> lineRenderer.setColorTo(color));
	public AutoBehaviourT setLineRendererStartingAndEndingColorsToColorOfItsMaterial()
		=> selfAfter(()=> lineRenderer.setStartingAndEndingColorsToColorOfMaterial());
	#endregion setting starting and ending colors

	#region line of light setup
	public AutoBehaviourT setupLineRendererAsLineOfLightLocallyDirectedFrom(object startingTransform_TransformProvider, Vector3 localDirection, float distance, Material material)
	{
		Transform startingTransform = Provide.transformVia(startingTransform_TransformProvider);

		return selfAfter(()=> ensuredLineRenderer.setupAsLineOfLightLocallyDirectedFrom(startingTransform, localDirection, distance, material));
	}
	#endregion line of light setup
	#endregion LineRenderer


	#region ParticleSystem

	#region playing
	public AutoBehaviourT togglePlayingChildParticlesSystems(bool boolean)
		=> selfAfter(()=> gameObject.togglePlayingChildParticlesSystems(boolean));
	public AutoBehaviourT playChildParticlesSystems(bool boolean = true)
		=> selfAfter(()=> gameObject.playChildParticlesSystems(boolean));
	public AutoBehaviourT stopChildParticlesSystems(bool boolean = true)
		=> selfAfter(()=> gameObject.stopChildParticlesSystems(boolean));
	#endregion playing

	#region acting upon child particles systems
	public AutoBehaviourT actUponChildParticlesSystems(Action<List<ParticleSystem>> action)
		=> selfAfter(()=> gameObject.actUponChildParticlesSystems(action));
	#endregion acting upon child particles systems
	#endregion ParticleSystem


	#region MeshFilter
	public Mesh mesh => meshFilter.mesh;
	public AutoBehaviourT setMeshTo(object mesh_MeshProvider, bool boolean = true)
	{
		Mesh providedMesh = Provide.meshVia(mesh_MeshProvider);

		return selfAfter(()=> meshFilter.setMeshTo(providedMesh, boolean));
	}
	public Mesh sharedMesh => meshFilter.sharedMesh;
	public AutoBehaviourT setSharedMeshTo(object sharedMesh_SharedMeshProvider, bool boolean = true)
	{
		Mesh providedSharedMesh = Provide.meshVia(sharedMesh_SharedMeshProvider);

		return selfAfter(()=> meshFilter.setSharedMeshTo(providedSharedMesh, boolean));
	}
	public Mesh sharedMeshOtherwiseMesh => sharedMesh ? sharedMesh : mesh;
	#endregion MeshFilter


	#region Light

	#region intensities
	public float lightIntensity => light.intensity;
	public List<float> childLightIntensities => gameObject.childLightIntensities();
	public AutoBehaviourT setLightIntensityTo(float targetIntensity)
		=> selfAfter(()=> light.setIntensityTo(targetIntensity));
	public AutoBehaviourT setChildLightIntensitiesTo(float targetIntensity)
		=> selfAfter(()=> gameObject.setChildLightIntensitiesTo(targetIntensity));
	public AutoBehaviourT setChildLightIntensitiesTo(IList<float> targetIntensities)
		=> selfAfter(()=> gameObject.setChildLightIntensitiesTo(targetIntensities));
	#endregion intensities

	#region setting render mode
	public AutoBehaviourT renderChildLightsBy(LightRenderMode lightRenderMode)
		=> selfAfter(()=> gameObject.renderChildLightsBy(lightRenderMode));
	public AutoBehaviourT renderChildLightsByPixel()
		=> selfAfter(()=> gameObject.renderChildLightsByPixel());
	public AutoBehaviourT renderChildLightsByVertex()
		=> selfAfter(()=> gameObject.renderChildLightsByVertex());
	#endregion setting render mode

	#region acting upon child lights
	public AutoBehaviourT actUponChildLights(Action<List<Light>> action)
		=> selfAfter(()=> gameObject.actUponChildLights(action));
	#endregion acting upon child lights
	#endregion Light


	#region EdgeCollider2D

	#region setting points
	public AutoBehaviourT setPointsTo(params Vector2[] points)
		=> selfAfter(()=> edgeCollider.setPointsTo(points));
	public AutoBehaviourT setPointsTo(IEnumerable<Vector2> points)
		=> selfAfter(()=> edgeCollider.setPointsTo(points));
	#endregion setting points
	#endregion EdgeCollider2D
}