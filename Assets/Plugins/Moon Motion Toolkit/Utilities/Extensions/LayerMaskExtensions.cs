using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Layer Mask Extensions: provides extension methods for handling layer masks //
public static class LayerMaskExtensions
{
	// method: return whether this given layer mask includes the layer for the given provided layer index //
	public static bool includes(this LayerMask layerMask, object layerIndex_LayerIndexProvider)
		=> layerMask == (layerMask | (1 << layerIndex_LayerIndexProvider.provideLayerIndex()));

	// method: return whether this given layer mask does not include the layer for the given provided layer index //
	public static bool doesNotInclude(this LayerMask layerMask, object layerIndex_LayerIndexProvider)
		=> !layerMask.includes(layerIndex_LayerIndexProvider);

	// method: return whether this given layer mask includes any of the the layers of the given provided set of game objects //
	public static bool includesAnyLayersOf(this LayerMask layerMask, object uniqueGameObjects_UniqueGameObjectProvider)
		=>	uniqueGameObjects_UniqueGameObjectProvider.provideUniqueGameObjects()
				.hasAny(gameObject =>
					layerMask.includes(gameObject.layerIndex()));

	// method: return whether this given layer mask does not include any of the the layers of the given provided set of game objects //
	public static bool doesNotIncludeAnyLayersOf(this LayerMask layerMask, object uniqueGameObjects_UniqueGameObjectProvider)
		=> !layerMask.includesAnyLayersOf(uniqueGameObjects_UniqueGameObjectProvider);

	// method: return whether this given provided layer index is for a layer in the given layer mask //
	public static bool layerIsIn(this object layerIndex_LayerIndexProvider, LayerMask layerMask)
		=> layerMask.includes(layerIndex_LayerIndexProvider);
	public static bool layerIsNotIn(this object layerIndex_LayerIndexProvider, LayerMask layerMask)
		=> !layerIndex_LayerIndexProvider.layerIsIn(layerMask);

	// method: return the layer mask for just these given provided layer names //
	public static LayerMask asLayerMask(this object uniqueLayerNames_UniqueLayerNamesProvider)
		=> LayerMask.GetMask(uniqueLayerNames_UniqueLayerNamesProvider.provideUniqueLayerNames().toArray());

	// method: return the set of layer names recognized by this given layer mask //
	public static HashSet<string> recognizedLayerNames(this LayerMask layerMask)
		=> Layers.names.uniquesWhere(layerName => layerMask.includes(layerName));
}