using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Corality Extensions:
// • provides extension methods for handling corality (local or ancestor beingness)
// #corality #family #transform #component
public static class CoralityExtensions
{
	#region determining corality

	// method: return whether this given transform is coral to the other given transform //
	public static bool isCoralTo(this Transform transform, Transform otherTransform)
		=> otherTransform.isLodalTo(transform);

	// method: return whether this given game object has any coral component of the specified type //
	public static bool hasAnyCoral<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.coral<ComponentT>(includeInactiveComponents).hasAny();
	// method: return whether this given game object has any coral component of the specified type //
	public static bool hasAnyCoral<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.hasAnyCoral<ComponentT>(includeInactiveComponents);

	// method: (via reflection:) return whether this given game object has any coral component of the given type //
	public static bool hasAnyCoral_ViaReflection(this GameObject gameObject, Type type, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> gameObject.coral_ViaReflection(type, includeInactiveComponents).hasAny();
	public static bool hasNoCoral_ViaReflection(this GameObject gameObject, Type type, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> !gameObject.hasAnyCoral_ViaReflection(type, includeInactiveComponents);
	// method: (via reflection:) return whether this given component has any coral component of the given type //
	public static bool hasAnyCoral_ViaReflection(this Component component, Type type, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> component.gameObject.hasAnyCoral_ViaReflection(type, includeInactiveComponents);
	public static bool hasNoCoral_ViaReflection(this Component component, Type type, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> !component.hasAnyCoral_ViaReflection(type, includeInactiveComponents);
	#endregion determining corality
	

	#region accessing corals

	// method: return this given game object's first coral component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstCoral<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> includeInactiveComponents ? gameObject.GetComponentsInParent<ComponentT>(true).firstOtherwiseDefault() : gameObject.GetComponentInParent<ComponentT>();

	// method: return this given transform's first coral component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstCoral<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.firstCoral<ComponentT>(includeInactiveComponents);

	// method: return this given component's first coral component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstCoral<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.firstCoral<ComponentT>(includeInactiveComponents);
	
	public static Component firstCoral_ViaReflection(this GameObject gameObject, Type type, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> gameObject.coral_ViaReflection(type, includeInactiveComponents).firstOtherwiseDefault();
	
	public static Component firstCoral_ViaReflection(this Component component, Type type, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> component.gameObject.firstCoral_ViaReflection(type, includeInactiveComponents);

	// method: return an array of this given game object's coral components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] coral<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.GetComponentsInParent<ComponentT>(includeInactiveComponents);

	// method: return an array of this given transform's coral components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] coral<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.GetComponentsInParent<ComponentT>(includeInactiveComponents);

	// method: return an array of this given component's coral components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] coral<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.GetComponentsInParent<ComponentT>(includeInactiveComponents);

	// method: (via reflection:) return the list of this given game object's coral components of the given type, optionally including inactive components according to the given boolean //
	public static List<Component> coral_ViaReflection(this GameObject gameObject, Type type, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=>	gameObject.GetComponentsInParent<Component>(includeInactiveComponents)
				.where(coralComponent => coralComponent.isDerivedFrom_ViaReflection(type));

	// method: return the first game object out of this given game object and its ancestor game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static GameObject firstCoralObjectWith<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
	{
		if (gameObject.first<ComponentT>(includeInactiveComponents))
		{
			return gameObject;
		}

		Transform transformAtCurrentLevel = gameObject.transform;
		while (transformAtCurrentLevel.parent)
		{
			Transform parentTransform = transformAtCurrentLevel.parent;
			if (parentTransform.first<ComponentT>(includeInactiveComponents))
			{
				return parentTransform.gameObject;
			}

			transformAtCurrentLevel = parentTransform;
		}

		return null;
	}

	// method: return the first game object out of the game object for this component and that game object's ancestor game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static GameObject firstCoralObjectWith<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.firstCoralObjectWith<ComponentT>(includeInactiveComponents);

	// method: return the transform of the first game object out of this given game object and its ancestor game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static Transform firstCoralTransformWith<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstCoralObjectWith<ComponentT>(includeInactiveComponents).transform;

	// method: return the transform of the first game object out of the game object for this component and that game object's ancestor game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static Transform firstCoralTransformWith<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.firstCoralTransformWith<ComponentT>(includeInactiveComponents);
	#endregion accessing corals
}