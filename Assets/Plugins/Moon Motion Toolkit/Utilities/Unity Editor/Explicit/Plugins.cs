using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Plugins:
// • provides functionality for plugins
public static class Plugins
{
	public const string folderName = "Plugins";
	public static readonly string assetAddress = Assets.filepath;
	public const string assetPath = folderName;
	public static Object folder => Asset.folderAtAssetPath(assetPath);
}