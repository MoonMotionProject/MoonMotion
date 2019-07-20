using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LightExtensions: provides extension methods for handling lights //
public static class LightExtensions
{
	// methods for: intensities //

	public static float[] intensities(this Light[] lights)
	{
		float[] childLightIntensities = new float[lights.Length];
		for (int childLightIndex = 0; childLightIndex < lights.Length; childLightIndex++)
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

	public static Light[] setIntensitiesTo(this Light[] lights, float targetIntensity)
	{
		foreach (Light light in lights)
		{
			light.setIntensityTo(targetIntensity);
		}

		return lights;
	}

	public static Light[] setIntensitiesTo(this Light[] lights, float[] targetIntensities)
	{
		for (int childLightIndex = 0; childLightIndex < lights.Length; childLightIndex++)
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

	public static Light[] renderBy(this Light[] lights, LightRenderMode lightRenderMode)
	{
		lights.forEach(light => light.renderBy(lightRenderMode));

		return lights;
	}

	public static Light renderByPixel(this Light light)
		=> light.renderBy(LightRenderMode.ForcePixel);

	public static Light[] renderByPixel(this Light[] lights)
		=> lights.renderBy(LightRenderMode.ForcePixel);

	public static Light renderByVertex(this Light light)
		=> light.renderBy(LightRenderMode.ForceVertex);

	public static Light[] renderByVertex(this Light[] lights)
		=> lights.renderBy(LightRenderMode.ForceVertex);
}