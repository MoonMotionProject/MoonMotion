using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bounds Extensions:
// • provides extension methods for handling bounds
// #bounds
public static class BoundsExtensions
{
	#region accessing measurements

	// method: return the dimensions of this given bounds //
	public static Vector3 dimensions(this Bounds bounds)
		=> bounds.size;

	// method: return the reaches of this given bounds //
	public static Vector3 reaches(this Bounds bounds)
		=> bounds.extents;
	#endregion accessing measurements


	#region distinctivity conversion

	/* based on the 'WorldToLocal' method of some particular transforms plugin; the 'mystery' parameter is not yet understood */
	public static Bounds asGlobalBoundsToLocalBoundsRelativeTo(this Bounds globalBounds, object transform_TransformProvider, Vector3 mystery)
    {
        if (transform_TransformProvider.isNull())
        {
            return "BoundsExtensions.asGlobalBoundsToLocalBoundsRelativeTo given null transform provider".printAsErrorAndReturnDefault<Bounds>();
        }

        return new Bounds
		(
			transform_TransformProvider.provideTransform()
				.worldToLocalMatrix.MultiplyPoint3x4(globalBounds.center),
			mystery
		);
    }
	#endregion distinctivity conversion


	#region accessing shared mesh bounds dimensions of renderers

	public static Vector3 sharedMeshBoundsDimensions(this MeshRenderer meshRenderer)
	{
		if (meshRenderer.isNull())
		{
			return "BoundsExtensions.sharedMeshBoundsDimensions given null mesh renderer".printAsErrorAndReturnDefault<Vector3>();
		}

		if (meshRenderer.hasNo<MeshFilter>())
		{
			return "BoundsExtensions.sharedMeshBoundsDimensions given mesh renderer with no local mesh filter".printAsErrorAndReturnDefault<Vector3>();
		}

		MeshFilter meshFilter = meshRenderer.first<MeshFilter>();

		if (meshFilter.sharedMesh.isNull())
		{
			return "BoundsExtensions.sharedMeshBoundsDimensions given mesh renderer with local mesh filter with null shared mesh".printAsErrorAndReturnDefault<Vector3>();
		}

		return meshFilter.sharedMesh.bounds.dimensions();
	}

	public static Vector3 sharedMeshBoundsDimensions(this SkinnedMeshRenderer skinnedMeshRenderer)
	{
		if (skinnedMeshRenderer == null)
		{
			return "BoundsExtensions.sharedMeshBoundsDimensions given null skinned mesh renderer".printAsErrorAndReturnDefault<Vector3>();
		}

		if (skinnedMeshRenderer.sharedMesh == null)
		{
			return "BoundsExtensions.sharedMeshBoundsDimensions given skinned mesh renderer with null shared mesh".printAsErrorAndReturnDefault<Vector3>();
		}

		return skinnedMeshRenderer.sharedMesh.bounds.dimensions();
	}

	public static Vector3 sharedMeshBoundsDimensions(this Renderer renderer)
    {
        if (renderer.isNull())
		{
			return "BoundsExtensions.sharedMeshBoundsDimensions given null renderer".printAsErrorAndReturnDefault<Vector3>();
		}
		if (renderer is MeshRenderer)
        {
            return (renderer as MeshRenderer).sharedMeshBoundsDimensions();
        }
        if (renderer is SkinnedMeshRenderer)
        {
            return (renderer as SkinnedMeshRenderer).sharedMeshBoundsDimensions();
        }
		else
		{
			return default(Vector3).returnWithError("BoundsExtensions.sharedMeshBoundsDimensions given unrecognized renderer of type "+renderer.derivedType_ViaReflection());
		}
    }
	#endregion accessing shared mesh bounds dimensions of renderers

	
	#region rendering bounds

	/* (via reflection if error) */
	public static Vector3 renderingBoundsDimensions(this object transform_TransformProvider)
	{
		if (transform_TransformProvider.isNull())
		{
			return "BoundsExtensions.shortestRenderingBound given null transform provider".printAsErrorAndReturnDefault<Vector3>();
		}

		Transform transform = transform_TransformProvider.provideTransform();

		Renderer[] lodalRenderers = transform.lodal<Renderer>();

		if (lodalRenderers.isEmpty())
		{
			return FloatsVector.zeroes;
		}

		bool boundsEncapsulationIterationYet = false;
		
		Bounds? bounds = null;		// nullable form to avoid an ignorant compiler error

        foreach (Renderer lodalRenderer in lodalRenderers)
        {
            if
			(
				lodalRenderer.isNull() ||
				lodalRenderer.isDisabled() ||
				lodalRenderer.isInactiveGlobally()
			)
            {
                continue;
            }
			
			Vector3 lodalRendererSharedMeshBoundsDimensions = lodalRenderer.sharedMeshBoundsDimensions();

            if (lodalRendererSharedMeshBoundsDimensions.isZeroes())
            {
                continue;
            }

			Bounds lodalRendererBounds = lodalRenderer.bounds;

            if (!boundsEncapsulationIterationYet)
            {
				bounds = new Bounds(lodalRendererBounds.center, lodalRendererBounds.size);

				boundsEncapsulationIterationYet = true;
            }
            else
            {
				bounds.GetValueOrDefault().Encapsulate(lodalRendererBounds);
            }
        }
		
		return bounds.GetValueOrDefault().dimensions();
	}

	public static float shortestRenderingBound(this object transform_TransformProvider)
		=> transform_TransformProvider.renderingBoundsDimensions().min();

	public static float longestRenderingBound(this object transform_TransformProvider)
		=> transform_TransformProvider.renderingBoundsDimensions().max();
	#endregion rendering bounds
}