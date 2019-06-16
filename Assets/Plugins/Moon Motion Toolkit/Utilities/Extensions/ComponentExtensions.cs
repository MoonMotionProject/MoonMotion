using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Component Extensions: provides extension methods for handling components //
// #auto
public static class ComponentExtensions
{
	// methods for: destruction //

	// method: destroy this given component //
	public static void destroy(this Component component)
		=> UnityEngine.Object.Destroy(component);

	// method: destroy the game object of this given component //
	public static void destroyObject(this Component component)
		=> component.gameObject.destroy();

	// method: destroy all components in this given dictionary of components, then return this given dictionary of components //
	public static Dictionary<TKey, Component> destroyComponents<TKey>(this Dictionary<TKey, Component> dictionary)
	{
		dictionary.forEachValue(component => component.destroy());

		return dictionary;
	}


	// methods for: connection //

	// method: return the array of game objects corresponding to these given components //
	public static GameObject[] gameObjects(this Component[] components)
		=> components.Select(component => component.gameObject).ToArray();


	// methods for: searching for self or parent based on comparison //

	// method: return the first game object out of this given game object and its parent game objects (searching upward) to have a component of the given type (null if none found) //
	public static GameObject selfOrParentObjectWith<TComponent>(this GameObject gameObject) where TComponent : Component
	{
		if (gameObject.GetComponent<TComponent>())
		{
			return gameObject;
		}

		Transform transformAtCurrentLevel = gameObject.transform;
		while (transformAtCurrentLevel.parent)
		{
			Transform parentTransform = transformAtCurrentLevel.parent;
			if (parentTransform.GetComponent<TComponent>())
			{
				return parentTransform.gameObject;
			}

			transformAtCurrentLevel = parentTransform;
		}

		return null;
	}

	// method: return the first game object out of the game object for this component and that game object's parent game objects (searching upward) to have a component of the given type (null if none found) //
	public static GameObject selfOrParentObjectWith<TComponent>(this Component component) where TComponent : Component
		=> component.gameObject.selfOrParentObjectWith<TComponent>();

	// method: return the transform of the first game object out of this given game object and its parent game objects (searching upward) to have a component of the given type (null if none found) //
	public static Transform selfOrParentTransformWith<TComponent>(this GameObject gameObject) where TComponent : Component
		=> gameObject.selfOrParentObjectWith<TComponent>().transform;

	// method: return the transform of the first game object out of the game object for this component and that game object's parent game objects (searching upward) to have a component of the given type (null if none found) //
	public static Transform selfOrParentTransformWith<TComponent>(this Component component) where TComponent : Component
		=> component.gameObject.selfOrParentTransformWith<TComponent>();


	// methods for: acting //

	// method: invoke the given action on each of these given components, then return them //
	public static TComponent[] ForEachComponent<TComponent>(this TComponent[] components, Action<TComponent> action) where TComponent : Component
	{
		foreach (TComponent component in components)
		{
			action.Invoke(component);
		}

		return components;
	}

	// method: get the given type of component on this given game object, then invoke the given success action on the component or invoke the given failure action depending on whether the given type of component was successfully gotten, returning the component if successful and otherwise returning null //
	public static TComponent GetComponent<TComponent>(this GameObject gameObject, Action<TComponent> success, Action failure) where TComponent : Component
	{
		TComponent component = gameObject.GetComponent<TComponent>();

		if (component)
		{
			success.Invoke(component);
			return component;
		}
		else
		{
			failure.Invoke();
			return null;
		}
	}


	// methods for: transform parent //

	// method: return the parent of the transform of this given component //
	public static Transform parent<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.parent;

	// method: return the parent object of the transform of this given component //
	public static GameObject parentObject<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.parentObject();

	// method: (according to the given boolean:) set the parent of this given component's transform to the given parent transform, then return this given component //
	public static TComponent setParent<TComponent>(this TComponent component, Transform parent, bool boolean = true) where TComponent : Component
	{
		component.transform.setParent(parent, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the parent of this given component's transform to the transform of the given game object, then return this given component //
	public static TComponent setParent<TComponent>(this TComponent component, GameObject parentObject, bool boolean = true) where TComponent : Component
		=> component.setParent(parentObject.transform, boolean);

	// method: (according to the given boolean:) set the parent of this given component's transform to the transform of the given component, then return this given component //
	public static TComponent setParent<TComponent>(this TComponent component, Component parentComponent, bool boolean = true) where TComponent : Component
		=> component.setParent(parentComponent.transform, boolean);

	// method: (according to the given boolean:) unparent the transform of this given component (set its parent to null), then return this given component //
	public static TComponent unparent<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.unparent(boolean);

		return component;
	}


	// methods for: children iteration //

	// method: invoke the given action on each child transform of this given component's transform, then return this given component //
	public static TComponent forEachChildTransform<TComponent>(this TComponent component, Action<Transform> action) where TComponent : Component
	{
		component.transform.forEachChildTransform(action);

		return component;
	}

	// method: set the enablement of all child objects of the transform of this given component to the given boolean, then return this given component //
	public static TComponent setEnablementOfChildrenTo<TComponent>(this TComponent component, bool boolean) where TComponent : Component
	{
		component.transform.setEnablementOfChildrenTo(boolean);

		return component;
	}

	// method: destroy all of the children of the game object of this given component, then return this given component //
	public static TComponent destroyChildren<TComponent>(this TComponent component) where TComponent : Component
	{
		component.gameObject.destroyChildren();

		return component;
	}


	// methods for: getting transformations //

	// method: return the local position of the transform of this given component //
	public static Vector3 localPosition<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.localPosition;

	// method: return the local x position of the transform of this given component //
	public static float localPositionX<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.localPositionX();

	// method: return the local y position of the transform of this given component //
	public static float localPositionY<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.localPositionY();

	// method: return the local z position of the transform of this given component //
	public static float localPositionZ<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.localPositionZ();

	// method: return the local rotation of the transform of this given component //
	public static Quaternion localRotation<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.localRotation;

	// method: return the local euler angles of the transform of this given component //
	public static Vector3 localEulerAngles<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.localEulerAngles;

	// method: return the local x euler angle of the transform of this given component //
	public static float localEulerAngleX<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.localEulerAngleX();

	// method: return the local y euler angle of the transform of this given component //
	public static float localEulerAngleY<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.localEulerAngleY();

	// method: return the local z euler angle of the transform of this given component //
	public static float localEulerAngleZ<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.localEulerAngleZ();

	// method: return the local scale of the transform of this given component //
	public static Vector3 localScale<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.localScale;

	// method: return the local x scale of the transform of this given component //
	public static float localScaleX<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.localScaleX();

	// method: return the local y scale of the transform of this given component //
	public static float localScaleY<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.localScaleY();

	// method: return the local z scale of the transform of this given component //
	public static float localScaleZ<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.localScaleZ();

	// method: return the (global) position of the transform of this given component //
	public static Vector3 position<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.position;

	// method: return the (global) x position of the transform of this given component //
	public static float positionX<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.positionX();

	// method: return the (global) y position of the transform of this given component //
	public static float positionY<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.positionY();

	// method: return the (global) z position of the transform of this given component //
	public static float positionZ<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.positionZ();

	// method: return the (global) rotation of the transform of this given component //
	public static Quaternion rotation<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.rotation;

	// method: return the (global) euler angles of the transform of this given component //
	public static Vector3 eulerAngles<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.eulerAngles;

	// method: return the (global) x euler angle of the transform of this given component //
	public static float eulerAngleX<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.eulerAngleX();

	// method: return the (global) y euler angle of the transform of this given component //
	public static float eulerAngleY<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.eulerAngleY();

	// method: return the (global) z euler angle of the transform of this given component //
	public static float eulerAngleZ<TComponent>(this TComponent component) where TComponent : Component
		=> component.transform.eulerAngleZ();


	// methods for: setting transformations //

	// method: (according to the given boolean:) set the local position of the transform of this given component to the given local position, then return this given component //
	public static TComponent setLocalPosition<TComponent>(this TComponent component, Vector3 localPosition, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocalPosition(localPosition, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local position of the transform of this given component to the local position for the given x, y, and z values, then return this given component //
	public static TComponent setLocalPosition<TComponent>(this TComponent component, float x, float y, float z, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocalPosition(x, y, z, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local x position of the transform of this given component to the given x value, then return this given component //
	public static TComponent setLocalPositionX<TComponent>(this TComponent component, float x, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocalPositionX(x, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local y position of the transform of this given component to the given y value, then return this given component //
	public static TComponent setLocalPositionY<TComponent>(this TComponent component, float y, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocalPositionY(y, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local z position of the transform of this given component to the given z value, then return this given component //
	public static TComponent setLocalPositionZ<TComponent>(this TComponent component, float z, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocalPositionZ(z, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local rotation of the transform of this given component to the given local rotation, then return this given component //
	public static TComponent setLocalRotation<TComponent>(this TComponent component, Quaternion localRotation, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocalRotation(localRotation, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local euler angles of the transform of this given component to the given local euler angles, then return this given component //
	public static TComponent setLocalEulerAngles<TComponent>(this TComponent component, Vector3 localEulerAngles, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocalEulerAngles(localEulerAngles, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local euler angles of the transform of this given component to the local euler angles for the given x, y, and z values, then return this given component //
	public static TComponent setLocalEulerAngles<TComponent>(this TComponent component, float x, float y, float z, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocalEulerAngles(x, y, z, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local x euler angle of the transform of this given component to the given x value, then return this given component //
	public static TComponent setLocalEulerAngleX<TComponent>(this TComponent component, float x, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocalEulerAngleX(x, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local y euler angle of the transform of this given component to the given y value, then return this given component //
	public static TComponent setLocalEulerAngleY<TComponent>(this TComponent component, float y, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocalEulerAngleY(y, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local z euler angle of the transform of this given component to the given z value, then return this given component //
	public static TComponent setLocalEulerAngleZ<TComponent>(this TComponent component, float z, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocalEulerAngleZ(z, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local scale of the transform of this given component to the given local scale, then return this given component //
	public static TComponent setLocalScale<TComponent>(this TComponent component, Vector3 localScale, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocalScale(localScale, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local scale of the transform of this given component to the local scale for the given x, y, and z values, then return this given component //
	public static TComponent setLocalScale<TComponent>(this TComponent component, float x, float y, float z, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocalScale(x, y, z, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local x scale of the transform of this given component to the given x value, then return this given component //
	public static TComponent setLocalScaleX<TComponent>(this TComponent component, float x, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocalScaleX(x, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local y scale of the transform of this given component to the given y value, then return this given component //
	public static TComponent setLocalScaleY<TComponent>(this TComponent component, float y, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocalScaleY(y, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local z scale of the transform of this given component to the given z value, then return this given component //
	public static TComponent setLocalScaleZ<TComponent>(this TComponent component, float z, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocalScaleZ(z, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local transformations (local position, local rotation, local scale) for the transform of this given component respectively to the given local position, local rotation, and local scale, then return this given component //
	public static TComponent setLocals<TComponent>(this TComponent component, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocals(localPosition, localRotation, localScale, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local transformations (local position, local euler angles, local scale) for the transform of this given component respectively to the given local position, local euler angles, and local scale, then return this given component //
	public static TComponent setLocals<TComponent>(this TComponent component, Vector3 localPosition, Vector3 localEulerAngles, Vector3 localScale, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocals(localPosition, localEulerAngles, localScale, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (nonscale) local transformations (local position, local rotation) for the transform of this given component respectively to the given local position and local rotation //
	public static TComponent setLocals<TComponent>(this TComponent component, Vector3 localPosition, Quaternion localRotation, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocals(localPosition, localRotation, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (nonposition) local transformations (local rotation, local scale) for the transform of this given component respectively to the given local rotation and local scale //
	public static TComponent setLocals<TComponent>(this TComponent component, Quaternion localRotation, Vector3 localScale, bool boolean = true) where TComponent : Component
	{
		component.transform.setLocals(localRotation, localScale, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (global) position for the transform of this given component to the given (global) position, then return this given component //
	public static TComponent setPosition<TComponent>(this TComponent component, Vector3 position, bool boolean = true) where TComponent : Component
	{
		component.transform.setPosition(position, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (global) position for the transform of this given component to the (global) position for the given x, y, and z values, then return this given component //
	public static TComponent setPosition<TComponent>(this TComponent component, float x, float y, float z, bool boolean = true) where TComponent : Component
	{
		component.transform.setPosition(x, y, z, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (global) x position for the transform of this given component to the given x value, then return this given component //
	public static TComponent setPositionX<TComponent>(this TComponent component, float x, bool boolean = true) where TComponent : Component
	{
		component.transform.setPositionX(x, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (global) y position for the transform of this given component to the given y value, then return this given component //
	public static TComponent setPositionY<TComponent>(this TComponent component, float y, bool boolean = true) where TComponent : Component
	{
		component.transform.setPositionY(y, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (global) z position for the transform of this given component to the given z value, then return this given component //
	public static TComponent setPositionZ<TComponent>(this TComponent component, float z, bool boolean = true) where TComponent : Component
	{
		component.transform.setPositionZ(z, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (global) rotation for the transform of this given component to the given (global) rotation, then return this given component //
	public static TComponent setRotation<TComponent>(this TComponent component, Quaternion rotation, bool boolean = true) where TComponent : Component
	{
		component.transform.setRotation(rotation, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (global) euler angles of the transform of this given component to the given (global) euler angles, then return this given component //
	public static TComponent setEulerAngles<TComponent>(this TComponent component, Vector3 eulerAngles, bool boolean = true) where TComponent : Component
	{
		component.transform.setEulerAngles(eulerAngles, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (global) euler angles of the transform of this given component to the (global) euler angles for the given x, y, and z values, then return this given component //
	public static TComponent setEulerAngles<TComponent>(this TComponent component, float x, float y, float z, bool boolean = true) where TComponent : Component
	{
		component.transform.setEulerAngles(x, y, z, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (global) x euler angle of the transform of this given component to the given x value, then return this given component //
	public static TComponent setEulerAngleX<TComponent>(this TComponent component, float x, bool boolean = true) where TComponent : Component
	{
		component.transform.setEulerAngleX(x, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (global) y euler angle of the transform of this given component to the given y value, then return this given component //
	public static TComponent setEulerAngleY<TComponent>(this TComponent component, float y, bool boolean = true) where TComponent : Component
	{
		component.transform.setEulerAngleY(y, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (global) z euler angle of the transform of this given component to the given z value, then return this given component //
	public static TComponent setEulerAngleZ<TComponent>(this TComponent component, float z, bool boolean = true) where TComponent : Component
	{
		component.transform.setEulerAngleZ(z, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the global transformations (global position, global rotation) for the transform of this given component respectively to the given (global) position and (global) rotation //
	public static TComponent setGlobals<TComponent>(this TComponent component, Vector3 position, Quaternion rotation, bool boolean = true) where TComponent : Component
	{
		component.transform.setGlobals(position, rotation, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the global transformations (global position, global euler angles) for the transform of this given component respectively to the given (global) position and (global) euler angles //
	public static TComponent setGlobals<TComponent>(this TComponent component, Vector3 position, Vector3 eulerAngles, bool boolean = true) where TComponent : Component
	{
		component.transform.setGlobals(position, eulerAngles, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the global transformations (global position, global rotation) and local scale for the transform of this given component respectively to the given (global) position and (global) rotation and local scale //
	public static TComponent setGlobalsAndLocalScale<TComponent>(this TComponent component, Vector3 position, Quaternion rotation, Vector3 localScale, bool boolean = true) where TComponent : Component
	{
		component.transform.setGlobalsAndLocalScale(position, rotation, localScale, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the global transformations (global position, global euler angles) and local scale for the transform of this given component respectively to the given (global) position and (global) euler angles and local scale //
	public static TComponent setGlobalsAndLocalScale<TComponent>(this TComponent component, Vector3 position, Vector3 eulerAngles, Vector3 localScale, bool boolean = true) where TComponent : Component
	{
		component.transform.setGlobalsAndLocalScale(position, eulerAngles, localScale, boolean);

		return component;
	}


	// methods for: resetting transformations //

	// method: (according to the given boolean:) reset the local position for the transform of this given component to zeroes, then return this given component //
	public static TComponent resetLocalPosition<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetLocalPosition(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local x position for the transform of this given component to zero, then return this given component //
	public static TComponent resetLocalPositionX<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetLocalPositionX(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the localy position for the transform of this given component to zero, then return this given component //
	public static TComponent resetLocalPositionY<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetLocalPositionY(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local z position for the transform of this given component to zero, then return this given component //
	public static TComponent resetLocalPositionZ<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetLocalPositionZ(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local rotation for the transform of this given component to no rotation, then return this given component //
	public static TComponent resetLocalRotation<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetLocalRotation(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local euler angles for the transform of this given component to zeroes, then return this given component //
	public static TComponent resetLocalEulerAngles<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetLocalEulerAngles(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local x euler angle for the transform of this given component to zero, then return this given component //
	public static TComponent resetLocalEulerAngleX<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetLocalEulerAngleX(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local y euler angle for the transform of this given component to zero, then return this given component //
	public static TComponent resetLocalEulerAngleY<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetLocalEulerAngleY(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local z euler angle for the transform of this given component to zero, then return this given component //
	public static TComponent resetLocalEulerAngleZ<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetLocalEulerAngleZ(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local scale for the transform of this given component to ones, then return this given component //
	public static TComponent resetLocalScale<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetLocalScale(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local x scale for the transform of this given component to one, then return this given component //
	public static TComponent resetLocalScaleX<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetLocalScaleX(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local y scale for the transform of this given component to one, then return this given component //
	public static TComponent resetLocalScaleY<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetLocalScaleY(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local z scale for the transform of this given component to one, then return this given component //
	public static TComponent resetLocalScaleZ<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetLocalScaleZ(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local transformations (local position, local rotation, local scale) for the transform of this given component respectively to the zeroes, no rotation, and ones, then return this given component //
	public static TComponent resetLocals<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetLocals(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) position for the transform of this given component to zeroes, then return this given component //
	public static TComponent resetPosition<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetPosition(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) x position for the transform of this given component to zero, then return this given component //
	public static TComponent resetPositionX<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetPositionX(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) y position for the transform of this given component to zero, then return this given component //
	public static TComponent resetPositionY<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetPositionY(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) z position for the transform of this given component to zero, then return this given component //
	public static TComponent resetPositionZ<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetPositionZ(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) rotation for the transform of this given component to no rotation, then return this given component //
	public static TComponent resetRotation<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetRotation(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) euler angles for the transform of this given component to zeroes, then return this given component //
	public static TComponent resetEulerAngles<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetEulerAngles(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) x euler angle for the transform of this given component to zero, then return this given component //
	public static TComponent resetEulerAngleX<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetEulerAngleX(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) y euler angle for the transform of this given component to zero, then return this given component //
	public static TComponent resetEulerAngleY<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetEulerAngleY(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) z euler angle for the transform of this given component to zero, then return this given component //
	public static TComponent resetEulerAngleZ<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetEulerAngleZ(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the global transformations (global position, global rotation) for the transform of this given component respectively to zeroes and no rotation //
	public static TComponent resetGlobals<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetGlobals(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the global transformations (global position, global rotation) and local scale for the transform of this given component respectively to zeroes, no rotation, and ones //
	public static TComponent resetGlobalsAndLocalScale<TComponent>(this TComponent component, bool boolean = true) where TComponent : Component
	{
		component.transform.resetGlobalsAndLocalScale(boolean);

		return component;
	}
}