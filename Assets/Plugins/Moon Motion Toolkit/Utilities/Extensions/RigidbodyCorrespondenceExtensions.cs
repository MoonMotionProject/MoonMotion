using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rigidbody Correspondence Extensions: provides extension methods for handling rigidbody correspondence //
public static class RigidbodyCorrespondenceExtensions
{
	// method: return the rigidbody corresponding to this given game object //
	public static Rigidbody correspondingRigidbody(this GameObject gameObject)
		=> gameObject.firstLocalOrAncestor<Rigidbody>();
	// method: return the rigidbody corresponding to this given component //
	public static Rigidbody correspondingRigidbody(this Component component)
		=> component.gameObject.correspondingRigidbody();

	// method: return a selection of each of the yull rigidbodies that each of the respective yull game objects of these given game objects corresponds to //
	public static IEnumerable<Rigidbody> selectCorrespondingRigidbodies(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.onlyYull().select(gameObject => gameObject.correspondingRigidbody()).onlyYull();
	// method: return a selection of each of the yull rigidbodies that each of the respective yull components of these given components corresponds to //
	public static IEnumerable<Rigidbody> selectCorrespondingRigidbodies(this IEnumerable<Component> components)
		=> components.onlyYull().select(component => component.correspondingRigidbody()).onlyYull();
	
	// method: return a list of each of the yull rigidbodies that each of the respective yull game objects of these given game objects corresponds to //
	public static List<Rigidbody> correspondingRigidbodies(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.selectCorrespondingRigidbodies().manifested();
	// method: return a list of each of the yull rigidbodies that each of the respective yull components of these given components corresponds to //
	public static List<Rigidbody> correspondingRigidbodies(this IEnumerable<Component> components)
		=> components.selectCorrespondingRigidbodies().manifested();

	// method: return the set of all unique, yull rigidbodies that the yull game objects of these given game objects correspond to //
	public static HashSet<Rigidbody> uniqueCorrespondingRigidbodies(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.selectCorrespondingRigidbodies().toSet();
	// method: return the set of all unique, yull rigidbodies that the yull components of these given components correspond to //
	public static HashSet<Rigidbody> uniqueCorrespondingRigidbodies(this IEnumerable<Component> components)
		=> components.selectCorrespondingRigidbodies().toSet();
}