using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

// Game Object Extensions:
// • provides extension methods for handling game objects
// #gameobject #execution
public static class GameObjectExtensions
{
	#region accessing

	// method: return an accessor for the game objects for these given components //
	public static IEnumerable<GameObject> accessObjects(this IList<Component> components)
		=> components.access(component => component.gameObject);
	#endregion accessing


	#region determining prefabness

	public static bool isPartOfPrefabAsset(this GameObject gameObject)
		=> gameObject.scene.rootCount == 0;
	public static bool isNotPartOfPrefabAsset(this GameObject gameObject)
		=> !gameObject.isPartOfPrefabAsset();

	#if UNITY_EDITOR
	public static bool isInstanceOfPrefabAsset(this GameObject gameObject)
		=> PrefabUtility.GetPrefabParent(gameObject).isYull();
	public static bool isNotInstanceOfPrefabAsset(this GameObject gameObject)
		=> !gameObject.isInstanceOfPrefabAsset();
	#endif
	#endregion determining prefabness


	#region determining whether this game object could be awake right now

	public static bool couldBeAwakeRightNow(this GameObject gameObject)
		=> UnityIs.playing && gameObject.isNotPartOfPrefabAsset();
	public static bool couldNotBeAwakeRightNow(this GameObject gameObject)
		=> !gameObject.couldBeAwakeRightNow();
	#endregion determining whether this game object could be awake right now


	#region existence

	// note: refer here for how to handle exceptions related to game object existence: https://stackoverflow.com/a/53195170/3900755 //

	// method: return whether this given game object is destroyed //
	public static bool destroyed(this GameObject gameObject)
		=> gameObject == null;		// based on https://answers.unity.com/questions/13840/how-to-detect-if-a-gameobject-has-been-destroyed.html; checking whether a game object is equal to null (but not when checking that game object cast to 'object') will return true even if its reference is not null but it has been destroyed (note that a game object's reference cannot be set to null unless by Unity destroying the game object)

	// method: return whether this given game object exists //
	public static bool exists(this GameObject gameObject)
		=> gameObject.isYull().and(!gameObject.destroyed());

	// method: in this given dictionary, remove all (game object) keys which are destroyed, then return this given dictionary //
	public static Dictionary<GameObject, ObjectT> clean<ObjectT>(this Dictionary<GameObject, ObjectT> dictionary)
		=> dictionary.removeWhere(gameObjectKey => gameObjectKey.destroyed());
	#endregion existence


	#region printing
	
	public static GameObject log(this GameObject gameObject, string string_, string loggingSeparator = Default.loggingSeparator)
		=> gameObject.after(()=> string_.logAs(""+gameObject, gameObject, loggingSeparator));
	
	public static List<GameObject> asEachObjectLog(this IEnumerable<GameObject> gameObjects, string string_, string loggingSeparator = Default.loggingSeparator)
		=>	gameObjects.forEachManifested(gameObject =>
				gameObject.log(string_, loggingSeparator));
	
	public static HashSet<GameObject> uniquesAfterAsEachObjectLogging(this IEnumerable<GameObject> gameObjects, string string_, string loggingSeparator = Default.loggingSeparator)
		=>	gameObjects.uniquesAfterForEach(gameObject =>
				gameObject.log(string_, loggingSeparator));
	#endregion printing


	#region activity

	// method: return whether this given game object is active locally //
	public static bool activeLocally(this GameObject gameObject)
		=> gameObject.activeSelf;

	// method: return whether this given game object is active globally //
	public static bool activeGlobally(this GameObject gameObject)
		=> gameObject.activeInHierarchy;

	// method: set the activity of this given game object to the given boolean, then return this given game object //
	public static GameObject setActivityTo(this GameObject gameObject, bool activity)
		=> gameObject.after(()=>
			gameObject.SetActive(activity));

	// method: activate this given game object, then return it //
	public static GameObject activate(this GameObject gameObject)
		=> gameObject.setActivityTo(true);

	// method: deactivate this given game object, then return it //
	public static GameObject deactivate(this GameObject gameObject)
		=> gameObject.setActivityTo(false);

	// method: toggle the activity of this given game object using the given toggling, then return this given game object //
	public static GameObject toggleActivityBy(this GameObject gameObject, Toggling toggling)
		=> gameObject.setActivityTo(gameObject.activeLocally().toggledBy(toggling));

	// method: toggle the activity of these given game objects using the given toggling, then return them //
	public static GameObject[] toggleActivityBy(this GameObject[] gameObjects, Toggling toggling)
		=> gameObjects.forEach(gameObject => gameObject.toggleActivityBy(toggling));

	// method: toggle the activity of this given game object, then return this given game object //
	public static GameObject toggleActivity(this GameObject gameObject)
		=> gameObject.toggleActivityBy(Toggling.invertToggle);
	// method: toggle the activity of these given game objects, then return the list of these given game objects //
	public static List<GameObject> toggleActivity(this IEnumerable<GameObject> gameObjects)
		=>	gameObjects.forEachManifested(gameObject =>
				gameObject.toggleActivity());

	// method: set the activity of these given game objects to the given boolean, then return them //
	public static GameObject[] setActivityTo(this GameObject[] gameObjects, bool activity)
		=> gameObjects.forEach(gameObject => gameObject.setActivityTo(activity));

	// method: activate these given game objects, then return them //
	public static GameObject[] activate(this GameObject[] gameObjects)
		=> gameObjects.setActivityTo(true);

	// method: deactivate these given game objects, then return them //
	public static GameObject[] deactivate(this GameObject[] gameObjects)
		=> gameObjects.setActivityTo(false);
	#endregion activity


	#region labels setting

	// method: (according to the given boolean:) set the labels (tag and layer) of this given provided game object to the labels (respectively) of the other given provided game object, then return this given provided game object //
	public static ObjectT setLabelsTo<ObjectT>(this ObjectT gameObject_GameObjectProvider, object otherGameObject_GameObjectProvider, bool boolean = true)
		=>	gameObject_GameObjectProvider
				.setTagTo(otherGameObject_GameObjectProvider, boolean)
				.setLayerTo(otherGameObject_GameObjectProvider, boolean);
	#endregion labels setting


	#region acting

	// method: if this given object exists, return this given object; otherwise, return null //
	public static GameObject ifExists(this GameObject gameObject)
		=> gameObject.exists() ? gameObject : null;

	// method: (according to the given boolean:) if this given object exists, execute the given action, then return this given object //
	public static GameObject ifExists(this GameObject gameObject, Action action, bool boolean = true)
		=> gameObject.after(
			action,
			gameObject.exists().and(boolean));

	// method: if this given object exists and the given boolean is true, execute the given action on this given object and return this given object //
	public static GameObject ifExists(this GameObject gameObject, Action<GameObject> action, bool boolean = true)
		=> gameObject.after(
			action,
			gameObject.exists().and(boolean));

	// method: if this given object exists, execute the given function upon it and return the function's result, otherwise returning the default value of the function's result type //
	public static TResult ifExists<TResult>(this GameObject object_, Func<GameObject, TResult> function)
		=> object_.exists() ?
			function(object_) :
			default(TResult);

	// method: if this given object is destroyed, return this given object; otherwise, return null //
	public static GameObject ifDestroyed(this GameObject gameObject)
		=> gameObject.destroyed() ? gameObject : null;

	// method: (according to the given boolean:) if this given object is destroyed, execute the given action, then return this given object //
	public static GameObject ifDestroyed(this GameObject gameObject, Action action, bool boolean = true)
		=> gameObject.after(
			action,
			gameObject.destroyed().and(boolean));

	// method: if this given object is destroyed and the given boolean is true, execute the given action on this given object and return this given object //
	public static GameObject ifDestroyed(this GameObject gameObject, Action<GameObject> action, bool boolean = true)
		=> gameObject.after(
			action,
			gameObject.destroyed().and(boolean));

	// method: if this given object is destroyed, execute the given function upon it and return the function's result, otherwise returning the default value of the function's result type //
	public static TResult ifDestroyed<TResult>(this GameObject gameObject, Func<GameObject, TResult> function)
		=> gameObject.destroyed() ?
			function(gameObject) :
			default(TResult);
	#endregion acting


	#region calling local methods

	// method: if this given game object exists and the given boolean is true: execute all of this given game object's mono behaviours' defined methods (ignoring inherited methods that haven't been overriden) with the given name, then return this given game object //
	public static GameObject executeAllLocal(this GameObject gameObject, string methodName, SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver, bool boolean = true)
		=> gameObject.after(()=>
			gameObject.SendMessage(methodName, sendMessageOptions),
			boolean);

	// method: (if in the editor:) have all mono behaviours on this game object validate (if they have OnValidate defined), then return this given game object //
	public static GameObject validate_IfInEditor(this GameObject gameObject)
		=>	gameObject.executeAllLocal
			(
				"OnValidate", SendMessageOptions.DontRequireReceiver,
				UnityIs.inEditor
			);
	#endregion calling local methods


	#region conversion

	// method: return the game object idee for this given game object //
	public static int idee(this GameObject gameObject)
		=> gameObject.GetInstanceID();

	#if UNITY_EDITOR
	// method: if there is a game object corresponding to this given integer as a game object idee, return that game object; otherwise, return null //
	public static GameObject gameObject(this int gameObjectIdee)
		=> EditorUtility.InstanceIDToObject(gameObjectIdee) as GameObject;
	#endif
	#endregion conversion
}