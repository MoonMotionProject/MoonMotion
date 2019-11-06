using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component Correspondence Extensions:
// • provides extension methods for handling component correspondence
// #component
public static class ComponentCorrespondenceExtensions
{
	// method: return the component of the specified type that is corresponding to (is the first local or ancestor component of the specified type of) this given game object //
	public static ComponentT corresponding<ComponentT>(this GameObject gameObject)
		where ComponentT : Component
		=> gameObject.firstLocalOrAncestor<ComponentT>();
	// method: return the component of the specified type that is corresponding to this given component //
	public static ComponentT corresponding<ComponentT>(this Component component)
		where ComponentT : Component
		=> component.gameObject.corresponding<ComponentT>();

	// method: return a selection of each of the yull components of the specified type that each of the respective yull game objects of these given game objects corresponds to //
	public static IEnumerable<ComponentT> selectCorresponding<ComponentT>(this IEnumerable<GameObject> gameObjects)
		where ComponentT : Component
		=> gameObjects.onlyYull().select(gameObject => gameObject.corresponding<ComponentT>()).onlyYull();
	// method: return a selection of each of the yull components of the specified type that each of the respective yull components of these given components corresponds to //
	public static IEnumerable<ComponentT> selectCorresponding<ComponentT>(this IEnumerable<Component> components)
		where ComponentT : Component
		=> components.onlyYull().select(component => component.corresponding<ComponentT>()).onlyYull();
	
	// method: return a list of each of the yull components of the specified type that each of the respective yull game objects of these given game objects corresponds to //
	public static List<ComponentT> corresponding<ComponentT>(this IEnumerable<GameObject> gameObjects) 
		where ComponentT : Component
		=> gameObjects.selectCorresponding<ComponentT>().manifested();
	// method: return a list of each of the yull components of the specified type that each of the respective yull components of these given components corresponds to //
	public static List<ComponentT> corresponding<ComponentT>(this IEnumerable<Component> components)
		where ComponentT : Component
		=> components.selectCorresponding<ComponentT>().manifested();

	// method: return the set of all unique, yull components of the specified type that the yull game objects of these given game objects correspond to //
	public static HashSet<ComponentT> uniqueCorresponding<ComponentT>(this IEnumerable<GameObject> gameObjects)
		where ComponentT : Component
		=> gameObjects.selectCorresponding<ComponentT>().uniques();
	// method: return the set of all unique, yull components of the specified type that the yull components of these given components correspond to //
	public static HashSet<ComponentT> uniqueCorresponding<ComponentT>(this IEnumerable<Component> components) 
	
		where ComponentT : Component
		=> components.selectCorresponding<ComponentT>().uniques();
}