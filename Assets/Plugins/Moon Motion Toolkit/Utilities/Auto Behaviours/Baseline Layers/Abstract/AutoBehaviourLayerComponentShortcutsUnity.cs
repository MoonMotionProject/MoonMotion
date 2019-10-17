using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
#if NAV_MESH_COMPONENTS
using UnityEngine.AI;
#endif

// Auto Behaviour Layer Component Shortcuts Unity:
// #auto #shortcuts #component #force
// • provides this behaviour with automatically-connected state and methods (recursively) of its game object's and its descendant game objects' Unity components
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
	public AutoBehaviourT setDescendantsColorTo(Color targetColor)
		=> selfAfter(()=> gameObject.setDescendantsColorTo(targetColor));
	public AutoBehaviourT randomizeColor()
		=> selfAfter(()=> material.randomizeColor());
	public AutoBehaviourT setDescendantsEmissionColorTo(Color targetColor, bool boolean = true)
		=> selfAfter(()=> gameObject.setDescendantsEmissionColorTo(targetColor, boolean));
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
	public bool kinematicity => ensuredCorrespondingRigidbody.kinematicity();
	public AutoBehaviourT setKinematicityTo(bool kinematicity, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.setKinematicityTo(kinematicity, boolean));
	public AutoBehaviourT kinematize(bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.kinematize(boolean));
	public AutoBehaviourT nonkinematize(bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.nonkinematize(boolean));
	#endregion kinematicity

	#region gravitization
	public bool gravitization => ensuredCorrespondingRigidbody.gravitization();
	public AutoBehaviourT setGravitizationTo(bool gravitization, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.setGravitizationTo(gravitization, boolean));
	public AutoBehaviourT gravitize(bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.gravitize(boolean));
	public AutoBehaviourT nongravitize(bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.nongravitize(boolean));
	#endregion gravitization

	#region velocity vectrals
	public Vector3 velocityDirection => ensuredCorrespondingRigidbody.velocityDirection();
	public AutoBehaviourT setVelocityDirectionTo(Vector3 direction, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.setVelocityDirectionTo(direction, boolean));
	public Vector3 angularVelocityAngling => ensuredCorrespondingRigidbody.angularVelocityAngling();
	public AutoBehaviourT setAngularVelocityAnglingTo(Vector3 angling, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.setAngularVelocityAnglingTo(angling, boolean));
	#endregion velocity vectrals

	#region speeds
	public float speed => ensuredCorrespondingRigidbody.speed();
	public AutoBehaviourT setSpeedTo(float speed, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.setSpeedTo(speed, boolean));
	public AutoBehaviourT honeSpeed(float honingTarget, float honingAmount, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.honeSpeed(honingTarget, honingAmount, boolean));
	public AutoBehaviourT slowSpeedBy(float speedReduction, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.slowSpeedBy(speedReduction, boolean));
	public float angularSpeed => ensuredCorrespondingRigidbody.angularSpeed();
	public AutoBehaviourT setAngularSpeedTo(float angularSpeed, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.setAngularSpeedTo(angularSpeed, boolean));
	#endregion speed

	#region velocities
	public Vector3 velocity => ensuredCorrespondingRigidbody.velocity;
	public Vector3 angularVelocity => ensuredCorrespondingRigidbody.angularVelocity;
	public AutoBehaviourT setVelocityTo(Vector3 velocity, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.setVelocityTo(velocity, boolean));
	public AutoBehaviourT setAngularVelocityTo(Vector3 angularVelocity, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.setAngularVelocityTo(angularVelocity, boolean));
	public AutoBehaviourT setVelocitiesTo(Vector3 directionalVelocity, Vector3 angularVelocity, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.setVelocitiesTo(directionalVelocity, angularVelocity, boolean));
	public AutoBehaviourT setVelocitiesTo(Vector3 velocity, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.setVelocitiesTo(velocity, boolean));
	public AutoBehaviourT zeroVelocity(bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.zeroVelocity(boolean));
	public AutoBehaviourT zeroAngularVelocity(bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.zeroAngularVelocity(boolean));
	public AutoBehaviourT zeroVelocities(bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.zeroVelocities(boolean));
	#endregion velocities

	#region accelerating
	public AutoBehaviourT accelerateBy(Vector3 acceleration, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.accelerateBy(acceleration, boolean));
	#endregion accelerating

	#region applying force
	public AutoBehaviourT applyForceOf(Vector3 force, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyForceOf(force, boolean));
	public AutoBehaviourT applyForceOf(float forceX, float forceY, float forceZ, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyForceOf(forceX, forceY, forceZ, boolean));
	public AutoBehaviourT applyForceAlong(Vector3 direction, float magnitude, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyForceAlong(direction, magnitude, boolean));
	public AutoBehaviourT applyForceAlong(Vector3 direction, Distinctivity distinctivity, object potentialTransform_TransformProvider, float magnitude, bool boolean = true)
	{
		Transform potentialTransform = potentialTransform_TransformProvider.provideTransform();

		return selfAfter(()=> ensuredCorrespondingRigidbody.applyForceAlong(direction, distinctivity, potentialTransform, magnitude, boolean));
	}
	public AutoBehaviourT applyForceAlongLocal(Vector3 localDirection, object transform_TransformProvider, float magnitude, bool boolean = true)
	{
		Transform transform = transform_TransformProvider.provideTransform();

		return selfAfter(()=> ensuredCorrespondingRigidbody.applyForceAlongLocal(localDirection, transform, magnitude, boolean));
	}
	public AutoBehaviourT applyForceAlong(BasicDirection localBasicDirection, float magnitude, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyForceAlong(localBasicDirection, magnitude, boolean));
	public AutoBehaviourT applyForceAlongGlobal(BasicDirection basicDirection, float magnitude, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyForceAlongGlobal(basicDirection, magnitude, boolean));
	public AutoBehaviourT applyForceAlong(BasicDirection basicDirection, Distinctivity distinctivity, float magnitude, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyForceAlong(basicDirection, distinctivity, magnitude, boolean));
	public AutoBehaviourT applyForwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyForwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyBackwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyBackwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyRightwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyRightwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyLeftwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyLeftwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyUpwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyUpwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyDownwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyDownwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyGlobalForwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyGlobalForwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyGlobalBackwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyGlobalBackwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyGlobalRightwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyGlobalRightwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyGlobalLeftwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyGlobalLeftwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyGlobalUpwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyGlobalUpwardForceOf(magnitude, boolean));
	public AutoBehaviourT applyGlobalDownwardForceOf(float magnitude, bool boolean = true)
		=> selfAfter(()=> ensuredCorrespondingRigidbody.applyGlobalDownwardForceOf(magnitude, boolean));
	#endregion applying force

	#region applying directed force
	public AutoBehaviourT applyDirectedForceFrom(object forcingPosition_PositionProvider, Vector3 direction, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
		=>	selfAfter(()=> ensuredCorrespondingRigidbody.applyDirectedForceFrom
			(
				forcingPosition_PositionProvider.providePosition(),
				direction,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			));
	public AutoBehaviourT applyDirectedForceFrom(object forcingTransform_TransformProvider, Vector3 direction, Distinctivity distinctivity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
		=>	selfAfter(()=> ensuredCorrespondingRigidbody.applyDirectedForceFrom
			(
				forcingTransform_TransformProvider.providePosition(),
				direction,
				distinctivity,
				magnitude,
				reach,
				reachMagnitudeZeroingCurve,
				zeroForceOutsideReach,
				clamp
			));
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
	public List<float> descendantAudioVolumes => gameObject.descendantAudioVolumes();
	public AutoBehaviourT setAudioVolumeTo(float targetVolume, bool boolean = true)
		=> selfAfter(()=> audioSource.setVolumeTo(targetVolume, boolean));
	public AutoBehaviourT setDescendantsAudioVolumeTo(IList<float> targetVolumes)
		=> selfAfter(()=> gameObject.setDescendantsAudioVolumeTo(targetVolumes));
	#endregion volume

	#region playing
	public bool audioPlaying => audioSource.playing();
	public AutoBehaviourT playAudio()
		=> selfAfter(()=> audioSource.play());
	public AutoBehaviourT playDescendantAudios()
		=> selfAfter(()=> gameObject.playDescendantAudios());
	public AutoBehaviourT stopAudio()
		=> selfAfter(()=> audioSource.stop());
	public AutoBehaviourT stopDescendantAudios()
		=> selfAfter(()=> gameObject.stopDescendantAudios());
	public float audioTime => audioSource.time;
	public AutoBehaviourT setAudioTimeTo(float targetTime, bool boolean = true)
		=> selfAfter(()=> audioSource.setTimeTo(targetTime, boolean));
	#endregion playing

	#region acting upon descendant audio
	public AutoBehaviourT actUponDescendantAudioSources(Action<List<AudioSource>> action)
		=> selfAfter(()=> gameObject.actUponDescendantAudioSources(action));
	#endregion acting upon descendant audio
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
		=>	selfAfter(()=>
				lineRenderer.setFirstTwoPointsTo
				(
					firstPosition_PositionProvider.providePosition(),
					secondPosition_PositionProvider.providePosition()
				));
	public AutoBehaviourT setLineRendererFirstTwoPointsForLineLocallyDirectedFrom(object startingTransform_TransformProvider, Vector3 localDirection, float distance)
		=>	selfAfter(()=> lineRenderer.setFirstTwoPointsForLineLocallyDirectedFrom
			(
				startingTransform_TransformProvider.provideTransform(),
				localDirection,
				distance
			));
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
		=>	selfAfter(()=>
				ensuredLineRenderer.setupAsLineOfLightLocallyDirectedFrom
				(
					startingTransform_TransformProvider.provideTransform(),
					localDirection,
					distance,
					material
				));
	#endregion line of light setup
	#endregion LineRenderer


	#region ParticleSystem

	#region playing
	public AutoBehaviourT togglePlayingDescendantParticlesSystems(bool boolean)
		=> selfAfter(()=> gameObject.togglePlayingDescendantParticlesSystems(boolean));
	public AutoBehaviourT playDescendantParticlesSystems(bool boolean = true)
		=> selfAfter(()=> gameObject.playDescendantParticlesSystems(boolean));
	public AutoBehaviourT stopDescendantParticlesSystems(bool boolean = true)
		=> selfAfter(()=> gameObject.stopDescendantParticlesSystems(boolean));
	#endregion playing

	#region acting upon descendant particles systems
	public AutoBehaviourT actUponDescendantParticlesSystems(Action<List<ParticleSystem>> action)
		=> selfAfter(()=> gameObject.actUponDescendantParticlesSystems(action));
	#endregion acting upon descendant particles systems
	#endregion ParticleSystem


	#region MeshFilter
	public Mesh mesh => meshFilter.mesh;
	public AutoBehaviourT setMeshTo(object mesh_MeshProvider, bool boolean = true)
		=> selfAfter(()=> meshFilter.setMeshTo(mesh_MeshProvider.provideMesh(), boolean));
	public Mesh sharedMesh => meshFilter.sharedMesh;
	public AutoBehaviourT setSharedMeshTo(object sharedMesh_SharedMeshProvider, bool boolean = true)
		=> selfAfter(()=> meshFilter.setSharedMeshTo(sharedMesh_SharedMeshProvider.provideSharedMesh(), boolean));
	public Mesh sharedMeshOtherwiseMesh => sharedMesh ? sharedMesh : mesh;
	#endregion MeshFilter


	#region Light

	#region intensities
	public float lightIntensity => light.intensity;
	public List<float> descendantLightIntensities => gameObject.descendantLightIntensities();
	public AutoBehaviourT setLightIntensityTo(float targetIntensity)
		=> selfAfter(()=> light.setIntensityTo(targetIntensity));
	public AutoBehaviourT setDescendantLightIntensitiesTo(float targetIntensity)
		=> selfAfter(()=> gameObject.setDescendantLightIntensitiesTo(targetIntensity));
	public AutoBehaviourT setDescendantLightIntensitiesTo(IList<float> targetIntensities)
		=> selfAfter(()=> gameObject.setDescendantLightIntensitiesTo(targetIntensities));
	#endregion intensities

	#region setting render mode
	public AutoBehaviourT renderDescendantLightsBy(LightRenderMode lightRenderMode)
		=> selfAfter(()=> gameObject.renderDescendantLightsBy(lightRenderMode));
	public AutoBehaviourT renderDescendantLightsByPixel()
		=> selfAfter(()=> gameObject.renderDescendantLightsByPixel());
	public AutoBehaviourT renderDescendantLightsByVertex()
		=> selfAfter(()=> gameObject.renderDescendantLightsByVertex());
	#endregion setting render mode

	#region acting upon descendant lights
	public AutoBehaviourT actUponDescendantLights(Action<List<Light>> action)
		=> selfAfter(()=> gameObject.actUponDescendantLights(action));
	#endregion acting upon descendant lights
	#endregion Light


	#region EdgeCollider2D

	#region setting points
	public AutoBehaviourT setPointsTo(params Vector2[] points)
		=> selfAfter(()=> edgeCollider.setPointsTo(points));
	public AutoBehaviourT setPointsTo(IEnumerable<Vector2> points)
		=> selfAfter(()=> edgeCollider.setPointsTo(points));
	#endregion setting points
	#endregion EdgeCollider2D


	#if NAV_MESH_COMPONENTS
	#region NavMeshAgent

	#region destinating
	public bool destinateTo(object destinationPosition_PositionProvider)
		=> navmeshAgent.destinateTo(destinationPosition_PositionProvider);
	public bool destinateTo<SingletonBehaviourT>() where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> navmeshAgent.destinateTo<SingletonBehaviourT>();
	public bool destinateToCamera()
		=> navmeshAgent.destinateToCamera();
	#endregion destinating
	
	#region setting haltedness
	public AutoBehaviourT setHaltednessTo(bool boolean)
		=> selfAfter(()=> navmeshAgent.setHaltednessTo(boolean));
	public AutoBehaviourT halt()
		=> selfAfter(()=> navmeshAgent.halt());
	public AutoBehaviourT unhalt()
		=> selfAfter(()=> navmeshAgent.unhalt());
	#endregion setting haltedness
	
	#region navigating
	public bool beginNavigatingTo(object destinationPosition_PositionProvider)
		=> navmeshAgent.beginNavigatingTo(destinationPosition_PositionProvider);
	public bool beginNavigatingTo<SingletonBehaviourT>() where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> navmeshAgent.beginNavigatingTo<SingletonBehaviourT>();
	public bool beginNavigatingToCamera()
		=> navmeshAgent.beginNavigatingToCamera();
	#endregion navigating
	
	#region setting enablement of rotation via navigation
	public NavMeshAgent setEnablementOfRotationViaNavigationTo(bool boolean)
		=> navmeshAgent.setEnablementOfRotationViaNavigationTo(boolean);
	public NavMeshAgent enableRotationViaNavigation()
		=> navmeshAgent.enableRotationViaNavigation();
	public NavMeshAgent disableRotationViaNavigation()
		=> navmeshAgent.disableRotationViaNavigation();
	#endregion setting enablement of rotation via navigation
	#endregion NavMeshAgent
	#endif
}