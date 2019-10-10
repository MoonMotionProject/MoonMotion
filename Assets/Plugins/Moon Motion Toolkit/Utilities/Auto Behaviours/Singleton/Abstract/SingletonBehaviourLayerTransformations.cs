using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Transformations:
// #auto #transform #transformations
// • provides this singleton behaviour with static access to its auto behaviour's transformations layer
public abstract class	SingletonBehaviourLayerTransformations<SingletonBehaviourT> :
					SingletonBehaviourLayerGameObject<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	public static new Vector3 localPosition => autoBehaviour.localPosition;
	public static new AutoBehaviour<SingletonBehaviourT> setLocalPositionTo(Vector3 localPosition, bool boolean = true)
		=> autoBehaviour.setLocalPositionTo(localPosition, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalPositionTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setLocalPositionTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalPositionTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setLocalPositionTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalPositionTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setLocalPositionTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetLocalPosition(bool boolean = true)
		=> autoBehaviour.resetLocalPosition(boolean);


	public static new float localPositionX => autoBehaviour.localPosition.x;
	public static new AutoBehaviour<SingletonBehaviourT> setLocalPositionXTo(float x, bool boolean = true)
		=> autoBehaviour.setLocalPositionXTo(x, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalPositionXTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setLocalPositionXTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalPositionXTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setLocalPositionXTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalPositionXTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setLocalPositionXTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetLocalPositionX(bool boolean = true)
		=> autoBehaviour.resetLocalPositionX(boolean);

	public static new float localPositionY => autoBehaviour.localPosition.y;
	public static new AutoBehaviour<SingletonBehaviourT> setLocalPositionYTo(float y, bool boolean = true)
		=> autoBehaviour.setLocalPositionYTo(y, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalPositionYTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setLocalPositionYTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalPositionYTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setLocalPositionYTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalPositionYTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setLocalPositionYTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetLocalPositionY(bool boolean = true)
		=> autoBehaviour.resetLocalPositionY(boolean);

	public static new float localPositionZ => autoBehaviour.localPosition.z;
	public static new AutoBehaviour<SingletonBehaviourT> setLocalPositionZTo(float z, bool boolean = true)
		=> autoBehaviour.setLocalPositionZTo(z, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalPositionZTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setLocalPositionZTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalPositionZTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setLocalPositionYTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalPositionZTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setLocalPositionYTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetLocalPositionZ(bool boolean = true)
		=> autoBehaviour.resetLocalPositionZ(boolean);
	public static new AutoBehaviour<SingletonBehaviourT> negateLocalPositionY(bool boolean = true)
		=> autoBehaviour.negateLocalPositionY(boolean);

	public static new Quaternion localRotation => autoBehaviour.localRotation;
	public static new AutoBehaviour<SingletonBehaviourT> setLocalRotationTo(Quaternion localRotation, bool boolean = true)
		=> autoBehaviour.setLocalRotationTo(localRotation, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalRotationTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setLocalRotationTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalRotationTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setLocalRotationTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalRotationTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setLocalRotationTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetLocalRotation(bool boolean = true)
		=> autoBehaviour.resetLocalRotation(boolean);

	public static new Vector3 localEulerAngles => autoBehaviour.localEulerAngles;
	public static new AutoBehaviour<SingletonBehaviourT> setLocalEulerAnglesTo(Vector3 localEulerAngles, bool boolean = true)
		=> autoBehaviour.setLocalEulerAnglesTo(localEulerAngles, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalEulerAnglesTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setLocalEulerAnglesTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalEulerAnglesTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setLocalEulerAnglesTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalEulerAnglesTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setLocalEulerAnglesTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetLocalEulerAngles(bool boolean = true)
		=> autoBehaviour.resetLocalEulerAngles(boolean);

	public static new float localEulerAngleX => autoBehaviour.localEulerAngleX;
	public static new AutoBehaviour<SingletonBehaviourT> setLocalEulerAngleXTo(float localEulerAngleX, bool boolean = true)
		=> autoBehaviour.setLocalEulerAngleXTo(localEulerAngleX, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalEulerAngleXTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setLocalEulerAngleXTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalEulerAngleXTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setLocalEulerAngleXTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalEulerAngleXTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setLocalEulerAngleXTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetLocalEulerAngleX(bool boolean = true)
		=> autoBehaviour.resetLocalEulerAngleX(boolean);

	public static new float localEulerAngleY => autoBehaviour.localEulerAngleY;
	public static new AutoBehaviour<SingletonBehaviourT> setLocalEulerAngleYTo(float localEulerAngleY, bool boolean = true)
		=> autoBehaviour.setLocalEulerAngleYTo(localEulerAngleY, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalEulerAngleYTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setLocalEulerAngleYTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalEulerAngleYTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setLocalEulerAngleYTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalEulerAngleYTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setLocalEulerAngleYTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetLocalEulerAngleY(bool boolean = true)
		=> autoBehaviour.resetLocalEulerAngleY(boolean);

	public static new float localEulerAngleZ => autoBehaviour.localEulerAngleZ;
	public static new AutoBehaviour<SingletonBehaviourT> setLocalEulerAngleZTo(float localEulerAngleZ, bool boolean = true)
		=> autoBehaviour.setLocalEulerAngleZTo(localEulerAngleZ, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalEulerAngleZTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setLocalEulerAngleZTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalEulerAngleZTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setLocalEulerAngleZTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalEulerAngleZTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setLocalEulerAngleZTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetLocalEulerAngleZ(bool boolean = true)
		=> autoBehaviour.resetLocalEulerAngleZ(boolean);

	public static new Vector3 localScale => autoBehaviour.localScale;
	public static new AutoBehaviour<SingletonBehaviourT> setLocalScaleTo(Vector3 localScale, bool boolean = true)
		=> autoBehaviour.setLocalScaleTo(localScale, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalScaleTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setLocalScaleTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalScaleTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setLocalScaleTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalScaleTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setLocalScaleTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetLocalScale(bool boolean = true)
		=> autoBehaviour.resetLocalScale(boolean);

	public static new float localScaleX => autoBehaviour.localScale.x;
	public static new AutoBehaviour<SingletonBehaviourT> setLocalScaleXTo(float x, bool boolean = true)
		=> autoBehaviour.setLocalScaleXTo(x, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalScaleXTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setLocalScaleXTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalScaleXTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setLocalScaleXTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalScaleXTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setLocalScaleXTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetLocalScaleX(bool boolean = true)
		=> autoBehaviour.resetLocalScaleX(boolean);

	public static new float localScaleY => autoBehaviour.localScale.y;
	public static new AutoBehaviour<SingletonBehaviourT> setLocalScaleYTo(float y, bool boolean = true)
		=> autoBehaviour.setLocalScaleYTo(y, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalScaleYTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setLocalScaleYTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalScaleYTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setLocalScaleYTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalScaleYTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setLocalScaleYTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetLocalScaleY(bool boolean = true)
		=> autoBehaviour.resetLocalScaleY(boolean);

	public static new float localScaleZ => autoBehaviour.localScale.z;
	public static new AutoBehaviour<SingletonBehaviourT> setLocalScaleZTo(float z, bool boolean = true)
		=> autoBehaviour.setLocalScaleZTo(z, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalScaleZTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setLocalScaleZTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalScaleZTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setLocalScaleZTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalScaleZTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setLocalScaleZTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetLocalScaleZ(bool boolean = true)
		=> autoBehaviour.resetLocalScaleZ(boolean);

	public static new AutoBehaviour<SingletonBehaviourT> setLocalsTo(Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> autoBehaviour.setLocalsTo(localPosition, localRotation, localScale, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalsTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setLocalsTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalsTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setLocalsTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalsTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setLocalsTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetLocals(bool boolean = true)
		=> autoBehaviour.resetLocals(boolean);

	public static new AutoBehaviour<SingletonBehaviourT> setLocalsTo(Vector3 localPosition, Vector3 localEulerAngles, Vector3 localScale, bool boolean = true)
		=> autoBehaviour.setLocalsTo(localPosition, localEulerAngles, localScale, boolean);

	public static new AutoBehaviour<SingletonBehaviourT> setLocalsTo(Vector3 localPosition, Quaternion localRotation, bool boolean = true)
		=> autoBehaviour.setLocalsTo(localPosition, localRotation, boolean);

	public static new AutoBehaviour<SingletonBehaviourT> setLocalsTo(Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> autoBehaviour.setLocalsTo(localRotation, localScale, boolean);

	public static new AutoBehaviour<SingletonBehaviourT> setLocalsParentlyForRelativeTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setLocalsParentlyForRelativeTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalsParentlyForRelativeTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setLocalsParentlyForRelativeTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalsParentlyForRelativeTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setLocalsParentlyForRelativeTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setLocalsParentlyForRelativeTo<OtherSingletonBehaviourT>(bool boolean = true) where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.setLocalsParentlyForRelativeTo<OtherSingletonBehaviourT>(boolean);

	public static new Vector3 position => autoBehaviour.position;
	public static new AutoBehaviour<SingletonBehaviourT> movePositionTo(Vector3 position, bool boolean = true)
		=> autoBehaviour.movePositionTo(position, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> movePositionTo(Transform transform, bool boolean = true)
		=> autoBehaviour.movePositionTo(transform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> movePositionTo(GameObject gameObject, bool boolean = true)
		=> autoBehaviour.movePositionTo(gameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> movePositionTo(Component component, bool boolean = true)
		=> autoBehaviour.movePositionTo(component, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> movePositionTo(RaycastHit raycastHit, bool boolean = true)
		=> autoBehaviour.movePositionTo(raycastHit, boolean);
	public static new Vector3 positionForMovingPositionTo(Vector3 targetPosition)
		=> autoBehaviour.positionForMovingPositionTo(targetPosition);
	public static new Vector3 displacementForMovingPositionTo(Vector3 targetPosition)
		=> autoBehaviour.displacementForMovingPositionTo(targetPosition);
	public static new AutoBehaviour<SingletonBehaviourT> setPositionTo(Vector3 position, bool boolean = true)
		=> autoBehaviour.setPositionTo(position, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setPositionTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setPositionTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setPositionTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setPositionTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setPositionTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setPositionTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setPositionTo(RaycastHit raycastHit, bool boolean = true)
		=> autoBehaviour.setPositionTo(raycastHit, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetPosition(bool boolean = true)
		=> autoBehaviour.resetPosition(boolean);
	public static new AutoBehaviour<SingletonBehaviourT> displacePositionBy(Vector3 displacement, bool boolean = true)
		=> autoBehaviour.displacePositionBy(displacement, boolean);

	public static new float positionX => autoBehaviour.position.x;
	public static new AutoBehaviour<SingletonBehaviourT> movePositionXTo(float x, bool boolean = true)
		=> autoBehaviour.movePositionXTo(x, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> movePositionXTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.movePositionXTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> movePositionXTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.movePositionXTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> movePositionXTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.movePositionXTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setPositionXTo(float x, bool boolean = true)
		=> autoBehaviour.setPositionXTo(x, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setPositionXTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setPositionXTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setPositionXTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setPositionXTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setPositionXTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setPositionXTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetPositionX(bool boolean = true)
		=> autoBehaviour.resetPositionX(boolean);

	public static new float positionY => autoBehaviour.position.y;
	public static new AutoBehaviour<SingletonBehaviourT> movePositionYTo(float y, bool boolean = true)
		=> autoBehaviour.movePositionYTo(y, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> movePositionYTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.movePositionYTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> movePositionYTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.movePositionYTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> movePositionYTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.movePositionYTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setPositionYTo(float y, bool boolean = true)
		=> autoBehaviour.setPositionYTo(y, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setPositionYTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setPositionYTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setPositionYTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setPositionYTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setPositionYTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setPositionYTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetPositionY(bool boolean = true)
		=> autoBehaviour.resetPositionY(boolean);
	public static new AutoBehaviour<SingletonBehaviourT> negatePositionY(bool boolean = true)
		=> autoBehaviour.negatePositionY(boolean);

	public static new float positionZ => autoBehaviour.position.z;
	public static new AutoBehaviour<SingletonBehaviourT> movePositionZTo(float z, bool boolean = true)
		=> autoBehaviour.movePositionZTo(z, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> movePositionZTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.movePositionZTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> movePositionZTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.movePositionZTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> movePositionZTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.movePositionZTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setPositionZTo(float z, bool boolean = true)
		=> autoBehaviour.setPositionZTo(z, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setPositionZTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setPositionZTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setPositionZTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setPositionZTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setPositionZTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setPositionZTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetPositionZ(bool boolean = true)
		=> autoBehaviour.resetPositionZ(boolean);

	public static new Quaternion rotation => autoBehaviour.rotation;
	public static new AutoBehaviour<SingletonBehaviourT> setRotationTo(Quaternion rotation, bool boolean = true)
		=> autoBehaviour.setRotationTo(rotation, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setRotationTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setRotationTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setRotationTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setRotationTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setRotationTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setRotationTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetRotation(bool boolean = true)
		=> autoBehaviour.resetRotation(boolean);

	public static new Vector3 eulerAngles => autoBehaviour.eulerAngles;
	public static new AutoBehaviour<SingletonBehaviourT> setEulerAnglesTo(Vector3 eulerAngles, bool boolean = true)
		=> autoBehaviour.setEulerAnglesTo(eulerAngles, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setEulerAnglesTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setEulerAnglesTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setEulerAnglesTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setEulerAnglesTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setEulerAnglesTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setEulerAnglesTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetEulerAngles(bool boolean = true)
		=> autoBehaviour.resetEulerAngles(boolean);

	public static new float eulerAngleX => autoBehaviour.eulerAngleX;
	public static new AutoBehaviour<SingletonBehaviourT> setEulerAngleXTo(float eulerAngleX, bool boolean = true)
		=> autoBehaviour.setEulerAngleXTo(eulerAngleX, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setEulerAngleXTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setEulerAngleXTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setEulerAngleXTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setEulerAngleXTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setEulerAngleXTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setEulerAngleXTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetEulerAngleX(bool boolean = true)
		=> autoBehaviour.resetEulerAngleX(boolean);

	public static new float eulerAngleY => autoBehaviour.eulerAngleY;
	public static new AutoBehaviour<SingletonBehaviourT> setEulerAngleYTo(float eulerAngleY, bool boolean = true)
		=> autoBehaviour.setEulerAngleYTo(eulerAngleY, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setEulerAngleYTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setEulerAngleYTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setEulerAngleYTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setEulerAngleYTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setEulerAngleYTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setEulerAngleYTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetEulerAngleY(bool boolean = true)
		=> autoBehaviour.resetEulerAngleY(boolean);

	public static new float eulerAngleZ => autoBehaviour.eulerAngleZ;
	public static new AutoBehaviour<SingletonBehaviourT> setEulerAngleZTo(float eulerAngleZ, bool boolean = true)
		=> autoBehaviour.setEulerAngleZTo(eulerAngleZ, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setEulerAngleZTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setEulerAngleZTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setEulerAngleZTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setEulerAngleZTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setEulerAngleZTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setEulerAngleZTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetEulerAngleZ(bool boolean = true)
		=> autoBehaviour.resetEulerAngleZ(boolean);

	public static new AutoBehaviour<SingletonBehaviourT> setGlobalsTo(Vector3 position, Quaternion rotation, bool boolean = true)
		=> autoBehaviour.setGlobalsTo(position, rotation, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setGlobalsTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setGlobalsTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setGlobalsTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setGlobalsTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setGlobalsTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setGlobalsTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setGlobalsTo(Vector3 position, Vector3 eulerAngles, bool boolean = true)
		=> autoBehaviour.setGlobalsTo(position, eulerAngles, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetGlobals(bool boolean = true)
		=> autoBehaviour.resetGlobals(boolean);

	public static new AutoBehaviour<SingletonBehaviourT> setGlobalsAndLocalScaleTo(Vector3 position, Quaternion rotation, Vector3 localScale, bool boolean = true)
		=> autoBehaviour.setGlobalsAndLocalScaleTo(position, rotation, localScale, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setGlobalsAndLocalScaleTo(Transform otherTransform, bool boolean = true)
		=> autoBehaviour.setGlobalsAndLocalScaleTo(otherTransform, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setGlobalsAndLocalScaleTo(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.setGlobalsAndLocalScaleTo(otherGameObject, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setGlobalsAndLocalScaleTo(Component otherComponent, bool boolean = true)
		=> autoBehaviour.setGlobalsAndLocalScaleTo(otherComponent, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setGlobalsAndLocalScaleTo(Vector3 position, Vector3 eulerAngles, Vector3 localScale, bool boolean = true)
		=> autoBehaviour.setGlobalsAndLocalScaleTo(position, eulerAngles, localScale, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> resetGlobalsAndLocalScale(bool boolean = true)
		=> autoBehaviour.resetGlobalsAndLocalScale(boolean);
	
	public static new AutoBehaviour<SingletonBehaviourT> setTransformationsTo(Vector3 position, Quaternion rotation, object otherTransform_TransformProvider, bool boolean = true)
	{
		Transform otherTransform = Provide.transformVia(otherTransform_TransformProvider);

		return autoBehaviour.setTransformationsTo(position, rotation, otherTransform, boolean);
	}
	public static new AutoBehaviour<SingletonBehaviourT> setTransformationsTo(Vector3 position, Vector3 eulerAngles, object otherTransform_TransformProvider, bool boolean = true)
	{
		Transform otherTransform = Provide.transformVia(otherTransform_TransformProvider);

		return autoBehaviour.setTransformationsTo(position, eulerAngles, otherTransform, boolean);
	}
	public static new AutoBehaviour<SingletonBehaviourT> setTransformationsTo(object otherTransform_TransformProvider, bool boolean = true)
	{
		Transform otherTransform = Provide.transformVia(otherTransform_TransformProvider);

		return autoBehaviour.setTransformationsTo(otherTransform, boolean);
	}
}