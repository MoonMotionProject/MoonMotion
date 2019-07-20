using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Type Extensions: provides extension methods for handling types //
public static class TypeExtensions
{
	// methods for: purpose //

	
	// method: return the static property of this given type with the given name and the specified type //
	public static PropertyT getStaticProperty<PropertyT>(this Type type, string propertyName)
		=> (PropertyT) type.GetProperty(propertyName).GetValue(null);

	// method: return the static field of this given type with the given name and the specified type //
	public static FieldT getStaticField<FieldT>(this Type type, string propertyName)
		=> (FieldT) type.GetField(propertyName).GetValue(null);

	// method: return whether this given type is assignable from the other given type //
	public static bool isAssignableFrom(this Type type, Type otherType)
		=> type.isYull() && type.IsAssignableFrom(otherType);
}