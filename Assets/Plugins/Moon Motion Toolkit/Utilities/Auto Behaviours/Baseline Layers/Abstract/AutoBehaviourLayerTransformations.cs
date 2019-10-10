using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Transformations:
// #auto #transform #transformations
// • provides this behaviour with transformation methods
public abstract class	AutoBehaviourLayerTransformations<AutoBehaviourT> :
					AutoBehaviourLayerGameObject<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	public Vector3 localPosition => transform.localPosition;
	public AutoBehaviourT setLocalPositionTo(Vector3 localPosition, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionTo(localPosition, boolean));
	public AutoBehaviourT setLocalPositionTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionTo(otherTransform, boolean));
	public AutoBehaviourT setLocalPositionTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionTo(otherGameObject, boolean));
	public AutoBehaviourT setLocalPositionTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionTo(otherComponent, boolean));
	public AutoBehaviourT resetLocalPosition(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalPosition(boolean));


	public float localPositionX => transform.localPosition.x;
	public AutoBehaviourT setLocalPositionXTo(float x, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionXTo(x, boolean));
	public AutoBehaviourT setLocalPositionXTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionXTo(otherTransform, boolean));
	public AutoBehaviourT setLocalPositionXTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionXTo(otherGameObject, boolean));
	public AutoBehaviourT setLocalPositionXTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionXTo(otherComponent, boolean));
	public AutoBehaviourT resetLocalPositionX(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalPositionX(boolean));

	public float localPositionY => transform.localPosition.y;
	public AutoBehaviourT setLocalPositionYTo(float y, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionYTo(y, boolean));
	public AutoBehaviourT setLocalPositionYTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionYTo(otherTransform, boolean));
	public AutoBehaviourT setLocalPositionYTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionYTo(otherGameObject, boolean));
	public AutoBehaviourT setLocalPositionYTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionYTo(otherComponent, boolean));
	public AutoBehaviourT resetLocalPositionY(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalPositionY(boolean));
	public AutoBehaviourT negateLocalPositionY(bool boolean = true)
		=> selfAfter(()=> transform.negateLocalPositionY(boolean));

	public float localPositionZ => transform.localPosition.z;
	public AutoBehaviourT setLocalPositionZTo(float z, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionZTo(z, boolean));
	public AutoBehaviourT setLocalPositionZTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionZTo(otherTransform, boolean));
	public AutoBehaviourT setLocalPositionZTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionZTo(otherGameObject, boolean));
	public AutoBehaviourT setLocalPositionZTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionZTo(otherComponent, boolean));
	public AutoBehaviourT resetLocalPositionZ(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalPositionZ(boolean));

	public Quaternion localRotation => transform.localRotation;
	public AutoBehaviourT setLocalRotationTo(Quaternion localRotation, bool boolean = true)
		=> selfAfter(()=> transform.setLocalRotationTo(localRotation, boolean));
	public AutoBehaviourT setLocalRotationTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalRotationTo(otherTransform, boolean));
	public AutoBehaviourT setLocalRotationTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalRotationTo(otherGameObject, boolean));
	public AutoBehaviourT setLocalRotationTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalRotationTo(otherComponent, boolean));
	public AutoBehaviourT resetLocalRotation(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalRotation(boolean));

	public Vector3 localEulerAngles => transform.localEulerAngles;
	public AutoBehaviourT setLocalEulerAnglesTo(Vector3 localEulerAngles, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAnglesTo(localEulerAngles, boolean));
	public AutoBehaviourT setLocalEulerAnglesTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAnglesTo(otherTransform, boolean));
	public AutoBehaviourT setLocalEulerAnglesTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAnglesTo(otherGameObject, boolean));
	public AutoBehaviourT setLocalEulerAnglesTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAnglesTo(otherComponent, boolean));
	public AutoBehaviourT resetLocalEulerAngles(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalEulerAngles(boolean));

	public float localEulerAngleX => transform.localEulerAngleX();
	public AutoBehaviourT setLocalEulerAngleXTo(float localEulerAngleX, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleXTo(localEulerAngleX, boolean));
	public AutoBehaviourT setLocalEulerAngleXTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleXTo(otherTransform, boolean));
	public AutoBehaviourT setLocalEulerAngleXTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleXTo(otherGameObject, boolean));
	public AutoBehaviourT setLocalEulerAngleXTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleXTo(otherComponent, boolean));
	public AutoBehaviourT resetLocalEulerAngleX(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalEulerAngleX(boolean));

	public float localEulerAngleY => transform.localEulerAngleY();
	public AutoBehaviourT setLocalEulerAngleYTo(float localEulerAngleY, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleYTo(localEulerAngleY, boolean));
	public AutoBehaviourT setLocalEulerAngleYTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleYTo(otherTransform, boolean));
	public AutoBehaviourT setLocalEulerAngleYTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleYTo(otherGameObject, boolean));
	public AutoBehaviourT setLocalEulerAngleYTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleYTo(otherComponent, boolean));
	public AutoBehaviourT resetLocalEulerAngleY(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalEulerAngleY(boolean));

	public float localEulerAngleZ => transform.localEulerAngleZ();
	public AutoBehaviourT setLocalEulerAngleZTo(float localEulerAngleZ, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleZTo(localEulerAngleZ, boolean));
	public AutoBehaviourT setLocalEulerAngleZTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleZTo(otherTransform, boolean));
	public AutoBehaviourT setLocalEulerAngleZTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleZTo(otherGameObject, boolean));
	public AutoBehaviourT setLocalEulerAngleZTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleZTo(otherComponent, boolean));
	public AutoBehaviourT resetLocalEulerAngleZ(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalEulerAngleZ(boolean));

	public Vector3 localScale => transform.localScale;
	public AutoBehaviourT setLocalScaleTo(Vector3 localScale, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleTo(localScale, boolean));
	public AutoBehaviourT setLocalScaleTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleTo(otherTransform, boolean));
	public AutoBehaviourT setLocalScaleTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleTo(otherGameObject, boolean));
	public AutoBehaviourT setLocalScaleTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleTo(otherComponent, boolean));
	public AutoBehaviourT resetLocalScale(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalScale(boolean));

	public float localScaleX => transform.localScale.x;
	public AutoBehaviourT setLocalScaleXTo(float x, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleXTo(x, boolean));
	public AutoBehaviourT setLocalScaleXTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleXTo(otherTransform, boolean));
	public AutoBehaviourT setLocalScaleXTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleXTo(otherGameObject, boolean));
	public AutoBehaviourT setLocalScaleXTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleXTo(otherComponent, boolean));
	public AutoBehaviourT resetLocalScaleX(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalScaleX(boolean));

	public float localScaleY => transform.localScale.y;
	public AutoBehaviourT setLocalScaleYTo(float y, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleYTo(y, boolean));
	public AutoBehaviourT setLocalScaleYTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleYTo(otherTransform, boolean));
	public AutoBehaviourT setLocalScaleYTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleYTo(otherGameObject, boolean));
	public AutoBehaviourT setLocalScaleYTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleYTo(otherComponent, boolean));
	public AutoBehaviourT resetLocalScaleY(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalScaleY(boolean));

	public float localScaleZ => transform.localScale.z;
	public AutoBehaviourT setLocalScaleZTo(float z, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleZTo(z, boolean));
	public AutoBehaviourT setLocalScaleZTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleZTo(otherTransform, boolean));
	public AutoBehaviourT setLocalScaleZTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleZTo(otherGameObject, boolean));
	public AutoBehaviourT setLocalScaleZTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleZTo(otherComponent, boolean));
	public AutoBehaviourT resetLocalScaleZ(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalScaleZ(boolean));

	public AutoBehaviourT setLocalsTo(Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsTo(localPosition, localRotation, localScale, boolean));
	public AutoBehaviourT setLocalsTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsTo(otherTransform, boolean));
	public AutoBehaviourT setLocalsTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsTo(otherGameObject, boolean));
	public AutoBehaviourT setLocalsTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsTo(otherComponent, boolean));
	public AutoBehaviourT resetLocals(bool boolean = true)
		=> selfAfter(()=> transform.resetLocals(boolean));

	public AutoBehaviourT setLocalsTo(Vector3 localPosition, Vector3 localEulerAngles, Vector3 localScale, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsTo(localPosition, localEulerAngles, localScale, boolean));

	public AutoBehaviourT setLocalsTo(Vector3 localPosition, Quaternion localRotation, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsTo(localPosition, localRotation, boolean));

	public AutoBehaviourT setLocalsTo(Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsTo(localRotation, localScale, boolean));

	public AutoBehaviourT setLocalsParentlyForRelativeTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsParentlyForRelativeTo(otherTransform, boolean));
	public AutoBehaviourT setLocalsParentlyForRelativeTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsParentlyForRelativeTo(otherGameObject, boolean));
	public AutoBehaviourT setLocalsParentlyForRelativeTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsParentlyForRelativeTo(otherComponent, boolean));
	public AutoBehaviourT setLocalsParentlyForRelativeTo<SingletonBehaviourT>(bool boolean = true) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> selfAfter(()=> transform.setLocalsParentlyForRelativeTo<SingletonBehaviourT>(boolean));

	public Vector3 position => transform.position;
	public AutoBehaviourT movePositionTo(Vector3 position, bool boolean = true)
		=> selfAfter(()=> rigidbody.movePositionTo(position, boolean));
	public AutoBehaviourT movePositionTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> rigidbody.movePositionTo(otherTransform, boolean));
	public AutoBehaviourT movePositionTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> rigidbody.movePositionTo(otherGameObject, boolean));
	public AutoBehaviourT movePositionTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> rigidbody.movePositionTo(otherComponent, boolean));
	public AutoBehaviourT movePositionTo(RaycastHit raycastHit, bool boolean = true)
		=> selfAfter(()=> rigidbody.movePositionTo(raycastHit, boolean));
	public Vector3 positionForMovingPositionTo(Vector3 targetPosition)
		=> transform.positionForMovingPositionTo(targetPosition);
	public Vector3 displacementForMovingPositionTo(Vector3 targetPosition)
		=> transform.displacementForMovingPositionTo(targetPosition);
	public AutoBehaviourT setPositionTo(Vector3 position, bool boolean = true)
		=> selfAfter(()=> transform.setPositionTo(position, boolean));
	public AutoBehaviourT setPositionTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setPositionTo(otherTransform, boolean));
	public AutoBehaviourT setPositionTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setPositionTo(otherGameObject, boolean));
	public AutoBehaviourT setPositionTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setPositionTo(otherComponent, boolean));
	public AutoBehaviourT setPositionTo(RaycastHit raycastHit, bool boolean = true)
		=> selfAfter(()=> transform.setPositionTo(raycastHit, boolean));
	public AutoBehaviourT resetPosition(bool boolean = true)
		=> selfAfter(()=> transform.resetPosition(boolean));
	public AutoBehaviourT displacePositionBy(Vector3 displacement, bool boolean = true)
		=> selfAfter(()=> transform.displacePositionBy(displacement, boolean));

	public float positionX => transform.position.x;
	public AutoBehaviourT movePositionXTo(float x, bool boolean = true)
		=> selfAfter(() => transform.movePositionXTo(x, boolean));
	public AutoBehaviourT movePositionXTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(() => transform.movePositionXTo(otherTransform, boolean));
	public AutoBehaviourT movePositionXTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(() => transform.movePositionXTo(otherGameObject, boolean));
	public AutoBehaviourT movePositionXTo(Component otherComponent, bool boolean = true)
		=> selfAfter(() => transform.movePositionXTo(otherComponent, boolean));
	public AutoBehaviourT setPositionXTo(float x, bool boolean = true)
		=> selfAfter(()=> transform.setPositionXTo(x, boolean));
	public AutoBehaviourT setPositionXTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setPositionXTo(otherTransform, boolean));
	public AutoBehaviourT setPositionXTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setPositionXTo(otherGameObject, boolean));
	public AutoBehaviourT setPositionXTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setPositionXTo(otherComponent, boolean));
	public AutoBehaviourT resetPositionX(bool boolean = true)
		=> selfAfter(()=> transform.resetPositionX(boolean));

	public float positionY => transform.position.y;
	public AutoBehaviourT movePositionYTo(float y, bool boolean = true)
		=> selfAfter(() => transform.movePositionYTo(y, boolean));
	public AutoBehaviourT movePositionYTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(() => transform.movePositionYTo(otherTransform, boolean));
	public AutoBehaviourT movePositionYTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(() => transform.movePositionYTo(otherGameObject, boolean));
	public AutoBehaviourT movePositionYTo(Component otherComponent, bool boolean = true)
		=> selfAfter(() => transform.movePositionYTo(otherComponent, boolean));
	public AutoBehaviourT setPositionYTo(float y, bool boolean = true)
		=> selfAfter(()=> transform.setPositionYTo(y, boolean));
	public AutoBehaviourT setPositionYTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setPositionYTo(otherTransform, boolean));
	public AutoBehaviourT setPositionYTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setPositionYTo(otherGameObject, boolean));
	public AutoBehaviourT setPositionYTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setPositionYTo(otherComponent, boolean));
	public AutoBehaviourT resetPositionY(bool boolean = true)
		=> selfAfter(()=> transform.resetPositionY(boolean));
	public AutoBehaviourT negatePositionY(bool boolean = true)
		=> selfAfter(()=> transform.negatePositionY(boolean));

	public float positionZ => transform.position.z;
	public AutoBehaviourT movePositionZTo(float z, bool boolean = true)
		=> selfAfter(() => transform.movePositionZTo(z, boolean));
	public AutoBehaviourT movePositionZTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(() => transform.movePositionZTo(otherTransform, boolean));
	public AutoBehaviourT movePositionZTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(() => transform.movePositionZTo(otherGameObject, boolean));
	public AutoBehaviourT movePositionZTo(Component otherComponent, bool boolean = true)
		=> selfAfter(() => transform.movePositionZTo(otherComponent, boolean));
	public AutoBehaviourT setPositionZTo(float z, bool boolean = true)
		=> selfAfter(()=> transform.setPositionZTo(z, boolean));
	public AutoBehaviourT setPositionZTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setPositionZTo(otherTransform, boolean));
	public AutoBehaviourT setPositionZTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setPositionZTo(otherGameObject, boolean));
	public AutoBehaviourT setPositionZTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setPositionZTo(otherComponent, boolean));
	public AutoBehaviourT resetPositionZ(bool boolean = true)
		=> selfAfter(()=> transform.resetPositionZ(boolean));

	public Quaternion rotation => transform.rotation;
	public AutoBehaviourT setRotationTo(Quaternion rotation, bool boolean = true)
		=> selfAfter(()=> transform.setRotationTo(rotation, boolean));
	public AutoBehaviourT setRotationTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setRotationTo(otherTransform, boolean));
	public AutoBehaviourT setRotationTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setRotationTo(otherGameObject, boolean));
	public AutoBehaviourT setRotationTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setRotationTo(otherComponent, boolean));
	public AutoBehaviourT resetRotation(bool boolean = true)
		=> selfAfter(()=> transform.resetRotation(boolean));

	public Vector3 eulerAngles => transform.eulerAngles;
	public AutoBehaviourT setEulerAnglesTo(Vector3 eulerAngles, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAnglesTo(eulerAngles, boolean));
	public AutoBehaviourT setEulerAnglesTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAnglesTo(otherTransform, boolean));
	public AutoBehaviourT setEulerAnglesTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAnglesTo(otherGameObject, boolean));
	public AutoBehaviourT setEulerAnglesTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAnglesTo(otherComponent, boolean));
	public AutoBehaviourT resetEulerAngles(bool boolean = true)
		=> selfAfter(()=> transform.resetEulerAngles(boolean));

	public float eulerAngleX => transform.eulerAngleX();
	public AutoBehaviourT setEulerAngleXTo(float eulerAngleX, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleXTo(eulerAngleX, boolean));
	public AutoBehaviourT setEulerAngleXTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleXTo(otherTransform, boolean));
	public AutoBehaviourT setEulerAngleXTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleXTo(otherGameObject, boolean));
	public AutoBehaviourT setEulerAngleXTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleXTo(otherComponent, boolean));
	public AutoBehaviourT resetEulerAngleX(bool boolean = true)
		=> selfAfter(()=> transform.resetEulerAngleX(boolean));

	public float eulerAngleY => transform.eulerAngleY();
	public AutoBehaviourT setEulerAngleYTo(float eulerAngleY, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleYTo(eulerAngleY, boolean));
	public AutoBehaviourT setEulerAngleYTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleYTo(otherTransform, boolean));
	public AutoBehaviourT setEulerAngleYTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleYTo(otherGameObject, boolean));
	public AutoBehaviourT setEulerAngleYTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleYTo(otherComponent, boolean));
	public AutoBehaviourT resetEulerAngleY(bool boolean = true)
		=> selfAfter(()=> transform.resetEulerAngleY(boolean));

	public float eulerAngleZ => transform.eulerAngleZ();
	public AutoBehaviourT setEulerAngleZTo(float eulerAngleZ, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleZTo(eulerAngleZ, boolean));
	public AutoBehaviourT setEulerAngleZTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleZTo(otherTransform, boolean));
	public AutoBehaviourT setEulerAngleZTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleZTo(otherGameObject, boolean));
	public AutoBehaviourT setEulerAngleZTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleZTo(otherComponent, boolean));
	public AutoBehaviourT resetEulerAngleZ(bool boolean = true)
		=> selfAfter(()=> transform.resetEulerAngleZ(boolean));

	public AutoBehaviourT setGlobalsTo(Vector3 position, Quaternion rotation, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsTo(position, rotation, boolean));
	public AutoBehaviourT setGlobalsTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsTo(otherTransform, boolean));
	public AutoBehaviourT setGlobalsTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsTo(otherGameObject, boolean));
	public AutoBehaviourT setGlobalsTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsTo(otherComponent, boolean));
	public AutoBehaviourT setGlobalsTo(Vector3 position, Vector3 eulerAngles, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsTo(position, eulerAngles, boolean));
	public AutoBehaviourT resetGlobals(bool boolean = true)
		=> selfAfter(()=> transform.resetGlobals(boolean));

	public AutoBehaviourT setGlobalsAndLocalScaleTo(Vector3 position, Quaternion rotation, Vector3 localScale, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsAndLocalScaleTo(position, rotation, localScale, boolean));
	public AutoBehaviourT setGlobalsAndLocalScaleTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsAndLocalScaleTo(otherTransform, boolean));
	public AutoBehaviourT setGlobalsAndLocalScaleTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsAndLocalScaleTo(otherGameObject, boolean));
	public AutoBehaviourT setGlobalsAndLocalScaleTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsAndLocalScaleTo(otherComponent, boolean));
	public AutoBehaviourT setGlobalsAndLocalScaleTo(Vector3 position, Vector3 eulerAngles, Vector3 localScale, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsAndLocalScaleTo(position, eulerAngles, localScale, boolean));
	public AutoBehaviourT resetGlobalsAndLocalScale(bool boolean = true)
		=> selfAfter(()=> transform.resetGlobalsAndLocalScale(boolean));
	
	public AutoBehaviourT setTransformationsTo(Vector3 position, Quaternion rotation, object otherTransform_TransformProvider, bool boolean = true)
	{
		Transform otherTransform = Provide.transformVia(otherTransform_TransformProvider);

		return selfAfter(()=> transform.setTransformationsTo(position, rotation, otherTransform, boolean));
	}
	public AutoBehaviourT setTransformationsTo(Vector3 position, Vector3 eulerAngles, object otherTransform_TransformProvider, bool boolean = true)
	{
		Transform otherTransform = Provide.transformVia(otherTransform_TransformProvider);

		return selfAfter(()=> transform.setTransformationsTo(position, eulerAngles, otherTransform, boolean));
	}
	public AutoBehaviourT setTransformationsTo(object otherTransform_TransformProvider, bool boolean = true)
	{
		Transform otherTransform = Provide.transformVia(otherTransform_TransformProvider);

		return selfAfter(()=> transform.setTransformationsTo(otherTransform, boolean));
	}
}