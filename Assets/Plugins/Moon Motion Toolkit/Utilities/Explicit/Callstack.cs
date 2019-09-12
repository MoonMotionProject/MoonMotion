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

	public static IEnumerable<MethodBase> selectMethods => stackFrames.select(stackFrame => stackFrame.GetMethod());

	public static IEnumerable<string> selectMethodNames => selectMethods.select(method => method.Name);

	public static IEnumerable<IEnumerable<Attribute>> selectAttributesOfEachMethod => selectMethods.select(method => method.GetCustomAttributes());

	public static IEnumerable<Attribute> selectAttributesOfAllMethods => selectMethods.selectNested(method => method.GetCustomAttributes());

	public static IEnumerable<string> selectNamesOfAtttributesOfAllMethods => selectAttributesOfAllMethods.select(attribute => attribute.className());

	public static bool includesMethodNamed(string name)
		=> selectMethodNames.contains(name);

	public static bool includesMethodWithAttributeNamed(string name)
		=> selectNamesOfAtttributesOfAllMethods.contains(name);
	#endregion callstack in general




	#region determining specific information about the callstack


	// whether the current callstack includes 'OnValidate' //
	public static bool includesOnValidate => selectMethodNames.contains("OnValidate");
	
	// whether the current callstack includes a method with an attribute named 'ContextMenu' //
	public static bool includesContextMenu => includesMethodWithAttributeNamed("ContextMenu");
	#endregion determining specific information about the callstack
}
