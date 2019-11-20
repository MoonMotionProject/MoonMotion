using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Ancestor Extensions:
// • provides extension methods for handling ancestors
// #ancestor #family #transform #component
public static class AncestorExtensions
{
	#region determining ancestrals

	// method: return whether this given game object has any of the specified type of ancestral component, optionally including inactive components according to the given boolean //
	public static bool hasAnyAncestral<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(gameObject.ancestral<ComponentT>(includeInactiveComponents));

	// method: return whether this given component has any of the specified type of ancestral component, optionally including inactive components according to the given boolean //
	public static bool hasAnyAncestral<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.hasAnyAncestral<ComponentT>();
	#endregion determining ancestrals


	#region accessing ancestrals

	// method: return this given game object's first ancestor component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstAncestor<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.transform.firstAncestor<ComponentT>(includeInactiveComponents);

	// method: return this given transform's first ancestor component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstAncestor<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> includeInactiveComponents ? transform.ancestral<ComponentT>(true).FirstOrDefault() : transform.parent.GetComponentInParent<ComponentT>();

	// method: return this given component's first ancestor component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstAncestor<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.transform.firstAncestor<ComponentT>(includeInactiveComponents);

	// method: return an array of this given game object's ancestral components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] ancestral<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=>	gameObject.hasAnyParent() ?
				gameObject.parent().GetComponentsInParent<ComponentT>(includeInactiveComponents) :
				new ComponentT[] {};

	// method: return an array of this given transform's ancestral components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] ancestral<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.parent.GetComponentsInParent<ComponentT>(includeInactiveComponents);

	// method: return an array of this given component's ancestral components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] ancestral<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.parent().GetComponentsInParent<ComponentT>(includeInactiveComponents);
	#endregion accessing ancestrals
}