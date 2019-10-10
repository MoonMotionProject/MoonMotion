using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameObject Transformation Extensions: provides extension methods for handling game object transformations
// #auto #transform #transformations
public static class GameObjectTransformationExtensions
{
	// method: return this given game object's local position //
	public static Vector3 localPosition(this GameObject gameObject)
		=> gameObject.transform.localPosition;
	// method: return an selection of local positions corresponding to these given game objects //
	public static IEnumerable<Vector3> selectLocalPositions(this IList<GameObject> gameObjects)
		=> gameObjects.select(gameObject => gameObject.localPosition());// method: (according to the given boolean:) set this given game object's local position to the given local position, then return this given game object //
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
		=> gameObject.setLocalPositionTo(component.localPosition(), boolean);// method: (according to the given boolean:) reset this given game object's local position to zeroes, then return this given game object //
	public static GameObject resetLocalPosition(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalPosition(boolean).gameObject;



	// method: return this given game object's local x position //
	public static float localPositionX(this GameObject gameObject)
		=> gameObject.transform.localPositionX();
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
	// method: (according to the given boolean:) reset this given game object's local x position to zero, then return this given game object //
	public static GameObject resetLocalPositionX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalPositionX(boolean).gameObject;



	// method: return this given game object's local y position //
	public static float localPositionY(this GameObject gameObject)
		=> gameObject.transform.localPositionY();
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
	// method: (according to the given boolean:) reset this given game object's local y position to zero, then return this given game object //
	public static GameObject resetLocalPositionY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalPositionY(boolean).gameObject;
	// method: (according to the given boolean:) negate this given game object's local y position, then return this given game object //
	public static GameObject negateLocalPositionY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.negateLocalPositionY(boolean).gameObject;



	// method: return this given game object's local z position //
	public static float localPositionZ(this GameObject gameObject)
		=> gameObject.transform.localPositionZ();
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
	// method: (according to the given boolean:) reset this given game object's local z position to zero, then return this given game object //
	public static GameObject resetLocalPositionZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalPositionZ(boolean).gameObject;



	// method: return this given game object's local rotation //
	public static Quaternion localRotation(this GameObject gameObject)
		=> gameObject.transform.localRotation;
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
	// method: (according to the given boolean:) reset this given game object's local rotation to no rotation, then return this given game object //
	public static GameObject resetLocalRotation(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalRotation(boolean).gameObject;



	// method: return this given game object's local euler angles //
	public static Vector3 localEulerAngles(this GameObject gameObject)
		=> gameObject.transform.localEulerAngles;
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
	// method: (according to the given boolean:) reset this given game object's local euler angles to zeroes, then return this given game object //
	public static GameObject resetLocalEulerAngles(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalEulerAngles(boolean).gameObject;



	// method: return this given game object's local x euler angle //
	public static float localEulerAngleX(this GameObject gameObject)
		=> gameObject.transform.localEulerAngleX();
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
	// method: (according to the given boolean:) reset this given game object's local x euler angle to zero, then return this given game object //
	public static GameObject resetLocalEulerAngleX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalEulerAngleX(boolean).gameObject;



	// method: return this given game object's local y euler angle //
	public static float localEulerAngleY(this GameObject gameObject)
		=> gameObject.transform.localEulerAngleY();
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
	// method: (according to the given boolean:) reset this given game object's local y euler angle to zero, then return this given game object //
	public static GameObject resetLocalEulerAngleY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalEulerAngleY(boolean).gameObject;



	// method: return this given game object's local z euler angle //
	public static float localEulerAngleZ(this GameObject gameObject)
		=> gameObject.transform.localEulerAngleZ();
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
	// method: (according to the given boolean:) reset this given game object's local z euler angle to zero, then return this given game object //
	public static GameObject resetLocalEulerAngleZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalEulerAngleZ(boolean).gameObject;



	// method: return this given game object's local scale //
	public static Vector3 localScale(this GameObject gameObject)
		=> gameObject.transform.localScale;
	// method: return a selection of local scales corresponding to these given game objects //
	public static IEnumerable<Vector3> selectLocalScales(this IList<GameObject> gameObjects)
		=> gameObjects.select(gameObject => gameObject.localScale());
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
	// method: (according to the given boolean:) reset this given game object's local scale to ones, then return this given game object //
	public static GameObject resetLocalScale(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalScale(boolean).gameObject;



	// method: return this given game object's local x scale //
	public static float localScaleX(this GameObject gameObject)
		=> gameObject.transform.localScaleX();
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
	// method: (according to the given boolean:) reset this given game object's local x scale to one, then return this given game object //
	public static GameObject resetLocalScaleX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalScaleX(boolean).gameObject;



	// method: return this given game object's local y scale //
	public static float localScaleY(this GameObject gameObject)
		=> gameObject.transform.localScaleY();
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
	// method: (according to the given boolean:) reset this given game object's local y scale to one, then return this given game object //
	public static GameObject resetLocalScaleY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalScaleY(boolean).gameObject;



	// method: return this given game object's local z scale //
	public static float localScaleZ(this GameObject gameObject)
		=> gameObject.transform.localScaleZ();
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
	// method: (according to the given boolean:) reset this given game object's local z scale to one, then return this given game object //
	public static GameObject resetLocalScaleZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalScaleZ(boolean).gameObject;



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
	// method: (according to the given boolean:) reset this given game object's local transformations (local position, local rotation, local scale) respectively to the zeroes, no rotation, and ones, then return this given game object //
	public static GameObject resetLocals(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocals(boolean).gameObject;



	// method: (according to the given boolean:) set this given game object's local transformations to its parent's while temporarily childed to the given transform, then return this given game object //
	public static GameObject setLocalsParentlyForRelativeTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.transform.setLocalsParentlyForRelativeTo(transform, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's local transformations to its parent's while temporarily childed to the other given game object, then return this given game object //
	public static GameObject setLocalsParentlyForRelativeTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.transform.setLocalsParentlyForRelativeTo(otherGameObject, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's local transformations to its parent's while temporarily childed to the given component, then return this given game object //
	public static GameObject setLocalsParentlyForRelativeTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.transform.setLocalsParentlyForRelativeTo(component, boolean).gameObject;



	// method: return this given game object's (global) position //
	public static Vector3 position(this GameObject gameObject)
		=> gameObject.transform.position;
	// method: return a selection of (global) positions corresponding to these given game objects //
	public static IEnumerable<Vector3> selectPositions(this IList<GameObject> gameObjects)
		=> gameObjects.select(gameObject => gameObject.position());
	// method: (assumes this game object has a rigidbody attached:) (according to the given boolean:) move this given game object's (global) position to the given position provider (try to set, but respect collisions in the way), then return this given game object //
	public static GameObject movePositionTo(this GameObject gameObject, Vector3 position, bool boolean = true)
		=> gameObject.correspondingRigidbody().movePositionTo(position, boolean).gameObject;
	public static GameObject movePositionTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.movePositionTo(transform.position, boolean);
	public static GameObject movePositionTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.movePositionTo(otherGameObject.position(), boolean);
	public static GameObject movePositionTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.movePositionTo(component.position(), boolean);
	public static Vector3 positionForMovingPositionTo(this GameObject gameObject, Vector3 targetPosition)
		=> gameObject.correspondingRigidbody().positionForMovingPositionTo(targetPosition);
	public static Vector3 displacementForMovingPositionTo(this GameObject gameObject, Vector3 targetPosition)
		=> gameObject.correspondingRigidbody().displacementForMovingPositionTo(targetPosition);
	// method: (according to the given boolean:) set this given game object's (global) position to the given (global) position, then return this given game object //
	public static GameObject setPositionTo(this GameObject gameObject, Vector3 position, bool boolean = true)
		=> gameObject.transform.setPositionTo(position, boolean).gameObject;
	// method: (according to the given boolean:) set this given game object's (global) position to the (global) position for the given x, y, and z values, then return this given game object //
	public static GameObject setPositionTo(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.setPositionTo(new Vector3(x, y, z), boolean);
	// method: (according to the given boolean:) set this given game object's position to the given transform's position, then return this given game object //
	public static GameObject setPositionTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.setPositionTo(transform.position, boolean);
	// method: (according to the given boolean:) set this given game object's position to the other given game object's position, then return this given game object //
	public static GameObject setPositionTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.setPositionTo(otherGameObject.position(), boolean);
	// method: (according to the given boolean:) set this given game object's position to the given component's position, then return this given game object //
	public static GameObject setPositionTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.setPositionTo(component.position(), boolean);
	// method: (according to the given boolean:) set this given game object's position to the given raycast hit's position, then return this given game object //
	public static GameObject setPositionTo(this GameObject gameObject, RaycastHit raycastHit, bool boolean = true)
		=> gameObject.setPositionTo(raycastHit.position(), boolean);
	// method: (according to the given boolean:) reset this given game object's (global) position to zeroes, then return this given game object //
	public static GameObject resetPosition(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetPosition(boolean).gameObject;
	public static GameObject displacePositionBy(this GameObject gameObject, Vector3 displacement, bool boolean = true)
		=> gameObject.transform.displacePositionBy(displacement).gameObject;



	// method: return this given game object's (global) x position //
	public static float positionX(this GameObject gameObject)
		=> gameObject.transform.positionX();
	// methods: (assumes this game object has a rigidbody attached:) (according to the given boolean:) move this given game object's (global) x position to the given x position provider (try to set, but respect collisions in the way), then return this given game object //
	public static GameObject movePositionXTo(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.correspondingRigidbody().movePositionXTo(x, boolean).gameObject;
	public static GameObject movePositionXTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.movePositionXTo(transform.position.x, boolean);
	public static GameObject movePositionXTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.movePositionXTo(otherGameObject.position().x, boolean);
	public static GameObject movePositionXTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.movePositionXTo(component.position().x, boolean);
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
	// method: (according to the given boolean:) reset this given game object's (global) x position to zero, then return this given game object //
	public static GameObject resetPositionX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetPositionX(boolean).gameObject;



	// method: return this given game object's (global) y position //
	public static float positionY(this GameObject gameObject)
		=> gameObject.transform.positionY();
	// methods: (assumes this game object has a rigidbody attached:) (according to the given boolean:) move this given game object's (global) y position to the given y position provider (try to set, but respect collisions in the way), then return this given game object //
	public static GameObject movePositionYTo(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.correspondingRigidbody().movePositionYTo(y, boolean).gameObject;
	public static GameObject movePositionYTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.movePositionYTo(transform.position.y, boolean);
	public static GameObject movePositionYTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.movePositionYTo(otherGameObject.position().y, boolean);
	public static GameObject movePositionYTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.movePositionYTo(component.position().y, boolean);
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
	// method: (according to the given boolean:) reset this given game object's (global) y position to zero, then return this given game object //
	public static GameObject resetPositionY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetPositionY(boolean).gameObject;
	// method: (according to the given boolean:) negate this given game object's (global) y position, then return this given game object //
	public static GameObject negatePositionY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.negatePositionY(boolean).gameObject;



	// method: return this given game object's (global) z position //
	public static float positionZ(this GameObject gameObject)
		=> gameObject.transform.positionZ();
	// methods: (assumes this game object has a rigidbody attached:) (according to the given boolean:) move this given game object's (global) z position to the given z position provider (try to set, but respect collisions in the way), then return this given game object //
	public static GameObject movePositionZTo(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.correspondingRigidbody().movePositionZTo(z, boolean).gameObject;
	public static GameObject movePositionZTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.movePositionZTo(transform.position.z, boolean);
	public static GameObject movePositionZTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.movePositionZTo(otherGameObject.position().z, boolean);
	public static GameObject movePositionZTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.movePositionZTo(component.position().z, boolean);
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
	// method: (according to the given boolean:) reset this given game object's (global) z position to zero, then return this given game object //
	public static GameObject resetPositionZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetPositionZ(boolean).gameObject;



	// method: return this given game object's (global) rotation //
	public static Quaternion rotation(this GameObject gameObject)
		=> gameObject.transform.rotation;
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
	// method: (according to the given boolean:) reset this given game object's (global) rotation to no rotation, then return this given game object //
	public static GameObject resetRotation(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetRotation(boolean).gameObject;



	// method: return this given game object's (global) euler angles //
	public static Vector3 eulerAngles(this GameObject gameObject)
		=> gameObject.transform.eulerAngles;
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
	// method: (according to the given boolean:) reset this given game object's (global) euler angles to zeroes, then return this given game object //
	public static GameObject resetEulerAngles(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetEulerAngles(boolean).gameObject;



	// method: return this given game object's (global) x euler angle //
	public static float eulerAngleX(this GameObject gameObject)
		=> gameObject.transform.eulerAngleX();
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
	// method: (according to the given boolean:) reset this given game object's (global) x euler angles to zero, then return this given game object //
	public static GameObject resetEulerAngleX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetEulerAngleX(boolean).gameObject;



	// method: return this given game object's (global) y euler angle //
	public static float eulerAngleY(this GameObject gameObject)
		=> gameObject.transform.eulerAngleY();
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
	// method: (according to the given boolean:) reset this given game object's (global) y euler angles to zero, then return this given game object //
	public static GameObject resetEulerAngleY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetEulerAngleY(boolean).gameObject;



	// method: return this given game object's (global) z euler angle //
	public static float eulerAngleZ(this GameObject gameObject)
		=> gameObject.transform.eulerAngleZ();
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
	// method: (according to the given boolean:) reset this given game object's (global) z euler angles to zero, then return this given game object //
	public static GameObject resetEulerAngleZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetEulerAngleZ(boolean).gameObject;



	// method: (according to the given boolean:) set this given transform's (global) scale to the given transform's (global) scale, then return this given transform //
	public static GameObject setScaleTo(this GameObject gameObject, Transform transform, bool boolean = true)
		=> gameObject.transform.setScaleTo(transform, boolean).gameObject;
	// method: (according to the given boolean:) set this given transform's (global) scale to the other given game object's (global) scale, then return this given transform //
	public static GameObject setScaleTo(this GameObject gameObject, GameObject otherGameObject, bool boolean = true)
		=> gameObject.transform.setScaleTo(otherGameObject, boolean).gameObject;
	// method: (according to the given boolean:) set this given transform's (global) scale to the given component's (global) scale, then return this given transform //
	public static GameObject setScaleTo(this GameObject gameObject, Component component, bool boolean = true)
		=> gameObject.transform.setScaleTo(component, boolean).gameObject;



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
	// method: (according to the given boolean:) reset this given game object's global transformations (global position, global rotation) respectively to zeroes and no rotation //
	public static GameObject resetGlobals(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetGlobals(boolean).gameObject;



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
	// method: (according to the given boolean:) reset this given game object's global transformations (global position, global rotation) and local scale respectively to zeroes, no rotation, and ones //
	public static GameObject resetGlobalsAndLocalScale(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetGlobalsAndLocalScale(boolean).gameObject;



	// method: (according to the given boolean:) set this given game object's (global) transformations respectively to the given (global) position and (global) rotation, and set this given game object's (global) scale to the (global) scale of the given provided transform, then return this given game object //
	public static GameObject setTransformationsTo(this GameObject gameObject, Vector3 position, Quaternion rotation, object transform_TransformProvider, bool boolean = true)
	{
		Transform transform = Provide.transformVia(transform_TransformProvider);

		return gameObject.transform.setTransformationsTo(position, rotation, transform, boolean).gameObject;
	}
	// method: (according to the given boolean:) set this given game object's (global) transformations respectively to the given (global) position and (global) euler angles, and set this given game object's (global) scale to the (global) scale of the given provided transform, then return this given game object //
	public static GameObject setTransformationsTo(this GameObject gameObject, Vector3 position, Vector3 eulerAngles, object transform_TransformProvider, bool boolean = true)
	{
		Transform transform = Provide.transformVia(transform_TransformProvider);

		return gameObject.transform.setTransformationsTo(position, eulerAngles, transform, boolean).gameObject;
	}
	// method: (according to the given boolean:) set this given game object's (global) transformations respectively to (global) transformations of the given provided transform, then return this given game object //
	public static GameObject setTransformationsTo(this GameObject gameObject, object transform_TransformProvider, bool boolean = true)
	{
		Transform transform = Provide.transformVia(transform_TransformProvider);

		return gameObject.transform.setTransformationsTo(transform, boolean).gameObject;
	}
}