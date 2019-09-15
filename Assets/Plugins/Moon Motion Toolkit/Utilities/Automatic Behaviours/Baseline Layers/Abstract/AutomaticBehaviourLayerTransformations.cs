using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour Layer Transformations:
// #auto #transform #transformations
// • provides this behaviour with transformation methods
public abstract class	AutomaticBehaviourLayerTransformations<AutomaticBehaviourT> :
					AutomaticBehaviourLayerGameObject<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	public Vector3 localPosition => transform.localPosition;
	public AutomaticBehaviourT setLocalPositionTo(Vector3 localPosition, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionTo(localPosition, boolean));
	public AutomaticBehaviourT setLocalPositionTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionTo(otherTransform, boolean));
	public AutomaticBehaviourT setLocalPositionTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionTo(otherGameObject, boolean));
	public AutomaticBehaviourT setLocalPositionTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionTo(otherComponent, boolean));
	public AutomaticBehaviourT resetLocalPosition(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalPosition(boolean));


	public float localPositionX => transform.localPosition.x;
	public AutomaticBehaviourT setLocalPositionXTo(float x, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionXTo(x, boolean));
	public AutomaticBehaviourT setLocalPositionXTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionXTo(otherTransform, boolean));
	public AutomaticBehaviourT setLocalPositionXTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionXTo(otherGameObject, boolean));
	public AutomaticBehaviourT setLocalPositionXTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionXTo(otherComponent, boolean));
	public AutomaticBehaviourT resetLocalPositionX(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalPositionX(boolean));

	public float localPositionY => transform.localPosition.y;
	public AutomaticBehaviourT setLocalPositionYTo(float y, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionYTo(y, boolean));
	public AutomaticBehaviourT setLocalPositionYTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionYTo(otherTransform, boolean));
	public AutomaticBehaviourT setLocalPositionYTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionYTo(otherGameObject, boolean));
	public AutomaticBehaviourT setLocalPositionYTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionYTo(otherComponent, boolean));
	public AutomaticBehaviourT resetLocalPositionY(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalPositionY(boolean));
	public AutomaticBehaviourT negateLocalPositionY(bool boolean = true)
		=> selfAfter(()=> transform.negateLocalPositionY(boolean));

	public float localPositionZ => transform.localPosition.z;
	public AutomaticBehaviourT setLocalPositionZTo(float z, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionZTo(z, boolean));
	public AutomaticBehaviourT setLocalPositionZTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionZTo(otherTransform, boolean));
	public AutomaticBehaviourT setLocalPositionZTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionZTo(otherGameObject, boolean));
	public AutomaticBehaviourT setLocalPositionZTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalPositionZTo(otherComponent, boolean));
	public AutomaticBehaviourT resetLocalPositionZ(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalPositionZ(boolean));

	public Quaternion localRotation => transform.localRotation;
	public AutomaticBehaviourT setLocalRotationTo(Quaternion localRotation, bool boolean = true)
		=> selfAfter(()=> transform.setLocalRotationTo(localRotation, boolean));
	public AutomaticBehaviourT setLocalRotationTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalRotationTo(otherTransform, boolean));
	public AutomaticBehaviourT setLocalRotationTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalRotationTo(otherGameObject, boolean));
	public AutomaticBehaviourT setLocalRotationTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalRotationTo(otherComponent, boolean));
	public AutomaticBehaviourT resetLocalRotation(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalRotation(boolean));

	public Vector3 localEulerAngles => transform.localEulerAngles;
	public AutomaticBehaviourT setLocalEulerAnglesTo(Vector3 localEulerAngles, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAnglesTo(localEulerAngles, boolean));
	public AutomaticBehaviourT setLocalEulerAnglesTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAnglesTo(otherTransform, boolean));
	public AutomaticBehaviourT setLocalEulerAnglesTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAnglesTo(otherGameObject, boolean));
	public AutomaticBehaviourT setLocalEulerAnglesTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAnglesTo(otherComponent, boolean));
	public AutomaticBehaviourT resetLocalEulerAngles(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalEulerAngles(boolean));

	public float localEulerAngleX => transform.localEulerAngleX();
	public AutomaticBehaviourT setLocalEulerAngleXTo(float localEulerAngleX, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleXTo(localEulerAngleX, boolean));
	public AutomaticBehaviourT setLocalEulerAngleXTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleXTo(otherTransform, boolean));
	public AutomaticBehaviourT setLocalEulerAngleXTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleXTo(otherGameObject, boolean));
	public AutomaticBehaviourT setLocalEulerAngleXTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleXTo(otherComponent, boolean));
	public AutomaticBehaviourT resetLocalEulerAngleX(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalEulerAngleX(boolean));

	public float localEulerAngleY => transform.localEulerAngleY();
	public AutomaticBehaviourT setLocalEulerAngleYTo(float localEulerAngleY, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleYTo(localEulerAngleY, boolean));
	public AutomaticBehaviourT setLocalEulerAngleYTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleYTo(otherTransform, boolean));
	public AutomaticBehaviourT setLocalEulerAngleYTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleYTo(otherGameObject, boolean));
	public AutomaticBehaviourT setLocalEulerAngleYTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleYTo(otherComponent, boolean));
	public AutomaticBehaviourT resetLocalEulerAngleY(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalEulerAngleY(boolean));

	public float localEulerAngleZ => transform.localEulerAngleZ();
	public AutomaticBehaviourT setLocalEulerAngleZTo(float localEulerAngleZ, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleZTo(localEulerAngleZ, boolean));
	public AutomaticBehaviourT setLocalEulerAngleZTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleZTo(otherTransform, boolean));
	public AutomaticBehaviourT setLocalEulerAngleZTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleZTo(otherGameObject, boolean));
	public AutomaticBehaviourT setLocalEulerAngleZTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalEulerAngleZTo(otherComponent, boolean));
	public AutomaticBehaviourT resetLocalEulerAngleZ(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalEulerAngleZ(boolean));

	public Vector3 localScale => transform.localScale;
	public AutomaticBehaviourT setLocalScaleTo(Vector3 localScale, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleTo(localScale, boolean));
	public AutomaticBehaviourT setLocalScaleTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleTo(otherTransform, boolean));
	public AutomaticBehaviourT setLocalScaleTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleTo(otherGameObject, boolean));
	public AutomaticBehaviourT setLocalScaleTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleTo(otherComponent, boolean));
	public AutomaticBehaviourT resetLocalScale(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalScale(boolean));

	public float localScaleX => transform.localScale.x;
	public AutomaticBehaviourT setLocalScaleXTo(float x, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleXTo(x, boolean));
	public AutomaticBehaviourT setLocalScaleXTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleXTo(otherTransform, boolean));
	public AutomaticBehaviourT setLocalScaleXTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleXTo(otherGameObject, boolean));
	public AutomaticBehaviourT setLocalScaleXTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleXTo(otherComponent, boolean));
	public AutomaticBehaviourT resetLocalScaleX(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalScaleX(boolean));

	public float localScaleY => transform.localScale.y;
	public AutomaticBehaviourT setLocalScaleYTo(float y, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleYTo(y, boolean));
	public AutomaticBehaviourT setLocalScaleYTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleYTo(otherTransform, boolean));
	public AutomaticBehaviourT setLocalScaleYTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleYTo(otherGameObject, boolean));
	public AutomaticBehaviourT setLocalScaleYTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleYTo(otherComponent, boolean));
	public AutomaticBehaviourT resetLocalScaleY(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalScaleY(boolean));

	public float localScaleZ => transform.localScale.z;
	public AutomaticBehaviourT setLocalScaleZTo(float z, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleZTo(z, boolean));
	public AutomaticBehaviourT setLocalScaleZTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleZTo(otherTransform, boolean));
	public AutomaticBehaviourT setLocalScaleZTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleZTo(otherGameObject, boolean));
	public AutomaticBehaviourT setLocalScaleZTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalScaleZTo(otherComponent, boolean));
	public AutomaticBehaviourT resetLocalScaleZ(bool boolean = true)
		=> selfAfter(()=> transform.resetLocalScaleZ(boolean));

	public AutomaticBehaviourT setLocalsTo(Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsTo(localPosition, localRotation, localScale, boolean));
	public AutomaticBehaviourT setLocalsTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsTo(otherTransform, boolean));
	public AutomaticBehaviourT setLocalsTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsTo(otherGameObject, boolean));
	public AutomaticBehaviourT setLocalsTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsTo(otherComponent, boolean));
	public AutomaticBehaviourT resetLocals(bool boolean = true)
		=> selfAfter(()=> transform.resetLocals(boolean));

	public AutomaticBehaviourT setLocalsTo(Vector3 localPosition, Vector3 localEulerAngles, Vector3 localScale, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsTo(localPosition, localEulerAngles, localScale, boolean));

	public AutomaticBehaviourT setLocalsTo(Vector3 localPosition, Quaternion localRotation, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsTo(localPosition, localRotation, boolean));

	public AutomaticBehaviourT setLocalsTo(Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsTo(localRotation, localScale, boolean));

	public AutomaticBehaviourT setLocalsParentlyForRelativeTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsParentlyForRelativeTo(otherTransform, boolean));
	public AutomaticBehaviourT setLocalsParentlyForRelativeTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsParentlyForRelativeTo(otherGameObject, boolean));
	public AutomaticBehaviourT setLocalsParentlyForRelativeTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setLocalsParentlyForRelativeTo(otherComponent, boolean));
	public AutomaticBehaviourT setLocalsParentlyForRelativeTo<SingletonBehaviourT>(bool boolean = true) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> selfAfter(()=> transform.setLocalsParentlyForRelativeTo<SingletonBehaviourT>(boolean));

	public Vector3 position => transform.position;
	public AutomaticBehaviourT movePositionTo(Vector3 position, bool boolean = true)
		=> selfAfter(()=> rigidbody.movePositionTo(position, boolean));
	public AutomaticBehaviourT movePositionTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> rigidbody.movePositionTo(otherTransform, boolean));
	public AutomaticBehaviourT movePositionTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> rigidbody.movePositionTo(otherGameObject, boolean));
	public AutomaticBehaviourT movePositionTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> rigidbody.movePositionTo(otherComponent, boolean));
	public AutomaticBehaviourT setPositionTo(Vector3 position, bool boolean = true)
		=> selfAfter(()=> transform.setPositionTo(position, boolean));
	public AutomaticBehaviourT setPositionTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setPositionTo(otherTransform, boolean));
	public AutomaticBehaviourT setPositionTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setPositionTo(otherGameObject, boolean));
	public AutomaticBehaviourT setPositionTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setPositionTo(otherComponent, boolean));
	public AutomaticBehaviourT resetPosition(bool boolean = true)
		=> selfAfter(()=> transform.resetPosition(boolean));

	public float positionX => transform.position.x;
	public AutomaticBehaviourT movePositionXTo(float x, bool boolean = true)
		=> selfAfter(() => transform.movePositionXTo(x, boolean));
	public AutomaticBehaviourT movePositionXTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(() => transform.movePositionXTo(otherTransform, boolean));
	public AutomaticBehaviourT movePositionXTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(() => transform.movePositionXTo(otherGameObject, boolean));
	public AutomaticBehaviourT movePositionXTo(Component otherComponent, bool boolean = true)
		=> selfAfter(() => transform.movePositionXTo(otherComponent, boolean));
	public AutomaticBehaviourT setPositionXTo(float x, bool boolean = true)
		=> selfAfter(()=> transform.setPositionXTo(x, boolean));
	public AutomaticBehaviourT setPositionXTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setPositionXTo(otherTransform, boolean));
	public AutomaticBehaviourT setPositionXTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setPositionXTo(otherGameObject, boolean));
	public AutomaticBehaviourT setPositionXTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setPositionXTo(otherComponent, boolean));
	public AutomaticBehaviourT resetPositionX(bool boolean = true)
		=> selfAfter(()=> transform.resetPositionX(boolean));

	public float positionY => transform.position.y;
	public AutomaticBehaviourT movePositionYTo(float y, bool boolean = true)
		=> selfAfter(() => transform.movePositionYTo(y, boolean));
	public AutomaticBehaviourT movePositionYTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(() => transform.movePositionYTo(otherTransform, boolean));
	public AutomaticBehaviourT movePositionYTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(() => transform.movePositionYTo(otherGameObject, boolean));
	public AutomaticBehaviourT movePositionYTo(Component otherComponent, bool boolean = true)
		=> selfAfter(() => transform.movePositionYTo(otherComponent, boolean));
	public AutomaticBehaviourT setPositionYTo(float y, bool boolean = true)
		=> selfAfter(()=> transform.setPositionYTo(y, boolean));
	public AutomaticBehaviourT setPositionYTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setPositionYTo(otherTransform, boolean));
	public AutomaticBehaviourT setPositionYTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setPositionYTo(otherGameObject, boolean));
	public AutomaticBehaviourT setPositionYTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setPositionYTo(otherComponent, boolean));
	public AutomaticBehaviourT resetPositionY(bool boolean = true)
		=> selfAfter(()=> transform.resetPositionY(boolean));
	public AutomaticBehaviourT negatePositionY(bool boolean = true)
		=> selfAfter(()=> transform.negatePositionY(boolean));

	public float positionZ => transform.position.z;
	public AutomaticBehaviourT movePositionZTo(float z, bool boolean = true)
		=> selfAfter(() => transform.movePositionZTo(z, boolean));
	public AutomaticBehaviourT movePositionZTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(() => transform.movePositionZTo(otherTransform, boolean));
	public AutomaticBehaviourT movePositionZTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(() => transform.movePositionZTo(otherGameObject, boolean));
	public AutomaticBehaviourT movePositionZTo(Component otherComponent, bool boolean = true)
		=> selfAfter(() => transform.movePositionZTo(otherComponent, boolean));
	public AutomaticBehaviourT setPositionZTo(float z, bool boolean = true)
		=> selfAfter(()=> transform.setPositionZTo(z, boolean));
	public AutomaticBehaviourT setPositionZTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setPositionZTo(otherTransform, boolean));
	public AutomaticBehaviourT setPositionZTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setPositionZTo(otherGameObject, boolean));
	public AutomaticBehaviourT setPositionZTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setPositionZTo(otherComponent, boolean));
	public AutomaticBehaviourT resetPositionZ(bool boolean = true)
		=> selfAfter(()=> transform.resetPositionZ(boolean));

	public Quaternion rotation => transform.rotation;
	public AutomaticBehaviourT setRotationTo(Quaternion rotation, bool boolean = true)
		=> selfAfter(()=> transform.setRotationTo(rotation, boolean));
	public AutomaticBehaviourT setRotationTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setRotationTo(otherTransform, boolean));
	public AutomaticBehaviourT setRotationTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setRotationTo(otherGameObject, boolean));
	public AutomaticBehaviourT setRotationTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setRotationTo(otherComponent, boolean));
	public AutomaticBehaviourT resetRotation(bool boolean = true)
		=> selfAfter(()=> transform.resetRotation(boolean));

	public Vector3 eulerAngles => transform.eulerAngles;
	public AutomaticBehaviourT setEulerAnglesTo(Vector3 eulerAngles, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAnglesTo(eulerAngles, boolean));
	public AutomaticBehaviourT setEulerAnglesTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAnglesTo(otherTransform, boolean));
	public AutomaticBehaviourT setEulerAnglesTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAnglesTo(otherGameObject, boolean));
	public AutomaticBehaviourT setEulerAnglesTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAnglesTo(otherComponent, boolean));
	public AutomaticBehaviourT resetEulerAngles(bool boolean = true)
		=> selfAfter(()=> transform.resetEulerAngles(boolean));

	public float eulerAngleX => transform.eulerAngleX();
	public AutomaticBehaviourT setEulerAngleXTo(float eulerAngleX, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleXTo(eulerAngleX, boolean));
	public AutomaticBehaviourT setEulerAngleXTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleXTo(otherTransform, boolean));
	public AutomaticBehaviourT setEulerAngleXTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleXTo(otherGameObject, boolean));
	public AutomaticBehaviourT setEulerAngleXTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleXTo(otherComponent, boolean));
	public AutomaticBehaviourT resetEulerAngleX(bool boolean = true)
		=> selfAfter(()=> transform.resetEulerAngleX(boolean));

	public float eulerAngleY => transform.eulerAngleY();
	public AutomaticBehaviourT setEulerAngleYTo(float eulerAngleY, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleYTo(eulerAngleY, boolean));
	public AutomaticBehaviourT setEulerAngleYTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleYTo(otherTransform, boolean));
	public AutomaticBehaviourT setEulerAngleYTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleYTo(otherGameObject, boolean));
	public AutomaticBehaviourT setEulerAngleYTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleYTo(otherComponent, boolean));
	public AutomaticBehaviourT resetEulerAngleY(bool boolean = true)
		=> selfAfter(()=> transform.resetEulerAngleY(boolean));

	public float eulerAngleZ => transform.eulerAngleZ();
	public AutomaticBehaviourT setEulerAngleZTo(float eulerAngleZ, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleZTo(eulerAngleZ, boolean));
	public AutomaticBehaviourT setEulerAngleZTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleZTo(otherTransform, boolean));
	public AutomaticBehaviourT setEulerAngleZTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleZTo(otherGameObject, boolean));
	public AutomaticBehaviourT setEulerAngleZTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setEulerAngleZTo(otherComponent, boolean));
	public AutomaticBehaviourT resetEulerAngleZ(bool boolean = true)
		=> selfAfter(()=> transform.resetEulerAngleZ(boolean));

	public AutomaticBehaviourT setGlobalsTo(Vector3 position, Quaternion rotation, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsTo(position, rotation, boolean));
	public AutomaticBehaviourT setGlobalsTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsTo(otherTransform, boolean));
	public AutomaticBehaviourT setGlobalsTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsTo(otherGameObject, boolean));
	public AutomaticBehaviourT setGlobalsTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsTo(otherComponent, boolean));
	public AutomaticBehaviourT setGlobalsTo(Vector3 position, Vector3 eulerAngles, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsTo(position, eulerAngles, boolean));
	public AutomaticBehaviourT resetGlobals(bool boolean = true)
		=> selfAfter(()=> transform.resetGlobals(boolean));

	public AutomaticBehaviourT setGlobalsAndLocalScaleTo(Vector3 position, Quaternion rotation, Vector3 localScale, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsAndLocalScaleTo(position, rotation, localScale, boolean));
	public AutomaticBehaviourT setGlobalsAndLocalScaleTo(Transform otherTransform, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsAndLocalScaleTo(otherTransform, boolean));
	public AutomaticBehaviourT setGlobalsAndLocalScaleTo(GameObject otherGameObject, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsAndLocalScaleTo(otherGameObject, boolean));
	public AutomaticBehaviourT setGlobalsAndLocalScaleTo(Component otherComponent, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsAndLocalScaleTo(otherComponent, boolean));
	public AutomaticBehaviourT resetGlobalsAndLocalScale(bool boolean = true)
		=> selfAfter(()=> transform.resetGlobalsAndLocalScale(boolean));

	public AutomaticBehaviourT setGlobalsAndLocalScaleTo(Vector3 position, Vector3 eulerAngles, Vector3 localScale, bool boolean = true)
		=> selfAfter(()=> transform.setGlobalsAndLocalScaleTo(position, eulerAngles, localScale, boolean));
}