using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LightExtensions: provides extension methods for handling lights //
public static class LightExtensions
{
	// methods for: intensities //

	public static float[] intensities<IListT>(this IListT lights) where IListT : IList<Light>
	{
		float[] childLightIntensities = new float[lights.Count];
		for (int childLightIndex = 0; childLightIndex < lights.Count; childLightIndex++)
		{
			childLightIntensities[childLightIndex] = lights[childLightIndex].intensity;
		}
		return childLightIntensities;
	}

	public static Light setIntensityTo(this Light light, float targetIntensity)
	{
		light.intensity = targetIntensity.clampedValidAndNonnegative();

		return light;
	}

	public static IEnumerableT setIntensitiesTo<IEnumerableT>(this IEnumerableT lights, float targetIntensity) where IEnumerableT : IEnumerable<Light>
	{
		foreach (Light light in lights)
		{
			light.setIntensityTo(targetIntensity);
		}

		return lights;
	}

	public static IListT setIntensitiesTo<IListT>(this IListT lights, float[] targetIntensities) where IListT : IList<Light>
	{
		for (int childLightIndex = 0; childLightIndex < lights.Count; childLightIndex++)
		{
			lights[childLightIndex].setIntensityTo(targetIntensities[childLightIndex % targetIntensities.Length]);
		}

		return lights;
	}


	// methods for: setting render mode //

	public static Light renderBy(this Light light, LightRenderMode lightRenderMode)
	{
		light.renderMode = lightRenderMode;

		return light;
	}

	public static IEnumerableT renderBy<IEnumerableT>(this IEnumerableT lights, LightRenderMode lightRenderMode) where IEnumerableT : IEnumerable<Light>
	{
		lights.forEach(light => light.renderBy(lightRenderMode));

		return lights;
	}

	public static Light renderByPixel(this Light light)
		=> light.renderBy(LightRenderMode.ForcePixel);

	public static IEnumerableT renderByPixel<IEnumerableT>(this IEnumerableT lights) where IEnumerableT : IEnumerable<Light>
		=> lights.renderBy(LightRenderMode.ForcePixel);

	public static Light renderByVertex(this Light light)
		=> light.renderBy(LightRenderMode.ForceVertex);

	public static IEnumerableT renderByVertex<IEnumerableT>(this IEnumerableT lights) where IEnumerableT : IEnumerable<Light>
		=> lights.renderBy(LightRenderMode.ForceVertex);
}