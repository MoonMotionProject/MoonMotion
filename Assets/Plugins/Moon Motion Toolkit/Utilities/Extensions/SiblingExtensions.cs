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

	// method: return an accessor for the transforms of this given transform's siblings and itself //
	public static IEnumerable<Transform> accessSiblingAndSelfTransforms(this Transform transform)
		=> transform.parent.accessChildTransforms();
	// method: return an accessor for the transforms of this given game object's siblings and itself //
	public static IEnumerable<Transform> accessSiblingAndSelfTransforms(this GameObject gameObject)
		=> gameObject.transform.accessSiblingAndSelfTransforms();
	// method: return an accessor for the transforms of this given component's siblings and itself //
	public static IEnumerable<Transform> accessSiblingAndSelfTransforms(this Component component)
		=> component.transform.accessSiblingAndSelfTransforms();
	// method: return an accessor for the transforms of this given transform's siblings and itself //
	public static Transform[] siblingAndSelfTransforms(this Transform transform)
		=> transform.parent.childTransforms();
	// method: return an array of the transforms of this given game object's siblings and itself //
	public static Transform[] siblingAndSelfTransforms(this GameObject gameObject)
		=> gameObject.transform.siblingAndSelfTransforms();
	// method: return an array of the transforms of this given component's siblings and itself //
	public static Transform[] siblingAndSelfTransforms(this Component component)
		=> component.transform.siblingAndSelfTransforms();

	// method: return an accessor for the game objects of this given transform's siblings and itself //
	public static IEnumerable<GameObject> accessSiblingAndSelfObjects(this Transform transform)
		=> transform.parent.accessChildObjects();
	// method: return an accessor for the game objects of this given game object's siblings and itself //
	public static IEnumerable<GameObject> accessSiblingAndSelfObjects(this GameObject gameObject)
		=> gameObject.transform.accessSiblingAndSelfObjects();
	// method: return an accessor for the game objects of this given component's siblings and itself //
	public static IEnumerable<GameObject> accessSiblingAndSelfObjects(this Component component)
		=> component.transform.accessSiblingAndSelfObjects();
	// method: return an array of the game objects of this given transform's siblings and itself //
	public static GameObject[] siblingAndSelfObjects(this Transform transform)
		=> transform.parent.childObjects();
	// method: return an array of the game objects of this given game object's siblings and itself //
	public static GameObject[] siblingAndSelfObjects(this GameObject gameObject)
		=> gameObject.transform.siblingAndSelfObjects();
	// method: return an array of the game objects of this given component's siblings and itself //
	public static GameObject[] siblingAndSelfObjects(this Component component)
		=> component.transform.siblingAndSelfObjects();

	// method: return an accessor for the transforms of this given transform's siblings (not including itself) //
	public static IEnumerable<Transform> accessSiblingTransforms(this Transform transform)
		=> transform.accessSiblingAndSelfTransforms().only(siblingOrSelfTransform => (siblingOrSelfTransform != transform));
	// method: return an accessor for the transforms of this given game object's siblings (not including itself) //
	public static IEnumerable<Transform> accessSiblingTransforms(this GameObject gameObject)
		=> gameObject.transform.accessSiblingTransforms();
	// method: return an accessor for the transforms of this given component's siblings (not including itself) //
	public static IEnumerable<Transform> accessSiblingTransforms(this Component component)
		=> component.transform.accessSiblingTransforms();
	// method: return a list of the transforms of this given transform's siblings (not including itself) //
	public static List<Transform> siblingTransforms(this Transform transform)
		=> transform.accessSiblingTransforms().manifested();
	// method: return a list of the transforms of this given game object's siblings (not including itself) //
	public static List<Transform> siblingTransforms(this GameObject gameObject)
		=> gameObject.transform.siblingTransforms();
	// method: return a list of the transforms of this given component's siblings (not including itself) //
	public static List<Transform> siblingTransforms(this Component component)
		=> component.transform.siblingTransforms();

	// method: return an accessor for the game objects of this given transform's siblings (not including itself) //
	public static IEnumerable<GameObject> accessSiblingObjects(this Transform transform)
		=> transform.accessSiblingAndSelfObjects().only(siblingOrSelfObject => (siblingOrSelfObject != transform.gameObject));
	// method: return an accessor for the game objects of this given game object's siblings (not including itself) //
	public static IEnumerable<GameObject> accessSiblingObjects(this GameObject gameObject)
		=> gameObject.transform.accessSiblingObjects();
	// method: return an accessor for the game objects of this given component's siblings (not including itself) //
	public static IEnumerable<GameObject> accessSiblingObjects(this Component component)
		=> component.transform.accessSiblingObjects();
	// method: return a list of the game objects of this given transform's siblings (not including itself) //
	public static List<GameObject> siblingObjects(this Transform transform)
		=> transform.accessSiblingObjects().manifested();
	// method: return a list of the game objects of this given game object's siblings (not including itself) //
	public static List<GameObject> siblingObjects(this GameObject gameObject)
		=> gameObject.transform.siblingObjects();
	// method: return a list of the game objects of this given component's siblings (not including itself) //
	public static List<GameObject> siblingObjects(this Component component)
		=> component.transform.siblingObjects();
	#endregion accessing siblings
}