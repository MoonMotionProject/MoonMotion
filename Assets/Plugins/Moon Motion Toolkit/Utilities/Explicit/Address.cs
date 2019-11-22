using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Address: provides methods for handling addresses //
public static class Address
{
	public const string divider = "\\";

	public static string forProjectAddress(string projectAddress)
		=> Project.path+projectAddress;
	public static string forAssetPath(string assetAddress)
		=> Assets.path+assetAddress;
}