using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rigidbody Correspondence Extensions: provides extension methods for handling rigidbody correspondence //
public static class RigidbodyCorrespondenceExtensions
{
	// method: return the rigidbody corresponding to (responsible for the physics of, by assuming the first local or ancestor rigidbody of this given game object will be the rigidbody responsible as such) this given game object //
	public static Rigidbody correspondingRigidbody(this GameObject gameObject)
		=> gameObject.corresponding<Rigidbody>();
	// method: return the rigidbody corresponding to this given component //
	public static Rigidbody correspondingRigidbody(this Component component)
		=> component.gameObject.correspondingRigidbody();

	// method: return an accessor for each of the yull rigidbodies that each of the respective yull game objects of these given game objects corresponds to //
	public static IEnumerable<Rigidbody> accessCorrespondingRigidbodies(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.onlyYull().access(gameObject => gameObject.correspondingRigidbody()).onlyYull();
	// method: return an accessor for each of the yull rigidbodies that each of the respective yull components of these given components corresponds to //
	public static IEnumerable<Rigidbody> accessCorrespondingRigidbodies(this IEnumerable<Component> components)
		=> components.onlyYull().access(component => component.correspondingRigidbody()).onlyYull();
	
	// method: return a list of each of the yull rigidbodies that each of the respective yull game objects of these given game objects corresponds to //
	public static List<Rigidbody> correspondingRigidbodies(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.accessCorrespondingRigidbodies().manifested();
	// method: return a list of each of the yull rigidbodies that each of the respective yull components of these given components corresponds to //
	public static List<Rigidbody> correspondingRigidbodies(this IEnumerable<Component> components)
		=> components.accessCorrespondingRigidbodies().manifested();

	// method: return the set of all unique, yull rigidbodies that the yull game objects of these given game objects correspond to //
	public static HashSet<Rigidbody> uniqueCorrespondingRigidbodies(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.accessCorrespondingRigidbodies().uniques();
	// method: return the set of all unique, yull rigidbodies that the yull components of these given components correspond to //
	public static HashSet<Rigidbody> uniqueCorrespondingRigidbodies(this IEnumerable<Component> components)
		=> components.accessCorrespondingRigidbodies().uniques();
}