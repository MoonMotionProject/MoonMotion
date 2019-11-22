#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reimport: provides methods for reimporting assets //
public static class Reimport
{
	// method: reimport the given asset Unity object if it is actually imported currently //
	public static void assetIfImported(Object assetUnityObject)
		=> Import.assetIfInAssets(assetUnityObject);
}
#endif