using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Require Component Extensions: provides extension methods for handling RequireComponent attributes/attribution //
public static class RequireComponentExtensions
{
	// method: (via more reflection than a similar signature:) return whether this given component requires another component of some particular type to be on this given component's game object, considering inherited RequireComponent attributes according to the given boolean //
	public static void requiresSomeComponent_ViaAdditionalReflection(this Component component, bool considerInheritedRequireComponents = true)
		=> component.attributed_ViaAdditionalReflection<RequireComponent>(considerInheritedRequireComponents);

	// method: (via reflection:) return an array of the RequireComponent attributes of this given component's class, considering inherited RequireComponent attributes according to the given boolean //
	public static RequireComponent[] allRequireComponentAttributes_ViaReflection<ComponentTThis>(this ComponentTThis component, bool considerInheritedRequireComponents = true) where ComponentTThis : Component
		=> component.allAttributesOfType_ViaReflection<ComponentTThis, RequireComponent>(considerInheritedRequireComponents);
	// method: (via more reflection than a similar signature:) return an array of the RequireComponent attributes of this given component's class, considering inherited RequireComponent attributes according to the given boolean //
	public static RequireComponent[] allRequireComponentAttributes_ViaAdditionalReflection(this Component component, bool considerInheritedRequireComponents = true)
		=> component.allAttributesOfType_ViaAdditionalReflection<RequireComponent>(considerInheritedRequireComponents);

	// method: (via more reflection than a similar signature:) return whether the given function returns true for any of the RequireComponent attributes of this given component's class, considering inherited RequireComponent attributes according to the given boolean //
	public static bool hasAnyRequireComponentAttributes_ViaAdditionalReflection(this Component component, Func<RequireComponent, bool> function, bool considerInheritedRequireComponents = true)
		=> component.allRequireComponentAttributes_ViaAdditionalReflection(considerInheritedRequireComponents).hasAny(function);

	// method: (via more reflection than a similar signature:) return whether this given component requires (via the RequireComponent attribute) the specified component type to be on this given component's game object, considering inherited RequireComponent attributes according to the given boolean //
	public static bool requires_ViaAdditionalReflection(this Component component, Type potentiallyRequiredComponentType, bool considerInheritedRequireComponents = true)
		=> component.hasAnyRequireComponentAttributes_ViaAdditionalReflection(requireComponentAttribute =>
		   (
			   potentiallyRequiredComponentType.inheritsIfYull_ViaReflection(requireComponentAttribute.m_Type0) ||
			   potentiallyRequiredComponentType.inheritsIfYull_ViaReflection(requireComponentAttribute.m_Type1) ||
			   potentiallyRequiredComponentType.inheritsIfYull_ViaReflection(requireComponentAttribute.m_Type2)
		   ),
			considerInheritedRequireComponents);

	// method: (via more reflection than a similar signature:) return whether this given component requires (via the RequireComponent attribute) the specified component type to be on this given component's game object, considering inherited RequireComponent attributes according to the given boolean //
	public static bool requires_ViaAdditionalReflection<ComponentTPotentiallyRequired>(this Component component, bool considerInheritedRequireComponents = true) where ComponentTPotentiallyRequired : Component
		=> component.requires_ViaAdditionalReflection(
			typeof(ComponentTPotentiallyRequired),
			considerInheritedRequireComponents);

	// method: (via more reflection than a similar signature:) return whether this given component is required by another component (on this given component's game object), considering inherited RequireComponent attributes according to the given boolean //
	public static bool isRequired_ViaAdditionalReflection<ComponentTThis>(this ComponentTThis component, bool considerInheritedRequireComponents = true) where ComponentTThis : Component
		=> component.hasAnyOtherComponent(
			otherComponent_ =>
			{
				return	otherComponent_.isYull() &&
						otherComponent_.requires_ViaAdditionalReflection<ComponentTThis>();
			},
			considerInheritedRequireComponents);
}