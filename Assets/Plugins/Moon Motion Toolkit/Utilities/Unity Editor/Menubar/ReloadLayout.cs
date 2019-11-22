#if UNITY_EDITOR
using System.Reflection;
using UnityEditor;
using UnityEngine;

// #layouts
public static class ReloadLayout
{
	[MenuItem("Status/Reload Layout &%#q")]
	public static void reloadLayout()
		=> Layout.reload();
}
#endif