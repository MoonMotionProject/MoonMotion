using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parent Extensions: provides extension methods for handling parents //
public static class ParentExtensions
{
	// method: return whether this given transform has any parent //
	public static bool hasAnyParent(this Transform transform)
		=> transform.parent.isYull();
	// method: return whether this given game object has no parent //
	public static bool hasAnyParent(this GameObject gameObject)
		=> gameObject.transform.hasAnyParent();
	// method: return whether this given component has no parent //
	public static bool hasAnyParent(this Component component)
		=> component.transform.hasAnyParent();

	// method: return whether this given transform has no parent //
	public static bool isParentless(this Transform transform)
		=> !transform.hasAnyParent();
	// method: return whether this given game object has no parent //
	public static bool isParentless(this GameObject gameObject)
		=> gameObject.transform.isParentless();
	// method: return whether this given component has no parent //
	public static bool isParentless(this Component component)
		=> component.transform.isParentless();

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

	// methods: (according to the given boolean:) set this given provided transform's parent to the given provided parent transform or specified singleton behaviour (respectively), then return this given provided transform (unless this given transform provider is a component and the parent is specified as a singleton behaviour) //
	public static ObjectT setParentTo<ObjectT>(this ObjectT transform_TransformProvider, object parentTransform_TransformProvider, bool boolean = true)
	{
		if (boolean)
		{
			transform_TransformProvider.provideTransform().SetParent(parentTransform_TransformProvider.provideTransform());
		}

		return transform_TransformProvider;
	}
	public static GameObject setParentTo<ParentSingletonBehaviourT>(this GameObject gameObject, bool boolean = true) where ParentSingletonBehaviourT : SingletonBehaviour<ParentSingletonBehaviourT>
		=> gameObject.transform.setParentTo<ParentSingletonBehaviourT>(boolean).gameObject;
	public static Transform setParentTo<ParentSingletonBehaviourT>(this Transform transform, bool boolean = true) where ParentSingletonBehaviourT : SingletonBehaviour<ParentSingletonBehaviourT>
		=> transform.setParentTo(SingletonBehaviour<ParentSingletonBehaviourT>.transform, boolean);
	public static void setParentTo<ParentSingletonBehaviourT>(this Component component, bool boolean = true) where ParentSingletonBehaviourT : SingletonBehaviour<ParentSingletonBehaviourT>
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