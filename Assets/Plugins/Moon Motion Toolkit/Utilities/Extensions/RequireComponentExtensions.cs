using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Require Component Extensions: provides extension methods for handling RequireComponent attributes/attribution //
public static class RequireComponentExtensions
{
	// method: return whether this given component requires another component of some particular type to be on this given component's game object, considering inherited RequireComponent attributes according to the given boolean //
	public static void requiresSomeComponent_ViaReflection(this Component component, bool considerInheritedRequireComponents = true)
		=> component.attributed_ViaReflection<RequireComponent>(considerInheritedRequireComponents);

	// method: return an array of the RequireComponent attributes of this given component's class, considering inherited RequireComponent attributes according to the given boolean //
	public static RequireComponent[] allRequireComponentAttributes<ComponentTThis>(this ComponentTThis component, bool considerInheritedRequireComponents = true) where ComponentTThis : Component
		=> component.allAttributesOfType<ComponentTThis, RequireComponent>(considerInheritedRequireComponents);
	// method: (via reflection:) return an array of the RequireComponent attributes of this given component's class, considering inherited RequireComponent attributes according to the given boolean //
	public static RequireComponent[] allRequireComponentAttributes_ViaReflection(this Component component, bool considerInheritedRequireComponents = true)
		=> component.allAttributesOfType_ViaReflection<RequireComponent>(considerInheritedRequireComponents);

	// method: (via reflection:) return whether the given function returns true for any of the RequireComponent attributes of this given component's class, considering inherited RequireComponent attributes according to the given boolean //
	public static bool hasAnyRequireComponentAttributes_ViaReflection(this Component component, Func<RequireComponent, bool> function, bool considerInheritedRequireComponents = true)
		=> component.allRequireComponentAttributes_ViaReflection(considerInheritedRequireComponents).hasAny(function);

	// method: (via reflection:) return whether this given component requires (via the RequireComponent attribute) the specified component type to be on this given component's game object, considering inherited RequireComponent attributes according to the given boolean //
	public static bool requires_ViaReflection(this Component component, Type potentiallyRequiredComponentType, bool considerInheritedRequireComponents = true)
		=> component.hasAnyRequireComponentAttributes_ViaReflection(requireComponentAttribute =>
		   (
			   requireComponentAttribute.m_Type0.isAssignableFrom(potentiallyRequiredComponentType) ||
			   requireComponentAttribute.m_Type1.isAssignableFrom(potentiallyRequiredComponentType) ||
			   requireComponentAttribute.m_Type2.isAssignableFrom(potentiallyRequiredComponentType)
		   ),
			considerInheritedRequireComponents);

	// method: (via reflection:) return whether this given component requires (via the RequireComponent attribute) the specified component type to be on this given component's game object, considering inherited RequireComponent attributes according to the given boolean //
	public static bool requires_ViaReflection<ComponentTPotentiallyRequired>(this Component component, bool considerInheritedRequireComponents = true) where ComponentTPotentiallyRequired : Component
		=> component.requires_ViaReflection(
			typeof(ComponentTPotentiallyRequired),
			considerInheritedRequireComponents);

	// method: (via reflection:) return whether this given component is required by another component (on this given component's game object), considering inherited RequireComponent attributes according to the given boolean //
	public static bool required_ViaReflection<ComponentTThis>(this ComponentTThis component, bool considerInheritedRequireComponents = true) where ComponentTThis : Component
		=> component.hasAnyOtherComponent(
			otherComponent_ => otherComponent_.requires_ViaReflection<ComponentTThis>(),
			considerInheritedRequireComponents);
}