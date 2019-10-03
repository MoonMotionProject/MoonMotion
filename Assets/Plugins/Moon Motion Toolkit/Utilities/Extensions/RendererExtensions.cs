using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Renderer Extensions: provides extension methods for handling renderers //
public static class RendererExtensions
{
	#region game object's renderer enablement

	// method: set the enablement of this given game object's renderer to the given boolean, then return this given game object //
	public static GameObject setRendererEnablementTo(this GameObject gameObject, bool enablement)
		=> gameObject.after(()=>
			gameObject.first<Renderer>().setEnablementTo(enablement));
	#endregion game object's renderer enablement


	#region setting materials

	public static RendererT setMaterialTo<RendererT>(this RendererT renderer, Material material) where RendererT : Renderer
		=> renderer.after(()=>
			renderer.material = material);
	public static GameObject setMaterialTo(this GameObject gameObject, Material material)
		=> gameObject.after(()=>
			gameObject.ensuredRenderer().setMaterialTo(material));

	public static RendererT setSharedMaterialTo<RendererT>(this RendererT renderer, Material sharedMaterial) where RendererT : Renderer
		=> renderer.after(()=>
			renderer.sharedMaterial = sharedMaterial);
	public static GameObject setSharedMaterialTo(this GameObject gameObject, Material sharedMaterial)
		=> gameObject.after(()=>
			gameObject.ensuredRenderer().setSharedMaterialTo(sharedMaterial));
	#endregion setting materials


	#region shadowcasting

	public static RendererT setShadowcastingTo<RendererT>(this RendererT renderer, ShadowCastingMode shadowcasting) where RendererT : Renderer
		=> renderer.after(()=>
			renderer.shadowCastingMode = shadowcasting);

	public static RendererT shadowcast<RendererT>(this RendererT renderer) where RendererT : Renderer
		=> renderer.setShadowcastingTo(ShadowCastingMode.On);

	public static RendererT nonshadowcast<RendererT>(this RendererT renderer) where RendererT : Renderer
		=> renderer.setShadowcastingTo(ShadowCastingMode.Off);
	#endregion shadowcasting


	#region shadowability

	public static RendererT setShadowabilityTo<RendererT>(this RendererT renderer, bool shadowability) where RendererT : Renderer
		=> renderer.after(()=>
			renderer.receiveShadows = shadowability);

	public static RendererT shadowable<RendererT>(this RendererT renderer) where RendererT : Renderer
		=> renderer.setShadowabilityTo(true);

	public static RendererT nonshadowable<RendererT>(this RendererT renderer) where RendererT : Renderer
		=> renderer.setShadowabilityTo(false);
	#endregion shadowability


	#region reflection source

	private static RendererT setReflectionSourceTo<RendererT>(this RendererT renderer, ReflectionProbeUsage reflectionProbeUsage) where RendererT : Renderer
		=> renderer.after(()=>
			renderer.reflectionProbeUsage = reflectionProbeUsage);
	public static RendererT setReflectionSourceTo<RendererT>(this RendererT renderer, ReflectionSource reflectionSource) where RendererT : Renderer
		=> renderer.setReflectionSourceTo(reflectionSource.asReflectionProbeUsage());

	public static RendererT setReflectionSourceToSkybox<RendererT>(this RendererT renderer) where RendererT : Renderer
		=> renderer.setReflectionSourceTo(ReflectionSource.skybox);

	public static RendererT setReflectionSourceToBlendedReflectionProbesOtherwiseSkybox<RendererT>(this RendererT renderer) where RendererT : Renderer
		=> renderer.setReflectionSourceTo(ReflectionSource.blendedReflectionProbesOtherwiseSkybox);

	public static RendererT setReflectionSourceToBlendedReflectionProbesAndSkybox<RendererT>(this RendererT renderer) where RendererT : Renderer
		=> renderer.setReflectionSourceTo(ReflectionSource.blendedReflectionProbesAndSkybox);

	public static RendererT setReflectionSourceToSingleMostRelevantProbeOrSkybox<RendererT>(this RendererT renderer) where RendererT : Renderer
		=> renderer.setReflectionSourceTo(ReflectionSource.singleMostRelevantProbeOrSkybox);
	#endregion reflection source


	#region light probe usage

	public static RendererT setLightProbeUsageTo<RendererT>(this RendererT renderer, LightProbeUsage lightProbeUsage) where RendererT : Renderer
		=> renderer.after(()=>
			renderer.lightProbeUsage = lightProbeUsage);

	public static RendererT setLightProbeUsageToOff<RendererT>(this RendererT renderer) where RendererT : Renderer
		=> renderer.setLightProbeUsageTo(LightProbeUsage.Off);

	public static RendererT setLightProbeUsageToBlendProbes<RendererT>(this RendererT renderer) where RendererT : Renderer
		=> renderer.setLightProbeUsageTo(LightProbeUsage.BlendProbes);

	public static RendererT setRLightProbeUsageToUseProxyVolume<RendererT>(this RendererT renderer) where RendererT : Renderer
		=> renderer.setLightProbeUsageTo(LightProbeUsage.UseProxyVolume);

	public static RendererT setReflectionSourceToCustomProvided<RendererT>(this RendererT renderer) where RendererT : Renderer
		=> renderer.setLightProbeUsageTo(LightProbeUsage.CustomProvided);
	#endregion light probe usage
}