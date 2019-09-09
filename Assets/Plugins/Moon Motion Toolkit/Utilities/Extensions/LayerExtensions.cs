using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LayerExtensions: provides extension methods for handling layers //
public static class LayerExtensions
{
	#region identification


	// method: return the layer name for this given game object //
	public static string layerName(this GameObject gameObject)
		=> gameObject.layer.asLayerName();
	// method: return the layer name for the game object of this given component //
	public static string layerName(this Component component)
		=> component.gameObject.layerName();

	// method: return the layer index for this given game object //
	public static int layerIndex(this GameObject gameObject)
		=> gameObject.layer;
	// method: return the layer index for the game object of this given component //
	public static int layerIndex(this Component component)
		=> component.gameObject.layerIndex();

	// method: return whether this given game object is on the default layer //
	public static bool isOnDefaultLayer(this GameObject gameObject)
		=> gameObject.layerMatches(Layer.defaultIndex);
	// method: return whether this given component's game object is on the default layer //
	public static bool isOnDefaultLayer(this Component component)
		=> component.gameObject.isOnDefaultLayer();

	// method: return whether this given game object is not on the default layer //
	public static bool isNotOnDefaultLayer(this GameObject gameObject)
		=> !gameObject.isOnDefaultLayer();
	// method: return whether this given component's game object is not on the default layer //
	public static bool isNotOnDefaultLayer(this Component component)
		=> component.gameObject.isNotOnDefaultLayer();
	#endregion identification




	#region defaulting

	// method: return these given layer names, unless none are given, in which case return only the default layer name //
	public static IEnumerable<string> defaultLayerIfNone(this IEnumerable<string> layerNames)
		=>	layerNames.hasAny() ?
				layerNames :
				new string[] {Layer.defaultName};

	// method: return these given layer indeces, unless none are given, in which case return only the default layer index //
	public static IEnumerable<int> defaultLayerIfNone(this IEnumerable<int> layerIndeces)
		=>	layerIndeces.hasAny() ?
				layerIndeces :
				new int[] {0};
	#endregion defaulting




	#region matching


	// method: return whether the layer of this given game object matches the layer for the given layer index //
	public static bool layerMatches(this GameObject gameObject, int layerIndex)
		=> (gameObject.layer == layerIndex);
	// method: return whether the layer of the game object of this given component matches the layer for the given layer index //
	public static bool layerMatches(this Component component, int layerIndex)
		=> component.gameObject.layerMatches(layerIndex);
	// method: return whether the layer of this given game object matches the layer for the given layer name //
	public static bool layerMatches(this GameObject gameObject, string layerName)
		=> gameObject.layerMatches(layerName.asLayerIndex());
	// method: return whether the layer of the game object of this given component matches the layer for the given layer name //
	public static bool layerMatches(this Component component, string layerName)
		=> component.gameObject.layerMatches(layerName);

	// method: return whether this given layer index matches the given layer name //
	public static bool asLayerIndexMatches(this int layerIndex, string layerName)
		=> (layerIndex == layerName.asLayerIndex());
	// method: return whether this given layer name matches the given layer index //
	public static bool asLayerNameMatches(this string layerName, int layerIndex)
		=> layerIndex.asLayerIndexMatches(layerName);

	// method: return whether any of the given layer indeces matches the given layer name //
	public static bool hasAnyThatAsLayerIndexMatches(this IEnumerable<int> layerIndeces, string layerName)
		=> layerIndeces.hasAny(layerIndex =>
			layerIndex.asLayerIndexMatches(layerName));
	// method: return whether this given layer name matches any of the given layer indeces //
	public static bool matchesAnyLayerIndexIn(this string layerName, IEnumerable<int> layerIndeces)
		=> layerIndeces.hasAnyThatAsLayerIndexMatches(layerName);
	// method: return whether any of the given layer names matches the given layer index //
	public static bool hasAnyThatAsLayerNameMatches(this IEnumerable<string> layerNames, int layerIndex)
		=> layerNames.hasAny(layerName =>
			layerName.asLayerNameMatches(layerIndex));
	// method: return whether this given layer index matches any of the given layer names //
	public static bool matchesAnyLayerNameIn(this int layerIndex, IEnumerable<string> layerNames)
		=> layerNames.hasAnyThatAsLayerNameMatches(layerIndex);
	// method: return whether this given layer index matches any of the given layer names //
	public static bool matchesAnyLayerNameIn(this int layerIndex, params IEnumerable<string>[] layerNameses)
		=> layerNameses.hasAny(layerNames =>
			layerIndex.matchesAnyLayerNameIn(layerNames));
	#endregion matching




	#region containing


	// method: return whether the layer of this given game object contains the given string //
	public static bool layerContains(this GameObject gameObject, string string_)
		=> gameObject.layerName().Contains(string_);

	// method: return whether the layer of the game object of this given component contains the given string //
	public static bool layerContains(this Component component, string string_)
		=> component.gameObject.layerContains(string_);
	#endregion containing




	#region matching or containing


	// method: return whether the layer name of this given game object matches or contains (based on the given boolean) the given layer name //
	public static bool layerMatchesOrContains(this GameObject gameObject, string layerName, bool matchesVersusContains)
		=> (
				matchesVersusContains ?
					gameObject.layerMatches(layerName) :
					gameObject.layerContains(layerName)
			);

	// method: return whether the layer name of the game object for this given component matches or contains (based on the given boolean) the given layer name //
	public static bool layerMatchesOrContains(this Component component, string layerName, bool matchesVersusContains)
		=> component.gameObject.layerMatchesOrContains(layerName, matchesVersusContains);
	#endregion matching or containing




	#region searching for self or parent based on comparison

	// method: return the first game object out of this given game object and its parent game objects (searching upward) to have the given layer name (null if none found) //
	public static GameObject selfOrParentWithLayer(this GameObject gameObject, string layerName)
		=> gameObject.selfOrParentWithLabelThatMatchesOrContains(layerName, LabelType.layerName, true);

	// method: return the first game object out of the game object for this component and that game object's parent game objects (searching upward) to have the given layer name (null if none found) //
	public static GameObject selfOrParentWithLayer(this Component component, string layerName)
		=> component.gameObject.selfOrParentWithLayer(layerName);

	// method: return the first game object out of this given game object and its parent game objects (searching upward) to have a layer name containing the given string (null if none found) //
	public static GameObject selfOrParentWithLayerContaining(this GameObject gameObject, string string_)
		=> gameObject.selfOrParentWithLabelThatMatchesOrContains(string_, LabelType.layerName, false);

	// method: return the first game object out of the game object for this component and that game object's parent game objects (searching upward) to have a layer name containing the given string (null if none found) //
	public static GameObject selfOrParentWithLayerContaining(this Component component, string string_)
		=> component.gameObject.selfOrParentWithLayerContaining(string_);
	#endregion searching for self or parent based on comparison




	#region setting


	// method: (according to the given boolean:) set this given game object's layer to the layer for the given layer index, then return this given game object //
	public static GameObject setLayerTo(this GameObject gameObject, int layerIndex, bool boolean = true)
	{
		if (boolean)
		{
			gameObject.layer = layerIndex;
		}

		return gameObject;
	}
	// method: (according to the given boolean:) set this given transform's game object's layer to the layer for the given layer index, then return this given transform //
	public static Transform setLayerTo(this Transform transform, int layerIndex, bool boolean = true)
		=> transform.gameObject.setLayerTo(layerIndex).transform;
	// method: (according to the given boolean:) set these given game objects' layers to the layer for the given layer index, then return these given game objects //
	public static GameObject[] setLayerTo(this GameObject[] gameObjects, int layerIndex, bool boolean = true)
	{
		gameObjects.forEach(gameObject => gameObject.setLayerTo(layerIndex, boolean));

		return gameObjects;
	}
	// method: (according to the given boolean:) set this given transform's game object's layer to the layer for the given layer index, then return these given transforms //
	public static Transform[] setLayerTo(this Transform[] transforms, int layerIndex, bool boolean = true)
	{
		transforms.forEach(transform => transform.setLayerTo(layerIndex, boolean));

		return transforms;
	}
	public static GameObject setChildLayersTo(this GameObject gameObject, int layerIndex, bool boolean = true)
		=> gameObject.setChildLayersTo(layerIndex.asLayerName(), boolean).gameObject;
	public static Transform setChildLayersTo(this Transform transform, int layerIndex, bool boolean = true)
		=> transform.setChildLayersTo(layerIndex.asLayerName(), boolean);

	// method: (according to the given boolean:) set this given game object's layer to the layer for the given layer name, then return this given game object //
	public static GameObject setLayerTo(this GameObject gameObject, string layerName, bool boolean = true)
		=> gameObject.setLayerTo(layerName.asLayerIndex(), boolean);
	// method: (according to the given boolean:) set this given transform's game object's layer to the layer for the given layer name, then return this given transform //
	public static Transform setLayerTo(this Transform transform, string layerName, bool boolean = true)
		=> transform.gameObject.setLayerTo(layerName, boolean).transform;
	// method: (according to the given boolean:) set this given game object's layer to the layer for the given layer name, then return these given game objects //
	public static GameObject[] setLayerTo(this GameObject[] gameObjects, string layerName, bool boolean = true)
		=> gameObjects.setLayerTo(layerName.asLayerIndex(), boolean);
	// method: (according to the given boolean:) set this given transform's game object's layer to the layer for the given layer name, then return these given transforms //
	public static Transform[] setLayerTo(this Transform[] transforms, string layerName, bool boolean = true)
		=> transforms.setLayerTo(layerName.asLayerIndex(), boolean);
	public static GameObject setChildLayersTo(this GameObject gameObject, string layerName, bool boolean = true)
		=> gameObject.transform.setChildLayersTo(layerName, boolean).gameObject;
	public static Transform setChildLayersTo(this Transform transform, string layerName, bool boolean = true)
	{
		transform.forEachChildTransform(childTransform => childTransform.setLayerTo(layerName, boolean));

		return transform;
	}
	#endregion setting




	#region conversion

	// method: return the layer name for this given layer index //
	public static string asLayerName(this int integer)
		=> LayerMask.LayerToName(integer);

	// method: return the layer index for this given layer name //
	public static int asLayerIndex(this string string_)
		=> LayerMask.NameToLayer(string_);

	// method: return the layer mask for these given layer names //
	public static int asLayerMask(params string[] layerNames)
		=> LayerMask.GetMask(layerNames);
	// method: return the layer mask for these given layer names //
	public static int asLayerMask(this IEnumerable<string> layerNames)
		=> LayerMask.GetMask(layerNames.toArray());
	#endregion conversion
}