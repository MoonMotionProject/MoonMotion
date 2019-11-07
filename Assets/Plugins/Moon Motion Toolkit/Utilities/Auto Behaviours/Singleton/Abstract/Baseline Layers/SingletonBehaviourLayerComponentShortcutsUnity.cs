using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Singleton Behaviour Layer Component Shortcuts Unity:
// • provides this singleton behaviour with static access to its auto behaviour's Unity component shortcuts layer
// #auto #shortcuts #component #force #linerenderers
public abstract class	SingletonBehaviourLayerComponentShortcutsUnity<SingletonBehaviourT> :
					SingletonBehaviourLayerMonoBehaviour<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region Renderer

	#region enablement
	public static new bool rendererEnablement => autoBehaviour.rendererEnablement;
	public static new AutoBehaviour<SingletonBehaviourT> setRendererEnablementTo(bool boolean)
		=> autoBehaviour.setRendererEnablementTo(boolean);
	public static new AutoBehaviour<SingletonBehaviourT> enableRenderer()
		=> autoBehaviour.enableRenderer();
	public static new AutoBehaviour<SingletonBehaviourT> disableRenderer()
		=> autoBehaviour.disableRenderer();
	public static new AutoBehaviour<SingletonBehaviourT> toggleRendererEnablementBy(Toggling toggling)
		=> autoBehaviour.toggleRendererEnablementBy(toggling);
	#endregion enablement

	#region material
	public static new Material material => autoBehaviour.material;
	public static new AutoBehaviour<SingletonBehaviourT> setMaterialTo(Material material)
		=> autoBehaviour.setMaterialTo(material);
	public static new Material sharedMaterial => autoBehaviour.sharedMaterial;
	public static new AutoBehaviour<SingletonBehaviourT> setSharedMaterialTo(Material sharedMaterial)
		=> autoBehaviour.setSharedMaterialTo(material);
	#endregion material

	#region color
	public static new Color color => material.color;
	public static new AutoBehaviour<SingletonBehaviourT> setColorTo(Color targetColor)
		=> autoBehaviour.setColorTo(targetColor);
	public static new AutoBehaviour<SingletonBehaviourT> setDescendantsColorTo(Color targetColor)
		=> autoBehaviour.setDescendantsColorTo(targetColor);
	public static new AutoBehaviour<SingletonBehaviourT> randomizeColor()
		=> autoBehaviour.randomizeColor();
	public static new AutoBehaviour<SingletonBehaviourT> setDescendantsEmissionColorTo(Color targetColor, bool boolean = true)
		=> autoBehaviour.setDescendantsEmissionColorTo(targetColor, boolean);
	#endregion color

	#region shadowcasting
	public static new AutoBehaviour<SingletonBehaviourT> setShadowcastingTo(ShadowCastingMode shadowcasting)
		=> autoBehaviour.setShadowcastingTo(shadowcasting);
	public static new AutoBehaviour<SingletonBehaviourT> shadowcast()
		=> autoBehaviour.shadowcast();
	public static new AutoBehaviour<SingletonBehaviourT> nonshadowcast()
		=> autoBehaviour.nonshadowcast();
	#endregion shadowcasting

	#region shadowability
	public static new AutoBehaviour<SingletonBehaviourT> setShadowabilityTo(bool shadowability)
		=> autoBehaviour.setShadowabilityTo(shadowability);
	public static new AutoBehaviour<SingletonBehaviourT> shadowable()
		=> autoBehaviour.shadowable();
	public static new AutoBehaviour<SingletonBehaviourT> nonshadowable()
		=> autoBehaviour.nonshadowable();
	#endregion shadowability

	#region reflection source
	public static new AutoBehaviour<SingletonBehaviourT> setReflectionSourceTo(ReflectionSource reflectionSource)
		=> autoBehaviour.setReflectionSourceTo(reflectionSource);
	public static new AutoBehaviour<SingletonBehaviourT> setReflectionSourceToSkybox()
		=> autoBehaviour.setReflectionSourceToSkybox();
	public static new AutoBehaviour<SingletonBehaviourT> setReflectionSourceToBlendedReflectionProbesOtherwiseSkybox()
		=> autoBehaviour.setReflectionSourceToBlendedReflectionProbesOtherwiseSkybox();
	public static new AutoBehaviour<SingletonBehaviourT> setReflectionSourceToBlendedReflectionProbesAndSkybox()
		=> autoBehaviour.setReflectionSourceToBlendedReflectionProbesAndSkybox();
	public static new AutoBehaviour<SingletonBehaviourT> setReflectionSourceToSingleMostRelevantProbeOrSkybox()
		=> autoBehaviour.setReflectionSourceToSingleMostRelevantProbeOrSkybox();
	#endregion reflection source

	#region light probe usage
	public static new AutoBehaviour<SingletonBehaviourT> setLightProbeUsageTo(LightProbeUsage lightProbeUsage)
		=> autoBehaviour.setLightProbeUsageTo(lightProbeUsage);
	public static new AutoBehaviour<SingletonBehaviourT> setLightProbeUsageToOff()
		=> autoBehaviour.setLightProbeUsageToOff();
	public static new AutoBehaviour<SingletonBehaviourT> setLightProbeUsageToBlendProbes()
		=> autoBehaviour.setLightProbeUsageToBlendProbes();
	public static new AutoBehaviour<SingletonBehaviourT> setRLightProbeUsageToUseProxyVolume()
		=> autoBehaviour.setRLightProbeUsageToUseProxyVolume();
	public static new AutoBehaviour<SingletonBehaviourT> setReflectionSourceToCustomProvided()
		=> autoBehaviour.setReflectionSourceToCustomProvided();
	#endregion light probe usage
	#endregion Renderer


	#region Rigidbody

	#region kinematicity
	public static new bool kinematicity => autoBehaviour.kinematicity;
	public static new AutoBehaviour<SingletonBehaviourT> setKinematicityTo(bool kinematicity, bool boolean = true)
		=> autoBehaviour.setKinematicityTo(kinematicity, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> kinematize(bool boolean = true)
		=> autoBehaviour.kinematize(boolean);
	public static new AutoBehaviour<SingletonBehaviourT> nonkinematize(bool boolean = true)
		=> autoBehaviour.nonkinematize(boolean);
	#endregion kinematicity

	#region gravitization
	public static new bool gravitization => autoBehaviour.gravitization;
	public static new AutoBehaviour<SingletonBehaviourT> setGravitizationTo(bool gravitization, bool boolean = true)
		=> autoBehaviour.setGravitizationTo(gravitization, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> gravitize(bool boolean = true)
		=> autoBehaviour.gravitize(boolean);
	public static new AutoBehaviour<SingletonBehaviourT> nongravitize(bool boolean = true)
		=> autoBehaviour.nongravitize(boolean);
	#endregion gravitization

	#region velocity vectrals
	public static new Vector3 velocityDirection => autoBehaviour.velocityDirection;
	public static new AutoBehaviour<SingletonBehaviourT> setVelocityDirectionTo(Vector3 direction, bool boolean = true)
		=> autoBehaviour.setVelocityDirectionTo(direction, boolean);
	public static new Vector3 angularVelocityAngling => autoBehaviour.angularVelocityAngling;
	public static new AutoBehaviour<SingletonBehaviourT> setAngularVelocityAnglingTo(Vector3 angling, bool boolean = true)
		=> autoBehaviour.setAngularVelocityAnglingTo(angling, boolean);
	#endregion velocity vectrals

	#region speeds
	public static new float speed => autoBehaviour.speed;
	public static new AutoBehaviour<SingletonBehaviourT> setSpeedTo(float speed, bool boolean = true)
		=> autoBehaviour.setSpeedTo(speed, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> honeSpeed(float honingTarget, float honingAmount, bool boolean = true)
		=> autoBehaviour.honeSpeed(honingTarget, honingAmount, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> slowSpeedBy(float speedReduction, bool boolean = true)
		=> autoBehaviour.slowSpeedBy(speedReduction, boolean);
	public static new float angularSpeed => autoBehaviour.angularSpeed;
	public static new AutoBehaviour<SingletonBehaviourT> setAngularSpeedTo(float angularSpeed, bool boolean = true)
		=> autoBehaviour.setAngularSpeedTo(angularSpeed, boolean);
	#endregion speed

	#region velocities
	public static new Vector3 velocity => autoBehaviour.velocity;
	public static new Vector3 angularVelocity => autoBehaviour.angularVelocity;
	public static new AutoBehaviour<SingletonBehaviourT> setVelocityTo(Vector3 velocity, bool boolean = true)
		=> autoBehaviour.setVelocityTo(velocity, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setAngularVelocityTo(Vector3 angularVelocity, bool boolean = true)
		=> autoBehaviour.setAngularVelocityTo(angularVelocity, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setVelocitiesTo(Vector3 directionalVelocity, Vector3 angularVelocity, bool boolean = true)
		=> autoBehaviour.setVelocitiesTo(directionalVelocity, angularVelocity, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setVelocitiesTo(Vector3 velocity, bool boolean = true)
		=> autoBehaviour.setVelocitiesTo(velocity, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> zeroVelocity(bool boolean = true)
		=> autoBehaviour.zeroVelocity(boolean);
	public static new AutoBehaviour<SingletonBehaviourT> zeroAngularVelocity(bool boolean = true)
		=> autoBehaviour.zeroAngularVelocity(boolean);
	public static new AutoBehaviour<SingletonBehaviourT> zeroVelocities(bool boolean = true)
		=> autoBehaviour.zeroVelocities(boolean);
	#endregion velocities

	#region accelerating
	public static new AutoBehaviour<SingletonBehaviourT> accelerateBy(Vector3 acceleration, bool boolean = true)
		=> autoBehaviour.accelerateBy(acceleration, boolean);
	#endregion accelerating

	#region applying force
	public static new AutoBehaviour<SingletonBehaviourT> applyForceOf(Vector3 force, bool boolean = true)
		=> autoBehaviour.applyForceOf(force, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> applyForceOf(float forceX, float forceY, float forceZ, bool boolean = true)
		=> autoBehaviour.applyForceOf(forceX, forceY, forceZ, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> applyForceAlong(Vector3 direction, float magnitude, bool boolean = true)
		=> autoBehaviour.applyForceAlong(direction, magnitude, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> applyForceAlong(Vector3 direction, Distinctivity distinctivity, object potentialTransform_TransformProvider, float magnitude, bool boolean = true)
	{
		Transform potentialTransform = potentialTransform_TransformProvider.provideTransform();

		return autoBehaviour.applyForceAlong(direction, distinctivity, potentialTransform, magnitude, boolean);
	}
	public static new AutoBehaviour<SingletonBehaviourT> applyForceAlongLocal(Vector3 localDirection, object transform_TransformProvider, float magnitude, bool boolean = true)
	{
		Transform transform = transform_TransformProvider.provideTransform();

		return autoBehaviour.applyForceAlongLocal(localDirection, transform, magnitude, boolean);
	}
	public static new AutoBehaviour<SingletonBehaviourT> applyForceAlong(BasicDirection localBasicDirection, float magnitude, bool boolean = true)
		=> autoBehaviour.applyForceAlong(localBasicDirection, magnitude, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> applyForceAlongGlobal(BasicDirection basicDirection, float magnitude, bool boolean = true)
		=> autoBehaviour.applyForceAlongGlobal(basicDirection, magnitude, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> applyForceAlong(BasicDirection basicDirection, Distinctivity distinctivity, float magnitude, bool boolean = true)
		=> autoBehaviour.applyForceAlong(basicDirection, distinctivity, magnitude, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> applyForwardForceOf(float magnitude, bool boolean = true)
		=> autoBehaviour.applyForwardForceOf(magnitude, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> applyBackwardForceOf(float magnitude, bool boolean = true)
		=> autoBehaviour.applyBackwardForceOf(magnitude, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> applyRightwardForceOf(float magnitude, bool boolean = true)
		=> autoBehaviour.applyRightwardForceOf(magnitude, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> applyLeftwardForceOf(float magnitude, bool boolean = true)
		=> autoBehaviour.applyLeftwardForceOf(magnitude, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> applyUpwardForceOf(float magnitude, bool boolean = true)
		=> autoBehaviour.applyUpwardForceOf(magnitude, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> applyDownwardForceOf(float magnitude, bool boolean = true)
		=> autoBehaviour.applyDownwardForceOf(magnitude, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> applyGlobalForwardForceOf(float magnitude, bool boolean = true)
		=> autoBehaviour.applyGlobalForwardForceOf(magnitude, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> applyGlobalBackwardForceOf(float magnitude, bool boolean = true)
		=> autoBehaviour.applyGlobalBackwardForceOf(magnitude, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> applyGlobalRightwardForceOf(float magnitude, bool boolean = true)
		=> autoBehaviour.applyGlobalRightwardForceOf(magnitude, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> applyGlobalLeftwardForceOf(float magnitude, bool boolean = true)
		=> autoBehaviour.applyGlobalLeftwardForceOf(magnitude, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> applyGlobalUpwardForceOf(float magnitude, bool boolean = true)
		=> autoBehaviour.applyGlobalUpwardForceOf(magnitude, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> applyGlobalDownwardForceOf(float magnitude, bool boolean = true)
		=> autoBehaviour.applyGlobalDownwardForceOf(magnitude, boolean);
	#endregion applying force

	#region applying directed force
	public static new AutoBehaviour<SingletonBehaviourT> applyDirectedForceFrom(object forcingPosition_PositionProvider, Vector3 direction, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		Vector3 forcingPosition = forcingPosition_PositionProvider.providePosition();

		return autoBehaviour.applyDirectedForceFrom
		(
			forcingPosition,
			direction,
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	}
	public static new AutoBehaviour<SingletonBehaviourT> applyDirectedForceFrom(object forcingTransform_TransformProvider, Vector3 direction, Distinctivity distinctivity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		Transform forcingTransform = forcingTransform_TransformProvider.provideTransform();

		return autoBehaviour.applyDirectedForceFrom
		(
			forcingTransform,
			direction,
			distinctivity,
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	}
	#endregion applying directed force
	#endregion Rigidbody


	#region AudioSource

	#region audio
	public static new AudioClip audio => autoBehaviour.audio;
	public static new AutoBehaviour<SingletonBehaviourT> setAudioTo(AudioClip targetAudio, bool boolean = true)
		=> autoBehaviour.setAudioTo(targetAudio, boolean);
	public static new float audioDuration => autoBehaviour.audioDuration;
	#endregion audio

	#region volume
	public static new float audioVolume => autoBehaviour.audioVolume;
	public static new List<float> descendantAudioVolumes => autoBehaviour.descendantAudioVolumes;
	public static new AutoBehaviour<SingletonBehaviourT> setAudioVolumeTo(float targetVolume, bool boolean = true)
		=> autoBehaviour.setAudioVolumeTo(targetVolume, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setDescendantsAudioVolumeTo(IList<float> targetVolumes)
		=> autoBehaviour.setDescendantsAudioVolumeTo(targetVolumes);
	#endregion volume

	#region playing
	public static new bool audioPlaying => autoBehaviour.audioPlaying;
	public static new AutoBehaviour<SingletonBehaviourT> playAudio()
		=> autoBehaviour.playAudio();
	public static new AutoBehaviour<SingletonBehaviourT> playDescendantAudios()
		=> autoBehaviour.playDescendantAudios();
	public static new AutoBehaviour<SingletonBehaviourT> stopAudio()
		=> autoBehaviour.stopAudio();
	public static new AutoBehaviour<SingletonBehaviourT> stopDescendantAudios()
		=> autoBehaviour.stopDescendantAudios();
	public static new float audioTime => autoBehaviour.audioTime;
	public static new AutoBehaviour<SingletonBehaviourT> setAudioTimeTo(float targetTime, bool boolean = true)
		=> autoBehaviour.setAudioTimeTo(targetTime, boolean);
	#endregion playing

	#region acting upon descendant audio
	public static new AutoBehaviour<SingletonBehaviourT> actUponDescendantAudioSources(Action<List<AudioSource>> action)
		=> autoBehaviour.actUponDescendantAudioSources(action);
	#endregion acting upon descendant audio
	#endregion AudioSource


	#region LineRenderer

	#region setting starting and ending widths
	public static new AutoBehaviour<SingletonBehaviourT> setLineRendererStartingWidthTo(float targetStartingWidth)
		=> autoBehaviour.setLineRendererStartingWidthTo(targetStartingWidth);
	public static new AutoBehaviour<SingletonBehaviourT> setLineRendererEndingWidthTo(float targetEndingWidth)
		=> autoBehaviour.setLineRendererEndingWidthTo(targetEndingWidth);
	public static new AutoBehaviour<SingletonBehaviourT> setLineRendererStartingAndEndingWidthsTo(float targetStartingWidth, float targetEndingWidth)
		=> autoBehaviour.setLineRendererStartingAndEndingWidthsTo(targetStartingWidth, targetEndingWidth);
	public static new AutoBehaviour<SingletonBehaviourT> setLineRendererStartingAndEndingWidthsTo(float targetWidth)
		=> autoBehaviour.setLineRendererStartingAndEndingWidthsTo(targetWidth);
	#endregion setting starting and ending widths

	#region setting number of points
	public static new AutoBehaviour<SingletonBehaviourT> setLineRendererNumberOfPointsTo(int numberOfPoints)
		=> autoBehaviour.setLineRendererNumberOfPointsTo(numberOfPoints);
	#endregion setting number of points

	#region setting points
	public static new AutoBehaviour<SingletonBehaviourT> setLineRendererPointAtIndex(int index, Vector2 point)
		=> autoBehaviour.setLineRendererPointAtIndex(index, point);
	public static new AutoBehaviour<SingletonBehaviourT> setLineRendererPointAtIndex(int index, object position_PositionProvider)
		=> autoBehaviour.setLineRendererPointAtIndex(index, position_PositionProvider);
	public static new AutoBehaviour<SingletonBehaviourT> setLineRendererFirstPointTo(object position_PositionProvider)
		=> autoBehaviour.setLineRendererFirstPointTo(position_PositionProvider);
	public static new AutoBehaviour<SingletonBehaviourT> setLineRendererSecondPointTo(object position_PositionProvider)
		=> autoBehaviour.setLineRendererSecondPointTo(position_PositionProvider);
	public static new AutoBehaviour<SingletonBehaviourT> setLineRendererFirstTwoPointsTo(object firstPosition_PositionProvider, object secondPosition_PositionProvider)
		=>	autoBehaviour.setLineRendererFirstTwoPointsTo
			(
				firstPosition_PositionProvider,
				secondPosition_PositionProvider
			);
	public static new AutoBehaviour<SingletonBehaviourT> setLineRendererFirstTwoPointsForLineLocallyDirectedFrom(object startingTransform_TransformProvider, Vector3 localDirection, float distance)
		=>	autoBehaviour.setLineRendererFirstTwoPointsForLineLocallyDirectedFrom
			(
				startingTransform_TransformProvider.provideTransform(),
				localDirection,
				distance
			);
	#endregion setting points
	
	#region setting distinctivity
	public static new AutoBehaviour<SingletonBehaviourT> setLineRendererDistinctivityTo(Distinctivity distinctivity)
		=> autoBehaviour.setLineRendererDistinctivityTo(distinctivity);
	public static new AutoBehaviour<SingletonBehaviourT> positionLineRendererGlobally()
		=> autoBehaviour.positionLineRendererGlobally();
	public static new AutoBehaviour<SingletonBehaviourT> positionLineRendererLocally()
		=> autoBehaviour.positionLineRendererLocally();
	#endregion setting distinctivity
	
	#region setting starting and ending colors
	public static new AutoBehaviour<SingletonBehaviourT> setLineRendererStartingColorTo(Color color)
		=> autoBehaviour.setLineRendererStartingColorTo(color);
	public static new AutoBehaviour<SingletonBehaviourT> setLineRendererEndingColorTo(Color color)
		=> autoBehaviour.setLineRendererEndingColorTo(color);
	public static new AutoBehaviour<SingletonBehaviourT> setLineRendererColorTo(Color color)
		=> autoBehaviour.setLineRendererColorTo(color);
	public static new AutoBehaviour<SingletonBehaviourT> setLineRendererStartingAndEndingColorsToColorOfItsMaterial()
		=> autoBehaviour.setLineRendererStartingAndEndingColorsToColorOfItsMaterial();
	#endregion setting starting and ending colors

	#region line of light setup
	public static new AutoBehaviour<SingletonBehaviourT> setupLineRendererAsLineOfLightFrom
	(
		object startingPosition_PositionProvider,
		object endingPosition_PositionProvider,
		Material material,
		float width = Default.lineRendererWidth
	)
		=>	autoBehaviour.setupLineRendererAsLineOfLightFrom
			(
				startingPosition_PositionProvider,
				endingPosition_PositionProvider,
				material,
				width
			);
	public static new AutoBehaviour<SingletonBehaviourT> setupLineRendererAsLineOfLightLocallyDirectedFrom(object startingTransform_TransformProvider, Vector3 localDirection, float distance, Material material)
		=>	autoBehaviour.setupLineRendererAsLineOfLightLocallyDirectedFrom
			(
				startingTransform_TransformProvider.provideTransform(),
				localDirection,
				distance,
				material
			);
	#endregion line of light setup
	#endregion LineRenderer


	#region ParticleSystem

	#region playing
	public static new AutoBehaviour<SingletonBehaviourT> togglePlayingDescendantParticlesSystems(bool boolean)
		=> autoBehaviour.togglePlayingDescendantParticlesSystems(boolean);
	public static new AutoBehaviour<SingletonBehaviourT> playDescendantParticlesSystems(bool boolean = true)
		=> autoBehaviour.playDescendantParticlesSystems(boolean);
	public static new AutoBehaviour<SingletonBehaviourT> stopDescendantParticlesSystems(bool boolean = true)
		=> autoBehaviour.stopDescendantParticlesSystems(boolean);
	#endregion playing

	#region acting upon descendant particles systems
	public static new AutoBehaviour<SingletonBehaviourT> actUponDescendantParticlesSystems(Action<List<ParticleSystem>> action)
		=> autoBehaviour.actUponDescendantParticlesSystems(action);
	#endregion acting upon descendant particles systems
	#endregion ParticleSystem


	#region MeshFilter
	public static new Mesh mesh => autoBehaviour.mesh;
	public static new AutoBehaviour<SingletonBehaviourT> setMeshTo(object mesh_MeshProvider, bool boolean = true)
		=>	autoBehaviour.setMeshTo
			(
				mesh_MeshProvider.provideMesh(),
				boolean
			);
	public static new Mesh sharedMesh => autoBehaviour.sharedMesh;
	public static new AutoBehaviour<SingletonBehaviourT> setSharedMeshTo(object sharedMesh_SharedMeshProvider, bool boolean = true)
		=>	autoBehaviour.setSharedMeshTo
			(
				sharedMesh_SharedMeshProvider.provideSharedMesh(),
				boolean
			);
	public static new Mesh sharedMeshOtherwiseMesh => sharedMesh ? sharedMesh : mesh;
	#endregion MeshFilter


	#region Animator

	#region triggering animatriggers
	public static new Animator triggerAnimatrigger(string targetAnimatriggerName, bool boolean = true)
		=>	autoBehaviour.triggerAnimatrigger(targetAnimatriggerName,
				boolean);
	#endregion triggering animatriggers

	#region setting enablement of animatoggles
	public static new Animator setEnablementOfAnimatoggle(string targetBooleanName, bool newBoolean, bool boolean = true)
		=> autoBehaviour.setEnablementOfAnimatoggle(targetBooleanName, newBoolean,
			boolean);
	public static new Animator enableAnimatoggle(string targetBooleanName, bool boolean = true)
		=> autoBehaviour.enableAnimatoggle(targetBooleanName,
			boolean);
	public static new Animator disableAnimatoggle(string targetBooleanName, bool boolean = true)
		=> autoBehaviour.disableAnimatoggle(targetBooleanName,
			boolean);
	#endregion setting enablement of animatoggles
	#endregion Animator


	#region Light

	#region intensities
	public static new float lightIntensity => autoBehaviour.lightIntensity;
	public static new List<float> descendantLightIntensities => autoBehaviour.descendantLightIntensities;
	public static new AutoBehaviour<SingletonBehaviourT> setLightIntensityTo(float targetIntensity)
		=> autoBehaviour.setLightIntensityTo(targetIntensity);
	public static new AutoBehaviour<SingletonBehaviourT> setDescendantLightIntensitiesTo(float targetIntensity)
		=> autoBehaviour.setDescendantLightIntensitiesTo(targetIntensity);
	public static new AutoBehaviour<SingletonBehaviourT> setDescendantLightIntensitiesTo(IList<float> targetIntensities)
		=> autoBehaviour.setDescendantLightIntensitiesTo(targetIntensities);
	#endregion intensities

	#region setting render mode
	public static new AutoBehaviour<SingletonBehaviourT> renderDescendantLightsBy(LightRenderMode lightRenderMode)
		=> autoBehaviour.renderDescendantLightsBy(lightRenderMode);
	public static new AutoBehaviour<SingletonBehaviourT> renderDescendantLightsByPixel()
		=> autoBehaviour.renderDescendantLightsByPixel();
	public static new AutoBehaviour<SingletonBehaviourT> renderDescendantLightsByVertex()
		=> autoBehaviour.renderDescendantLightsByVertex();
	#endregion setting render mode

	#region acting upon descendant lights
	public static new AutoBehaviour<SingletonBehaviourT> actUponDescendantLights(Action<List<Light>> action)
		=> autoBehaviour.actUponDescendantLights(action);
	#endregion acting upon descendant lights
	#endregion Light


	#region EdgeCollider2D

	#region setting points
	public static new AutoBehaviour<SingletonBehaviourT> setPointsTo(params Vector2[] points)
		=> autoBehaviour.setPointsTo(points);
	public static new AutoBehaviour<SingletonBehaviourT> setPointsTo(IEnumerable<Vector2> points)
		=> autoBehaviour.setPointsTo(points);
	#endregion setting points
	#endregion EdgeCollider2D
}