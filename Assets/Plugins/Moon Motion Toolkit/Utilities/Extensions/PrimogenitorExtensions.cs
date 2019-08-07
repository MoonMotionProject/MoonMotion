using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Primogenitor Extensions: provides extension methods for handling primogenitors //
public static class PrimogenitorExtensions
{
	#region primogenitor indexing
	
	public static int primogenitorIndex(this Transform transform)
		=> transform.primogenitorTransform().siblingIndex();
	public static int primogenitorIndex(this GameObject gameObject)
		=> gameObject.transform.primogenitorIndex();
	public static int primogenitorIndex(this Component component)
		=> component.transform.primogenitorIndex();

	public static float primogenitorIndexProgression(this Transform transform)
		=> transform.primogenitorIndex().progressionTo(Hierarchy.lastPrimogenitorIndex);
	public static float primogenitorIndexProgression(this GameObject gameObject)
		=> gameObject.transform.primogenitorIndexProgression();
	public static float primogenitorIndexProgression(this Component component)
		=> component.transform.primogenitorIndexProgression();
	#endregion primogenitor indexing


	#region accessing primogenitors

	public static Transform primogenitorTransform(this Transform transform)
		=> transform.root;
	public static Transform primogenitorTransform(this GameObject gameObject)
		=> gameObject.transform.primogenitorTransform();
	public static Transform primogenitorTransform(this Component component)
		=> component.transform.primogenitorTransform();

	public static GameObject primogenitorObject(this Transform transform)
		=> transform.primogenitorTransform().gameObject;
	public static GameObject primogenitorObject(this GameObject gameObject)
		=> gameObject.transform.primogenitorObject();
	public static GameObject primogenitorObject(this Component component)
		=> component.transform.primogenitorObject();
	#endregion primogenitor indexing
}