#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Select:
// • provides methods for selecting (in the editor)
// #selection
public static class Select
{
	#region given Unity objects

	// method: select only the given Unity objects, then return the set of the given Unity objects //
	public static HashSet<Object> only(params Object[] objects)
	{
		Selection.objects = objects;

		return objects.uniques();
	}
	public static HashSet<Object> only(IEnumerable<Object> objects)
		=> only(objects.toArray());
	public static Object only(Object object_)
		=>	object_.after(()=>
				only(object_.startEnumerable()));
	#endregion given Unity objects


	#region particular assets
	
	public static Object onlyFirstAsset()
		=> only(Assets.first);

	#region folders
	public static Object onlyAssetsFolder()
		=> only(Assets.folder);
	public static Object onlyPluginsFolder()
		=> only(Plugins.folder);
	#endregion folders
	#endregion particular assets
}
#endif