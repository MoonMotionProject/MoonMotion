using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LightExtensions: provides extension methods for handling lights //
public static class LightExtensions
{
	#region intensities

	public static List<float> intensities(this IEnumerable<Light> lights)
		=> lights.pick(light => light.intensity);
	public static List<float> childLightIntensities(this GameObject gameObject)
		=> gameObject.children<Light>().intensities();

	public static Light setIntensityTo(this Light light, float targetIntensity)
	{
		light.intensity = targetIntensity.clampedValidAndNonnegative();

		return light;
	}

	public static IEnumerable<Light> setIntensitiesTo(this IEnumerable<Light> lights, float targetIntensity)
		=> lights.forEach(light => light.setIntensityTo(targetIntensity));
	public static GameObject setChildLightIntensitiesTo(this GameObject gameObject, float targetIntensity)
		=> gameObject.setChildLightIntensitiesTo(new float[] {targetIntensity});

	public static IEnumerable<Light> setIntensitiesTo(this IEnumerable<Light> lights, IEnumerable<float> targetIntensities)
	=> lights.forEachByLooping(
			targetIntensities,
			(light, targetIntensity) => light.setIntensityTo(targetIntensity));
	public static GameObject setChildLightIntensitiesTo(this GameObject gameObject, IEnumerable<float> targetIntensities)
		=> gameObject.actUponChildLights(childLights =>
			childLights.setIntensitiesTo(targetIntensities));

	#endregion intensities


	#region setting render mode

	public static Light renderBy(this Light light, LightRenderMode lightRenderMode)
		=> light.after(()=>
			light.renderMode = lightRenderMode);
	public static IEnumerable<Light> renderBy(this IEnumerable<Light> lights, LightRenderMode lightRenderMode)
		=> lights.forEach(light => light.renderBy(lightRenderMode));
	public static GameObject renderChildLightsBy(this GameObject gameObject, LightRenderMode lightRenderMode)
		=> gameObject.actUponChildLights(childLights =>
			childLights.renderBy(lightRenderMode));

	public static Light renderByPixel(this Light light)
		=> light.renderBy(LightRenderMode.ForcePixel);
	public static IEnumerable<Light> renderByPixel(this IEnumerable<Light> lights)
		=> lights.renderBy(LightRenderMode.ForcePixel);
	public static GameObject renderChildLightsByPixel(this GameObject gameObject)
		=> gameObject.renderChildLightsBy(LightRenderMode.ForcePixel);

	public static Light renderByVertex(this Light light)
		=> light.renderBy(LightRenderMode.ForceVertex);
	public static IEnumerable<Light> renderByVertex(this IEnumerable<Light> lights)
		=> lights.renderBy(LightRenderMode.ForceVertex);
	public static GameObject renderChildLightsByVertex(this GameObject gameObject)
		=> gameObject.renderChildLightsBy(LightRenderMode.ForceVertex);
	#endregion setting render mode


	#region acting upon child lights

	public static GameObject actUponChildLights(this GameObject gameObject, Action<List<Light>> action)
		=> gameObject.after(()=>
			  action(gameObject.children<Light>()));
	#endregion acting upon child lights
}