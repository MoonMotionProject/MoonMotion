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

	public static IEnumerable<Transform> selectPiblingTransforms(this Transform transform)
		=> transform.parent.parent.selectChildTransforms();
	public static IEnumerable<Transform> selectPiblingTransforms(this GameObject gameObject)
		=> gameObject.transform.selectPiblingTransforms();
	public static IEnumerable<Transform> selectPiblingTransforms(this Component component)
		=> component.transform.selectPiblingTransforms();
	public static Transform[] piblingTransforms(this Transform transform)
		=> transform.parent.parent.childTransforms();
	public static Transform[] piblingTransforms(this GameObject gameObject)
		=> gameObject.transform.piblingTransforms();
	public static Transform[] piblingTransforms(this Component component)
		=> component.transform.piblingTransforms();

	public static IEnumerable<GameObject> selectPiblingObjects(this Transform transform)
		=> transform.parent.parent.selectChildObjects();
	public static IEnumerable<GameObject> selectPiblingObjects(this GameObject gameObject)
		=> gameObject.transform.selectPiblingObjects();
	public static IEnumerable<GameObject> selectPiblingObjects(this Component component)
		=> component.transform.selectPiblingObjects();
	public static GameObject[] piblingObjects(this Transform transform)
		=> transform.parent.parent.childObjects();
	public static GameObject[] piblingObjects(this GameObject gameObject)
		=> gameObject.transform.piblingObjects();
	public static GameObject[] piblingObjects(this Component component)
		=> component.transform.piblingObjects();
	
	public static IEnumerable<ComponentT> selectEachFirstPibling<ComponentT>(this Transform transform) where ComponentT : Component
		=> transform.piblingObjects().selectEachFirst<ComponentT>();
	public static IEnumerable<ComponentT> selectEachFirstPibling<ComponentT>(this GameObject gameObject) where ComponentT : Component
		=> gameObject.transform.selectEachFirstPibling<ComponentT>();
	public static IEnumerable<ComponentT> selectEachFirstPibling<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.selectEachFirstPibling<ComponentT>();
	public static List<ComponentT> eachFirstPibling<ComponentT>(this Transform transform) where ComponentT : Component
		=> transform.selectEachFirstPibling<ComponentT>().manifested();
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