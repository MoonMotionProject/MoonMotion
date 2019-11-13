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

	public static IEnumerable<MethodBase> accessMethods => stackFrames.access(stackFrame => stackFrame.GetMethod());

	public static IEnumerable<string> accessMethodNames => accessMethods.access(method => method.Name);

	public static IEnumerable<IEnumerable<Attribute>> accessAttributesOfEachMethod => accessMethods.access(method => method.GetCustomAttributes());

	public static IEnumerable<Attribute> accessAttributesOfAllMethods => accessMethods.accessNested(method => method.GetCustomAttributes());

	public static IEnumerable<string> accessNamesOfAtttributesOfAllMethods => accessAttributesOfAllMethods.access(attribute => attribute.className());

	public static bool includesMethodNamed(string name)
		=> accessMethodNames.contains(name);

	public static bool includesMethodWithAttributeNamed(string name)
		=> accessNamesOfAtttributesOfAllMethods.contains(name);
	#endregion callstack in general




	#region determining specific information about the callstack


	// whether the current callstack includes 'OnValidate' //
	public static bool includesOnValidate => accessMethodNames.contains("OnValidate");
	
	// whether the current callstack includes a method with an attribute named 'ContextMenu' //
	public static bool includesContextMenu => includesMethodWithAttributeNamed("ContextMenu");

	// whether the current callstack includes 'OnDrawGizmos' //
	public static bool includesEditorVisualization => accessMethodNames.contains("OnDrawGizmos");
	#endregion determining specific information about the callstack
}
