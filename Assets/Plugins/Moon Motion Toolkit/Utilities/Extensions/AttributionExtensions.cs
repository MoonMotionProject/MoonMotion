using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Attribution Extensions: provides extension methods for handling attribution //
public static class AttributionExtensions
{
	#region objects in general


	// method: (via reflection:) return whether this given object's class has the specified attribute, including inherited attributes according to the given boolean //
	public static bool attributed_ViaReflection<AttributeT>(this object object_, bool includeInheritedAttributes = true) where AttributeT : Attribute
		=> Attribute.IsDefined(
			object_.GetType(), typeof(AttributeT),
			includeInheritedAttributes);
	#endregion objects in general


	#region components

	// method: return whether this given component's class has the specified attribute, including inherited attributes according to the given boolean //
	public static bool attributed<ComponentTThis, AttributeT>(this ComponentTThis component, bool includeInheritedAttributes = true) where ComponentTThis : Component where AttributeT : Attribute
		=> Attribute.IsDefined(
			typeof(ComponentTThis), typeof(AttributeT),
			includeInheritedAttributes);

	// method: return an array of the attributes of the specified type of this given component's class, including inherited attributes according to the given boolean //
	public static AttributeT[] allAttributesOfType<ComponentTThis, AttributeT>(this ComponentTThis component, bool includeInheritedAttributes = true) where ComponentTThis : Component where AttributeT : Attribute
		=>	Attribute.GetCustomAttributes
			(
				typeof(ComponentTThis), typeof(AttributeT),
				includeInheritedAttributes
			)
			.castTo<AttributeT>();
	// method: (via reflection:) return an array of the attributes of the specified type of this given component's class, including inherited attributes according to the given boolean //
	public static AttributeT[] allAttributesOfType_ViaReflection<AttributeT>(this Component component, bool includeInheritedAttributes = true) where AttributeT : Attribute
		=>	Attribute.GetCustomAttributes
			(
				component.GetType(), typeof(AttributeT),
				includeInheritedAttributes
			)
			.castTo<AttributeT>();
	#endregion components
}