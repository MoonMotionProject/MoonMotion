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
		=> dictionary.afterRemovingWhere(gameObjectKey => gameObjectKey.destroyed());
	#endregion existence


	#region identification

	// method: return whether this given game object is named 'Player' //
	public static bool isPlayer(this GameObject gameObject)
		=> gameObject.nameMatches(Hierarchy.playerName);
	#endregion identification


	#region hierarchy

	// method: make this given game object temporary, then return it //
	public static GameObject makeTemporary(this GameObject gameObject)
		=> gameObject.after(()=>
			gameObject.hideFlags = HideFlags.HideAndDontSave);
	#endregion hierarchy


	#region creating fresh game objects

	// method: create a fresh game object with this given name (and no parent), then return the created game object //
	public static GameObject createAsObject(this string name)
		=> new GameObject(name);

	// method: create a fresh game object with this given name, as a child object of the given transform, then return the created game object //
	public static GameObject createAsChildObjectOf(this string name, Transform parent)
		=> new GameObject(name).setParent(parent);

	// method: create a fresh game object with this given name, as a child object of the given game object, then return the created game object //
	public static GameObject createAsChildObjectOf(this string name, GameObject parentObject)
		=> new GameObject(name).setParent(parentObject);

	// method: create a fresh game object with this given name, as a child object of the transform of the given component, then return the created game object //
	public static GameObject createAsChildObjectOf(this string name, Component parentComponent)
		=> new GameObject(name).setParent(parentComponent);

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
			.setName(name.substituteIfEmpty(template.name));

	// method: create an instance of this given object template (object instance or prefab), as a child object of the given transform, then return the created game object //
	public static GameObject createAsChildObjectOf(this GameObject template, Transform parent)
		=> template.create().setParent(parent);

	// method: create an instance of this given object template (object instance or prefab), as a child object of the given game object, then return the created game object //
	public static GameObject createAsChildObjectOf(this GameObject template, GameObject parentObject)
		=> template.create().setParent(parentObject);

	// method: create an instance of this given object template (object instance or prefab), as a child object of the transform of the given component, then return the created game object //
	public static GameObject createAsChildObjectOf(this GameObject template, Component parentComponent)
		=> template.create().setParent(parentComponent);

	// method: create an instance of this given object template (object instance or prefab), as a child object of the transform of the specified singleton behaviour class, then return the created game object //
	public static GameObject createAsChildObjectOf<SingletonBehaviourT>(this GameObject template) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> template.create().setParent<SingletonBehaviourT>();

	// method: create an instance of the given object template (object instance or prefab), as a child object of this given transform, with the given name (using the template's name if empty (which is the default)), then return the created game object //
	public static GameObject createChildObject(this Transform parent, GameObject template, string name = "")
		=> template.createAsChildObjectOf(parent)
			.setName(name.substituteIfEmpty(template.name));

	// method: create an instance of the given object template (object instance or prefab), as a child object of this given game object, with the given name (using the template's name if empty (which is the default)), then return the created game object //
	public static GameObject createChildObject(this GameObject parentObject, GameObject template, string name = "")
		=> template.createAsChildObjectOf(parentObject)
			.setName(name.substituteIfEmpty(template.name));

	// method: create an instance of the given object template (object instance or prefab), as a child object of the transform of this given component, with the given name (using the template's name if empty (which is the default)), then return the created game object //
	public static GameObject createChildObject(this Component parentComponent, GameObject template, string name = "")
		=> template.createAsChildObjectOf(parentComponent)
			.setName(name.substituteIfEmpty(template.name));
	#endregion creating templated game objects


	#region selection
	#if UNITY_EDITOR

	// method: return whether this given game object is currently selected //
	public static bool selected(this GameObject gameObject)
		=> Selection.gameObjects.contains(gameObject);

	// method: return whether this given game object is not currently selected //
	public static bool isNotSelected(this GameObject gameObject)
		=> !gameObject.selected();
	#endif
	#endregion selection


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
		=> gameObject.forWhich(
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
		=> gameObject.forWhich(
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
	public static GameObject validate(this GameObject gameObject)
		=>	gameObject.callAllLocal("OnValidate", SendMessageOptions.DontRequireReceiver, UnityIs.inEditor);
	#endregion calling local methods


	#region getting transformations

	// method: return this given game object's local position //
	public static Vector3 localPosition(this GameObject gameObject)
		=> gameObject.transform.localPosition;

	// method: return this given game object's local x position //
	public static float localPositionX(this GameObject gameObject)
		=> gameObject.transform.localPositionX();

	// method: return this given game object's local y position //
	public static float localPositionY(this GameObject gameObject)
		=> gameObject.transform.localPositionY();

	// method: return this given game object's local z position //
	public static float localPositionZ(this GameObject gameObject)
		=> gameObject.transform.localPositionZ();

	// method: return this given game object's local rotation //
	public static Quaternion localRotation(this GameObject gameObject)
		=> gameObject.transform.localRotation;

	// method: return this given game object's local euler angles //
	public static Vector3 localEulerAngles(this GameObject gameObject)
		=> gameObject.transform.localEulerAngles;

	// method: return this given game object's local x euler angle //
	public static float localEulerAngleX(this GameObject gameObject)
		=> gameObject.transform.localEulerAngleX();

	// method: return this given game object's local y euler angle //
	public static float localEulerAngleY(this GameObject gameObject)
		=> gameObject.transform.localEulerAngleY();

	// method: return this given game object's local z euler angle //
	public static float localEulerAngleZ(this GameObject gameObject)
		=> gameObject.transform.localEulerAngleZ();

	// method: return this given game object's local scale //
	public static Vector3 localScale(this GameObject gameObject)
		=> gameObject.transform.localScale;

	// method: return this given game object's local x scale //
	public static float localScaleX(this GameObject gameObject)
		=> gameObject.transform.localScaleX();

	// method: return this given game object's local y scale //
	public static float localScaleY(this GameObject gameObject)
		=> gameObject.transform.localScaleY();

	// method: return this given game object's local z scale //
	public static float localScaleZ(this GameObject gameObject)
		=> gameObject.transform.localScaleZ();

	// method: return this given game object's (global) position //
	public static Vector3 position(this GameObject gameObject)
		=> gameObject.transform.position;

	// method: return this given game object's (global) x position //
	public static float positionX(this GameObject gameObject)
		=> gameObject.transform.positionX();

	// method: return this given game object's (global) y position //
	public static float positionY(this GameObject gameObject)
		=> gameObject.transform.positionY();

	// method: return this given game object's (global) z position //
	public static float positionZ(this GameObject gameObject)
		=> gameObject.transform.positionZ();

	// method: return this given game object's (global) rotation //
	public static Quaternion rotation(this GameObject gameObject)
		=> gameObject.transform.rotation;

	// method: return this given game object's (global) euler angles //
	public static Vector3 eulerAngles(this GameObject gameObject)
		=> gameObject.transform.eulerAngles;

	// method: return this given game object's (global) x euler angle //
	public static float eulerAngleX(this GameObject gameObject)
		=> gameObject.transform.eulerAngleX();

	// method: return this given game object's (global) y euler angle //
	public static float eulerAngleY(this GameObject gameObject)
		=> gameObject.transform.eulerAngleY();

	// method: return this given game object's (global) z euler angle //
	public static float eulerAngleZ(this GameObject gameObject)
		=> gameObject.transform.eulerAngleZ();
	#endregion getting transformations


	#region setting transformations

	// method: (according to the given boolean:) set this given game object's local position to the given local position, then return this given game object //
	public static GameObject setLocalPosition(this GameObject gameObject, Vector3 localPosition, bool boolean = true)
		=> gameObject.transform.setLocalPosition(localPosition, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local position to the local position for the given x, y, and z values, then return this given game object //
	public static GameObject setLocalPosition(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.setLocalPosition(new Vector3(x, y, z), boolean);

	// method: (according to the given boolean:) set this given game object's local position to the given transform's local position, then return this given game object //
	public static GameObject setLocalPosition(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalPosition(transform.localPosition, boolean);

	// method: (according to the given boolean:) set this given transform's local position to the other given game object's local position, then return this given game object //
	public static GameObject setLocalPosition(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalPosition(otherGameObject.localPosition(), boolean);

	// method: (according to the given boolean:) set this given transform's local position to the given component's local position, then return this given game object //
	public static GameObject setLocalPosition(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalPosition(component.localPosition(), boolean);

	// method: (according to the given boolean:) set this given game object's local x position to the given x value, then return this given game object //
	public static GameObject setLocalPositionX(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.transform.setLocalPositionX(x, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local x position to the given transform's local x position, then return this given game object //
	public static GameObject setLocalPositionX(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalPositionX(transform.localPositionX(), boolean);

	// method: (according to the given boolean:) set this given transform's local x position to the other given game object's local x position, then return this given game object //
	public static GameObject setLocalPositionX(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalPositionX(otherGameObject.localPositionX(), boolean);

	// method: (according to the given boolean:) set this given transform's local x position to the given component's local x position, then return this given game object //
	public static GameObject setLocalPositionX(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalPositionX(component.localPositionX(), boolean);

	// method: (according to the given boolean:) set this given game object's local y position to the given y value, then return this given game object //
	public static GameObject setLocalPositionY(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.setLocalPositionY(y, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local y position to the given transform's local y position, then return this given game object //
	public static GameObject setLocalPositionY(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalPositionY(transform.localPositionY(), boolean);

	// method: (according to the given boolean:) set this given transform's local y position to the other given game object's local y position, then return this given game object //
	public static GameObject setLocalPositionY(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalPositionY(otherGameObject.localPositionY(), boolean);

	// method: (according to the given boolean:) set this given transform's local y position to the given component's local y position, then return this given game object //
	public static GameObject setLocalPositionY(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalPositionY(component.localPositionY(), boolean);

	// method: (according to the given boolean:) set this given game object's local z position to the given z value, then return this given game object //
	public static GameObject setLocalPositionZ(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.setLocalPositionZ(z, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local z position to the given transform's local z position, then return this given game object //
	public static GameObject setLocalPositionZ(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalPositionZ(transform.localPositionZ(), boolean);

	// method: (according to the given boolean:) set this given transform's local z position to the other given game object's local z position, then return this given game object //
	public static GameObject setLocalPositionZ(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalPositionZ(otherGameObject.localPositionZ(), boolean);

	// method: (according to the given boolean:) set this given transform's local z position to the given component's local z position, then return this given game object //
	public static GameObject setLocalPositionZ(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalPositionZ(component.localPositionZ(), boolean);

	// method: (according to the given boolean:) set this given game object's local rotation to the given local rotation, then return this given game object //
	public static GameObject setLocalRotation(this GameObject gameObject, Quaternion localRotation, bool boolean = true)
		=> gameObject.transform.setLocalRotation(localRotation, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local rotation to the given transform's local rotation, then return this given game object //
	public static GameObject setLocalRotation(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalRotation(transform.localRotation, boolean);

	// method: (according to the given boolean:) set this given transform's local rotation to the other given game object's local rotation, then return this given game object //
	public static GameObject setLocalRotation(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalRotation(otherGameObject.localRotation(), boolean);

	// method: (according to the given boolean:) set this given transform's local rotation to the given component's local rotation, then return this given game object //
	public static GameObject setLocalRotation(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalRotation(component.localRotation(), boolean);

	// method: (according to the given boolean:) set this given game object's local euler angles to the given local euler angles, then return this given game object //
	public static GameObject setLocalEulerAngles(this GameObject gameObject, Vector3 localEulerAngles, bool boolean = true)
		=> gameObject.transform.setLocalEulerAngles(localEulerAngles, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local euler angles to the local euler angles for the given x, y, and z values, then return this given game object //
	public static GameObject setLocalEulerAngles(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.transform.setLocalEulerAngles(x, y, z, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local euler angles to the given transform's local euler angles, then return this given game object //
	public static GameObject setLocalEulerAngles(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalEulerAngles(transform.localEulerAngles, boolean);

	// method: (according to the given boolean:) set this given transform's local euler angles to the other given game object's local euler angles, then return this given game object //
	public static GameObject setLocalEulerAngles(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalEulerAngles(otherGameObject.localEulerAngles(), boolean);

	// method: (according to the given boolean:) set this given transform's local euler angles to the given component's local euler angles, then return this given game object //
	public static GameObject setLocalEulerAngles(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalEulerAngles(component.localEulerAngles(), boolean);

	// method: (according to the given boolean:) set this given game object's local x euler angle to the given x value, then return this given game object //
	public static GameObject setLocalEulerAngleX(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.transform.setLocalEulerAngleX(x, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local x euler angle to the given transform's local x euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleX(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalEulerAngleX(transform.localEulerAngleX(), boolean);

	// method: (according to the given boolean:) set this given transform's local x euler angle to the other given game object's local x euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleX(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalEulerAngleX(otherGameObject.localEulerAngleX(), boolean);

	// method: (according to the given boolean:) set this given transform's local euler x angle to the given component's local x euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleX(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalEulerAngleX(component.localEulerAngleX(), boolean);

	// method: (according to the given boolean:) set this given game object's local y euler angle to the given y value, then return this given game object //
	public static GameObject setLocalEulerAngleY(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.setLocalEulerAngleY(y, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local y euler angle to the given transform's local y euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleY(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalEulerAngleY(transform.localEulerAngleY(), boolean);

	// method: (according to the given boolean:) set this given transform's local y euler angle to the other given game object's local y euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleY(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalEulerAngleY(otherGameObject.localEulerAngleY(), boolean);

	// method: (according to the given boolean:) set this given transform's local euler y angle to the given component's local y euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleY(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalEulerAngleY(component.localEulerAngleY(), boolean);

	// method: (according to the given boolean:) set this given game object's local z euler angle to the given z value, then return this given game object //
	public static GameObject setLocalEulerAngleZ(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.setLocalEulerAngleZ(z, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local z euler angle to the given transform's local z euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleZ(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalEulerAngleZ(transform.localEulerAngleZ(), boolean);

	// method: (according to the given boolean:) set this given transform's local z euler angle to the other given game object's local z euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleZ(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalEulerAngleZ(otherGameObject.localEulerAngleZ(), boolean);

	// method: (according to the given boolean:) set this given transform's local euler z angle to the given component's local z euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleZ(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalEulerAngleZ(component.localEulerAngleZ(), boolean);

	// method: (according to the given boolean:) set this given game object's local scale to the given local scale, then return this given game object //
	public static GameObject setLocalScale(this GameObject gameObject, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setLocalScale(localScale, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local scale to the local scale for the given x, y, and z values, then return this given game object //
	public static GameObject setLocalScale(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.setLocalScale(new Vector3(x, y, z), boolean);

	// method: (according to the given boolean:) set this given game object's local scale to the given transform's local scale, then return this given game object //
	public static GameObject setLocalScale(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalScale(transform.localScale, boolean);

	// method: (according to the given boolean:) set this given transform's local scale to the other given game object's local scale, then return this given game object //
	public static GameObject setLocalScale(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalScale(otherGameObject.localScale(), boolean);

	// method: (according to the given boolean:) set this given transform's local scale to the given component's local scale, then return this given game object //
	public static GameObject setLocalScale(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalScale(component.localScale(), boolean);

	// method: (according to the given boolean:) set this given game object's local x scale to the given x value, then return this given game object //
	public static GameObject setLocalScaleX(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.transform.setLocalScaleX(x, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local x scale to the given transform's local x scale, then return this given game object //
	public static GameObject setLocalScaleX(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalScaleX(transform.localScaleX(), boolean);

	// method: (according to the given boolean:) set this given transform's local x scale to the other given game object's local x scale, then return this given game object //
	public static GameObject setLocalScaleX(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalScaleX(otherGameObject.localScaleX(), boolean);

	// method: (according to the given boolean:) set this given transform's local x scale to the given component's local x scale, then return this given game object //
	public static GameObject setLocalScaleX(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalScaleX(component.localScaleX(), boolean);

	// method: (according to the given boolean:) set this given game object's local y scale to the given y value, then return this given game object //
	public static GameObject setLocalScaleY(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.setLocalScaleY(y, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local y scale to the given transform's local y scale, then return this given game object //
	public static GameObject setLocalScaleY(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalScaleY(transform.localScaleY(), boolean);

	// method: (according to the given boolean:) set this given transform's local y scale to the other given game object's local y scale, then return this given game object //
	public static GameObject setLocalScaleY(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalScaleY(otherGameObject.localScaleY(), boolean);

	// method: (according to the given boolean:) set this given transform's local y scale to the given component's local y scale, then return this given game object //
	public static GameObject setLocalScaleY(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalScaleY(component.localScaleY(), boolean);

	// method: (according to the given boolean:) set this given game object's local z scale to the given z value, then return this given game object //
	public static GameObject setLocalScaleZ(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.setLocalScaleZ(z, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local z scale to the given transform's local z scale, then return this given game object //
	public static GameObject setLocalScaleZ(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalScaleZ(transform.localScaleZ(), boolean);

	// method: (according to the given boolean:) set this given transform's local z scale to the other given game object's local z scale, then return this given game object //
	public static GameObject setLocalScaleZ(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalScaleZ(otherGameObject.localScaleZ(), boolean);

	// method: (according to the given boolean:) set this given transform's local z scale to the given component's local z scale, then return this given game object //
	public static GameObject setLocalScaleZ(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalScaleZ(component.localScaleZ(), boolean);

	// method: (according to the given boolean:) set this given game object's local transformations (local position, local rotation, local scale) respectively to the given local position, local rotation, and local scale, then return this given game object //
	public static GameObject setLocals(this GameObject gameObject, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setLocals(localPosition, localRotation, localScale, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local transformations (local position, local rotation, local scale) respectively to the given transform's local position, local rotation, and local scale, then return this given game object //
	public static GameObject setLocals(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocals(transform.localPosition, transform.localRotation, transform.localScale, boolean);

	// method: (according to the given boolean:) set this given game object's local transformations (local position, local rotation, local scale) respectively to the other given game object's local position, local rotation, and local scale, then return this given game object //
	public static GameObject setLocals(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocals(otherGameObject.localPosition(), otherGameObject.localRotation(), otherGameObject.localScale(), boolean);

	// method: (according to the given boolean:) set this given game object's local transformations (local position, local rotation, local scale) respectively to the given component's local position, local rotation, and local scale, then return this given game object //
	public static GameObject setLocals(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocals(component.localPosition(), component.localRotation(), component.localScale(), boolean);

	// method: (according to the given boolean:) set this given game object's local transformations (local position, local euler angles, local scale) respectively to the given local position, local euler angles, and local scale, then return this given game object //
	public static GameObject setLocals(this GameObject gameObject, Vector3 localPosition, Vector3 localEulerAngles, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setLocals(localPosition, localEulerAngles, localScale, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (nonscale) local transformations (local position, local rotation) respectively to the given local position and local rotation //
	public static GameObject setLocals(this GameObject gameObject, Vector3 localPosition, Quaternion localRotation, bool boolean = true)
		=> gameObject.transform.setLocals(localPosition, localRotation, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (nonposition) local transformations (local rotation, local scale) respectively to the given local rotation and local scale //
	public static GameObject setLocals(this GameObject gameObject, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setLocals(localRotation, localScale, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local transformations to its parent's while temporarily childed to the given transform, then return this given game object //
	public static GameObject setLocalsParentlyForRelativeTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.transform.setLocalsParentlyForRelativeTo(transform, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local transformations to its parent's while temporarily childed to the other given game object, then return this given game object //
	public static GameObject setLocalsParentlyForRelativeTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.transform.setLocalsParentlyForRelativeTo(otherGameObject, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local transformations to its parent's while temporarily childed to the given component, then return this given game object //
	public static GameObject setLocalsParentlyForRelativeTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.transform.setLocalsParentlyForRelativeTo(component, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) position to the given (global) position, then return this given game object //
	public static GameObject setPosition(this GameObject gameObject, Vector3 position, bool boolean = true)
		=> gameObject.transform.setPosition(position, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) position to the (global) position for the given x, y, and z values, then return this given game object //
	public static GameObject setPosition(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.setPosition(new Vector3(x, y, z), boolean);

	// method: (according to the given boolean:) set this given game object's position to the given transform's position, then return this given game object //
	public static GameObject setPosition(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setPosition(transform.position, boolean);

	// method: (according to the given boolean:) set this given transform's position to the other given game object's position, then return this given game object //
	public static GameObject setPosition(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setPosition(otherGameObject.position(), boolean);

	// method: (according to the given boolean:) set this given transform's position to the given component's position, then return this given game object //
	public static GameObject setPosition(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setPosition(component.position(), boolean);

	// method: (according to the given boolean:) set this given game object's (global) x position to the given x value, then return this given game object //
	public static GameObject setPositionX(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.setPositionX(x, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's x position to the given transform's x position, then return this given game object //
	public static GameObject setPositionX(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setPositionX(transform.positionX(), boolean);

	// method: (according to the given boolean:) set this given transform's x position to the other given game object's x position, then return this given game object //
	public static GameObject setPositionX(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setPositionX(otherGameObject.positionX(), boolean);

	// method: (according to the given boolean:) set this given transform's x position to the given component's x position, then return this given game object //
	public static GameObject setPositionX(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setPositionX(component.positionX(), boolean);

	// method: (according to the given boolean:) set this given game object's (global) y position to the given y value, then return this given game object //
	public static GameObject setPositionY(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.setPositionY(y, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's y position to the given transform's y position, then return this given game object //
	public static GameObject setPositionY(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setPositionY(transform.positionY(), boolean);

	// method: (according to the given boolean:) set this given transform's y position to the other given game object's y position, then return this given game object //
	public static GameObject setPositionY(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setPositionY(otherGameObject.positionY(), boolean);

	// method: (according to the given boolean:) set this given transform's y position to the given component's y position, then return this given game object //
	public static GameObject setPositionY(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setPositionY(component.positionY(), boolean);

	// method: (according to the given boolean:) set this given game object's (global) z position to the given z value, then return this given game object //
	public static GameObject setPositionZ(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.setPositionZ(z, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's z position to the given transform's z position, then return this given game object //
	public static GameObject setPositionZ(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setPositionZ(transform.positionZ(), boolean);

	// method: (according to the given boolean:) set this given transform's z position to the other given game object's z position, then return this given game object //
	public static GameObject setPositionZ(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setPositionZ(otherGameObject.positionZ(), boolean);

	// method: (according to the given boolean:) set this given transform's z position to the given component's z position, then return this given game object //
	public static GameObject setPositionZ(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setPositionZ(component.positionZ(), boolean);

	// method: (according to the given boolean:) set this given game object's (global) rotation to the given (global) rotation, then return this given game object //
	public static GameObject setRotation(this GameObject gameObject, Quaternion rotation, bool boolean = true)
		=> gameObject.transform.setRotation(rotation, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) rotation to the given transform's (global) rotation, then return this given game object //
	public static GameObject setRotation(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setRotation(transform.rotation(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) rotation to the other given game object's (global) rotation, then return this given game object //
	public static GameObject setRotation(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setRotation(otherGameObject.rotation(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) rotation to the given component's (global) rotation, then return this given game object //
	public static GameObject setRotation(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setRotation(component.rotation(), boolean);

	// method: (according to the given boolean:) set this given game object's (global) euler angles to the given (global) euler angles, then return this given game object //
	public static GameObject setEulerAngles(this GameObject gameObject, Vector3 eulerAngles, bool boolean = true)
		=> gameObject.transform.setEulerAngles(eulerAngles, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) euler angles to the (global) euler angles for the given x, y, and z values, then return this given game object //
	public static GameObject setEulerAngles(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.transform.setEulerAngles(x, y, z, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) euler angles to the given transform's (global) euler angles, then return this given game object //
	public static GameObject setEulerAngles(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setEulerAngles(transform.eulerAngles(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) euler angles to the other given game object's (global) euler angles, then return this given game object //
	public static GameObject setEulerAngles(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setEulerAngles(otherGameObject.eulerAngles(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) euler angles to the given component's (global) euler angles, then return this given game object //
	public static GameObject setEulerAngles(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setEulerAngles(component.eulerAngles(), boolean);

	// method: (according to the given boolean:) set this given game object's (global) x euler angle to the given x value, then return this given game object //
	public static GameObject setEulerAngleX(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.transform.setEulerAngleX(x, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) x euler angle to the given transform's (global) x euler angle, then return this given game object //
	public static GameObject setEulerAngleX(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setEulerAngleX(transform.eulerAngleX(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) x euler angle to the other given game object's (global) x euler angle, then return this given game object //
	public static GameObject setEulerAngleX(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setEulerAngleX(otherGameObject.eulerAngleX(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) x euler angle to the given component's (global) x euler angle, then return this given game object //
	public static GameObject setEulerAngleX(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setEulerAngleX(component.eulerAngleX(), boolean);

	// method: (according to the given boolean:) set this given game object's (global) y euler angle to the given y value, then return this given game object //
	public static GameObject setEulerAngleY(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.setEulerAngleY(y, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) y euler angle to the given transform's (global) y euler angle, then return this given game object //
	public static GameObject setEulerAngleY(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setEulerAngleY(transform.eulerAngleY(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) y euler angle to the other given game object's (global) y euler angle, then return this given game object //
	public static GameObject setEulerAngleY(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setEulerAngleY(otherGameObject.eulerAngleY(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) y euler angle to the given component's (global) y euler angle, then return this given game object //
	public static GameObject setEulerAngleY(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setEulerAngleY(component.eulerAngleY(), boolean);

	// method: (according to the given boolean:) set this given game object's (global) z euler angle to the given z value, then return this given game object //
	public static GameObject setEulerAngleZ(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.setEulerAngleZ(z, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) z euler angle to the given transform's (global) z euler angle, then return this given game object //
	public static GameObject setEulerAngleZ(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setEulerAngleZ(transform.eulerAngleZ(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) z euler angle to the other given game object's (global) z euler angle, then return this given game object //
	public static GameObject setEulerAngleZ(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setEulerAngleZ(otherGameObject.eulerAngleZ(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) z euler angle to the given component's (global) z euler angle, then return this given game object //
	public static GameObject setEulerAngleZ(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setEulerAngleZ(component.eulerAngleZ(), boolean);

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) respectively to the given (global) position and (global) rotation //
	public static GameObject setGlobals(this GameObject gameObject, Vector3 position, Quaternion rotation, bool boolean = true)
		=> gameObject.transform.setGlobals(position, rotation, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) respectively to the given transform's (global) position and (global) rotation //
	public static GameObject setGlobals(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setGlobals(transform.position, transform.rotation, boolean);

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) respectively to the other given game object's (global) position and (global) rotation //
	public static GameObject setGlobals(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setGlobals(otherGameObject.position(), otherGameObject.rotation(), boolean);

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) respectively to the given component's (global) position and (global) rotation //
	public static GameObject setGlobals(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setGlobals(component.position(), component.rotation(), boolean);

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global euler angles) respectively to the given (global) position and (global) euler angles //
	public static GameObject setGlobals(this GameObject gameObject, Vector3 position, Vector3 eulerAngles, bool boolean = true)
		=> gameObject.transform.setGlobals(position, eulerAngles, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) and local scale respectively to the given (global) position and (global) rotation and local scale //
	public static GameObject setGlobalsAndLocalScale(this GameObject gameObject, Vector3 position, Quaternion rotation, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setGlobalsAndLocalScale(position, rotation, localScale, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) and local scale respectively to the given transform's (global) position and (global) rotation and local scale //
	public static GameObject setGlobalsAndLocalScale(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setGlobalsAndLocalScale(transform.position, transform.rotation, transform.localScale, boolean);

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) and local scale respectively to the other given game object's (global) position and (global) rotation and local scale //
	public static GameObject setGlobalsAndLocalScale(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setGlobalsAndLocalScale(otherGameObject.position(), otherGameObject.rotation(), otherGameObject.localScale(), boolean);

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) and local scale respectively to the given component's (global) position and (global) rotation and local scale //
	public static GameObject setGlobalsAndLocalScale(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setGlobalsAndLocalScale(component.position(), component.rotation(), component.localScale(), boolean);

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global euler angles) and local scale respectively to the given (global) position and (global) euler angles and local scale //
	public static GameObject setGlobalsAndLocalScale(this GameObject gameObject, Vector3 position, Vector3 eulerAngles, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setGlobalsAndLocalScale(position, eulerAngles, localScale, boolean).gameObject;
	#endregion setting transformations


	#region resetting transformations

	// method: (according to the given boolean:) reset this given game object's local position to zeroes, then return this given game object //
	public static GameObject resetLocalPosition(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalPosition(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local x position to zero, then return this given game object //
	public static GameObject resetLocalPositionX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalPositionX(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local y position to zero, then return this given game object //
	public static GameObject resetLocalPositionY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalPositionY(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local z position to zero, then return this given game object //
	public static GameObject resetLocalPositionZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalPositionZ(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local rotation to no rotation, then return this given game object //
	public static GameObject resetLocalRotation(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalRotation(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local euler angles to zeroes, then return this given game object //
	public static GameObject resetLocalEulerAngles(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalEulerAngles(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local x euler angle to zero, then return this given game object //
	public static GameObject resetLocalEulerAngleX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalEulerAngleX(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local y euler angle to zero, then return this given game object //
	public static GameObject resetLocalEulerAngleY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalEulerAngleY(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local z euler angle to zero, then return this given game object //
	public static GameObject resetLocalEulerAngleZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalEulerAngleZ(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local scale to ones, then return this given game object //
	public static GameObject resetLocalScale(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalScale(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local x scale to one, then return this given game object //
	public static GameObject resetLocalScaleX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalScaleX(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local y scale to one, then return this given game object //
	public static GameObject resetLocalScaleY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalScaleY(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local z scale to one, then return this given game object //
	public static GameObject resetLocalScaleZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalScaleZ(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local transformations (local position, local rotation, local scale) respectively to the zeroes, no rotation, and ones, then return this given game object //
	public static GameObject resetLocals(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocals(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) position to zeroes, then return this given game object //
	public static GameObject resetPosition(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetPosition(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) x position to zero, then return this given game object //
	public static GameObject resetPositionX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetPositionX(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) y position to zero, then return this given game object //
	public static GameObject resetPositionY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetPositionY(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) z position to zero, then return this given game object //
	public static GameObject resetPositionZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetPositionZ(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) rotation to no rotation, then return this given game object //
	public static GameObject resetRotation(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetRotation(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) euler angles to zeroes, then return this given game object //
	public static GameObject resetEulerAngles(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetEulerAngles(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) x euler angles to zero, then return this given game object //
	public static GameObject resetEulerAngleX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetEulerAngleX(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) y euler angles to zero, then return this given game object //
	public static GameObject resetEulerAngleY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetEulerAngleY(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) z euler angles to zero, then return this given game object //
	public static GameObject resetEulerAngleZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetEulerAngleZ(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's global transformations (global position, global rotation) respectively to zeroes and no rotation //
	public static GameObject resetGlobals(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetGlobals(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's global transformations (global position, global rotation) and local scale respectively to zeroes, no rotation, and ones //
	public static GameObject resetGlobalsAndLocalScale(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetGlobalsAndLocalScale(boolean).gameObject;
	#endregion resetting transformations


	#region advanced rotation

	// method: (according to the given boolean:) have this given game object look at the given target position, then return this given game object //
	public static GameObject lookAt(this GameObject gameObject, Vector3 targetPosition, bool boolean = true)
		=> gameObject.transform.lookAt(targetPosition, boolean).gameObject;

	// method: (according to the given boolean:) have this given game object look at the given target transform, then return this given game object //
	public static GameObject lookAt(this GameObject gameObject, Transform targetTransform, bool boolean = true)
		=> gameObject.transform.lookAt(targetTransform, boolean).gameObject;

	// method: (according to the given boolean:) have this given game object look at the given target transform, then return this given game object //
	public static GameObject lookAt(this GameObject gameObject, GameObject targetObject, bool boolean = true)
		=> gameObject.transform.lookAt(targetObject, boolean).gameObject;

	// method: (according to the given boolean:) have this given game object look at the main camera, then return this given game object //
	public static GameObject lookAtCamera(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.lookAtCamera(boolean).gameObject;

	// method: (according to the given boolean:) have this given game object rotate by the given (x, y, and z) rotation angles, then return this given game object //
	public static GameObject rotate(this GameObject gameObject, Vector3 rotationAngles, bool boolean = true)
		=> gameObject.transform.rotate(rotationAngles, boolean).gameObject;

	// method: (according to the given boolean:) have this given game object rotate by the given x, y, and z rotation angles, then return this given game object //
	public static GameObject rotate(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.transform.rotate(x, y, z, boolean).gameObject;

	// method: (according to the given boolean:) have this given game object rotate by the given x rotation angle, then return this given game object //
	public static GameObject rotateX(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.transform.rotateX(x, boolean).gameObject;

	// method: (according to the given boolean:) have this given game object rotate by the given y rotation angle, then return this given game object //
	public static GameObject rotateY(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.rotateY(y, boolean).gameObject;

	// method: (according to the given boolean:) have this given game object rotate by the given z rotation angle, then return this given game object //
	public static GameObject rotateZ(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.rotateZ(z, boolean).gameObject;

	// method: (according to the given boolean:) have this given game object rotate by 180° on the x axis, then return this given game object //
	public static GameObject flipX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.flipX(boolean).gameObject;
	
	// method: (according to the given boolean:) have this given game object rotate by 180° on the y axis, then return this given game object //
	public static GameObject flipY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.flipY(boolean).gameObject;

	// method: (according to the given boolean:) have this given game object rotate by 180° on the z axis, then return this given game object //
	public static GameObject flipZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.flipZ(boolean).gameObject;
	#endregion advanced rotation


	#region distance

	// method: return the closest (by position) of the given game objects to this given game object //
	public static GameObject closestOf(this GameObject gameObject, IEnumerable<GameObject> gameObjects)
		=> gameObjects.itemWithMin(otherGameObject => gameObject.position().distanceWith(otherGameObject.position()));

	// method: return the closest (by position) of the given transforms to this given game object //
	public static Transform closestOf(this GameObject gameObject, IEnumerable<Transform> transforms)
		=> transforms.itemWithMin(otherTransform => gameObject.position().distanceWith(otherTransform.position));

	// method: return the closest of the given positions to this given game object's position //
	public static Vector3 closestOf(this GameObject gameObject, IEnumerable<Vector3> positions)
		=> positions.itemWithMin(otherPosition => gameObject.position().distanceWith(otherPosition));

	// method: return the farthest (by position) of the given game objects to this given game object //
	public static GameObject farthestOf(this GameObject gameObject, IEnumerable<GameObject> gameObjects)
		=> gameObjects.itemWithMax(otherGameObject => gameObject.position().distanceWith(otherGameObject.position()));

	// method: return the farthest (by position) of the given transforms to this given game object //
	public static Transform farthestOf(this GameObject gameObject, IEnumerable<Transform> transforms)
		=> transforms.itemWithMax(otherTransform => gameObject.position().distanceWith(otherTransform.position));

	// method: return the farthest of the given positions to this given game object's position //
	public static Vector3 farthestOf(this GameObject gameObject, IEnumerable<Vector3> positions)
		=> positions.itemWithMax(otherPosition => gameObject.position().distanceWith(otherPosition));
	#endregion distance


	#region conversion

	// method: return the game object idee for this given game object //
	public static int idee(this GameObject gameObject)
		=> gameObject.GetInstanceID();

	#if UNITY_EDITOR
	// method: if there is a game object corresponding to this given integer as a game object idee, return that game object; otherwise, return null //
	public static GameObject gameObject(this int gameObjectIdee)
		=> EditorUtility.InstanceIDToObject(gameObjectIdee) as GameObject;
	#endif

	// method: return an enumerable of the transforms for this given enumerable of game objects //
	public static IEnumerable<Transform> transforms(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.select(gameObject => gameObject.transform);

	// method: return an array of local positions corresponding to this given array of game objects //
	public static Vector3[] asLocalPositions(this GameObject[] gameObjects)
		=> gameObjects.Select(gameObject => gameObject.localPosition()).ToArray();

	// method: return an array of local scales corresponding to this given array of game objects //
	public static Vector3[] asLocalScales(this GameObject[] gameObjects)
		=> gameObjects.Select(gameObject => gameObject.localScale()).ToArray();

	// method: return an array of (world) positions corresponding to this given array of game objects //
	public static Vector3[] asPositions(this GameObject[] gameObjects)
		=> gameObjects.Select(gameObject => gameObject.position()).ToArray();
	#endregion conversion


	#region child lights

	public static float[] childLightsIntensities(this GameObject gameObject)
		=> gameObject.GetComponentsInChildren<Light>().intensities();
	
	public static GameObject setChildLightsIntensities(this GameObject gameObject, float[] targetIntensities)
	{
		gameObject.GetComponentsInChildren<Light>().setIntensitiesTo(targetIntensities);

		return gameObject;
	}

	public static GameObject setChildLightsIntensities(this GameObject gameObject, float targetIntensity)
		=> gameObject.setChildLightsIntensities(new float[] {targetIntensity});

	public static GameObject renderChildLightsBy(this GameObject gameObject, LightRenderMode lightRenderMode)
	{
		gameObject.GetComponentsInChildren<Light>().renderBy(lightRenderMode);

		return gameObject;
	}

	public static GameObject renderChildLightsByPixel(this GameObject gameObject)
		=> gameObject.renderChildLightsBy(LightRenderMode.ForcePixel);

	public static GameObject renderChildLightsByVertex(this GameObject gameObject)
		=> gameObject.renderChildLightsBy(LightRenderMode.ForceVertex);
	#endregion child lights


	#region child particles systems

	public static GameObject togglePlayingChildParticlesSystems(this GameObject gameObject, bool boolean)
	{
		gameObject.GetComponentsInChildren<ParticleSystem>().togglePlaying(boolean);

		return gameObject;
	}

	public static GameObject playChildParticlesSystems(this GameObject gameObject, bool boolean)
	{
		gameObject.GetComponentsInChildren<ParticleSystem>().play(boolean);

		return gameObject;
	}

	public static GameObject stopChildParticlesSystems(this GameObject gameObject, bool boolean)
	{
		gameObject.GetComponentsInChildren<ParticleSystem>().stop(boolean);

		return gameObject;
	}
	#endregion child particles systems
}