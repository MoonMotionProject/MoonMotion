using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

// Game Object Extensions: provides extension methods for handling game objects //
// #auto #gameobject
public static class GameObjectExtensions
{
	#region accessing

	// method: return a selection of the game objects for these given components //
	public static IEnumerable<GameObject> selectObjects(this IList<Component> components)
		=> components.select(component => component.gameObject);
	#endregion accessing


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


	#region creating fresh game objects

	// method: create a fresh game object with this given name (and no parent), then return the created game object //
	public static GameObject createAsObject(this string name)
		=> new GameObject(name);

	// method: create a fresh game object with this given name, as a child object of the given transform, then return the created game object //
	public static GameObject createAsChildObjectOf(this string name, Transform parent)
		=> new GameObject(name).setParentTo(parent);

	// method: create a fresh game object with this given name, as a child object of the given game object, then return the created game object //
	public static GameObject createAsChildObjectOf(this string name, GameObject parentObject)
		=> new GameObject(name).setParentTo(parentObject);

	// method: create a fresh game object with this given name, as a child object of the transform of the given component, then return the created game object //
	public static GameObject createAsChildObjectOf(this string name, Component parentComponent)
		=> new GameObject(name).setParentTo(parentComponent);

	// method: create a fresh game object as a child of this given transform, with the given name (defaulted to "New Game Object"), then return the created game object //
	public static GameObject createChildObject(this Transform parent, string name = "New Game Object")
		=> name.createAsChildObjectOf(parent);

	// method: create a fresh game object as a child of this given game object, with the given name (defaulted to "New Game Object"), then return the created game object //
	public static GameObject createChildObject(this GameObject parentObject, string name = "New Game Object")
		=> name.createAsChildObjectOf(parentObject);

	// method: create a fresh game object as a child of the transform of this given component, with the given name (defaulted to "New Game Object"), then return the created game object //
	public static GameObject createChildObject(this Component parentComponent, string name = "New Game Object")
		=> name.createAsChildObjectOf(parentComponent);
	#endregion creating fresh game objects


	#region creating templated game objects

	// method: create an instance of this given object template (object instance or prefab), with the given name (using the template's name if empty (which is the default)), then return the created game object //
	public static GameObject create(this GameObject template, string name = "")
		=>	UnityEngine.Object.Instantiate(template)
			.setNameTo(name.substituteIfEmpty(template.name));

	// method: create an instance of this given object template (object instance or prefab), as a child object of the given transform, then return the created game object //
	public static GameObject createAsChildObjectOf(this GameObject template, Transform parent)
		=> template.create().setParentTo(parent).resetLocalPosition();
	// method: create an instance of this given object template (object instance or prefab), as a child object of the given game object, then return the created game object //
	public static GameObject createAsChildObjectOf(this GameObject template, GameObject parentObject)
		=> template.createAsChildObjectOf(parentObject.transform);
	// method: create an instance of this given object template (object instance or prefab), as a child object of the transform of the given component, then return the created game object //
	public static GameObject createAsChildObjectOf(this GameObject template, Component parentComponent)
		=> template.createAsChildObjectOf(parentComponent.transform);
	// method: create an instance of this given object template (object instance or prefab), as a child object of the transform of the specified singleton behaviour class, then return the created game object //
	public static GameObject createAsChildObjectOf<SingletonBehaviourT>(this GameObject template) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> template.createAsChildObjectOf(SingletonBehaviour<SingletonBehaviourT>.transform);

	// method: create an instance of the given object template (object instance or prefab), as a child object of this given transform, with the given name (using the template's name if empty (which is the default)), then return the created game object //
	public static GameObject createChildObject(this Transform parent, GameObject template, string name = "")
		=> template.createAsChildObjectOf(parent)
			.setNameTo(name.substituteIfEmpty(template.name));
	// method: create an instance of the given object template (object instance or prefab), as a child object of this given game object, with the given name (using the template's name if empty (which is the default)), then return the created game object //
	public static GameObject createChildObject(this GameObject parentObject, GameObject template, string name = "")
		=> parentObject.transform.createChildObject(template, name);
	// method: create an instance of the given object template (object instance or prefab), as a child object of the transform of this given component, with the given name (using the template's name if empty (which is the default)), then return the created game object //
	public static GameObject createChildObject(this Component parentComponent, GameObject template, string name = "")
		=> parentComponent.transform.createChildObject(template, name);
	#endregion creating templated game objects


	#region hierarchy selection
#if UNITY_EDITOR

	// method: return whether this given game object is currently selected //
	public static bool selected(this GameObject gameObject)
		=> Selection.gameObjects.contains(gameObject);

	// method: return whether this given game object is not currently selected //
	public static bool isNotSelected(this GameObject gameObject)
		=> !gameObject.selected();
	#endif
	#endregion hierarchy selection


	#region printing

	// method: have this given game object print the given string, prefixed with this given game object's name, then retun this given game object //
	public static GameObject printNamely(this GameObject gameObject, string string_)
	{
		(gameObject.name+": "+string_).print();

		return gameObject;
	}
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

	// method: if this given game object exists and the given boolean is true: call all of this given game object's mono behaviours' defined methods (ignoring inherited methods that haven't been overriden) with the given name, then return this given game object //
	public static GameObject callAllLocal(this GameObject gameObject, string methodName, SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver, bool boolean = true)
		=> gameObject.after(()=>
			gameObject.SendMessage(methodName, sendMessageOptions),
			boolean);

	// method: (if in the editor:) have all mono behaviours on this game object validate (if they have OnValidate defined), then return this given game object //
	public static GameObject validate_IfInEditor(this GameObject gameObject)
		=>	gameObject.callAllLocal
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