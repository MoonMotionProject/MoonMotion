#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Asset File: provides methods for handling asset files (see also: 'Asset.cs') //
public static class AssetFile
{
	#region conversion

	// method: return the asset filename for the given asset path //
	public static string nameForAssetPath(string assetPath)
		=> Path.GetFileName(assetPath);

	// method: return the asset filename for the given asset idee //
	public static string nameForAssetIdee(this string assetIdee)
		=> nameForAssetPath(Asset.pathForAssetIdee(assetIdee));

	// method: return the asset file title for the given asset path //
	public static string titleForAssetPath(this string assetPath)
		=> Path.GetFileNameWithoutExtension(assetPath);

	// method: return the asset file title for the given asset idee //
	public static string titleForAssetIdee(this string assetIdee)
		=> titleForAssetPath(Asset.pathForAssetIdee(assetIdee));
	#endregion conversion
}
#endif