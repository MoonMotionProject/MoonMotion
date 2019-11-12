using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Layers: provides properties for layers //
public static class Layers
{
	public static readonly LayerMask all = Physics.AllLayers;        // (recognize all layers)
	public static readonly LayerMask none = 0;        // (recognize no layers)
	
	public const int supportedCount = 32;
	public const int stockCount = 8;
	public const int firstStockLayerIndex = 0;
	public const int lastStockLayerIndex = stockCount - 1;
	public const int customSupportedCount = supportedCount - stockCount;
	public const int firstCustomLayerIndex = lastStockLayerIndex + 1;
	public const int lastCustomLayerIndex = lastStockLayerIndex + customSupportedCount;
	public const int firstLayerIndex = firstStockLayerIndex;
	public const int lastLayerIndex = lastCustomLayerIndex;
	
	public static HashSet<string> names
	{
		get
		{
			HashSet<string> layerNames = New.setOf<string>();

			supportedCount.timesExecuteUponIndexStartingFrom(firstLayerIndex, layerIndex =>
				layerNames.includeIfNotEmpty(layerIndex.asLayerName()));

			return layerNames;
		}
	}

	public static HashSet<string> customNames
	{
		get
		{
			HashSet<string> layerNames = New.setOf<string>();

			customSupportedCount.timesExecuteUponIndexStartingFrom(firstCustomLayerIndex, layerIndex =>
				layerNames.includeIfNotEmpty(layerIndex.asLayerName()));

			return layerNames;
		}
	}
}