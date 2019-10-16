using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Descendant Extensions: provides extension methods for handling descendants //
public static class DescendantExtensions
{
	#region determining locality or descendance

	// method: return whether this given transform is local to or a descendant of the other given transform //
	public static bool isLocalToOrDescendantOf(this Transform transform, Transform otherTransform)
		=> transform.IsChildOf(otherTransform);
	// method: return whether this given game object is local to or a descendant of the given transform //
	public static bool isLocalToOrDescendantOf(this GameObject gameObject, Transform transform)
		=> gameObject.transform.isLocalToOrDescendantOf(transform);
	// method: return whether this given component is local to or a descendant of the given transform //
	public static bool isLocalToOrDescendantOf(this Component component, Transform transform)
		=> component.transform.isLocalToOrDescendantOf(transform);

	// method: return whether this given transform is local to or a descendant of the given game object //
	public static bool isLocalToOrDescendantOf(this Transform transform, GameObject gameObject)
		=> transform.isLocalToOrDescendantOf(gameObject.transform);
	// method: return whether this given game object is local to or a descendant of the other given game object //
	public static bool isLocalToOrDescendantOf(this GameObject gameObject, GameObject otherGameObject)
		=> gameObject.transform.isLocalToOrDescendantOf(otherGameObject);
	// method: return whether this given component is local to or a descendant of the given game object //
	public static bool isLocalToOrDescendantOf(this Component component, GameObject gameObject)
		=> component.transform.isLocalToOrDescendantOf(gameObject);

	// method: return whether this given transform is local to or a descendant of the given component //
	public static bool isLocalToOrDescendantOf(this Transform transform, Component component)
		=> transform.isLocalToOrDescendantOf(component);
	// method: return whether this given game object is local to or a descendant of the given component //
	public static bool isLocalToOrDescendantOf(this GameObject gameObject, Component component)
		=> gameObject.transform.isLocalToOrDescendantOf(component);
	// method: return whether this given component is local to or a descendant of the other given component //
	public static bool isLocalToOrDescendantOf(this Component component, Component otherComponent)
		=> component.transform.isLocalToOrDescendantOf(otherComponent);

	// method: return whether this given transform is local to or a descendant of the specified singleton behaviour class //
	public static bool isLocalToOrDescendantOf<SingletonBehaviourT>(this Transform transform) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> transform.isLocalToOrDescendantOf(SingletonBehaviour<SingletonBehaviourT>.transform);
	// method: return whether this given game object is local to or a descendant of the specified singleton behaviour class //
	public static bool isLocalToOrDescendantOf<SingletonBehaviourT>(this GameObject gameObject) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> gameObject.transform.isLocalToOrDescendantOf<SingletonBehaviourT>();
	// method: return whether this given component is local to or a descendant of the specified singleton behaviour class //
	public static bool isLocalToOrDescendantOf<SingletonBehaviourT>(this Component component) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> component.transform.isLocalToOrDescendantOf<SingletonBehaviourT>();
	#endregion determining locality or descendance


	#region destroying descendants

	// method: destroy the last descendant of this given game object that has the specified component type if such exists, then return this given game object //
	public static GameObject destroyLastDescendantObjectWithComponentIfItExists<ComponentT>(this GameObject gameObject) where ComponentT : Component
	{
		ComponentT lastDescendantComponent = gameObject.lastDescendant<ComponentT>();
		if (lastDescendantComponent)
		{
			lastDescendantComponent.destroyObject();
		}

		return gameObject;
	}
	// method: destroy the last descendant of this given component that has the specified component type if such exists, then return this given component //
	public static ThisComponentT destroyLastDescendantObjectWithComponentIfItExists<ThisComponentT, TargetComponentT>(this ThisComponentT component) where ThisComponentT : Component where TargetComponentT : Component
		=> component.after(()=>
			component.gameObject.destroyLastDescendantObjectWithComponentIfItExists<TargetComponentT>());
	#endregion destroying descendants
}