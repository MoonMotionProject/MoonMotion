using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

// Hierarchy Extensions:
// • provides extension methods for handling the hierarchy
// #hierarchy
public static class HierarchyExtensions
{
	#region making objects universal andor temporary

	// method: make this given game object universal (not specific to any scene), then return this given game object //
	public static GameObject makeUniversal(this GameObject gameObject)
		=>	gameObject.after(()=>
				Object.DontDestroyOnLoad(gameObject));
	// method: make this given component's game object universal, then return this given component //
	public static ComponentT makeObjectUniversal<ComponentT>(this ComponentT component) where ComponentT : Component
		=>	component.after(()=>
				component.gameObject.makeUniversal());

	// method: make this given game object temporary (hidden in the hierarchy and not saved with any scene – although not necessarily making this object universal (not specific to any scene)), then return this given game object //
	public static GameObject makeTemporary(this GameObject gameObject)
		=>	gameObject.after(()=>
				gameObject.hideFlags = HideFlags.HideAndDontSave);
	// method: make this given component's game object temporary, then return this given component //
	public static ComponentT makeObjectTemporary<ComponentT>(this ComponentT component) where ComponentT : Component
		=>	component.after(()=>
				component.gameObject.makeTemporary());

	// method: make this given game object universal and temporary, then return this given game object //
	public static GameObject makeUniversalAndTemporary(this GameObject gameObject)
		=> gameObject.makeUniversal().makeTemporary();
	// method: make this given component's game object universal and temporary, then return this given component //
	public static ComponentT makeUniversalAndTemporary<ComponentT>(this ComponentT component) where ComponentT : Component
		=>	component.after(()=>
				component.gameObject.makeUniversalAndTemporary());
	#endregion making objects universal andor temporary
	

	#region setting hierarchy expansion
	#if UNITY_EDITOR

	// method: (via reflection:) return whether the game object for this given instance idee is currently expanded in the hierarchy //
	public static bool asGameObjectInstanceIdeeIsExpandedInHierarchy_ViaReflection(this int gameObjectInstanceIdee)
		=>	TreeViews.expansionOf_ViaReflection
			(
				gameObjectInstanceIdee,
				Hierarchy.windowTreeViewController_ViaReflection
			);
	public static bool asGameObjectInstanceIdeeIsNotExpandedInHierarchy_ViaReflection(this int gameObjectInstanceIdee)
		=> !gameObjectInstanceIdee.asGameObjectInstanceIdeeIsExpandedInHierarchy_ViaReflection();

	// method: (via reflection:) return whether this given game object is currently expanded in the hierarchy //
	public static bool isExpandedInHierarchy_ViaReflection(this GameObject gameObject)
		=> gameObject.instanceIdee().asGameObjectInstanceIdeeIsExpandedInHierarchy_ViaReflection();
	public static bool isNotExpandedInHierarchy_ViaReflection(this GameObject gameObject)
		=> !gameObject.isExpandedInHierarchy_ViaReflection();
	#endif
	#endregion setting hierarchy expansion
	

	#region setting hierarchy expansion
	#if UNITY_EDITOR
	
	public static GameObject setHierarchyExpansionTo(this GameObject gameObject, bool expansion)
	{
		if (gameObject.hasAnyChildren())
		{
			GameObject[] childGameObjects = gameObject.childObjects();
				
			childGameObjects.unparentEach();

			GameObject temporaryChild = gameObject.createChildObject();

			gameObject.setHierarchyExpansionForLodalsTo(expansion);
			
			childGameObjects.forEachSetParentTo(gameObject);

			temporaryChild.destroy();
		}
		return gameObject;
	}
	public static HashSet<GameObject> setHierarchyExpansionTo(this IEnumerable<GameObject> gameObjects, bool expansion)
		=> gameObjects.forEachUnique(gameObject => gameObject.setHierarchyExpansionTo(expansion));
	public static GameObject expandInHierarchy(this GameObject gameObject)
		=> gameObject.setHierarchyExpansionTo(true);
	public static HashSet<GameObject> expandInHierarchy(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.setHierarchyExpansionTo(true);
	public static GameObject collapseInHierarchy(this GameObject gameObject)
		=> gameObject.setHierarchyExpansionTo(false);
	public static HashSet<GameObject> collapseInHierarchy(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.setHierarchyExpansionTo(false);
	
	public static GameObject setHierarchyExpansionForSelfAndChildrenTo(this GameObject gameObject, bool expansion)
		=>	gameObject.after(()=>
				gameObject.setHierarchyExpansionTo(expansion)
					.childObjects().setHierarchyExpansionTo(expansion));
	public static GameObject expandSelfAndChildrenInHierarchy(this GameObject gameObject)
		=> gameObject.setHierarchyExpansionForSelfAndChildrenTo(true);
	public static GameObject collapseSelfAndChildrenInHierarchy(this GameObject gameObject)
		=> gameObject.setHierarchyExpansionForSelfAndChildrenTo(false);

	public static GameObject setHierarchyExpansionForLodalsTo(this GameObject gameObject, bool expansion)
	{
		if (gameObject.hasAnyChildren())
		{
			TabTo.hierarchy();
			
			typeof(EditorWindow).Assembly.GetType("UnityEditor.SceneHierarchyWindow")
				.GetMethod
				(
					"SetExpandedRecursive"
				).Invoke
				(
					Focused.window,
					new object[]
					{
						gameObject.instanceIdee(),
						expansion
					}
				);
		}

		return gameObject;
	}
	public static GameObject expandLodalsInHierarchy(this GameObject gameObject)
		=> gameObject.setHierarchyExpansionForLodalsTo(true);
	public static GameObject collapseLodalsInHierarchy(this GameObject gameObject)
		=> gameObject.setHierarchyExpansionForLodalsTo(false);
	public static HashSet<GameObject> setHierarchyExpansionForLodalsTo(this IEnumerable<GameObject> gameObjects, bool expansion)
		=> gameObjects.forEachUnique(gameObject => gameObject.setHierarchyExpansionForLodalsTo(expansion));
	public static HashSet<GameObject> expandLodalsInHierarchy(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.forEachUnique(gameObject => gameObject.expandLodalsInHierarchy());
	public static HashSet<GameObject> collapseLodalsInHierarchy(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.forEachUnique(gameObject => gameObject.collapseLodalsInHierarchy());
	#endif
	#endregion setting hierarchy expansion
}