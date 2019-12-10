using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Address:
// • provides methods for handling (file) addresses
// #assets
public static class Address
{
	public static string forProjectAddress(string projectAddress)
		=> Project.filepath.withPotentialRessingSuffix(projectAddress);
	public static string forAssetAddress(string assetAddress)
		=> Assets.filepath.withPotentialRessingSuffix(assetAddress);
}