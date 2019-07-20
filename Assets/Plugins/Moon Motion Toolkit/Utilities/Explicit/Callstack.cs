using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;

// Callstack: provides functionality for handling the callstack //
public static class Callstack
{
	#region callstack in general


	public static StackTrace stackTrace => new StackTrace();

	public static StackFrame[] stackFrames => stackTrace.GetFrames();

	public static StackFrame stackFrame(int index)
		=> stackTrace.GetFrame(index);

	public static IEnumerable<MethodBase> methods => stackFrames.select(stackFrame => stackFrame.GetMethod());

	public static IEnumerable<string> methodNames => methods.select(method => method.Name);

	public static IEnumerable<IEnumerable<Attribute>> attributesOfEachMethod => methods.select(method => method.GetCustomAttributes());

	public static IEnumerable<Attribute> attributesOfAllMethods => methods.selectNested(method => method.GetCustomAttributes());

	public static IEnumerable<string> namesOfAtttributesOfAllMethods => attributesOfAllMethods.select(attribute => attribute.className_ViaReflection());

	public static bool includesMethodNamed(string name)
		=> methodNames.contains(name);

	public static bool includesMethodWithAttributeNamed(string name)
		=> namesOfAtttributesOfAllMethods.contains(name);
	#endregion callstack in general




	#region determining specific information about the callstack


	// whether the current callstack includes 'OnValidate' //
	public static bool includesOnValidate => methodNames.contains("OnValidate");
	
	// whether the current callstack includes a method with an attribute named 'ContextMenu' //
	public static bool includesContextMenu => includesMethodWithAttributeNamed("ContextMenu");
	#endregion determining specific information about the callstack
}
