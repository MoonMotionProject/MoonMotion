#if UNITY_EDITOR
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class ReloadLayout
{
	[MenuItem("Status/Reload Layout &%#q")]
	public static void reloadLayout()
		=> Layout.reload();
}
#endif