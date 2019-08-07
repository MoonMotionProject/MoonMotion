using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Subprimogenitor Extensions: provides extension methods for handling subprimogenitors //
public static class SubprimogenitorExtensions
{
	#region subprimogenitor indexing

	public static int subprimogenitorIndex(this Transform transform)
		=> transform.subprimogenitorTransform().siblingIndex();
	public static int subprimogenitorIndex(this GameObject gameObject)
		=> gameObject.transform.subprimogenitorIndex();
	public static int subprimogenitorIndex(this Component component)
		=> component.transform.subprimogenitorIndex();

	public static int lastSubprimogenitorIndex(this Transform transform)
		=> transform.primogenitorTransform().lastChildIndex();
	public static int lastSubprimogenitorIndex(this GameObject gameObject)
		=> gameObject.transform.lastSubprimogenitorIndex();
	public static int lastSubprimogenitorIndex(this Component component)
		=> component.transform.lastSubprimogenitorIndex();

	public static float subprimogenitorIndexProgression(this Transform transform)
		=> transform.subprimogenitorIndex().progressionTo(transform.lastSubprimogenitorIndex());
	public static float subprimogenitorIndexProgression(this GameObject gameObject)
		=> gameObject.transform.subprimogenitorIndexProgression();
	public static float subprimogenitorIndexProgression(this Component component)
		=> component.transform.subprimogenitorIndexProgression();
	#endregion subprimogenitor indexing


	#region accessing subprimogenitors

	public static Transform subprimogenitorTransform(this Transform transform)
	{
		foreach (Transform subprimogenitorTransform_ in transform.primogenitorTransform())
		{
			if (subprimogenitorTransform_.isLocalToOrAncestorOf(transform))
			{
				return subprimogenitorTransform_;
			}
		}

		return null;
	}
	public static Transform subprimogenitorTransform(this GameObject gameObject)
		=> gameObject.transform.subprimogenitorTransform();
	public static Transform subprimogenitorTransform(this Component component)
		=> component.transform.subprimogenitorTransform();

	public static GameObject subprimogenitorObject(this Transform transform)
		=> transform.subprimogenitorTransform().gameObject;
	public static GameObject subprimogenitorObject(this GameObject gameObject)
		=> gameObject.transform.subprimogenitorObject();
	public static GameObject subprimogenitorObject(this Component component)
		=> component.transform.subprimogenitorObject();
	#endregion accessing subprimogenitors
}