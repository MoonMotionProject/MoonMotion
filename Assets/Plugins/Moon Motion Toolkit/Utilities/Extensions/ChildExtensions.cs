using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Child Extensions: provides extension methods for handling children //
public static class ChildExtensions
{
	#region counting children

	public static bool childless(this Transform transform)
		=> (transform.childCount == 0);
	public static bool childless(this GameObject gameObject)
		=> gameObject.transform.childless();
	public static bool childless(this Component component)
		=> component.transform.childless();

	public static bool hasAnyChildren(this Transform transform)
		=> (transform.childCount > 0);
	public static bool hasAnyChildren(this GameObject gameObject)
		=> gameObject.transform.hasAnyChildren();
	public static bool hasAnyChildren(this Component component)
		=> component.transform.hasAnyChildren();

	public static bool pluralChildren(this Transform transform)
		=> (transform.childCount > 1);
	public static bool pluralChildren(this GameObject gameObject)
		=> gameObject.transform.pluralChildren();
	public static bool pluralChildren(this Component component)
		=> component.transform.pluralChildren();
	#endregion counting children
	

	#region accessing children

	public static Transform childTransform(this Transform transform, int childIndex)
		=> transform.GetChild(childIndex);
	public static Transform childTransform(this GameObject gameObject, int childIndex)
		=> gameObject.transform.childTransform(childIndex);
	public static Transform childTransform(this Component component, int childIndex)
		=> component.transform.childTransform(childIndex);

	public static GameObject childObject(this Transform transform, int childIndex)
		=> transform.childTransform(childIndex).gameObject;
	public static GameObject childObject(this GameObject gameObject, int childIndex)
		=> gameObject.transform.childObject(childIndex);
	public static GameObject childObject(this Component component, int childIndex)
		=> component.transform.childObject(childIndex);

	public static Transform firstChildTransform(this Transform transform)
		=> transform.childTransform(0);
	public static Transform firstChildTransform(this GameObject gameObject)
		=> gameObject.transform.firstChildTransform();
	public static Transform firstChildTransform(this Component component)
		=> component.transform.firstChildTransform();

	public static GameObject firstChildObject(this Transform transform)
		=> transform.childObject(0);
	public static GameObject firstChildObject(this GameObject gameObject)
		=> gameObject.transform.firstChildObject();
	public static GameObject firstChildObject(this Component component)
		=> component.transform.firstChildObject();

	public static Transform lastChildTransform(this Transform transform)
		=> transform.childTransform(transform.lastChildIndex());
	public static Transform lastChildTransform(this GameObject gameObject)
		=> gameObject.transform.lastChildTransform();
	public static Transform lastChildTransform(this Component component)
		=> component.transform.lastChildTransform();

	public static GameObject lastChildObject(this Transform transform)
		=> transform.childObject(transform.lastChildIndex());
	public static GameObject lastChildObject(this GameObject gameObject)
		=> gameObject.transform.lastChildObject();
	public static GameObject lastChildObject(this Component component)
		=> component.transform.lastChildObject();

	public static IEnumerable<Transform> selectChildTransforms(this Transform transform)
	{
		foreach (Transform childTransform in transform)
		{
			yield return childTransform;
		}
	}
	public static IEnumerable<Transform> selectChildTransforms(this GameObject gameObject)
		=> gameObject.transform.selectChildTransforms();
	public static IEnumerable<Transform> selectChildTransforms(this Component component)
		=> component.transform.selectChildTransforms();
	public static Transform[] childTransforms(this Transform transform)
	{
		Transform[] array = new Transform[transform.childCount];

		for (int childIndex = 0; childIndex < transform.childCount; childIndex++)
		{
			array[childIndex] = transform.GetChild(childIndex);
		}

		return array;
	}
	public static Transform[] childTransforms(this GameObject gameObject)
		=> gameObject.transform.childTransforms();
	public static Transform[] childTransforms(this Component component)
		=> component.transform.childTransforms();

	public static IEnumerable<GameObject> selectChildObjects(this Transform transform)
	{
		foreach (Transform childTransform in transform)
		{
			yield return childTransform.gameObject;
		}
	}
	public static IEnumerable<GameObject> selectChildObjects(this GameObject gameObject)
		=> gameObject.transform.selectChildObjects();
	public static IEnumerable<GameObject> selectChildObjects(this Component component)
		=> component.transform.selectChildObjects();
	public static GameObject[] childObjects(this Transform transform)
	{
		GameObject[] array = new GameObject[transform.childCount];

		for (int childIndex = 0; childIndex < transform.childCount; childIndex++)
		{
			array[childIndex] = transform.childObject(childIndex);
		}

		return array;
	}
	public static GameObject[] childObjects(this GameObject gameObject)
		=> gameObject.transform.childObjects();
	public static GameObject[] childObjects(this Component component)
		=> component.transform.childObjects();
	#endregion accessing children


	#region destroying children

	// method: destroy this given transform's child at the given index, then return this given transform //
	public static Transform destroyChild(this Transform transform, int childIndex)
	{
		transform.GetChild(childIndex).destroyObject();

		return transform;
	}
	// method: destroy this given game object's child at the given index, then return this given game object //
	public static GameObject destroyChild(this GameObject gameObject, int childIndex)
		=> gameObject.transform.destroyChild(childIndex).gameObject;
	// method: destroy this given game object's child at the given index, then return this given component //
	public static ComponentT destroyChild<ComponentT>(this ComponentT component, int childIndex) where ComponentT : Component
		=> component.after(()=>
			component.transform.destroyChild(childIndex));

	// method: destroy the child of this given transform at the given index if such exists, then return this given transform //
	public static Transform destroyChildIfItExists(this Transform transform, int childIndex)
	{
		if (transform.childCount > childIndex)
		{
			return transform.destroyChild(childIndex);
		}

		return transform;
	}
	// method: destroy the child of this given game object at the given index if such exists, then return this given game object //
	public static GameObject destroyChildIfItExists(this GameObject gameObject, int childIndex)
		=> gameObject.transform.destroyChildIfItExists(childIndex).gameObject;
	// method: destroy the child of this given component at the given index if such exists, then return this given component //
	public static ComponentT destroyChildIfItExists<ComponentT>(this ComponentT component, int childIndex) where ComponentT : Component
		=> component.after(()=>
			component.transform.destroyChildIfItExists(childIndex));

	// method: destroy this given transform's first child, then return this given transform //
	public static Transform destroyFirstChild(this Transform transform)
		=> transform.destroyChild(0);
	// method: destroy this given game object's first child, then return this given game object //
	public static GameObject destroyFirstChild(this GameObject gameObject)
		=> gameObject.transform.destroyFirstChild().gameObject;
	// method: destroy this given component's first child, then return this given component //
	public static ComponentT destroyFirstChild<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.after(()=>
			 component.transform.destroyFirstChild());

	// method: destroy the first child of this given transform if such exists, then return this given transform //
	public static Transform destroyFirstChildIfItExists(this Transform transform)
		=> transform.destroyChildIfItExists(0);
	// method: destroy the first child of this given game object if such exists, then return this given game object //
	public static GameObject destroyFirstChildIfItExists(this GameObject gameObject)
		=> gameObject.transform.destroyFirstChildIfItExists().gameObject;
	// method: destroy the first child of this given component if such exists, then return this given component //
	public static ComponentT destroyFirstChildIfItExists<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.after(()=>
			component.transform.destroyFirstChildIfItExists());

	// method: destroy this given transform's last child, then return this given transform //
	public static Transform destroyLastChild(this Transform transform)
		=> transform.destroyChild(transform.lastChildIndex());
	// method: destroy this given game object's last child, then return this given game object //
	public static GameObject destroyLastChild(this GameObject gameObject)
		=> gameObject.transform.destroyLastChild().gameObject;
	// method: destroy this given component's last child, then return this given component //
	public static ComponentT destroyLastChild<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.after(()=>
			component.transform.destroyLastChild());

	// method: destroy the last child of this given transform if such exists, then return this given transform //
	public static Transform destroyLastChildIfItExists(this Transform transform)
		=> transform.destroyChildIfItExists(transform.lastChildIndex());
	// method: destroy the last child of this given game object if such exists, then return this given game object //
	public static GameObject destroyLastChildIfItExists(this GameObject gameObject)
		=> gameObject.transform.destroyLastChildIfItExists().gameObject;
	// method: destroy the last child of this given component if such exists, then return this given component //
	public static ComponentT destroyLastChildIfItExists<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.after(()=>
			component.transform.destroyLastChildIfItExists());

	// method: destroy the last child of this given transform that has the specified component type if such exists, then return this given transform //
	public static Transform destroyLastChildIfItExists<ComponentT>(this Transform transform) where ComponentT : Component
	{
		ComponentT component = transform.lastChild<ComponentT>();
		if (component)
		{
			component.destroyObject();
		}

		return transform;
	}
	// method: destroy the last child of this given game object that has the specified component type if such exists, then return this given game object //
	public static GameObject destroyLastChildIfItExists<ComponentT>(this GameObject gameObject) where ComponentT : Component
		=> gameObject.destroyLastChildIfItExists<ComponentT>().gameObject;
	// method: destroy the last child of this given component that has the specified component type if such exists, then return this given component //
	public static ThisComponentT destroyLastChildIfItExists<ThisComponentT, TargetComponentT>(this ThisComponentT component) where ThisComponentT : Component where TargetComponentT : Component
		=> component.after(()=>
			component.gameObject.destroyLastChildIfItExists<TargetComponentT>());

	// method: destroy all of the children of this given transform, then return this given transform //
	public static Transform destroyChildren(this Transform transform)
	{
		for (int childIndex = transform.childCount - 1; childIndex >= 0; childIndex--)
		{
			transform.GetChild(childIndex).destroyObject();
		}

		return transform;
	}
	// method: destroy all of the children of this given game object, then return this given game object //
	public static GameObject destroyChildren(this GameObject gameObject)
		=> gameObject.transform.destroyChildren().gameObject;
	// method: destroy all of the children of the game object of this given component, then return this given component //
	public static ComponentT destroyChildren<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.after(()=>
			component.gameObject.destroyChildren());
	#endregion destroying children


	#region children iteration

	// method: return the index of the last child of this given transform //
	public static int lastChildIndex(this Transform transform)
		=> transform.childCount - 1;
	// method: return the index of the last child of this given game object //
	public static int lastChildIndex(this GameObject gameObject)
		=> gameObject.transform.lastChildIndex();
	// method: return the index of the last child of this given game object //
	public static int lastChildIndex(this Component component)
		=> component.transform.lastChildIndex();

	// method: invoke the given action on each child transform of this given component's transform, then return this given component //
	public static ComponentT forEachChildTransform<ComponentT>(this ComponentT component, Action<Transform> action, bool boolean = true) where ComponentT : Component
	{
		if (boolean)
		{
			foreach (Transform childTransform in component.transform)
			{
				action(childTransform);
			}
		}

		return component;
	}
	// method: invoke the given action on each child transform of this given game object, then return this given game object //
	public static GameObject forEachChildTransform(this GameObject gameObject, Action<Transform> action, bool boolean = true)
		=>	gameObject.after(()=>
				gameObject.transform.forEachChildTransform(action),
				boolean);

	// method: set the activity of all child objects of this given transform to the given 'enablement' boolean, then return this given transform //
	public static Transform setActivityOfChildrenTo(this Transform transform, bool enablement)
		=> transform.forEachChildTransform(childTransform => childTransform.setActivityTo(enablement));
	// method: set the activity of all child objects of this given game object to the given 'enablement' boolean, then return this given game object //
	public static GameObject setActivityOfChildrenTo(this GameObject gameObject, bool enablement)
		=> gameObject.transform.setActivityOfChildrenTo(enablement).gameObject;
	// method: set the activity of all child objects of this given component to the given 'enablement' boolean, then return this given component //
	public static ComponentT setActivityOfChildrenTo<ComponentT>(this ComponentT component, bool enablement) where ComponentT : Component
		=> component.after(()=>
			component.transform.setActivityOfChildrenTo(enablement));

	// method: activate all child objects of this given transform, then return this given transform //
	public static Transform activateChildren(this Transform transform)
		=> transform.setActivityOfChildrenTo(true);
	// method: activate all child objects of this given game object, then return this given game object //
	public static GameObject activateChildren(this GameObject gameObject)
		=> gameObject.setActivityOfChildrenTo(true);
	// method: activate all child objects of this given component, then return this given component //
	public static ComponentT activateChildren<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.setActivityOfChildrenTo(true);

	// method: deactivate all child objects of this given transform, then return this given transform //
	public static Transform deactivateChildren(this Transform transform)
		=> transform.setActivityOfChildrenTo(false);
	// method: deactivate all child objects of this given game object, then return this given game object //
	public static GameObject deactivateChildren(this GameObject gameObject)
		=> gameObject.setActivityOfChildrenTo(false);
	// method: deactivate all child objects of this given component, then return this given component //
	public static ComponentT deactivateChildren<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.setActivityOfChildrenTo(false);
	#endregion children iteration
}