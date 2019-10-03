using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parent Extensions: provides extension methods for handling parents //
public static class ParentExtensions
{
	// method: return whether this given transform has no parent //
	public static bool parentless(this Transform transform)
		=> !transform.parent;
	// method: return whether this given game object has no parent //
	public static bool parentless(this GameObject gameObject)
		=> gameObject.transform.parentless();
	// method: return whether this given component has no parent //
	public static bool parentless(this Component component)
		=> component.transform.parentless();

	// method: return this given game object's parent //
	public static Transform parent(this GameObject gameObject)
		=> gameObject.transform.parent;
	// method: return the parent of the transform of this given component //
	public static Transform parent<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.parent;

	// method: return the parent object of this given transform //
	public static GameObject parentObject(this Transform transform)
		=> transform.parent.gameObject;
	// method: return this given game object's parent object //
	public static GameObject parentObject(this GameObject gameObject)
		=> gameObject.parent().gameObject;
	// method: return the parent object of the transform of this given component //
	public static GameObject parentObject<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.parentObject();

	// method: (according to the given boolean:) set this given transform's parent to the given parent transform, then return this given transform //
	public static Transform setParentTo(this Transform transform, Transform parent, bool boolean = true)
	{
		if (boolean)
		{
			transform.SetParent(parent);
		}

		return transform;
	}
	// method: (according to the given boolean:) set this given game object's parent to the given parent transform, then return this given game object //
	public static GameObject setParentTo(this GameObject gameObject, Transform parent, bool boolean = true)
		=> gameObject.transform.setParentTo(parent, boolean).gameObject;
	// method: (according to the given boolean:) set the parent of this given component's transform to the given parent transform, then return this given component //
	public static ComponentT setParentTo<ComponentT>(this ComponentT component, Transform parent, bool boolean = true) where ComponentT : Component
	{
		component.transform.setParentTo(parent, boolean);

		return component;
	}

	// method: (according to the given boolean:) set this given transform's parent to the transform of the given game object, then return this given transform //
	public static Transform setParentTo(this Transform transform, GameObject parentObject, bool boolean = true)
		=> transform.setParentTo(parentObject.transform, boolean);
	// method: (according to the given boolean:) set this given game object's parent to the transform of the given game object, then return this given game object //
	public static GameObject setParentTo(this GameObject gameObject, GameObject parentObject, bool boolean = true)
		=> gameObject.setParentTo(parentObject.transform, boolean);
	// method: (according to the given boolean:) set the parent of this given component's transform to the transform of the given game object, then return this given component //
	public static ComponentT setParentTo<ComponentT>(this ComponentT component, GameObject parentObject, bool boolean = true) where ComponentT : Component
		=> component.setParentTo(parentObject.transform, boolean);

	// method: (according to the given boolean:) set this given transform's parent to the transform of the given component, then return this given transform //
	public static Transform setParentTo(this Transform transform, Component parentComponent, bool boolean = true)
		=> transform.setParentTo(parentComponent.transform, boolean);
	// method: (according to the given boolean:) set this given game object's parent to the transform of the given component, then return this given game object //
	public static GameObject setParentTo(this GameObject gameObject, Component parentComponent, bool boolean = true)
		=> gameObject.setParentTo(parentComponent.transform, boolean);
	// method: (according to the given boolean:) set the parent of this given component's transform to the transform of the given component, then return this given component //
	public static ComponentT setParentTo<ComponentT>(this ComponentT component, Component parentComponent, bool boolean = true) where ComponentT : Component
		=> component.setParentTo(parentComponent.transform, boolean);

	// method: (according to the given boolean:) set this given transform's parent to the transform of the specified singleton behaviour class then return this given transform //
	public static Transform setParentTo<ParentSingletonBehaviourT>(this Transform transform, bool boolean = true) where ParentSingletonBehaviourT : SingletonBehaviour<ParentSingletonBehaviourT>
		=> transform.setParentTo(SingletonBehaviour<ParentSingletonBehaviourT>.transform, boolean);
	// method: (according to the given boolean:) set this given game object's parent to the transform of the specified singleton behaviour class then return this given game object //
	public static GameObject setParentTo<ParentSingletonBehaviourT>(this GameObject gameObject, bool boolean = true) where ParentSingletonBehaviourT : SingletonBehaviour<ParentSingletonBehaviourT>
		=> gameObject.transform.setParentTo<ParentSingletonBehaviourT>(boolean).gameObject;
	// method: (according to the given boolean:) set this given component's parent to the transform of the specified singleton behaviour class then return this given component //
	public static ComponentT setParentTo<ComponentT, ParentSingletonBehaviourT>(this ComponentT component, bool boolean = true) where ComponentT : Component where ParentSingletonBehaviourT : SingletonBehaviour<ParentSingletonBehaviourT>
		=> component.after(()=>
			component.transform.setParentTo<ParentSingletonBehaviourT>(boolean));

	// method: (according to the given boolean:) unparent this given transform (set its parent to null), then return this given transform //
	public static Transform unparent(this Transform transform, bool boolean = true)
		=> transform.setParentTo(((Transform)null), boolean);
	// method: (according to the given boolean:) unparent this given game object (set its parent to null), then return this given game object //
	public static GameObject unparent(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.unparent(boolean).gameObject;
	// method: (according to the given boolean:) unparent the transform of this given component (set its parent to null), then return this given component //
	public static ComponentT unparent<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
		=> component.after(()=>
			component.transform.unparent(boolean));

	// method: (according to the given boolean:) temporarily change this given transform's parent to the given other transform, during so invoking the given action on this given transform, then return this given transform //
	public static Transform actUponWithParentTemporarilySwappedTo(this Transform transform, Transform otherTransform, Action<Transform> action, bool boolean = true)
	{
		if (boolean)
		{
			if (otherTransform)
			{
				Transform extervalParent = transform.parent;
				return action.asFunction()(transform.setParentTo(otherTransform)).setParentTo(extervalParent);
			}
			else
			{
				return transform.returnWithError();
			}
		}
		else
		{
			return transform;
		}
	}
}