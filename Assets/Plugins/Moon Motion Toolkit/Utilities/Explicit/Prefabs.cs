#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Prefabs:
// • provides properties and methods for handling prefabs
// #assets
public static class Prefabs
{
	#region filtering all prefabs
	
	public static HashSet<GameObject> filteredBy(string filterString)
		=>	Project.pathsForPrefabAssetsFilteredBy(filterString)
				.pickUnique(projectPath =>
					Asset.atProjectPathOfType<GameObject>(projectPath));
	
	public static HashSet<GameObject> all => filteredBy("");

	public static HashSet<GameObject> withAnyLodal<ComponentT>() where ComponentT : Component
		=> all.uniquesWhere(prefab => prefab.hasAnyLodal<ComponentT>());

	public static HashSet<GameObject> withAnyLodalMonoBehaviour => withAnyLodal<MonoBehaviour>();

	public static HashSet<GameObject> withAnyLodalAutoBehaviourExternalLayer => withAnyLodal<AutoBehaviourExternalLayer>();

	public static HashSet<GameObject> withAnyLodalI<ComponentI>() where ComponentI : class
		=> all.uniquesWhere(prefab => prefab.hasAnyLodalI<ComponentI>());
	#endregion filtering all prefabs
}
#endif