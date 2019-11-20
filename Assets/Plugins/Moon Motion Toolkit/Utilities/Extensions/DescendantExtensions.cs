using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Descendant Extensions:
// • provides extension methods for handling descendants
// #descendant #family #transform #component
public static class DescendantExtensions
{
	#region determining descendants

	// method: return whether this given game object has any of the specified type of descendant component, optionally including inactive components according to the given boolean //
	public static bool hasAnyDescendant<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(gameObject.descendants<ComponentT>(includeInactiveComponents));

	// method: return whether this given transform has any of the specified type of descendant component, optionally including inactive components according to the given boolean //
	public static bool hasAnyDescendant<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(transform.descendants<ComponentT>(includeInactiveComponents));

	// method: return whether this given component has any of the specified type of descendant component, optionally including inactive components according to the given boolean //
	public static bool hasAnyDescendant<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(component.descendants<ComponentT>(includeInactiveComponents));
	#endregion determining descendants
	

	#region accessing descendants

	// methods: return a list of this given provided game object's descendant transforms //
	public static List<Transform> descendantTransforms(this GameObject gameObject)
		=> gameObject.descendants<Transform>();
	public static List<Transform> descendantTransforms(this Component component)
		=> component.gameObject.descendantTransforms();

	// methods: return a list of this given provided game object's descendant game objects //
	public static List<GameObject> descendantObjects(this GameObject gameObject)
		=> gameObject.descendantTransforms().pick(transform => transform.gameObject);
	public static List<GameObject> descendantObjects(this Component component)
		=> component.gameObject.descendantObjects();

	// method: return this given game object's first descendant component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstDescendant<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.descendants<ComponentT>(includeInactiveComponents).FirstOrDefault();

	// method: return this given transform's first descendant component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstDescendant<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.firstDescendant<ComponentT>(includeInactiveComponents);

	// method: return this given component's first descendant component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstDescendant<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.firstDescendant<ComponentT>(includeInactiveComponents);

	// method: return this given game object's last descendant component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT lastDescendant<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.descendants<ComponentT>(includeInactiveComponents).LastOrDefault();

	// method: return this given transform's last descendant component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT lastDescendant<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.lastDescendant<ComponentT>(includeInactiveComponents);

	// method: return this given component's last descendant component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT lastDescendant<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.lastDescendant<ComponentT>(includeInactiveComponents);

	// method: return a list of this given game object's descendant components of the specified class, optionally including inactive components according to the given boolean //
	public static List<ComponentT> descendants<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.GetComponentsInChildren<ComponentT>(includeInactiveComponents).where(component => component.whereNotOn(gameObject));

	// method: return a list of this given transform's descendant components of the specified class, optionally including inactive components according to the given boolean //
	public static List<ComponentT> descendants<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.descendants<ComponentT>(includeInactiveComponents);

	// method: return a list of this given component's descendant components of the specified class, optionally including inactive components according to the given boolean //
	public static List<ComponentT> descendants<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.descendants<ComponentT>(includeInactiveComponents);
	#endregion accessing descendants


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