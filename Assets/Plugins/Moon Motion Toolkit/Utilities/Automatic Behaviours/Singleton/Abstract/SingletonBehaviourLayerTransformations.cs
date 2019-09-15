using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Transformations:
// #auto #transform #transformations
// • provides this singleton behaviour with static access to its automatic behaviour's transformations layer
public abstract class	SingletonBehaviourLayerTransformations<SingletonBehaviourT> :
					SingletonBehaviourLayerGameObject<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	public static new Vector3 localPosition => automaticBehaviour.localPosition;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionTo(Vector3 localPosition, bool boolean = true)
		=> automaticBehaviour.setLocalPositionTo(localPosition, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalPositionTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setLocalPositionTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setLocalPositionTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalPosition(bool boolean = true)
		=> automaticBehaviour.resetLocalPosition(boolean);


	public static new float localPositionX => automaticBehaviour.localPosition.x;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionXTo(float x, bool boolean = true)
		=> automaticBehaviour.setLocalPositionXTo(x, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionXTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalPositionXTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionXTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setLocalPositionXTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionXTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setLocalPositionXTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalPositionX(bool boolean = true)
		=> automaticBehaviour.resetLocalPositionX(boolean);

	public static new float localPositionY => automaticBehaviour.localPosition.y;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionYTo(float y, bool boolean = true)
		=> automaticBehaviour.setLocalPositionYTo(y, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionYTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalPositionYTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionYTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setLocalPositionYTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionYTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setLocalPositionYTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalPositionY(bool boolean = true)
		=> automaticBehaviour.resetLocalPositionY(boolean);

	public static new float localPositionZ => automaticBehaviour.localPosition.z;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionZTo(float z, bool boolean = true)
		=> automaticBehaviour.setLocalPositionZTo(z, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionZTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalPositionZTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionZTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setLocalPositionYTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionZTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setLocalPositionYTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalPositionZ(bool boolean = true)
		=> automaticBehaviour.resetLocalPositionZ(boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> negateLocalPositionY(bool boolean = true)
		=> automaticBehaviour.negateLocalPositionY(boolean);

	public static new Quaternion localRotation => automaticBehaviour.localRotation;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalRotationTo(Quaternion localRotation, bool boolean = true)
		=> automaticBehaviour.setLocalRotationTo(localRotation, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalRotationTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalRotationTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalRotationTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setLocalRotationTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalRotationTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setLocalRotationTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalRotation(bool boolean = true)
		=> automaticBehaviour.resetLocalRotation(boolean);

	public static new Vector3 localEulerAngles => automaticBehaviour.localEulerAngles;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAnglesTo(Vector3 localEulerAngles, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAnglesTo(localEulerAngles, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAnglesTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAnglesTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAnglesTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAnglesTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAnglesTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAnglesTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalEulerAngles(bool boolean = true)
		=> automaticBehaviour.resetLocalEulerAngles(boolean);

	public static new float localEulerAngleX => automaticBehaviour.localEulerAngleX;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleXTo(float localEulerAngleX, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleXTo(localEulerAngleX, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleXTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleXTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleXTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleXTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleXTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleXTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalEulerAngleX(bool boolean = true)
		=> automaticBehaviour.resetLocalEulerAngleX(boolean);

	public static new float localEulerAngleY => automaticBehaviour.localEulerAngleY;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleYTo(float localEulerAngleY, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleYTo(localEulerAngleY, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleYTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleYTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleYTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleYTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleYTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleYTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalEulerAngleY(bool boolean = true)
		=> automaticBehaviour.resetLocalEulerAngleY(boolean);

	public static new float localEulerAngleZ => automaticBehaviour.localEulerAngleZ;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleZTo(float localEulerAngleZ, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleZTo(localEulerAngleZ, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleZTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleZTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleZTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleZTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleZTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleZTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalEulerAngleZ(bool boolean = true)
		=> automaticBehaviour.resetLocalEulerAngleZ(boolean);

	public static new Vector3 localScale => automaticBehaviour.localScale;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleTo(Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setLocalScaleTo(localScale, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalScaleTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setLocalScaleTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setLocalScaleTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalScale(bool boolean = true)
		=> automaticBehaviour.resetLocalScale(boolean);

	public static new float localScaleX => automaticBehaviour.localScale.x;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleXTo(float x, bool boolean = true)
		=> automaticBehaviour.setLocalScaleXTo(x, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleXTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalScaleXTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleXTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setLocalScaleXTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleXTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setLocalScaleXTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalScaleX(bool boolean = true)
		=> automaticBehaviour.resetLocalScaleX(boolean);

	public static new float localScaleY => automaticBehaviour.localScale.y;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleYTo(float y, bool boolean = true)
		=> automaticBehaviour.setLocalScaleYTo(y, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleYTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalScaleYTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleYTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setLocalScaleYTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleYTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setLocalScaleYTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalScaleY(bool boolean = true)
		=> automaticBehaviour.resetLocalScaleY(boolean);

	public static new float localScaleZ => automaticBehaviour.localScale.z;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleZTo(float z, bool boolean = true)
		=> automaticBehaviour.setLocalScaleZTo(z, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleZTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalScaleZTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleZTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setLocalScaleZTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleZTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setLocalScaleZTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalScaleZ(bool boolean = true)
		=> automaticBehaviour.resetLocalScaleZ(boolean);

	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsTo(Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setLocalsTo(localPosition, localRotation, localScale, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalsTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setLocalsTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setLocalsTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocals(bool boolean = true)
		=> automaticBehaviour.resetLocals(boolean);

	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsTo(Vector3 localPosition, Vector3 localEulerAngles, Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setLocalsTo(localPosition, localEulerAngles, localScale, boolean);

	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsTo(Vector3 localPosition, Quaternion localRotation, bool boolean = true)
		=> automaticBehaviour.setLocalsTo(localPosition, localRotation, boolean);

	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsTo(Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setLocalsTo(localRotation, localScale, boolean);

	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsParentlyForRelativeTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalsParentlyForRelativeTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsParentlyForRelativeTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setLocalsParentlyForRelativeTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsParentlyForRelativeTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setLocalsParentlyForRelativeTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsParentlyForRelativeTo<OtherSingletonBehaviourT>(bool boolean = true) where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> automaticBehaviour.setLocalsParentlyForRelativeTo<OtherSingletonBehaviourT>(boolean);

	public static new Vector3 position => automaticBehaviour.position;
	public static new AutomaticBehaviour<SingletonBehaviourT> movePositionTo(Vector3 position, bool boolean = true)
		=> automaticBehaviour.movePositionTo(position, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> movePositionTo(Transform transform, bool boolean = true)
		=> automaticBehaviour.movePositionTo(transform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> movePositionTo(GameObject gameObject, bool boolean = true)
		=> automaticBehaviour.movePositionTo(gameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> movePositionTo(Component component, bool boolean = true)
		=> automaticBehaviour.movePositionTo(component, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionTo(Vector3 position, bool boolean = true)
		=> automaticBehaviour.setPositionTo(position, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setPositionTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setPositionTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setPositionTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetPosition(bool boolean = true)
		=> automaticBehaviour.resetPosition(boolean);

	public static new float positionX => automaticBehaviour.position.x;
	public static new AutomaticBehaviour<SingletonBehaviourT> movePositionXTo(float x, bool boolean = true)
		=> automaticBehaviour.movePositionXTo(x, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> movePositionXTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.movePositionXTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> movePositionXTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.movePositionXTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> movePositionXTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.movePositionXTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionXTo(float x, bool boolean = true)
		=> automaticBehaviour.setPositionXTo(x, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionXTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setPositionXTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionXTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setPositionXTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionXTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setPositionXTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetPositionX(bool boolean = true)
		=> automaticBehaviour.resetPositionX(boolean);

	public static new float positionY => automaticBehaviour.position.y;
	public static new AutomaticBehaviour<SingletonBehaviourT> movePositionYTo(float y, bool boolean = true)
		=> automaticBehaviour.movePositionYTo(y, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> movePositionYTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.movePositionYTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> movePositionYTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.movePositionYTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> movePositionYTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.movePositionYTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionYTo(float y, bool boolean = true)
		=> automaticBehaviour.setPositionYTo(y, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionYTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setPositionYTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionYTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setPositionYTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionYTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setPositionYTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetPositionY(bool boolean = true)
		=> automaticBehaviour.resetPositionY(boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> negatePositionY(bool boolean = true)
		=> automaticBehaviour.negatePositionY(boolean);

	public static new float positionZ => automaticBehaviour.position.z;
	public static new AutomaticBehaviour<SingletonBehaviourT> movePositionZTo(float z, bool boolean = true)
		=> automaticBehaviour.movePositionZTo(z, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> movePositionZTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.movePositionZTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> movePositionZTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.movePositionZTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> movePositionZTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.movePositionZTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionZTo(float z, bool boolean = true)
		=> automaticBehaviour.setPositionZTo(z, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionZTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setPositionZTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionZTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setPositionZTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionZTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setPositionZTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetPositionZ(bool boolean = true)
		=> automaticBehaviour.resetPositionZ(boolean);

	public static new Quaternion rotation => automaticBehaviour.rotation;
	public static new AutomaticBehaviour<SingletonBehaviourT> setRotationTo(Quaternion rotation, bool boolean = true)
		=> automaticBehaviour.setRotationTo(rotation, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setRotationTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setRotationTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setRotationTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setRotationTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setRotationTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setRotationTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetRotation(bool boolean = true)
		=> automaticBehaviour.resetRotation(boolean);

	public static new Vector3 eulerAngles => automaticBehaviour.eulerAngles;
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAnglesTo(Vector3 eulerAngles, bool boolean = true)
		=> automaticBehaviour.setEulerAnglesTo(eulerAngles, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAnglesTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setEulerAnglesTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAnglesTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setEulerAnglesTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAnglesTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setEulerAnglesTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetEulerAngles(bool boolean = true)
		=> automaticBehaviour.resetEulerAngles(boolean);

	public static new float eulerAngleX => automaticBehaviour.eulerAngleX;
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleXTo(float eulerAngleX, bool boolean = true)
		=> automaticBehaviour.setEulerAngleXTo(eulerAngleX, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleXTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setEulerAngleXTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleXTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setEulerAngleXTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleXTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setEulerAngleXTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetEulerAngleX(bool boolean = true)
		=> automaticBehaviour.resetEulerAngleX(boolean);

	public static new float eulerAngleY => automaticBehaviour.eulerAngleY;
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleYTo(float eulerAngleY, bool boolean = true)
		=> automaticBehaviour.setEulerAngleYTo(eulerAngleY, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleYTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setEulerAngleYTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleYTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setEulerAngleYTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleYTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setEulerAngleYTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetEulerAngleY(bool boolean = true)
		=> automaticBehaviour.resetEulerAngleY(boolean);

	public static new float eulerAngleZ => automaticBehaviour.eulerAngleZ;
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleZTo(float eulerAngleZ, bool boolean = true)
		=> automaticBehaviour.setEulerAngleZTo(eulerAngleZ, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleZTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setEulerAngleZTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleZTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setEulerAngleZTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleZTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setEulerAngleZTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetEulerAngleZ(bool boolean = true)
		=> automaticBehaviour.resetEulerAngleZ(boolean);

	public static new AutomaticBehaviour<SingletonBehaviourT> setGlobalsTo(Vector3 position, Quaternion rotation, bool boolean = true)
		=> automaticBehaviour.setGlobalsTo(position, rotation, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setGlobalsTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setGlobalsTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setGlobalsTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setGlobalsTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setGlobalsTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setGlobalsTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setGlobalsTo(Vector3 position, Vector3 eulerAngles, bool boolean = true)
		=> automaticBehaviour.setGlobalsTo(position, eulerAngles, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetGlobals(bool boolean = true)
		=> automaticBehaviour.resetGlobals(boolean);

	public static new AutomaticBehaviour<SingletonBehaviourT> setGlobalsAndLocalScaleTo(Vector3 position, Quaternion rotation, Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setGlobalsAndLocalScaleTo(position, rotation, localScale, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setGlobalsAndLocalScaleTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setGlobalsAndLocalScaleTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setGlobalsAndLocalScaleTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setGlobalsAndLocalScaleTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setGlobalsAndLocalScaleTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setGlobalsAndLocalScaleTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetGlobalsAndLocalScale(bool boolean = true)
		=> automaticBehaviour.resetGlobalsAndLocalScale(boolean);

	public static new AutomaticBehaviour<SingletonBehaviourT> setGlobalsAndLocalScaleTo(Vector3 position, Vector3 eulerAngles, Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setGlobalsAndLocalScaleTo(position, eulerAngles, localScale, boolean);
}