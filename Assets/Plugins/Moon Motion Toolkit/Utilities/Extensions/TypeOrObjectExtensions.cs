using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Type Or Object Extensions:
// • provides extension methods for handling types or objects
// #types #objects
public static class TypeOrObjectExtensions
{
	// method: (via reflection:) return the derived type of this given object //
	public static Type derivedType_ViaReflection<ObjectT>(this ObjectT object_)
		=> object_.GetType();
	
	// method: (via reflection:) return the inherited type of this given type, where 'object' is returned if it has no inherited type other than 'object' //
	public static Type inheritedTypeAllowingObject_ViaReflection(this Type type)
		=> type.BaseType;
	// method: (via reflection:) return the inherited type of this given object, where 'object' is returned if it has no inherited type other than 'object' //
	public static Type inheritedTypeAllowingObject_ViaReflection<ObjectT>(this ObjectT object_)
		=> object_.derivedType_ViaReflection().inheritedTypeAllowingObject_ViaReflection();
	
	// method: (via reflection:) return the inherited type of this given type, where null is returned if it has no inherited type other than 'object' //
	public static Type inheritedType_ViaReflection(this Type type)
	{
		Type inheritedTypePotentiallyObject = type.inheritedTypeAllowingObject_ViaReflection();
		if (inheritedTypePotentiallyObject.Equals(typeof(object)))
		{
			return null;
		}
		return inheritedTypePotentiallyObject;
	}
	// method: (via reflection:) return the inherited type of this given object, where null is returned if it has no inherited type other than 'object' //
	public static Type inheritedType_ViaReflection<ObjectT>(this ObjectT object_)
		=> object_.derivedType_ViaReflection().inheritedType_ViaReflection();
	
	// method: (via reflection:) return whether this given type has any inherited type (other than 'object') //
	public static bool hasAnyInheritedType_ViaReflection(this Type type)
		=> type.inheritedType_ViaReflection().isYull();
	public static bool hasNoInheritedType_ViaReflection(this Type type)
		=> !type.hasAnyInheritedType_ViaReflection();
	// method: (via reflection:) return whether this given object has any inherited type (other than 'object') //
	public static bool hasAnyInheritedType_ViaReflection<ObjectT>(this ObjectT object_)
		=> object_.derivedType_ViaReflection().hasAnyInheritedType_ViaReflection();
	public static bool hasNoInheritedType_ViaReflection<ObjectT>(this ObjectT object_)
		=> !object_.hasAnyInheritedType_ViaReflection();

	// method: (via reflection:) return an accessor for this given type followed by each of its recursively inherited types //
	public static IEnumerable<Type> accessSelfThenInheritedTypes_ViaReflection(this Type type)
		=>	type.hasNoInheritedType_ViaReflection() ?
				type.startEnumerable() :
				type.with(type.inheritedType_ViaReflection().accessSelfThenInheritedTypes_ViaReflection());
	// method: (via reflection:) return an accessor for this given object's derived type followed by each of its recursively inherited types //
	public static IEnumerable<Type> accessDerivedThenInheritedTypes_ViaReflection<ObjectT>(this ObjectT object_)
		=> object_.derivedType_ViaReflection().accessSelfThenInheritedTypes_ViaReflection();
	// method: (via reflection:) return the set of this given type followed by each of its recursively inherited types //
	public static HashSet<Type> selfThenInheritedTypes_ViaReflection(this Type type)
		=> type.accessSelfThenInheritedTypes_ViaReflection().uniques();
	// method: (via reflection:) return the set of this given object's derived type followed by each of its recursively inherited types //
	public static HashSet<Type> derivedThenInheritedTypes_ViaReflection<ObjectT>(this ObjectT object_)
		=> object_.accessDerivedThenInheritedTypes_ViaReflection().uniques();

	// method: return the casted type of this given object //
	public static Type castedType<ObjectT>(this ObjectT object_)
		=> typeof(ObjectT);

	// method: (via reflection:) return whether this given object's derived type is the specified type //
	public static bool derivedTypeIs_ViaReflection<TPotentialType>(this object object_)
		=> object_.derivedType_ViaReflection().Equals(typeof(TPotentialType));
	public static bool derivedTypeIsNot_ViaReflection<TPotentialType>(this object object_)
		=> !object_.derivedTypeIs_ViaReflection<TPotentialType>();
	// method: (via reflection:) return whether this given object's derived type is the given type //
	public static bool derivedTypeIs_ViaReflection(this object object_, Type type)
		=> object_.derivedType_ViaReflection().Equals(type);
	public static bool derivedTypeIsNot_ViaReflection(this object object_, Type type)
		=> !object_.derivedTypeIs_ViaReflection(type);
	
	// method: (via reflection:) return whether this given object's casted type is the specified type //
	public static bool castedTypeIs_ViaReflection<TPotentialType>(this object object_)
		=> object_.castedType().Equals(typeof(TPotentialType));
	public static bool castedTypeIsNot_ViaReflection<TPotentialType>(this object object_)
		=> !object_.castedTypeIs_ViaReflection<TPotentialType>();
	// method: (via reflection:) return whether this given object's casted type is the given type //
	public static bool castedTypeIs_ViaReflection(this object object_, Type type)
		=> object_.castedType().Equals(type);
	public static bool castedTypeIsNot_ViaReflection(this object object_, Type type)
		=> !object_.castedTypeIs_ViaReflection(type);
	
	// method: (via reflection:) return whether this given object is derived from the given type //
	public static bool isDerivedFrom_ViaReflection(this object object_, Type type)
		=> type.IsInstanceOfType(object_);
	public static bool isNotDerivedFrom_ViaReflection(this object object_, Type type)
		=> !object_.isDerivedFrom_ViaReflection(type);
	// method: (via reflection:) return whether this given object is derived from the specified type //
	public static bool isDerivedFrom_ViaReflection<TPotentialType>(this object object_)
		=> object_.isDerivedFrom_ViaReflection(typeof(TPotentialType));
	public static bool isNotDerivedFrom_ViaReflection<TPotentialType>(this object object_)
		=> !object_.isDerivedFrom_ViaReflection<TPotentialType>();

	// method: (via reflection:) return the class name of this given type //
	public static string className_ViaReflection(this Type type)
		=> ""+type;		// this is the same as what 'type.FullName' would return
	// method: (via reflection:) return the (derived) class name of this given object //
	public static string className_ViaReflection<ObjectT>(this ObjectT object_)
		=> object_.derivedType_ViaReflection().className_ViaReflection();

	// method: (via reflection:) return the simple class name of this given type //
	public static string simpleClassName_ViaReflection(this Type type)
		=> type.Name;
	// method: (via reflesction:) return the (derived) simple class name of this given object //
	public static string simpleClassName_ViaReflection<ObjectT>(this ObjectT object_)
		=> object_.derivedType_ViaReflection().simpleClassName_ViaReflection();

	// method: (via reflection:) return an accessor for this given type's simple class name followed by each of its recursively inherited types' simple class names //
	public static IEnumerable<string> accessSelfThenInheritedSimpleClassNames_ViaReflection(this Type type)
		=> type.accessSelfThenInheritedTypes_ViaReflection().access(type_ => type_.simpleClassName_ViaReflection());
	// method: (via reflection:) return an accessor for this given object's simple class name followed by each of its recursively inherited types'  simple class names //
	public static IEnumerable<string> accessSelfThenInheritedSimpleClassNames_ViaReflection<ObjectT>(this ObjectT object_)
		=> object_.accessDerivedThenInheritedTypes_ViaReflection().access(type_ => type_.simpleClassName_ViaReflection());
	// method: (via reflection:) return the set of this given type's simple class name followed by each of its recursively inherited types' simple class names //
	public static HashSet<string> selfThenInheritedSimpleClassNames_ViaReflection(this Type type)
		=> type.accessSelfThenInheritedSimpleClassNames_ViaReflection().uniques();
	// method: (via reflection:) return the set of this given object's simple class name followed by each of its recursively inherited types'  simple class names //
	public static HashSet<string> selfThenInheritedSimpleClassNames_ViaReflection<ObjectT>(this ObjectT object_)
		=> object_.accessSelfThenInheritedSimpleClassNames_ViaReflection().uniques();

	// method: (via reflection:) return whether this given type has any self or inherited simple class name for which the given function returns true //
	public static bool hasAnySelfOrInheritedSimpleClassName_ViaReflection(this Type type, Func<string, bool> function)
		=> type.accessSelfThenInheritedSimpleClassNames_ViaReflection().hasAny(function);
	// method: (via reflection:) return whether this given object has any self or inherited simple class name for which the given function returns true //
	public static bool hasAnySelfOrInheritedSimpleClassName_ViaReflection<ObjectT>(this ObjectT object_, Func<string, bool> function)
		=> object_.accessSelfThenInheritedSimpleClassNames_ViaReflection().hasAny(function);

	// method: (via reflection:) return the (pascal) spaced simple class name of this given type //
	public static string spacedSimpleClassName_ViaReflection(this Type type)
		=> type.simpleClassName_ViaReflection().pascalSpaced();
}