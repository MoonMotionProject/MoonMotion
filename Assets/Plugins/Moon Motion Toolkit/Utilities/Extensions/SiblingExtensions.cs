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


	#region getting siblings

	// method: return an array of the transforms of this given transform's siblings and itself //
	public static Transform[] siblingAndSelfTransforms(this Transform transform)
		=> transform.parent.childTransforms();
	// method: return an array of the transforms of this given game object's siblings and itself //
	public static Transform[] siblingAndSelfTransforms(this GameObject gameObject)
		=> gameObject.transform.siblingAndSelfTransforms();
	// method: return an array of the transforms of this given component's siblings and itself //
	public static Transform[] siblingAndSelfTransforms(this Component component)
		=> component.transform.siblingAndSelfTransforms();

	// method: return an array of the transforms of this given transform's siblings and itself //
	public static GameObject[] siblingAndSelfObjects(this Transform transform)
		=> transform.parent.childObjects();
	// method: return an array of the transforms of this given game object's siblings and itself //
	public static GameObject[] siblingAndSelfObjects(this GameObject gameObject)
		=> gameObject.transform.siblingAndSelfObjects();
	// method: return an array of the transforms of this given component's siblings and itself //
	public static GameObject[] siblingAndSelfObjects(this Component component)
		=> component.transform.siblingAndSelfObjects();

	// method: return an array of the transforms of this given transform's siblings (not including itself) //
	public static IEnumerable<Transform> siblingTransforms(this Transform transform)
		=> transform.siblingAndSelfTransforms().where(siblingOrSelfTransform => (siblingOrSelfTransform != transform));
	// method: return an array of the transforms of this given game object's siblings (not including itself) //
	public static IEnumerable<Transform> siblingTransforms(this GameObject gameObject)
		=> gameObject.transform.siblingTransforms();
	// method: return an array of the transforms of this given component's siblings (not including itself) //
	public static IEnumerable<Transform> siblingTransforms(this Component component)
		=> component.transform.siblingTransforms();

	// method: return an array of the game objects of this given transform's siblings (not including itself) //
	public static IEnumerable<GameObject> siblingObjects(this Transform transform)
		=> transform.siblingAndSelfObjects().where(siblingOrSelfObject => (siblingOrSelfObject != transform.gameObject));
	// method: return an array of the game objects of this given game object's siblings (not including itself) //
	public static IEnumerable<GameObject> siblingObjects(this GameObject gameObject)
		=> gameObject.transform.siblingObjects();
	// method: return an array of the game objects of this given component's siblings (not including itself) //
	public static IEnumerable<GameObject> siblingObjects(this Component component)
		=> component.transform.siblingObjects();
	#endregion getting siblings
}