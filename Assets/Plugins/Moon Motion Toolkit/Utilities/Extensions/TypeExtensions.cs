using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Type Extensions:
// • provides extension methods for handling types
// #types #reflection
public static class TypeExtensions
{
	#region interface determination

	// method: return whether the specified type is an interface //
	public static bool isAnInterface(this Type type)
		=> type.IsInterface;
	public static bool isNotAnInterface(this Type type)
		=> !type.isAnInterface();
	#endregion interface determination
	

	#region inheritance determination

	// method: (via reflection:) return whether this given type is inherited by the other given type //
	public static bool isInheritedBy_ViaReflection(this Type type, Type otherType)
		=> type.IsAssignableFrom(otherType);
	// method: (via reflection:) return whether this given type is not inherited by the other given type //
	public static bool isNotInheritedBy_ViaReflection(this Type type, Type otherType)
		=> !type.isInheritedBy_ViaReflection(otherType);

	// method: (via reflection:) return whether this given type inherits the other given type //
	public static bool inherits_ViaReflection(this Type type, Type otherType)
		=> type.IsSubclassOf(otherType);
	// method: (via reflection:) return whether this given type does not inherit the other given type //
	public static bool doesNotInherit_ViaReflection(this Type type, Type otherType)
		=> !type.inherits_ViaReflection(otherType);

	// method: (via reflection:) return whether this given type inherits the other given type if that other given type is yull //
	public static bool inheritsIfYull_ViaReflection(this Type type, Type otherType)
		=> otherType.isNull() || type.inherits_ViaReflection(otherType);
	// method: (via reflection:) return whether this given type does not inherit the other given type if that other given type is yull //
	public static bool doesNotInheritIfYull_ViaReflection(this Type type, Type otherType)
		=> !type.inheritsIfYull_ViaReflection(otherType);
	#endregion inheritance determination


	#region implementation determination

	// method: return whether this given type implements the specified interface type //
	public static bool implements<I>(this Type type) where I : class
	{
		if (Interfaces.doesNotInclude<I>())
		{
			return false.returnWithError(typeof(I).simpleClassName_ViaReflection()+" is not an interface");
		}

		return typeof(I).IsAssignableFrom(type);
	}
	public static bool doesNotImplement<I>(this Type type) where I : class
		=> !type.implements<I>();
	#endregion implementation determination


	#if UNITY_EDITOR
	// method: (via reflection:) return the project path of the script asset with this given script asset type (class of a script asset) //
	public static string projectPath_ViaReflection(this Type scriptAssetType)
		=> Project.pathForScriptAssetType_ViaReflection(scriptAssetType);
	#endif


	// method: (via reflection:) return the static property of this given type with the given name and the specified type //
	public static PropertyT getStaticProperty_ViaReflection<PropertyT>(this Type type, string propertyName)
		=> (PropertyT) type.GetProperty(propertyName).GetValue(null);


	// method: (via reflection:) return the static field of this given type with the given name and the specified type //
	public static FieldT getStaticField_ViaReflection<FieldT>(this Type type, string propertyName)
		=> (FieldT) type.GetField(propertyName).GetValue(null);
}