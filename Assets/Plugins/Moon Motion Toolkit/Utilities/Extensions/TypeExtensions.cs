using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Type Extensions:
// • provides extension methods for handling types
// #types #reflection
public static class TypeExtensions
{
	#if UNITY_EDITOR
	// method: (via reflection:) return the asset path of the script asset with this given script asset type (class of a script asset) //
	public static string assetPath_ViaReflection(this Type scriptAssetType)
		=> Asset.pathForScriptAssetType_ViaReflection(scriptAssetType);
	#endif

	// method: (via reflection:) return the static property of this given type with the given name and the specified type //
	public static PropertyT getStaticProperty_ViaReflection<PropertyT>(this Type type, string propertyName)
		=> (PropertyT) type.GetProperty(propertyName).GetValue(null);

	// method: (via reflection:) return the static field of this given type with the given name and the specified type //
	public static FieldT getStaticField_ViaReflection<FieldT>(this Type type, string propertyName)
		=> (FieldT) type.GetField(propertyName).GetValue(null);

	// method: (via reflection:) return whether this given type is assignable from the other given type //
	public static bool isAssignableFrom_ViaReflection(this Type type, Type otherType)
		=> type.isYull() && type.IsAssignableFrom(otherType);
}