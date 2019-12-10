using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Instance:
// • provides methods for accessing instance idees
// #instancing #unityobject #assets
public static class Instance
{
	#if UNITY_EDITOR
	// method: return the instance idee of the asset with the given asset path //
	public static int ideeForAssetPath(string assetPath)
		=> Asset.atAssetPathOfType<Object>(assetPath).instanceIdee();
	#endif
}