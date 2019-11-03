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
	public static List<float> descendantLightIntensities(this GameObject gameObject)
		=> gameObject.descendants<Light>().intensities();

	public static Light setIntensityTo(this Light light, float targetIntensity)
	{
		light.intensity = targetIntensity.clampedValidAndNonnegative();

		return light;
	}

	public static IEnumerable<Light> setIntensitiesTo(this IEnumerable<Light> lights, float targetIntensity)
		=> lights.forEach(light => light.setIntensityTo(targetIntensity));
	public static GameObject setDescendantLightIntensitiesTo(this GameObject gameObject, float targetIntensity)
		=> gameObject.setDescendantLightIntensitiesTo(new float[] {targetIntensity});

	public static IEnumerable<Light> setIntensitiesTo(this IEnumerable<Light> lights, IEnumerable<float> targetIntensities)
	=> lights.forEachByLooping(
			targetIntensities,
			(light, targetIntensity) => light.setIntensityTo(targetIntensity));
	public static GameObject setDescendantLightIntensitiesTo(this GameObject gameObject, IEnumerable<float> targetIntensities)
		=> gameObject.actUponDescendantLights(descendantLights =>
			descendantLights.setIntensitiesTo(targetIntensities));

	#endregion intensities


	#region setting render mode

	public static Light renderBy(this Light light, LightRenderMode lightRenderMode)
		=> light.after(()=>
			light.renderMode = lightRenderMode);
	public static IEnumerable<Light> renderBy(this IEnumerable<Light> lights, LightRenderMode lightRenderMode)
		=> lights.forEach(light => light.renderBy(lightRenderMode));
	public static GameObject renderDescendantLightsBy(this GameObject gameObject, LightRenderMode lightRenderMode)
		=> gameObject.actUponDescendantLights(descendantLights =>
			descendantLights.renderBy(lightRenderMode));
	public static List<GameObject> forEachRenderDescendantLightsBy(this IEnumerable<GameObject> gameObjects, LightRenderMode lightRenderMode)
		=>	gameObjects.forEachManifested(gameObject =>
				gameObject.renderDescendantLightsBy(lightRenderMode));

	public static Light renderByPixel(this Light light)
		=> light.renderBy(LightRenderMode.ForcePixel);
	public static IEnumerable<Light> renderByPixel(this IEnumerable<Light> lights)
		=> lights.renderBy(LightRenderMode.ForcePixel);
	public static GameObject renderDescendantLightsByPixel(this GameObject gameObject)
		=> gameObject.renderDescendantLightsBy(LightRenderMode.ForcePixel);
	public static List<GameObject> forEachRenderDescendantLightsByPixel(this IEnumerable<GameObject> gameObjects)
		=>	gameObjects.forEachRenderDescendantLightsBy(LightRenderMode.ForcePixel);

	public static Light renderByVertex(this Light light)
		=> light.renderBy(LightRenderMode.ForceVertex);
	public static IEnumerable<Light> renderByVertex(this IEnumerable<Light> lights)
		=> lights.renderBy(LightRenderMode.ForceVertex);
	public static GameObject renderDescendantLightsByVertex(this GameObject gameObject)
		=> gameObject.renderDescendantLightsBy(LightRenderMode.ForceVertex);
	public static List<GameObject> forEachRenderDescendantLightsByVertex(this IEnumerable<GameObject> gameObjects)
		=>	gameObjects.forEachRenderDescendantLightsBy(LightRenderMode.ForceVertex);
	#endregion setting render mode


	#region acting upon descendant lights

	public static GameObject actUponDescendantLights(this GameObject gameObject, Action<List<Light>> action)
		=> gameObject.after(()=>
			  action(gameObject.descendants<Light>()));
	#endregion acting upon descendant lights
}