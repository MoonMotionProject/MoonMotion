using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Renderer Extensions: provides extension methods for handling renderers //
public static class RendererExtensions
{
	#region enablement

	// method: return the enablement of this given renderer //
	public static bool enablement(this Renderer renderer)
		=> renderer.enabled;

	// method: set the enablement of this given renderer to the given boolean, then return this given renderer //
	public static Renderer setEnablementTo(this Renderer renderer, bool boolean)
	{
		renderer.enabled = boolean;

		return renderer;
	}
	// method: set the enablement of this given game object's renderer to the given boolean, then return this given game object //
	public static GameObject setRendererEnablementTo(this GameObject gameObject, bool boolean)
		=> gameObject.after(()=>
			gameObject.first<Renderer>().setEnablementTo(boolean));

	// method: enable this given renderer, then return it //
	public static Renderer enable(this Renderer renderer)
		=> renderer.setEnablementTo(true);

	// method: disable this given renderer, then return it //
	public static Renderer disable(this Renderer renderer)
		=> renderer.setEnablementTo(false);

	// method: toggle the enablement of this given renderers using the given toggling, then return this given renderer //
	public static Renderer toggleEnablementBy(this Renderer renderer, Toggling toggling)
		=> renderer.setEnablementTo(renderer.enablement().toggledBy(toggling));

	// method: toggle the enablement of these given renderers using the given toggling, then return them //
	public static Renderer[] toggleEnablementBy(this Renderer[] renderers, Toggling toggling)
		=> renderers.forEach(renderer => renderer.toggleEnablementBy(toggling));

	// method: set the enablement of these given renderers to the given boolean, then return them //
	public static Renderer[] setEnablementTo(this Renderer[] renderers, bool boolean)
		=> renderers.forEach(renderer => renderer.setEnablementTo(boolean));

	// method: enable these given renderers, then return them //
	public static Renderer[] enable(this Renderer[] renderers)
		=> renderers.setEnablementTo(true);

	// method: disable these given renderers, then return them //
	public static Renderer[] disable(this Renderer[] renderers)
		=> renderers.setEnablementTo(false);
	#endregion enablement


	#region material

	public static Renderer setMaterialTo(this Renderer renderer, Material material)
	{
		renderer.material = material;

		return renderer;
	}
	public static Renderer setSharedMaterialTo(this Renderer renderer, Material sharedMaterial)
	{
		renderer.sharedMaterial = sharedMaterial;

		return renderer;
	}
	#endregion material


	#region shadowcasting

	public static Renderer setShadowcastingTo(this Renderer renderer, ShadowCastingMode shadowcasting)
	{
		renderer.shadowCastingMode = shadowcasting;

		return renderer;
	}

	public static Renderer shadowcast(this Renderer renderer)
		=> renderer.setShadowcastingTo(ShadowCastingMode.On);

	public static Renderer nonshadowcast(this Renderer renderer)
		=> renderer.setShadowcastingTo(ShadowCastingMode.Off);
	#endregion shadowcasting


	#region shadowability

	public static Renderer setShadowabilityTo(this Renderer renderer, bool shadowability)
	{
		renderer.receiveShadows = shadowability;

		return renderer;
	}

	public static Renderer shadowable(this Renderer renderer)
		=> renderer.setShadowabilityTo(true);

	public static Renderer nonshadowable(this Renderer renderer)
		=> renderer.setShadowabilityTo(false);
	#endregion shadowability
}