using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

// #reflection
public static class EditorAssembly
{
	private static readonly Assembly assembly
		= typeof(Editor).assembly();

	public static Type classNamed(string className)
		=> assembly.classNamed(className);
}