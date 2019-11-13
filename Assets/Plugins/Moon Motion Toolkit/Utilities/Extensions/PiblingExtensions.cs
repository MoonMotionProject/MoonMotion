using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Pibling Extensions: provides extension methods for handling piblings //
public static class PiblingExtensions
{
	#region pibling indexing

	public static int piblingIndex(this Transform transform)
		=> transform.parent.siblingIndex();
	public static int piblingIndex(this GameObject gameObject)
		=> gameObject.transform.piblingIndex();
	public static int piblingIndex(this Component component)
		=> component.transform.piblingIndex();
	#endregion pibling iteration


	#region accessing piblings

	public static Transform piblingTransform(this Transform transform, int piblingIndex)
		=> transform.parent.parent.childTransform(piblingIndex);
	public static Transform piblingTransform(this GameObject gameObject, int piblingIndex)
		=> gameObject.transform.piblingTransform(piblingIndex);
	public static Transform piblingTransform(this Component component, int piblingIndex)
		=> component.transform.piblingTransform(piblingIndex);

	public static Transform correspondingPiblingTransform(this Transform transform)
		=> transform.piblingTransform(transform.siblingIndex());
	public static Transform correspondingPiblingTransform(this GameObject gameObject)
		=> gameObject.transform.correspondingPiblingTransform();
	public static Transform correspondingPiblingTransform(this Component component)
		=> component.transform.correspondingPiblingTransform();

	public static GameObject piblingObject(this Transform transform, int piblingIndex)
		=> transform.piblingTransform(piblingIndex).gameObject;
	public static GameObject piblingObject(this GameObject gameObject, int piblingIndex)
		=> gameObject.transform.piblingObject(piblingIndex);
	public static GameObject piblingObject(this Component component, int piblingIndex)
		=> component.transform.piblingObject(piblingIndex);

	public static Transform firstPiblingTransform(this Transform transform)
		=> transform.piblingTransform(0);
	public static Transform firstPiblingTransform(this GameObject gameObject)
		=> gameObject.transform.firstPiblingTransform();
	public static Transform firstPiblingTransform(this Component component)
		=> component.transform.firstPiblingTransform();

	public static GameObject firstPiblingObject(this Transform transform)
		=> transform.piblingObject(0);
	public static GameObject firstPiblingObject(this GameObject gameObject)
		=> gameObject.transform.firstPiblingObject();
	public static GameObject firstPiblingObject(this Component component)
		=> component.transform.firstPiblingObject();

	public static Transform lastPiblingTransform(this Transform transform)
		=> transform.piblingTransform(transform.lastPiblingIndex());
	public static Transform lastPiblingTransform(this GameObject gameObject)
		=> gameObject.transform.lastPiblingTransform();
	public static Transform lastPiblingTransform(this Component component)
		=> component.transform.lastPiblingTransform();

	public static GameObject lastPiblingObject(this Transform transform)
		=> transform.piblingObject(transform.lastPiblingIndex());
	public static GameObject lastPiblingObject(this GameObject gameObject)
		=> gameObject.transform.lastPiblingObject();
	public static GameObject lastPiblingObject(this Component component)
		=> component.transform.lastPiblingObject();

	public static IEnumerable<Transform> accessPiblingTransforms(this Transform transform)
		=> transform.parent.parent.accessChildTransforms();
	public static IEnumerable<Transform> accessPiblingTransforms(this GameObject gameObject)
		=> gameObject.transform.accessPiblingTransforms();
	public static IEnumerable<Transform> accessPiblingTransforms(this Component component)
		=> component.transform.accessPiblingTransforms();
	public static Transform[] piblingTransforms(this Transform transform)
		=> transform.parent.parent.childTransforms();
	public static Transform[] piblingTransforms(this GameObject gameObject)
		=> gameObject.transform.piblingTransforms();
	public static Transform[] piblingTransforms(this Component component)
		=> component.transform.piblingTransforms();

	public static IEnumerable<GameObject> accessPiblingObjects(this Transform transform)
		=> transform.parent.parent.accessChildObjects();
	public static IEnumerable<GameObject> accessPiblingObjects(this GameObject gameObject)
		=> gameObject.transform.accessPiblingObjects();
	public static IEnumerable<GameObject> accessPiblingObjects(this Component component)
		=> component.transform.accessPiblingObjects();
	public static GameObject[] piblingObjects(this Transform transform)
		=> transform.parent.parent.childObjects();
	public static GameObject[] piblingObjects(this GameObject gameObject)
		=> gameObject.transform.piblingObjects();
	public static GameObject[] piblingObjects(this Component component)
		=> component.transform.piblingObjects();
	
	public static IEnumerable<ComponentT> accessEachFirstPibling<ComponentT>(this Transform transform) where ComponentT : Component
		=> transform.piblingObjects().accessEachFirst<ComponentT>();
	public static IEnumerable<ComponentT> accessEachFirstPibling<ComponentT>(this GameObject gameObject) where ComponentT : Component
		=> gameObject.transform.accessEachFirstPibling<ComponentT>();
	public static IEnumerable<ComponentT> accessEachFirstPibling<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.accessEachFirstPibling<ComponentT>();
	public static List<ComponentT> eachFirstPibling<ComponentT>(this Transform transform) where ComponentT : Component
		=> transform.accessEachFirstPibling<ComponentT>().manifested();
	public static List<ComponentT> eachFirstPibling<ComponentT>(this GameObject gameObject) where ComponentT : Component
		=> gameObject.transform.eachFirstPibling<ComponentT>();
	public static List<ComponentT> eachFirstPibling<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.eachFirstPibling<ComponentT>();
	#endregion accessing piblings


	#region pibling iteration

	public static int lastPiblingIndex(this Transform transform)
		=> transform.parent.parent.lastChildIndex();
	public static int lastPiblingIndex(this GameObject gameObject)
		=> gameObject.transform.lastPiblingIndex();
	public static int lastPiblingIndex(this Component component)
		=> component.transform.lastPiblingIndex();
	#endregion pibling iteration
}