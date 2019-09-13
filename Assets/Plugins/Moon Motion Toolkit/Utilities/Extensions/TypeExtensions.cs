using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Type Extensions: provides extension methods for handling types //
public static class TypeExtensions
{
	// method: return the class name of this given type //
	public static string className(this Type type)
		=> ""+type;		// this is the same as what 'type.FullName' would return

	// method: return the simple class name of this given type //
	public static string simpleClassName(this Type type)
		=> type.Name;

	#if UNITY_EDITOR
	// method: return the asset path of the script asset with this given script asset type (class of a script asset) //
	public static string assetPath(this Type scriptAssetType)
		=> Asset.pathForScriptAssetType(scriptAssetType);
	#endif

	// method: return the static property of this given type with the given name and the specified type //
	public static PropertyT getStaticProperty<PropertyT>(this Type type, string propertyName)
		=> (PropertyT) type.GetProperty(propertyName).GetValue(null);

	// method: return the static field of this given type with the given name and the specified type //
	public static FieldT getStaticField<FieldT>(this Type type, string propertyName)
		=> (FieldT) type.GetField(propertyName).GetValue(null);

	// method: return whether this given type is assignable from the other given type //
	public static bool isAssignableFrom(this Type type, Type otherType)
		=> type.isYull() && type.IsAssignableFrom(otherType);

	// method: return the base type of this given type //
	public static Type baseType(this Type type)
		=> type.BaseType;

	// method: return whether this given type has a base type (other than 'object') //
	public static bool hasABaseType(this Type type)
		=> (type.baseType() != typeof(object));
}