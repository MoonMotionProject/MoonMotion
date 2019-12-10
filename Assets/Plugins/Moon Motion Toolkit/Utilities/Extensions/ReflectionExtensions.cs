using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

// Reflection Extensions:
// • provides extension methods for handling reflection
// #reflection
public static class ReflectionExtensions
{
	public static Type asClassNameToType(this string className)
		=> Type.GetType(className);
	
	public static Assembly assembly(this Type type)
		=> type.Assembly;
	
	public static Type classNamed(this Assembly assembly, string className)
		=> assembly.GetType(className);
	
	public static FieldInfo fieldNamed(this Type type, string fieldName)
		=> type.GetField(fieldName);
	public static FieldInfo fieldNamed(this Type type, string fieldName, BindingFlags bindingFlags)
		=> type.GetField(fieldName, bindingFlags);
	public static FieldInfo publicInstanceFieldNamed(this Type type, string fieldName)
		=>	type.GetField
			(
				fieldName,
				BindingFlags.Public | BindingFlags.Instance
			);
	public static FieldInfo nonpublicInstanceFieldNamed(this Type type, string fieldName)
		=>	type.GetField
			(
				fieldName,
				BindingFlags.NonPublic | BindingFlags.Instance
			);
	
	public static object valueOf(this object object_, FieldInfo field)
		=> field.GetValue(object_);
	
	public static PropertyInfo propertyNamed(this Type type, string propertyName)
		=> type.GetProperty(propertyName);
	public static PropertyInfo propertyNamed(this Type type, string propertyName, BindingFlags bindingFlags)
		=> type.GetProperty(propertyName, bindingFlags);
	public static PropertyInfo publicInstancePropertyNamed(this Type type, string propertyName)
		=>	type.GetProperty
			(
				propertyName,
				BindingFlags.Public | BindingFlags.Instance
			);
	public static PropertyInfo nonpublicInstancePropertyNamed(this Type type, string propertyName)
		=>	type.GetProperty
			(
				propertyName,
				BindingFlags.NonPublic | BindingFlags.Instance
			);
	
	public static object valueOf(this object object_, PropertyInfo property)
		=> property.GetValue(object_);
	
	public static MethodInfo methodNamed(this Type type, string methodName)
		=> type.GetMethod(methodName);
	public static MethodInfo methodNamed(this Type type, string methodName, BindingFlags bindingFlags)
		=> type.GetMethod(methodName, bindingFlags);
	public static MethodInfo methodNamed(this Type type, string methodName, params Type[] parameterTypes)
		=> type.GetMethod(methodName, parameterTypes);
	public static MethodInfo publicInstanceMethodNamed(this Type type, string methodName)
		=>	type.GetMethod
			(
				methodName,
				BindingFlags.Public | BindingFlags.Instance
			);
	public static MethodInfo nonpublicInstanceMethodNamed(this Type type, string methodName)
		=>	type.GetMethod
			(
				methodName,
				BindingFlags.NonPublic | BindingFlags.Instance
			);
	public static MethodInfo possiblyInheritedMethodNamed(this Type type, string methodName)
		=>	type.GetMethod
			(
				methodName,
				BindingFlags.FlattenHierarchy
			);
	public static MethodInfo possiblyInheritedPublicInstanceMethodNamed(this Type type, string methodName)
		=>	type.GetMethod
			(
				methodName,
				BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance
			);
	public static MethodInfo possiblyInheritedNonpublicInstanceMethodNamed(this Type type, string methodName)
		=>	type.GetMethod
			(
				methodName,
				BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Instance
			);

	public static MethodInfo[] methods(this Type type)
		=> type.GetMethods();
	public static MethodInfo[] methods(this Type type, BindingFlags bindingFlags)
		=> type.GetMethods(bindingFlags);
	public static MethodInfo[] possiblyInheritedPublicInstanceMethods(this Type type)
		=>	type.methods(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
	
	public static object invokeGetResult<ObjectT>(this ObjectT object_, MethodInfo method) where ObjectT : class
		=> method.Invoke(object_, null);
	public static object invokeGetResult<ObjectT>(this ObjectT object_, MethodInfo method, params object[] parameters) where ObjectT : class
		=> method.Invoke(object_, parameters);
	
	public static ObjectT invoke<ObjectT>(this ObjectT object_, MethodInfo method) where ObjectT : class
		=>	object_.after(()=>
				object_.invokeGetResult(method));
	public static ObjectT invoke<ObjectT>(this ObjectT object_, MethodInfo method, params object[] parameters) where ObjectT : class
		=>	object_.after(()=>
				object_.invokeGetResult(method, parameters));
}