using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Attribution Extensions: provides extension methods for handling attribution //
public static class AttributionExtensions
{
	#region objects in general


	// method: (via more reflection than a similar signature:) return whether this given object's class has the specified attribute, including inherited attributes according to the given boolean //
	public static bool attributed_ViaAdditionalReflection<AttributeT>(this object object_, bool includeInheritedAttributes = true) where AttributeT : Attribute
		=> Attribute.IsDefined(
			object_.GetType(), typeof(AttributeT),
			includeInheritedAttributes);
	#endregion objects in general


	#region components

	// method: (via reflection:) return whether this given component's class has the specified attribute, including inherited attributes according to the given boolean //
	public static bool attributed_ViaReflection<ComponentTThis, AttributeT>(this ComponentTThis component, bool includeInheritedAttributes = true) where ComponentTThis : Component where AttributeT : Attribute
		=>	Attribute.IsDefined
			(
				typeof(ComponentTThis),
				typeof(AttributeT),
				includeInheritedAttributes
			);
	
	// method: (via reflection:) return an array of the attributes of the specified type on this given attributee type, including inherited attributes according to the given boolean //
	public static AttributeT[] allAttributesOfType_ViaReflection<AttributeT>(this Type attributeeType, bool includeInheritedAttributes = true) where AttributeT : Attribute
		=>	Attribute.GetCustomAttributes
			(
				attributeeType,
				typeof(AttributeT),
				includeInheritedAttributes
			).castTo<AttributeT>();
	// method: (via reflection:) return an array of the attributes of the specified type on this given component's class, including inherited attributes according to the given boolean //
	public static AttributeT[] allAttributesOfType_ViaReflection<ComponentTThis, AttributeT>(this ComponentTThis component, bool includeInheritedAttributes = true) where ComponentTThis : Component where AttributeT : Attribute
		=> typeof(ComponentTThis).allAttributesOfType_ViaReflection<AttributeT>(includeInheritedAttributes);
	// method: (via more reflection than a similar signature:) return an array of the attributes of the specified type on this given component's class, including inherited attributes according to the given boolean //
	public static AttributeT[] allAttributesOfType_ViaAdditionalReflection<AttributeT>(this Component component, bool includeInheritedAttributes = true) where AttributeT : Attribute
		=>	Attribute.GetCustomAttributes
			(
				component.derivedType_ViaReflection(),
				typeof(AttributeT),
				includeInheritedAttributes
			).castTo<AttributeT>();

	// method: (via reflection:) return whether the given function returns true for any of the attributes of the specified type on this given attributee type, including inherited attributes according to the given boolean //
	public static bool hasAnyAttributesOfType_ViaReflection<AttributeT>(this Type attributeeType, Func<AttributeT, bool> function, bool includeInheritedAttributes = true) where AttributeT : Attribute
		=> attributeeType.allAttributesOfType_ViaReflection<AttributeT>(includeInheritedAttributes).hasAny(function);
	// method: (via reflection:) return whether the given function returns true for any of the attributes of the specified type on this given component's class, including inherited attributes according to the given boolean //
	public static bool hasAnyAttributesOfType_ViaReflection<ComponentTThis, AttributeT>(this ComponentTThis component, Func<AttributeT, bool> function, bool includeInheritedAttributes = true) where ComponentTThis : Component where AttributeT : Attribute
		=> component.allAttributesOfType_ViaReflection<ComponentTThis, AttributeT>(includeInheritedAttributes).hasAny(function);
	// method: (via more reflection than a similar signature:) return whether the given function returns true for any of the attributes of the specified type on this given component's class, including inherited attributes according to the given boolean //
	public static bool hasAnyAttributesOfType_ViaAdditionalReflection<AttributeT>(this Component component, Func<AttributeT, bool> function, bool includeInheritedAttributes = true) where AttributeT : Attribute
		=> component.allAttributesOfType_ViaAdditionalReflection<AttributeT>(includeInheritedAttributes).hasAny(function);
	
	// method: (via reflection:) return the first of the attributes of the specified type on this given component's class, including inherited attributes according to the given boolean //
	public static AttributeT firstAttributeOfType_ViaReflection<ComponentTThis, AttributeT>(this ComponentTThis component, bool includeInheritedAttributes = true) where ComponentTThis : Component where AttributeT : Attribute
		=> component.allAttributesOfType_ViaReflection<ComponentTThis, AttributeT>(includeInheritedAttributes).first();
	// method: (via more reflection than a similar signature:) return the first of the attributes of the specified type on this given component's class, including inherited attributes according to the given boolean //
	public static AttributeT firstAttributeOfType_ViaAdditionalReflection<AttributeT>(this Component component, bool includeInheritedAttributes = true) where AttributeT : Attribute
		=> component.allAttributesOfType_ViaAdditionalReflection<AttributeT>(includeInheritedAttributes).first();
	#endregion components
}