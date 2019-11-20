using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;

// Callstack:
// • provides functionality for handling the callstack
// #callstack #reflection
/* (all methods use reflection) */
public static class Callstack
{
	#region callstack in general


	public static StackTrace stackTrace => new StackTrace();

	public static StackFrame[] stackFrames => stackTrace.GetFrames();

	public static StackFrame stackFrame(int index)
		=> stackTrace.GetFrame(index);

	public static IEnumerable<MethodBase> accessMethods => stackFrames.access(stackFrame => stackFrame.GetMethod());

	public static IEnumerable<string> accessMethodNames => accessMethods.access(method => method.Name);
	public static List<string> methodNames => accessMethodNames.manifested();

	public static IEnumerable<IEnumerable<Attribute>> accessAttributesOfEachMethod => accessMethods.access(method => method.GetCustomAttributes());

	public static IEnumerable<Attribute> accessAttributesOfAllMethods => accessMethods.accessNested(method => method.GetCustomAttributes());

	public static IEnumerable<string> accessNamesOfAtttributesOfAllMethods => accessAttributesOfAllMethods.access(attribute => attribute.className_ViaReflection());

	public static bool includesMethodNamed(string name)
		=> accessMethodNames.contains(name);

	public static bool includesMethodNamedAnyOf(params string[] names)
		=> names.hasAny(name => includesMethodNamed(name));

	public static bool includesMethodWithAttributeNamed(string name)
		=> accessNamesOfAtttributesOfAllMethods.contains(name);
	#endregion callstack in general




	#region determining specific information about the callstack


	// whether the current callstack includes 'OnValidate' //
	public static bool includesOnValidate => includesMethodNamed("OnValidate");
	
	// whether the current callstack includes a method with an attribute named 'ContextMenu' //
	public static bool includesContextMenu => includesMethodWithAttributeNamed("ContextMenu");

	#if ODIN_INSPECTOR
	public static bool includesDrawOdinInspector => includesMethodNamed("DrawOdinInspector");
	public static bool doesNotIncludeDrawOdinInspector => !includesDrawOdinInspector;
	#endif

	// whether the current callstack includes 'OnDrawGizmos' //
	public static bool includesEditorVisualization => includesMethodNamedAnyOf("OnDrawGizmos", "OnDrawGizmosSelected");

	#if ODIN_INSPECTOR
	public static bool includesDrawOdinInspectorOrEditorVisualization
		=> includesDrawOdinInspector || includesEditorVisualization;
	#endif
	#endregion determining specific information about the callstack
}
