using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sibling Extensions: provides extension methods for handling siblings //
public static class SiblingExtensions
{
	#region sibling indexing

	// method: return the index of this given transform among its siblings //
	public static int siblingIndex(this Transform transform)
		=> transform.GetSiblingIndex();
	// method: return the index of this given game object among its siblings //
	public static int siblingIndex(this GameObject gameObject)
		=> gameObject.transform.siblingIndex();
	// method: return the index of this given component among its siblings //
	public static int siblingIndex(this Component component)
		=> component.transform.siblingIndex();
	#endregion sibling indexing


	#region accessing siblings

	// method: return a selection of the transforms of this given transform's siblings and itself //
	public static IEnumerable<Transform> selectSiblingAndSelfTransforms(this Transform transform)
		=> transform.parent.selectChildTransforms();
	// method: return a selection of the transforms of this given game object's siblings and itself //
	public static IEnumerable<Transform> selectSiblingAndSelfTransforms(this GameObject gameObject)
		=> gameObject.transform.selectSiblingAndSelfTransforms();
	// method: return a selection of the transforms of this given component's siblings and itself //
	public static IEnumerable<Transform> selectSiblingAndSelfTransforms(this Component component)
		=> component.transform.selectSiblingAndSelfTransforms();
	// method: return a selection of the transforms of this given transform's siblings and itself //
	public static Transform[] siblingAndSelfTransforms(this Transform transform)
		=> transform.parent.childTransforms();
	// method: return an array of the transforms of this given game object's siblings and itself //
	public static Transform[] siblingAndSelfTransforms(this GameObject gameObject)
		=> gameObject.transform.siblingAndSelfTransforms();
	// method: return an array of the transforms of this given component's siblings and itself //
	public static Transform[] siblingAndSelfTransforms(this Component component)
		=> component.transform.siblingAndSelfTransforms();

	// method: return a selection of the game objects of this given transform's siblings and itself //
	public static IEnumerable<GameObject> selectSiblingAndSelfObjects(this Transform transform)
		=> transform.parent.selectChildObjects();
	// method: return a selection of the game objects of this given game object's siblings and itself //
	public static IEnumerable<GameObject> selectSiblingAndSelfObjects(this GameObject gameObject)
		=> gameObject.transform.selectSiblingAndSelfObjects();
	// method: return a selection of the game objects of this given component's siblings and itself //
	public static IEnumerable<GameObject> selectSiblingAndSelfObjects(this Component component)
		=> component.transform.selectSiblingAndSelfObjects();
	// method: return an array of the game objects of this given transform's siblings and itself //
	public static GameObject[] siblingAndSelfObjects(this Transform transform)
		=> transform.parent.childObjects();
	// method: return an array of the game objects of this given game object's siblings and itself //
	public static GameObject[] siblingAndSelfObjects(this GameObject gameObject)
		=> gameObject.transform.siblingAndSelfObjects();
	// method: return an array of the game objects of this given component's siblings and itself //
	public static GameObject[] siblingAndSelfObjects(this Component component)
		=> component.transform.siblingAndSelfObjects();

	// method: return a selection of the transforms of this given transform's siblings (not including itself) //
	public static IEnumerable<Transform> selectSiblingTransforms(this Transform transform)
		=> transform.selectSiblingAndSelfTransforms().only(siblingOrSelfTransform => (siblingOrSelfTransform != transform));
	// method: return a selection of the transforms of this given game object's siblings (not including itself) //
	public static IEnumerable<Transform> selectSiblingTransforms(this GameObject gameObject)
		=> gameObject.transform.selectSiblingTransforms();
	// method: return a selection of the transforms of this given component's siblings (not including itself) //
	public static IEnumerable<Transform> selectSiblingTransforms(this Component component)
		=> component.transform.selectSiblingTransforms();
	// method: return a list of the transforms of this given transform's siblings (not including itself) //
	public static List<Transform> siblingTransforms(this Transform transform)
		=> transform.selectSiblingTransforms().manifested();
	// method: return a list of the transforms of this given game object's siblings (not including itself) //
	public static List<Transform> siblingTransforms(this GameObject gameObject)
		=> gameObject.transform.siblingTransforms();
	// method: return a list of the transforms of this given component's siblings (not including itself) //
	public static List<Transform> siblingTransforms(this Component component)
		=> component.transform.siblingTransforms();

	// method: return a selection of the game objects of this given transform's siblings (not including itself) //
	public static IEnumerable<GameObject> selectSiblingObjects(this Transform transform)
		=> transform.selectSiblingAndSelfObjects().only(siblingOrSelfObject => (siblingOrSelfObject != transform.gameObject));
	// method: return a selection of the game objects of this given game object's siblings (not including itself) //
	public static IEnumerable<GameObject> selectSiblingObjects(this GameObject gameObject)
		=> gameObject.transform.selectSiblingObjects();
	// method: return a selection of the game objects of this given component's siblings (not including itself) //
	public static IEnumerable<GameObject> selectSiblingObjects(this Component component)
		=> component.transform.selectSiblingObjects();
	// method: return a list of the game objects of this given transform's siblings (not including itself) //
	public static List<GameObject> siblingObjects(this Transform transform)
		=> transform.selectSiblingObjects().manifested();
	// method: return a list of the game objects of this given game object's siblings (not including itself) //
	public static List<GameObject> siblingObjects(this GameObject gameObject)
		=> gameObject.transform.siblingObjects();
	// method: return a list of the game objects of this given component's siblings (not including itself) //
	public static List<GameObject> siblingObjects(this Component component)
		=> component.transform.siblingObjects();
	#endregion accessing siblings
}