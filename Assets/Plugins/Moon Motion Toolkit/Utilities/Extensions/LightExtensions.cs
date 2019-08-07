using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LightExtensions: provides extension methods for handling lights //
public static class LightExtensions
{
	#region intensities

	public static List<float> intensities<IListT>(this IListT lights) where IListT : IList<Light>
		=> lights.pick(light => light.intensity);

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

	public static IListT setIntensitiesTo<IListT>(this IListT lights, IList<float> targetIntensities) where IListT : IList<Light>
	{
		for (int lightIndex = 0; lightIndex < lights.Count; lightIndex++)
		{
			lights[lightIndex].setIntensityTo(targetIntensities[lightIndex % targetIntensities.Count]);
		}

		return lights;
	}
	#endregion intensities


	#region setting render mode

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
	#endregion setting render mode


	#region child lights

	public static List<float> childLightIntensities(this GameObject gameObject)
		=> gameObject.children<Light>().intensities();

	public static GameObject setChildLightIntensitiesTo(this GameObject gameObject, IList<float> targetIntensities)
		=> gameObject.after(()=>
			gameObject.children<Light>().setIntensitiesTo(targetIntensities));

	public static GameObject setChildLightIntensitiesTo(this GameObject gameObject, float targetIntensity)
		=> gameObject.setChildLightIntensitiesTo(new float[] { targetIntensity });

	public static GameObject renderChildLightsBy(this GameObject gameObject, LightRenderMode lightRenderMode)
	{
		gameObject.children<Light>().renderBy(lightRenderMode);

		return gameObject;
	}

	public static GameObject renderChildLightsByPixel(this GameObject gameObject)
		=> gameObject.renderChildLightsBy(LightRenderMode.ForcePixel);

	public static GameObject renderChildLightsByVertex(this GameObject gameObject)
		=> gameObject.renderChildLightsBy(LightRenderMode.ForceVertex);
	#endregion child lights
}