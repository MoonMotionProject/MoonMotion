using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lights: provides methods for handling lights //
public static class Lights
{
	// methods //

	
	// methods for: getting intensities //
	public static float[] getIntensities(Light[] childLights)
	{
		float[] childLightIntensities = new float[childLights.Length];
		for (int childLightIndex = 0; childLightIndex < childLights.Length; childLightIndex++)
		{
			childLightIntensities[childLightIndex] = childLights[childLightIndex].intensity;
		}
		return childLightIntensities;
	}
	public static float[] getChildLightsIntensities(Transform parentTransform)
	{
		return getIntensities(parentTransform.GetComponentsInChildren<Light>());
	}

	// methods for: setting intensities //
	public static void setIntensities(Light[] childLights, float targetIntensity)
	{
		foreach (Light childLight in childLights)
		{
			childLight.intensity = targetIntensity;
		}
	}
	public static void setChildLightsIntensities(Transform parentTransform, float targetIntensity)
	{
		setIntensities(parentTransform.GetComponentsInChildren<Light>(), targetIntensity);
	}
	public static void setIntensities(Light[] childLights, float[] targetIntensities)
	{
		for (int childLightIndex = 0; childLightIndex < childLights.Length; childLightIndex++)
		{
			childLights[childLightIndex].intensity = targetIntensities[(childLightIndex < targetIntensities.Length) ? childLightIndex : (childLightIndex % targetIntensities.Length)];
		}
	}
	public static void setChildLightsIntensities(Transform parentTransform, float[] targetIntensities)
	{
		setIntensities(parentTransform.GetComponentsInChildren<Light>(), targetIntensities);
	}
}