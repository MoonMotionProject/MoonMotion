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
		=> dictionary.removeWhere(gameObjectKey => gameObjectKey.destroyed());
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
		=> template.create().setParentTo(parent);

	// method: create an instance of this given object template (object instance or prefab), as a child object of the given game object, then return the created game object //
	public static GameObject createAsChildObjectOf(this GameObject template, GameObject parentObject)
		=> template.create().setParentTo(parentObject);

	// method: create an instance of this given object template (object instance or prefab), as a child object of the transform of the given component, then return the created game object //
	public static GameObject createAsChildObjectOf(this GameObject template, Component parentComponent)
		=> template.create().setParentTo(parentComponent);

	// method: create an instance of this given object template (object instance or prefab), as a child object of the transform of the specified singleton behaviour class, then return the created game object //
	public static GameObject createAsChildObjectOf<SingletonBehaviourT>(this GameObject template) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> template.create().setParentTo<SingletonBehaviourT>();

	// method: create an instance of the given object template (object instance or prefab), as a child object of this given transform, with the given name (using the template's name if empty (which is the default)), then return the created game object //
	public static GameObject createChildObject(this Transform parent, GameObject template, string name = "")
		=> template.createAsChildObjectOf(parent)
			.setNameTo(name.substituteIfEmpty(template.name));

	// method: create an instance of the given object template (object instance or prefab), as a child object of this given game object, with the given name (using the template's name if empty (which is the default)), then return the created game object //
	public static GameObject createChildObject(this GameObject parentObject, GameObject template, string name = "")
		=> template.createAsChildObjectOf(parentObject)
			.setNameTo(name.substituteIfEmpty(template.name));

	// method: create an instance of the given object template (object instance or prefab), as a child object of the transform of this given component, with the given name (using the template's name if empty (which is the default)), then return the created game object //
	public static GameObject createChildObject(this Component parentComponent, GameObject template, string name = "")
		=> template.createAsChildObjectOf(parentComponent)
			.setNameTo(name.substituteIfEmpty(template.name));
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
	public static GameObject setLocalPositionTo(this GameObject gameObject, Vector3 localPosition, bool boolean = true)
		=> gameObject.transform.setLocalPositionTo(localPosition, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's local position to the local position for the given x, y, and z values, then return this given game object //
	public static GameObject setLocalPositionTo(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.setLocalPositionTo(new Vector3(x, y, z), boolean);
	// method: (according to the given boolean:) set this given game object's local position to the given transform's local position, then return this given game object //
	public static GameObject setLocalPositionTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalPositionTo(transform.localPosition, boolean);
	// method: (according to the given boolean:) set this given transform's local position to the other given game object's local position, then return this given game object //
	public static GameObject setLocalPositionTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalPositionTo(otherGameObject.localPosition(), boolean);
	// method: (according to the given boolean:) set this given transform's local position to the given component's local position, then return this given game object //
	public static GameObject setLocalPositionTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalPositionTo(component.localPosition(), boolean);

	// method: (according to the given boolean:) set this given game object's local x position to the given x value, then return this given game object //
	public static GameObject setLocalPositionXTo(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.transform.setLocalPositionXTo(x, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's local x position to the given transform's local x position, then return this given game object //
	public static GameObject setLocalPositionXTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalPositionXTo(transform.localPositionX(), boolean);
	// method: (according to the given boolean:) set this given transform's local x position to the other given game object's local x position, then return this given game object //
	public static GameObject setLocalPositionXTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalPositionXTo(otherGameObject.localPositionX(), boolean);
	// method: (according to the given boolean:) set this given transform's local x position to the given component's local x position, then return this given game object //
	public static GameObject setLocalPositionXTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalPositionXTo(component.localPositionX(), boolean);

	// method: (according to the given boolean:) set this given game object's local y position to the given y value, then return this given game object //
	public static GameObject setLocalPositionYTo(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.setLocalPositionYTo(y, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's local y position to the given transform's local y position, then return this given game object //
	public static GameObject setLocalPositionYTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalPositionYTo(transform.localPositionY(), boolean);
	// method: (according to the given boolean:) set this given transform's local y position to the other given game object's local y position, then return this given game object //
	public static GameObject setLocalPositionYTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalPositionYTo(otherGameObject.localPositionY(), boolean);
	// method: (according to the given boolean:) set this given transform's local y position to the given component's local y position, then return this given game object //
	public static GameObject setLocalPositionYTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalPositionYTo(component.localPositionY(), boolean);

	// method: (according to the given boolean:) set this given game object's local z position to the given z value, then return this given game object //
	public static GameObject setLocalPositionZTo(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.setLocalPositionZTo(z, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's local z position to the given transform's local z position, then return this given game object //
	public static GameObject setLocalPositionZTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalPositionZTo(transform.localPositionZ(), boolean);
	// method: (according to the given boolean:) set this given transform's local z position to the other given game object's local z position, then return this given game object //
	public static GameObject setLocalPositionZTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalPositionZTo(otherGameObject.localPositionZ(), boolean);
	// method: (according to the given boolean:) set this given transform's local z position to the given component's local z position, then return this given game object //
	public static GameObject setLocalPositionZTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalPositionZTo(component.localPositionZ(), boolean);

	// method: (according to the given boolean:) set this given game object's local rotation to the given local rotation, then return this given game object //
	public static GameObject setLocalRotationTo(this GameObject gameObject, Quaternion localRotation, bool boolean = true)
		=> gameObject.transform.setLocalRotationTo(localRotation, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's local rotation to the given transform's local rotation, then return this given game object //
	public static GameObject setLocalRotationTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalRotationTo(transform.localRotation, boolean);
	// method: (according to the given boolean:) set this given transform's local rotation to the other given game object's local rotation, then return this given game object //
	public static GameObject setLocalRotationTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalRotationTo(otherGameObject.localRotation(), boolean);
	// method: (according to the given boolean:) set this given transform's local rotation to the given component's local rotation, then return this given game object //
	public static GameObject setLocalRotationTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalRotationTo(component.localRotation(), boolean);

	// method: (according to the given boolean:) set this given game object's local euler angles to the given local euler angles, then return this given game object //
	public static GameObject setLocalEulerAnglesTo(this GameObject gameObject, Vector3 localEulerAngles, bool boolean = true)
		=> gameObject.transform.setLocalEulerAnglesTo(localEulerAngles, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's local euler angles to the local euler angles for the given x, y, and z values, then return this given game object //
	public static GameObject setLocalEulerAnglesTo(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.transform.setLocalEulerAnglesTo(x, y, z, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's local euler angles to the given transform's local euler angles, then return this given game object //
	public static GameObject setLocalEulerAnglesTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalEulerAnglesTo(transform.localEulerAngles, boolean);
	// method: (according to the given boolean:) set this given transform's local euler angles to the other given game object's local euler angles, then return this given game object //
	public static GameObject setLocalEulerAnglesTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalEulerAnglesTo(otherGameObject.localEulerAngles(), boolean);
	// method: (according to the given boolean:) set this given transform's local euler angles to the given component's local euler angles, then return this given game object //
	public static GameObject setLocalEulerAnglesTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalEulerAnglesTo(component.localEulerAngles(), boolean);

	// method: (according to the given boolean:) set this given game object's local x euler angle to the given x value, then return this given game object //
	public static GameObject setLocalEulerAngleXTo(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.transform.setLocalEulerAngleXTo(x, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's local x euler angle to the given transform's local x euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleXTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalEulerAngleXTo(transform.localEulerAngleX(), boolean);
	// method: (according to the given boolean:) set this given transform's local x euler angle to the other given game object's local x euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleXTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalEulerAngleXTo(otherGameObject.localEulerAngleX(), boolean);
	// method: (according to the given boolean:) set this given transform's local euler x angle to the given component's local x euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleXTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalEulerAngleXTo(component.localEulerAngleX(), boolean);

	// method: (according to the given boolean:) set this given game object's local y euler angle to the given y value, then return this given game object //
	public static GameObject setLocalEulerAngleYTo(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.setLocalEulerAngleYTo(y, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's local y euler angle to the given transform's local y euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleYTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalEulerAngleYTo(transform.localEulerAngleY(), boolean);
	// method: (according to the given boolean:) set this given transform's local y euler angle to the other given game object's local y euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleYTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalEulerAngleYTo(otherGameObject.localEulerAngleY(), boolean);
	// method: (according to the given boolean:) set this given transform's local euler y angle to the given component's local y euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleYTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalEulerAngleYTo(component.localEulerAngleY(), boolean);

	// method: (according to the given boolean:) set this given game object's local z euler angle to the given z value, then return this given game object //
	public static GameObject setLocalEulerAngleZTo(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.setLocalEulerAngleZTo(z, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's local z euler angle to the given transform's local z euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleZTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalEulerAngleZTo(transform.localEulerAngleZ(), boolean);
	// method: (according to the given boolean:) set this given transform's local z euler angle to the other given game object's local z euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleZTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalEulerAngleZTo(otherGameObject.localEulerAngleZ(), boolean);
	// method: (according to the given boolean:) set this given transform's local euler z angle to the given component's local z euler angle, then return this given game object //
	public static GameObject setLocalEulerAngleZTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalEulerAngleZTo(component.localEulerAngleZ(), boolean);

	// method: (according to the given boolean:) set this given game object's local scale to the given local scale, then return this given game object //
	public static GameObject setLocalScaleTo(this GameObject gameObject, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setLocalScaleTo(localScale, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's local scale to the local scale for the given x, y, and z values, then return this given game object //
	public static GameObject setLocalScaleTo(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.setLocalScaleTo(new Vector3(x, y, z), boolean);
	// method: (according to the given boolean:) set this given game object's local scale to the given transform's local scale, then return this given game object //
	public static GameObject setLocalScaleTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalScaleTo(transform.localScale, boolean);
	// method: (according to the given boolean:) set this given transform's local scale to the other given game object's local scale, then return this given game object //
	public static GameObject setLocalScaleTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalScaleTo(otherGameObject.localScale(), boolean);
	// method: (according to the given boolean:) set this given transform's local scale to the given component's local scale, then return this given game object //
	public static GameObject setLocalScaleTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalScaleTo(component.localScale(), boolean);

	// method: (according to the given boolean:) set this given game object's local x scale to the given x value, then return this given game object //
	public static GameObject setLocalScaleXTo(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.transform.setLocalScaleXTo(x, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's local x scale to the given transform's local x scale, then return this given game object //
	public static GameObject setLocalScaleXTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalScaleXTo(transform.localScaleX(), boolean);
	// method: (according to the given boolean:) set this given transform's local x scale to the other given game object's local x scale, then return this given game object //
	public static GameObject setLocalScaleXTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalScaleXTo(otherGameObject.localScaleX(), boolean);
	// method: (according to the given boolean:) set this given transform's local x scale to the given component's local x scale, then return this given game object //
	public static GameObject setLocalScaleXTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalScaleXTo(component.localScaleX(), boolean);

	// method: (according to the given boolean:) set this given game object's local y scale to the given y value, then return this given game object //
	public static GameObject setLocalScaleYTo(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.setLocalScaleYTo(y, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's local y scale to the given transform's local y scale, then return this given game object //
	public static GameObject setLocalScaleYTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalScaleYTo(transform.localScaleY(), boolean);
	// method: (according to the given boolean:) set this given transform's local y scale to the other given game object's local y scale, then return this given game object //
	public static GameObject setLocalScaleYTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalScaleYTo(otherGameObject.localScaleY(), boolean);
	// method: (according to the given boolean:) set this given transform's local y scale to the given component's local y scale, then return this given game object //
	public static GameObject setLocalScaleYTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalScaleYTo(component.localScaleY(), boolean);

	// method: (according to the given boolean:) set this given game object's local z scale to the given z value, then return this given game object //
	public static GameObject setLocalScaleZTo(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.setLocalScaleZTo(z, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's local z scale to the given transform's local z scale, then return this given game object //
	public static GameObject setLocalScaleZTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalScaleZTo(transform.localScaleZ(), boolean);
	// method: (according to the given boolean:) set this given transform's local z scale to the other given game object's local z scale, then return this given game object //
	public static GameObject setLocalScaleZTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalScaleZTo(otherGameObject.localScaleZ(), boolean);
	// method: (according to the given boolean:) set this given transform's local z scale to the given component's local z scale, then return this given game object //
	public static GameObject setLocalScaleZTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalScaleZTo(component.localScaleZ(), boolean);

	// method: (according to the given boolean:) set this given game object's local transformations (local position, local rotation, local scale) respectively to the given local position, local rotation, and local scale, then return this given game object //
	public static GameObject setLocalsTo(this GameObject gameObject, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setLocalsTo(localPosition, localRotation, localScale, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's local transformations (local position, local rotation, local scale) respectively to the given transform's local position, local rotation, and local scale, then return this given game object //
	public static GameObject setLocalsTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setLocalsTo(transform.localPosition, transform.localRotation, transform.localScale, boolean);
	// method: (according to the given boolean:) set this given game object's local transformations (local position, local rotation, local scale) respectively to the other given game object's local position, local rotation, and local scale, then return this given game object //
	public static GameObject setLocalsTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setLocalsTo(otherGameObject.localPosition(), otherGameObject.localRotation(), otherGameObject.localScale(), boolean);
	// method: (according to the given boolean:) set this given game object's local transformations (local position, local rotation, local scale) respectively to the given component's local position, local rotation, and local scale, then return this given game object //
	public static GameObject setLocalsTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setLocalsTo(component.localPosition(), component.localRotation(), component.localScale(), boolean);
	// method: (according to the given boolean:) set this given game object's local transformations (local position, local euler angles, local scale) respectively to the given local position, local euler angles, and local scale, then return this given game object //
	public static GameObject setLocalsTo(this GameObject gameObject, Vector3 localPosition, Vector3 localEulerAngles, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setLocalsTo(localPosition, localEulerAngles, localScale, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's (nonscale) local transformations (local position, local rotation) respectively to the given local position and local rotation //
	public static GameObject setLocalsTo(this GameObject gameObject, Vector3 localPosition, Quaternion localRotation, bool boolean = true)
		=> gameObject.transform.setLocalsTo(localPosition, localRotation, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's (nonposition) local transformations (local rotation, local scale) respectively to the given local rotation and local scale //
	public static GameObject setLocalsTo(this GameObject gameObject, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setLocalsTo(localRotation, localScale, boolean).gameObject;

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
	public static GameObject setPositionTo(this GameObject gameObject, Vector3 position, bool boolean = true)
		=> gameObject.transform.setPositionTo(position, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's (global) position to the (global) position for the given x, y, and z values, then return this given game object //
	public static GameObject setPositionTo(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.setPositionTo(new Vector3(x, y, z), boolean);
	// method: (according to the given boolean:) set this given game object's position to the given transform's position, then return this given game object //
	public static GameObject setPositionTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setPositionTo(transform.position, boolean);
	// method: (according to the given boolean:) set this given transform's position to the other given game object's position, then return this given game object //
	public static GameObject setPositionTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setPositionTo(otherGameObject.position(), boolean);
	// method: (according to the given boolean:) set this given transform's position to the given component's position, then return this given game object //
	public static GameObject setPositionTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setPositionTo(component.position(), boolean);

	// method: (according to the given boolean:) set this given game object's (global) x position to the given x value, then return this given game object //
	public static GameObject setPositionXTo(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.setPositionXTo(x, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's x position to the given transform's x position, then return this given game object //
	public static GameObject setPositionXTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setPositionXTo(transform.positionX(), boolean);
	// method: (according to the given boolean:) set this given transform's x position to the other given game object's x position, then return this given game object //
	public static GameObject setPositionXTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setPositionXTo(otherGameObject.positionX(), boolean);
	// method: (according to the given boolean:) set this given transform's x position to the given component's x position, then return this given game object //
	public static GameObject setPositionXTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setPositionXTo(component.positionX(), boolean);

	// method: (according to the given boolean:) set this given game object's (global) y position to the given y value, then return this given game object //
	public static GameObject setPositionYTo(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.setPositionYTo(y, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's y position to the given transform's y position, then return this given game object //
	public static GameObject setPositionYTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setPositionYTo(transform.positionY(), boolean);
	// method: (according to the given boolean:) set this given transform's y position to the other given game object's y position, then return this given game object //
	public static GameObject setPositionYTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setPositionYTo(otherGameObject.positionY(), boolean);
	// method: (according to the given boolean:) set this given transform's y position to the given component's y position, then return this given game object //
	public static GameObject setPositionYTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setPositionYTo(component.positionY(), boolean);

	// method: (according to the given boolean:) set this given game object's (global) z position to the given z value, then return this given game object //
	public static GameObject setPositionZTo(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.setPositionZTo(z, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's z position to the given transform's z position, then return this given game object //
	public static GameObject setPositionZTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setPositionZTo(transform.positionZ(), boolean);

	// method: (according to the given boolean:) set this given transform's z position to the other given game object's z position, then return this given game object //
	public static GameObject setPositionZTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setPositionZTo(otherGameObject.positionZ(), boolean);

	// method: (according to the given boolean:) set this given transform's z position to the given component's z position, then return this given game object //
	public static GameObject setPositionZTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setPositionZTo(component.positionZ(), boolean);

	// method: (according to the given boolean:) set this given game object's (global) rotation to the given (global) rotation, then return this given game object //
	public static GameObject setRotationTo(this GameObject gameObject, Quaternion rotation, bool boolean = true)
		=> gameObject.transform.setRotationTo(rotation, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) rotation to the given transform's (global) rotation, then return this given game object //
	public static GameObject setRotationTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setRotationTo(transform.rotation(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) rotation to the other given game object's (global) rotation, then return this given game object //
	public static GameObject setRotationTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setRotationTo(otherGameObject.rotation(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) rotation to the given component's (global) rotation, then return this given game object //
	public static GameObject setRotationTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setRotationTo(component.rotation(), boolean);

	// method: (according to the given boolean:) set this given game object's (global) euler angles to the given (global) euler angles, then return this given game object //
	public static GameObject setEulerAnglesTo(this GameObject gameObject, Vector3 eulerAngles, bool boolean = true)
		=> gameObject.transform.setEulerAnglesTo(eulerAngles, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) euler angles to the (global) euler angles for the given x, y, and z values, then return this given game object //
	public static GameObject setEulerAnglesTo(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.transform.setEulerAnglesTo(x, y, z, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) euler angles to the given transform's (global) euler angles, then return this given game object //
	public static GameObject setEulerAnglesTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setEulerAnglesTo(transform.eulerAngles(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) euler angles to the other given game object's (global) euler angles, then return this given game object //
	public static GameObject setEulerAnglesTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setEulerAnglesTo(otherGameObject.eulerAngles(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) euler angles to the given component's (global) euler angles, then return this given game object //
	public static GameObject setEulerAnglesTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setEulerAnglesTo(component.eulerAngles(), boolean);

	// method: (according to the given boolean:) set this given game object's (global) x euler angle to the given x value, then return this given game object //
	public static GameObject setEulerAngleXTo(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.transform.setEulerAngleXTo(x, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) x euler angle to the given transform's (global) x euler angle, then return this given game object //
	public static GameObject setEulerAngleXTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setEulerAngleXTo(transform.eulerAngleX(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) x euler angle to the other given game object's (global) x euler angle, then return this given game object //
	public static GameObject setEulerAngleXTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setEulerAngleXTo(otherGameObject.eulerAngleX(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) x euler angle to the given component's (global) x euler angle, then return this given game object //
	public static GameObject setEulerAngleXTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setEulerAngleXTo(component.eulerAngleX(), boolean);

	// method: (according to the given boolean:) set this given game object's (global) y euler angle to the given y value, then return this given game object //
	public static GameObject setEulerAngleYTo(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.setEulerAngleYTo(y, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) y euler angle to the given transform's (global) y euler angle, then return this given game object //
	public static GameObject setEulerAngleYTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setEulerAngleYTo(transform.eulerAngleY(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) y euler angle to the other given game object's (global) y euler angle, then return this given game object //
	public static GameObject setEulerAngleYTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setEulerAngleYTo(otherGameObject.eulerAngleY(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) y euler angle to the given component's (global) y euler angle, then return this given game object //
	public static GameObject setEulerAngleYTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setEulerAngleYTo(component.eulerAngleY(), boolean);

	// method: (according to the given boolean:) set this given game object's (global) z euler angle to the given z value, then return this given game object //
	public static GameObject setEulerAngleZTo(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.setEulerAngleZTo(z, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) z euler angle to the given transform's (global) z euler angle, then return this given game object //
	public static GameObject setEulerAngleZTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setEulerAngleZTo(transform.eulerAngleZ(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) z euler angle to the other given game object's (global) z euler angle, then return this given game object //
	public static GameObject setEulerAngleZTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setEulerAngleZTo(otherGameObject.eulerAngleZ(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) z euler angle to the given component's (global) z euler angle, then return this given game object //
	public static GameObject setEulerAngleZTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setEulerAngleZTo(component.eulerAngleZ(), boolean);

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) respectively to the given (global) position and (global) rotation //
	public static GameObject setGlobalsTo(this GameObject gameObject, Vector3 position, Quaternion rotation, bool boolean = true)
		=> gameObject.transform.setGlobalsTo(position, rotation, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) respectively to the given transform's (global) position and (global) rotation //
	public static GameObject setGlobalsTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setGlobalsTo(transform.position, transform.rotation, boolean);

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) respectively to the other given game object's (global) position and (global) rotation //
	public static GameObject setGlobalsTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setGlobalsTo(otherGameObject.position(), otherGameObject.rotation(), boolean);

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) respectively to the given component's (global) position and (global) rotation //
	public static GameObject setGlobalsTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setGlobalsTo(component.position(), component.rotation(), boolean);

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global euler angles) respectively to the given (global) position and (global) euler angles //
	public static GameObject setGlobalsTo(this GameObject gameObject, Vector3 position, Vector3 eulerAngles, bool boolean = true)
		=> gameObject.transform.setGlobalsTo(position, eulerAngles, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) and local scale respectively to the given (global) position and (global) rotation and local scale //
	public static GameObject setGlobalsAndLocalScaleTo(this GameObject gameObject, Vector3 position, Quaternion rotation, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setGlobalsAndLocalScaleTo(position, rotation, localScale, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) and local scale respectively to the given transform's (global) position and (global) rotation and local scale //
	public static GameObject setGlobalsAndLocalScaleTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setGlobalsAndLocalScaleTo(transform.position, transform.rotation, transform.localScale, boolean);

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) and local scale respectively to the other given game object's (global) position and (global) rotation and local scale //
	public static GameObject setGlobalsAndLocalScaleTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setGlobalsAndLocalScaleTo(otherGameObject.position(), otherGameObject.rotation(), otherGameObject.localScale(), boolean);

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) and local scale respectively to the given component's (global) position and (global) rotation and local scale //
	public static GameObject setGlobalsAndLocalScaleTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setGlobalsAndLocalScaleTo(component.position(), component.rotation(), component.localScale(), boolean);

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global euler angles) and local scale respectively to the given (global) position and (global) euler angles and local scale //
	public static GameObject setGlobalsAndLocalScaleTo(this GameObject gameObject, Vector3 position, Vector3 eulerAngles, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setGlobalsAndLocalScaleTo(position, eulerAngles, localScale, boolean).gameObject;
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


	#region selection
	
	// method: return a selection of the transforms for this given enumerable of game objects //
	public static IEnumerable<Transform> selectTransforms(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.select(gameObject => gameObject.transform);

	// method: return an selection of local positions corresponding to this given array of game objects //
	public static IEnumerable<Vector3> selectLocalPositions(this GameObject[] gameObjects)
		=> gameObjects.select(gameObject => gameObject.localPosition());

	// method: return a selection of local scales corresponding to this given array of game objects //
	public static IEnumerable<Vector3> selectLocalScales(this GameObject[] gameObjects)
		=> gameObjects.select(gameObject => gameObject.localScale());

	// method: return a selection of (global) positions corresponding to this given array of game objects //
	public static IEnumerable<Vector3> selectPositions(this GameObject[] gameObjects)
		=> gameObjects.select(gameObject => gameObject.position());
	#endregion selection


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


	#region child lights

	public static float[] childLightsIntensities(this GameObject gameObject)
		=> gameObject.children<Light>().intensities();
	
	public static GameObject setChildLightsIntensitiesTo(this GameObject gameObject, float[] targetIntensities)
	{
		gameObject.children<Light>().setIntensitiesTo(targetIntensities);

		return gameObject;
	}

	public static GameObject setChildLightsIntensitiesTo(this GameObject gameObject, float targetIntensity)
		=> gameObject.setChildLightsIntensitiesTo(new float[] {targetIntensity});

	public static GameObject renderChildLightsBy(this GameObject gameObject, LightRenderMode lightRenderMode)
	{
		gameObject.children<Light>().renderBy(lightRenderMode);

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