using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Filepath:
// • provides methods for handling filepaths
// #assets
public static class Filepath
{
	public static string forProjectPath(string projectPath)
		=> Project.filepath.withPotentialRessingSuffix(projectPath);
	public static string forAssetPath(string assetPath)
		=> Assets.filepath.withPotentialRessingSuffix(assetPath);
	public static string forAsset(string assetTitle, string assetAddress)
		=> forAssetPath(Asset.pathFor(assetTitle, assetAddress));
}