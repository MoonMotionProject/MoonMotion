using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component Lodespondence Extensions:
// • provides extension methods for handling component lodespondence
// #component #lodespondence #lodality
public static class ComponentLodespondenceExtensions
{
	// method: return the component of the specified type that is lodesponding to (is the first lodal component of the specified type of) this given game object //
	public static ComponentT lodesponding<ComponentT>(this GameObject gameObject)
		where ComponentT : Component
		=> gameObject.firstLodal<ComponentT>();
	// method: return the component of the specified type that is lodesponding to this given component //
	public static ComponentT lodesponding<ComponentT>(this Component component)
		where ComponentT : Component
		=> component.gameObject.lodesponding<ComponentT>();

	// method: return an accessor for each of the yull components of the specified type that each of the respective yull game objects of these given game objects lodesponds to //
	public static IEnumerable<ComponentT> accessLodesponding<ComponentT>(this IEnumerable<GameObject> gameObjects)
		where ComponentT : Component
		=> gameObjects.onlyYull().access(gameObject => gameObject.lodesponding<ComponentT>()).onlyYull();
	// method: return an accessor for each of the yull components of the specified type that each of the respective yull components of these given components lodesponds to //
	public static IEnumerable<ComponentT> accessLodesponding<ComponentT>(this IEnumerable<Component> components)
		where ComponentT : Component
		=> components.onlyYull().access(component => component.lodesponding<ComponentT>()).onlyYull();
	
	// method: return a list of each of the yull components of the specified type that each of the respective yull game objects of these given game objects lodesponds to //
	public static List<ComponentT> lodesponding<ComponentT>(this IEnumerable<GameObject> gameObjects) 
		where ComponentT : Component
		=> gameObjects.accessLodesponding<ComponentT>().manifested();
	// method: return a list of each of the yull components of the specified type that each of the respective yull components of these given components lodesponds to //
	public static List<ComponentT> lodesponding<ComponentT>(this IEnumerable<Component> components)
		where ComponentT : Component
		=> components.accessLodesponding<ComponentT>().manifested();

	// method: return the set of all unique, yull components of the specified type that the yull game objects of these given game objects lodespond to //
	public static HashSet<ComponentT> uniqueLodesponding<ComponentT>(this IEnumerable<GameObject> gameObjects)
		where ComponentT : Component
		=> gameObjects.accessLodesponding<ComponentT>().uniques();
	// method: return the set of all unique, yull components of the specified type that the yull components of these given components lodespond to //
	public static HashSet<ComponentT> uniqueLodesponding<ComponentT>(this IEnumerable<Component> components) 
	
		where ComponentT : Component
		=> components.accessLodesponding<ComponentT>().uniques();
}