using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Address: provides methods for handling addresses //
public static class Address
{
	public static string forAssetAddress(string assetAddress)
		=> Assets.address+assetAddress;
}