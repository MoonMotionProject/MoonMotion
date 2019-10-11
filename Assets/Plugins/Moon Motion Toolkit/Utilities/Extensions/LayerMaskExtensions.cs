using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Layer Mask Extensions: provides extension methods for handling layer masks //
public static class LayerMaskExtensions
{
	// method: return whether this given layer mask includes the layer for the given provided layer index //
	public static bool includes(this LayerMask layerMask, object layerIndex_LayerIndexProvider)
		=> layerMask == (layerMask | (1 << Provide.layerIndexVia(layerIndex_LayerIndexProvider)));

	// method: return whether this given layer mask does not include the layer for the given provided layer index //
	public static bool doesNotInclude(this LayerMask layerMask, object layerIndex_LayerIndexProvider)
		=> !layerMask.includes(layerIndex_LayerIndexProvider);

	// method: return whether this given layer mask includes any of the the layers of the given provided set of game objects //
	public static bool includesAnyLayersOf(this LayerMask layerMask, object uniqueGameObjects_UniqueGameObjectProvider)
		=>	Provide.uniqueGameObjectsVia(uniqueGameObjects_UniqueGameObjectProvider)
				.hasAny(gameObject =>
					layerMask.includes(gameObject.layerIndex()));

	// method: return whether this given layer mask does not include any of the the layers of the given provided set of game objects //
	public static bool doesNotIncludeAnyLayersOf(this LayerMask layerMask, object uniqueGameObjects_UniqueGameObjectProvider)
		=> !layerMask.includesAnyLayersOf(uniqueGameObjects_UniqueGameObjectProvider);
}