#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Assets:
// • provides methods for handling Assets
// #assets
public static class Assets
{
	// method: return the set of assets of the specified type corresponding to each of the given asset paths //
	public static HashSet<AssetT> atPathsOfType<AssetT>(IEnumerable<string> assetPaths) where AssetT : class
		=>	assetPaths.pickUnique(assetPath =>
				Asset.atPathOfType<AssetT>(assetPath));

	// method: return the set of assets of the specified type //
	public static HashSet<AssetT> ofType<AssetT>() where AssetT : class
		=> atPathsOfType<AssetT>(Asset.pathsForAssetsOfType<AssetT>());
	// method: return the list of assets of the specified type //
	public static List<AssetT> manifestedOfType<AssetT>() where AssetT : class
		=> ofType<AssetT>().manifested();

	// method: return the set of assets not from the Moon Motion Toolkit that are of the specified type //
	public static HashSet<AssetT> notFromMoonMotionToolkitOfType<AssetT>() where AssetT : class
		=> atPathsOfType<AssetT>(Asset.pathsForNonMoonMotionToolkitAssetsOfType<AssetT>());
	// method: return the list of assets not from the Moon Motion Toolkit that are of the specified type //
	public static List<AssetT> notFromMoonMotionToolkitManifestedOfType<AssetT>() where AssetT : class
		=> notFromMoonMotionToolkitOfType<AssetT>().manifested();
}
#endif