using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Filepath: provides methods for handling filepaths //
public static class Filepath
{
	public static string forProjectPath(string projectPath)
		=> Project.path+projectPath;
	public static string forAssetPath(string assetPath)
		=> Assets.path+assetPath;
	public static string forAsset(string assetTitle, string assetAddress)
		=> forAssetPath(Asset.pathFor(assetTitle, assetAddress));
}