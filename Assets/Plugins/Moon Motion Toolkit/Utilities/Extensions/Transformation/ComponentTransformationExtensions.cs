using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component Transformation Extensions: provides extension methods for handling component transformations
// #auto #transform #transformations
public static class ComponentTransformationExtensions
{
	// method: return the local position of the transform of this given component //
	public static Vector3 localPosition<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localPosition;// method: (according to the given boolean:) set the local position of the transform of this given component to the given local position, then return this given component //
	public static ComponentT setLocalPositionTo<ComponentT>(this ComponentT component, Vector3 localPosition, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalPositionTo(localPosition, boolean);

		return component;
	}
	// method: (according to the given boolean:) set the local position of the transform of this given component to the local position for the given x, y, and z values, then return this given component //
	public static ComponentT setLocalPositionTo<ComponentT>(this ComponentT component, float x, float y, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalPositionTo(x, y, z, boolean);

		return component;
	}
	public static ComponentT setLocalPositionTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionTo(transform.localPosition, boolean);
	public static ComponentT setLocalPositionTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionTo(gameObject.localPosition(), boolean);
	public static ComponentT setLocalPositionTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionTo(otherComponent.localPosition(), boolean);// method: (according to the given boolean:) reset the local position for the transform of this given component to zeroes, then return this given component //
	public static ComponentT resetLocalPosition<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalPosition(boolean);

		return component;
	}



	// method: return the local x position of the transform of this given component //
	public static float localPositionX<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localPositionX();
	// method: (according to the given boolean:) set the local x position of the transform of this given component to the given x value, then return this given component //
	public static ComponentT setLocalPositionXTo<ComponentT>(this ComponentT component, float x, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalPositionXTo(x, boolean);

		return component;
	}
	public static ComponentT setLocalPositionXTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionXTo(transform.localPositionX(), boolean);
	public static ComponentT setLocalPositionXTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionXTo(gameObject.localPositionX(), boolean);
	public static ComponentT setLocalPositionXTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionXTo(otherComponent.localPositionX(), boolean);
	// method: (according to the given boolean:) reset the local x position for the transform of this given component to zero, then return this given component //
	public static ComponentT resetLocalPositionX<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalPositionX(boolean);

		return component;
	}



	// method: return the local y position of the transform of this given component //
	public static float localPositionY<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localPositionY();
	// method: (according to the given boolean:) set the local y position of the transform of this given component to the given y value, then return this given component //
	public static ComponentT setLocalPositionYTo<ComponentT>(this ComponentT component, float y, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalPositionYTo(y, boolean);

		return component;
	}
	public static ComponentT setLocalPositionYTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionYTo(transform.localPositionY(), boolean);
	public static ComponentT setLocalPositionYTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionYTo(gameObject.localPositionY(), boolean);
	public static ComponentT setLocalPositionYTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionYTo(otherComponent.localPositionY(), boolean);
	// method: (according to the given boolean:) reset the localy position for the transform of this given component to zero, then return this given component //
	public static ComponentT resetLocalPositionY<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalPositionY(boolean);

		return component;
	}
	// method: (according to the given boolean:) negate this given component's local y position, then return this given component //
	public static ComponentT negateLocalPositionY<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.negateLocalPositionY(boolean);

		return component;
	}



	// method: return the local z position of the transform of this given component //
	public static float localPositionZ<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localPositionZ();
	// method: (according to the given boolean:) set the local z position of the transform of this given component to the given z value, then return this given component //
	public static ComponentT setLocalPositionZTo<ComponentT>(this ComponentT component, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalPositionZTo(z, boolean);

		return component;
	}
	public static ComponentT setLocalPositionZTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionZTo(transform.localPositionZ(), boolean);
	public static ComponentT setLocalPositionZTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionZTo(gameObject.localPositionZ(), boolean);
	public static ComponentT setLocalPositionZTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionZTo(otherComponent.localPositionZ(), boolean);
	// method: (according to the given boolean:) reset the local z position for the transform of this given component to zero, then return this given component //
	public static ComponentT resetLocalPositionZ<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalPositionZ(boolean);

		return component;
	}



	// method: return the local rotation of the transform of this given component //
	public static Quaternion localRotation<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localRotation;
	// method: (according to the given boolean:) set the local rotation of the transform of this given component to the given local rotation, then return this given component //
	public static ComponentT setLocalRotationTo<ComponentT>(this ComponentT component, Quaternion localRotation, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalRotationTo(localRotation, boolean);

		return component;
	}
	public static ComponentT setLocalRotationTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalRotationTo(transform.localRotation, boolean);
	public static ComponentT setLocalRotationTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalRotationTo(gameObject.localRotation(), boolean);
	public static ComponentT setLocalRotationTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalRotationTo(otherComponent.localRotation(), boolean);
	// method: (according to the given boolean:) reset the local rotation for the transform of this given component to no rotation, then return this given component //
	public static ComponentT resetLocalRotation<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalRotation(boolean);

		return component;
	}



	// method: return the local euler angles of the transform of this given component //
	public static Vector3 localEulerAngles<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localEulerAngles;
	// method: (according to the given boolean:) set the local euler angles of the transform of this given component to the given local euler angles, then return this given component //
	public static ComponentT setLocalEulerAnglesTo<ComponentT>(this ComponentT component, Vector3 localEulerAngles, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalEulerAnglesTo(localEulerAngles, boolean);

		return component;
	}
	// method: (according to the given boolean:) set the local euler angles of the transform of this given component to the local euler angles for the given x, y, and z values, then return this given component //
	public static ComponentT setLocalEulerAnglesTo<ComponentT>(this ComponentT component, float x, float y, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalEulerAnglesTo(x, y, z, boolean);

		return component;
	}
	public static ComponentT setLocalEulerAnglesTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAnglesTo(transform.localEulerAngles, boolean);
	public static ComponentT setLocalEulerAnglesTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAnglesTo(gameObject.localEulerAngles(), boolean);
	public static ComponentT setLocalEulerAnglesTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAnglesTo(otherComponent.localEulerAngles(), boolean);
	// method: (according to the given boolean:) reset the local euler angles for the transform of this given component to zeroes, then return this given component //
	public static ComponentT resetLocalEulerAngles<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalEulerAngles(boolean);

		return component;
	}



	// method: return the local x euler angle of the transform of this given component //
	public static float localEulerAngleX<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localEulerAngleX();
	// method: (according to the given boolean:) set the local x euler angle of the transform of this given component to the given x value, then return this given component //
	public static ComponentT setLocalEulerAngleXTo<ComponentT>(this ComponentT component, float x, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalEulerAngleXTo(x, boolean);

		return component;
	}
	public static ComponentT setLocalEulerAngleXTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleXTo(transform.localEulerAngleX(), boolean);
	public static ComponentT setLocalEulerAngleXTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleXTo(gameObject.localEulerAngleX(), boolean);
	public static ComponentT setLocalEulerAngleXTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleXTo(otherComponent.localEulerAngleX(), boolean);
	// method: (according to the given boolean:) reset the local x euler angle for the transform of this given component to zero, then return this given component //
	public static ComponentT resetLocalEulerAngleX<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalEulerAngleX(boolean);

		return component;
	}



	// method: return the local y euler angle of the transform of this given component //
	public static float localEulerAngleY<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localEulerAngleY();
	// method: (according to the given boolean:) set the local y euler angle of the transform of this given component to the given y value, then return this given component //
	public static ComponentT setLocalEulerAngleYTo<ComponentT>(this ComponentT component, float y, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalEulerAngleYTo(y, boolean);

		return component;
	}
	public static ComponentT setLocalEulerAngleYTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleYTo(transform.localEulerAngleY(), boolean);
	public static ComponentT setLocalEulerAngleYTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleYTo(gameObject.localEulerAngleY(), boolean);
	public static ComponentT setLocalEulerAngleYTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleYTo(otherComponent.localEulerAngleY(), boolean);
	// method: (according to the given boolean:) reset the local y euler angle for the transform of this given component to zero, then return this given component //
	public static ComponentT resetLocalEulerAngleY<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalEulerAngleY(boolean);

		return component;
	}



	// method: return the local z euler angle of the transform of this given component //
	public static float localEulerAngleZ<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localEulerAngleZ();
	// method: (according to the given boolean:) set the local z euler angle of the transform of this given component to the given z value, then return this given component //
	public static ComponentT setLocalEulerAngleZTo<ComponentT>(this ComponentT component, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalEulerAngleZTo(z, boolean);

		return component;
	}
	public static ComponentT setLocalEulerAngleZTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleZTo(transform.localEulerAngleZ(), boolean);
	public static ComponentT setLocalEulerAngleZTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleZTo(gameObject.localEulerAngleZ(), boolean);
	public static ComponentT setLocalEulerAngleZTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleZTo(otherComponent.localEulerAngleZ(), boolean);
	// method: (according to the given boolean:) reset the local z euler angle for the transform of this given component to zero, then return this given component //
	public static ComponentT resetLocalEulerAngleZ<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalEulerAngleZ(boolean);

		return component;
	}



	// method: return the local scale of the transform of this given component //
	public static Vector3 localScale<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localScale;// method: (according to the given boolean:) set the local scale of the transform of this given component to the given local scale, then return this given component //
	public static ComponentT setLocalScaleTo<ComponentT>(this ComponentT component, Vector3 localScale, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalScaleTo(localScale, boolean);

		return component;
	}
	// method: (according to the given boolean:) set the local scale of the transform of this given component to the local scale for the given x, y, and z values, then return this given component //
	public static ComponentT setLocalScaleTo<ComponentT>(this ComponentT component, float x, float y, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalScaleTo(x, y, z, boolean);

		return component;
	}
	public static ComponentT setLocalScaleTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleTo(transform.localScale, boolean);
	public static ComponentT setLocalScaleTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleTo(gameObject.localScale(), boolean);
	public static ComponentT setLocalScaleTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleTo(otherComponent.localScale(), boolean);
	// method: (according to the given boolean:) reset the local scale for the transform of this given component to ones, then return this given component //
	public static ComponentT resetLocalScale<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalScale(boolean);

		return component;
	}



	// method: return the local x scale of the transform of this given component //
	public static float localScaleX<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localScaleX();
	// method: (according to the given boolean:) set the local x scale of the transform of this given component to the given x value, then return this given component //
	public static ComponentT setLocalScaleXTo<ComponentT>(this ComponentT component, float x, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalScaleXTo(x, boolean);

		return component;
	}
	public static ComponentT setLocalScaleXTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleXTo(transform.localScaleX(), boolean);
	public static ComponentT setLocalScaleXTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleXTo(gameObject.localScaleX(), boolean);
	public static ComponentT setLocalScaleXTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleXTo(otherComponent.localScaleX(), boolean);
	// method: (according to the given boolean:) reset the local x scale for the transform of this given component to one, then return this given component //
	public static ComponentT resetLocalScaleX<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalScaleX(boolean);

		return component;
	}



	// method: return the local y scale of the transform of this given component //
	public static float localScaleY<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localScaleY();
	// method: (according to the given boolean:) set the local y scale of the transform of this given component to the given y value, then return this given component //
	public static ComponentT setLocalScaleYTo<ComponentT>(this ComponentT component, float y, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalScaleYTo(y, boolean);

		return component;
	}
	public static ComponentT setLocalScaleYTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleYTo(transform.localScaleY(), boolean);
	public static ComponentT setLocalScaleYTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleYTo(gameObject.localScaleY(), boolean);
	public static ComponentT setLocalScaleYTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleYTo(otherComponent.localScaleY(), boolean);
	// method: (according to the given boolean:) reset the local y scale for the transform of this given component to one, then return this given component //
	public static ComponentT resetLocalScaleY<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalScaleY(boolean);

		return component;
	}



	// method: return the local z scale of the transform of this given component //
	public static float localScaleZ<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localScaleZ();
	// method: (according to the given boolean:) set the local z scale of the transform of this given component to the given z value, then return this given component //
	public static ComponentT setLocalScaleZTo<ComponentT>(this ComponentT component, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalScaleZTo(z, boolean);

		return component;
	}
	public static ComponentT setLocalScaleZTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleZTo(transform.localScaleZ(), boolean);
	public static ComponentT setLocalScaleZTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleZTo(gameObject.localScaleZ(), boolean);
	public static ComponentT setLocalScaleZTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleZTo(otherComponent.localScaleZ(), boolean);
	// method: (according to the given boolean:) reset the local z scale for the transform of this given component to one, then return this given component //
	public static ComponentT resetLocalScaleZ<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalScaleZ(boolean);

		return component;
	}



	// method: (according to the given boolean:) set the local transformations (local position, local rotation, local scale) for the transform of this given component respectively to the given local position, local rotation, and local scale, then return this given component //
	public static ComponentT setLocalsTo<ComponentT>(this ComponentT component, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalsTo(localPosition, localRotation, localScale, boolean);

		return component;
	}
	public static ComponentT setLocalsTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalsTo(transform.localPosition, transform.localRotation, transform.localScale, boolean);
	public static ComponentT setLocalsTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalsTo(gameObject.localPosition(), gameObject.localRotation(), gameObject.localScale(), boolean);
	public static ComponentT setLocalsTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalsTo(otherComponent.localPosition(), otherComponent.localRotation(), otherComponent.localScale(), boolean);
	// method: (according to the given boolean:) set the local transformations (local position, local euler angles, local scale) for the transform of this given component respectively to the given local position, local euler angles, and local scale, then return this given component //
	public static ComponentT setLocalsTo<ComponentT>(this ComponentT component, Vector3 localPosition, Vector3 localEulerAngles, Vector3 localScale, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalsTo(localPosition, localEulerAngles, localScale, boolean);

		return component;
	}
	// method: (according to the given boolean:) set the (nonscale) local transformations (local position, local rotation) for the transform of this given component respectively to the given local position and local rotation //
	public static ComponentT setLocalsTo<ComponentT>(this ComponentT component, Vector3 localPosition, Quaternion localRotation, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalsTo(localPosition, localRotation, boolean);

		return component;
	}
	// method: (according to the given boolean:) set the (nonposition) local transformations (local rotation, local scale) for the transform of this given component respectively to the given local rotation and local scale //
	public static ComponentT setLocalsTo<ComponentT>(this ComponentT component, Quaternion localRotation, Vector3 localScale, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalsTo(localRotation, localScale, boolean);

		return component;
	}
	// method: (according to the given boolean:) reset the local transformations (local position, local rotation, local scale) for the transform of this given component respectively to the zeroes, no rotation, and ones, then return this given component //
	public static ComponentT resetLocals<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocals(boolean);

		return component;
	}



	// method: (according to the given boolean:) set this given component's transform's local transformations to its parent's while temporarily childed to the given transform, then return this given component //
	public static ComponentT setLocalsParentlyForRelativeTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalsParentlyForRelativeTo(transform, boolean);

		return component;
	}
	// method: (according to the given boolean:) set this given component's transform's local transformations to its parent's while temporarily childed to the given game object, then return this given component //
	public static ComponentT setLocalsParentlyForRelativeTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalsParentlyForRelativeTo(gameObject, boolean);

		return component;
	}
	// method: (according to the given boolean:) set this given component's transform's local transformations to its parent's while temporarily childed to the other given component, then return this given component //
	public static ComponentT setLocalsParentlyForRelativeTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalsParentlyForRelativeTo(otherComponent, boolean);

		return component;
	}



	// method: return the (global) position of the transform of this given component //
	public static Vector3 position<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.position;
	// method: (assumes this component has a rigidbody attached:) (according to the given boolean:) move this given component's (global) position to the given position provider (try to set, but respect collisions in the way), then return this given component //
	public static ComponentT movePositionTo<ComponentT>(this ComponentT component, Vector3 position, bool boolean = true) where ComponentT : Component
		=> component.after(()=>
			component.correspondingRigidbody().movePositionTo(position, boolean));
	public static ComponentT movePositionTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.movePositionTo(transform.position, boolean);
	public static ComponentT movePositionTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.movePositionTo(gameObject.position(), boolean);
	public static ComponentT movePositionTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.movePositionTo(otherComponent.position(), boolean);
	public static Vector3 positionForMovingPositionTo<ComponentT>(this ComponentT component, Vector3 targetPosition) where ComponentT : Component
		=> component.correspondingRigidbody().positionForMovingPositionTo(targetPosition);
	public static Vector3 displacementForMovingPositionTo<ComponentT>(this ComponentT component, Vector3 targetPosition) where ComponentT : Component
		=> component.correspondingRigidbody().displacementForMovingPositionTo(targetPosition);
	// method: (according to the given boolean:) set the (global) position for the transform of this given component to the given (global) position, then return this given component //
	public static ComponentT setPositionTo<ComponentT>(this ComponentT component, Vector3 position, bool boolean = true) where ComponentT : Component
	{
		component.transform.setPositionTo(position, boolean);

		return component;
	}
	// method: (according to the given boolean:) set the (global) position for the transform of this given component to the (global) position for the given x, y, and z values, then return this given component //
	public static ComponentT setPositionTo<ComponentT>(this ComponentT component, float x, float y, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setPositionTo(x, y, z, boolean);

		return component;
	}
	public static ComponentT setPositionTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setPositionTo(transform.position, boolean);
	public static ComponentT setPositionTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setPositionTo(gameObject.position(), boolean);
	public static ComponentT setPositionTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setPositionTo(otherComponent.position(), boolean);
	public static ComponentT setPositionTo<ComponentT>(this ComponentT component, RaycastHit raycastHit, bool boolean = true) where ComponentT : Component
		=> component.setPositionTo(component.position(), boolean);
	// method: (according to the given boolean:) reset the (global) position for the transform of this given component to zeroes, then return this given component //
	public static ComponentT resetPosition<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetPosition(boolean);

		return component;
	}
	public static ComponentT displacePositionBy<ComponentT>(this ComponentT component, Vector3 displacement, bool boolean = true) where ComponentT : Component
		=> component.after(()=>
			component.transform.displacePositionBy(displacement));



	// method: return the (global) x position of the transform of this given component //
	public static float positionX<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.positionX();
	// methods: (assumes this component has a rigidbody attached:) (according to the given boolean:) move this given component's (global) x position to the given x position provider (try to set, but respect collisions in the way), then return this given component //
	public static ComponentT movePositionXTo<ComponentT>(this ComponentT component, float x, bool boolean = true) where ComponentT : Component
		=> component.after(()=>
			component.correspondingRigidbody().movePositionXTo(x, boolean));
	public static ComponentT movePositionXTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.movePositionXTo(transform.position.x, boolean);
	public static ComponentT movePositionXTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.movePositionXTo(gameObject.position().x, boolean);
	public static ComponentT movePositionXTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.movePositionXTo(otherComponent.position().x, boolean);
	// method: (according to the given boolean:) set the (global) x position for the transform of this given component to the given x value, then return this given component //
	public static ComponentT setPositionXTo<ComponentT>(this ComponentT component, float x, bool boolean = true) where ComponentT : Component
		=> component.after(()=>
			component.transform.setPositionXTo(x, boolean));
	public static ComponentT setPositionXTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setPositionXTo(transform.positionX(), boolean);
	public static ComponentT setPositionXTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setPositionXTo(gameObject.positionX(), boolean);
	public static ComponentT setPositionXTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setPositionXTo(otherComponent.positionX(), boolean);
	// method: (according to the given boolean:) reset the (global) x position for the transform of this given component to zero, then return this given component //
	public static ComponentT resetPositionX<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetPositionX(boolean);

		return component;
	}



	// method: return the (global) y position of the transform of this given component //
	public static float positionY<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.positionY();
	// methods: (assumes this component has a rigidbody attached:) (according to the given boolean:) move this given component's (global) y position to the given y position provider (try to set, but respect collisions in the way), then return this given component //
	public static ComponentT movePositionYTo<ComponentT>(this ComponentT component, float y, bool boolean = true) where ComponentT : Component
		=> component.after(()=>
			component.correspondingRigidbody().movePositionYTo(y, boolean));
	public static ComponentT movePositionYTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.movePositionYTo(transform.position.y, boolean);
	public static ComponentT movePositionYTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.movePositionYTo(gameObject.position().y, boolean);
	public static ComponentT movePositionYTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.movePositionYTo(otherComponent.position().y, boolean);
	// method: (according to the given boolean:) set the (global) y position for the transform of this given component to the given y value, then return this given component //
	public static ComponentT setPositionYTo<ComponentT>(this ComponentT component, float y, bool boolean = true) where ComponentT : Component
	{
		component.transform.setPositionYTo(y, boolean);

		return component;
	}
	public static ComponentT setPositionYTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setPositionYTo(transform.positionY(), boolean);
	public static ComponentT setPositionYTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setPositionYTo(gameObject.positionY(), boolean);
	public static ComponentT setPositionYTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setPositionYTo(otherComponent.positionY(), boolean);
	// method: (according to the given boolean:) reset the (global) y position for the transform of this given component to zero, then return this given component //
	public static ComponentT resetPositionY<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetPositionY(boolean);

		return component;
	}
	// method: (according to the given boolean:) negate this given component's (global) y position, then return this given component //
	public static ComponentT negatePositionY<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.negatePositionY(boolean);

		return component;
	}



	// method: return the (global) z position of the transform of this given component //
	public static float positionZ<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.positionZ();
	// methods: (assumes this component has a rigidbody attached:) (according to the given boolean:) move this given component's (global) z position to the given z position provider (try to set, but respect collisions in the way), then return this given component //
	public static ComponentT movePositionZTo<ComponentT>(this ComponentT component, float z, bool boolean = true) where ComponentT : Component
		=> component.after(()=>
			component.correspondingRigidbody().movePositionZTo(z, boolean));
	public static ComponentT movePositionZTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.movePositionZTo(transform.position.z, boolean);
	public static ComponentT movePositionZTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.movePositionZTo(gameObject.position().z, boolean);
	public static ComponentT movePositionZTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.movePositionZTo(otherComponent.position().z, boolean);
	// method: (according to the given boolean:) set the (global) z position for the transform of this given component to the given z value, then return this given component //
	public static ComponentT setPositionZTo<ComponentT>(this ComponentT component, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setPositionZTo(z, boolean);

		return component;
	}
	public static ComponentT setPositionZTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setPositionZTo(transform.positionZ(), boolean);
	public static ComponentT setPositionZTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setPositionZTo(gameObject.positionZ(), boolean);
	public static ComponentT setPositionZTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setPositionZTo(otherComponent.positionZ(), boolean);
	// method: (according to the given boolean:) reset the (global) z position for the transform of this given component to zero, then return this given component //
	public static ComponentT resetPositionZ<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetPositionZ(boolean);

		return component;
	}



	// method: return the (global) rotation of the transform of this given component //
	public static Quaternion rotation<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.rotation;
	// method: (according to the given boolean:) set the (global) rotation for the transform of this given component to the given (global) rotation, then return this given component //
	public static ComponentT setRotationTo<ComponentT>(this ComponentT component, Quaternion rotation, bool boolean = true) where ComponentT : Component
	{
		component.transform.setRotationTo(rotation, boolean);

		return component;
	}
	public static ComponentT setRotationTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setRotationTo(transform.rotation, boolean);
	public static ComponentT setRotationTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setRotationTo(gameObject.rotation(), boolean);
	public static ComponentT setRotationTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setRotationTo(otherComponent.rotation(), boolean);
	// method: (according to the given boolean:) reset the (global) rotation for the transform of this given component to no rotation, then return this given component //
	public static ComponentT resetRotation<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetRotation(boolean);

		return component;
	}



	// method: return the (global) euler angles of the transform of this given component //
	public static Vector3 eulerAngles<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.eulerAngles;
	// method: (according to the given boolean:) set the (global) euler angles of the transform of this given component to the given (global) euler angles, then return this given component //
	public static ComponentT setEulerAnglesTo<ComponentT>(this ComponentT component, Vector3 eulerAngles, bool boolean = true) where ComponentT : Component
	{
		component.transform.setEulerAnglesTo(eulerAngles, boolean);

		return component;
	}
	// method: (according to the given boolean:) set the (global) euler angles of the transform of this given component to the (global) euler angles for the given x, y, and z values, then return this given component //
	public static ComponentT setEulerAnglesTo<ComponentT>(this ComponentT component, float x, float y, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setEulerAnglesTo(x, y, z, boolean);

		return component;
	}
	public static ComponentT setEulerAnglesTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setEulerAnglesTo(transform.eulerAngles, boolean);
	public static ComponentT setEulerAnglesTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setEulerAnglesTo(gameObject.eulerAngles(), boolean);
	public static ComponentT setEulerAnglesTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setEulerAnglesTo(otherComponent.eulerAngles(), boolean);
	// method: (according to the given boolean:) reset the (global) euler angles for the transform of this given component to zeroes, then return this given component //
	public static ComponentT resetEulerAngles<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetEulerAngles(boolean);

		return component;
	}



	// method: return the (global) x euler angle of the transform of this given component //
	public static float eulerAngleX<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.eulerAngleX();
	// method: (according to the given boolean:) set the (global) x euler angle of the transform of this given component to the given x value, then return this given component //
	public static ComponentT setEulerAngleXTo<ComponentT>(this ComponentT component, float x, bool boolean = true) where ComponentT : Component
	{
		component.transform.setEulerAngleXTo(x, boolean);

		return component;
	}
	public static ComponentT setEulerAngleXTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleXTo(transform.eulerAngleX(), boolean);
	public static ComponentT setEulerAngleXTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleXTo(gameObject.eulerAngleX(), boolean);
	public static ComponentT setEulerAngleXTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleXTo(otherComponent.eulerAngleX(), boolean);
	// method: (according to the given boolean:) reset the (global) x euler angle for the transform of this given component to zero, then return this given component //
	public static ComponentT resetEulerAngleX<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetEulerAngleX(boolean);

		return component;
	}



	// method: return the (global) y euler angle of the transform of this given component //
	public static float eulerAngleY<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.eulerAngleY();
	// method: (according to the given boolean:) set the (global) y euler angle of the transform of this given component to the given y value, then return this given component //
	public static ComponentT setEulerAngleYTo<ComponentT>(this ComponentT component, float y, bool boolean = true) where ComponentT : Component
	{
		component.transform.setEulerAngleYTo(y, boolean);

		return component;
	}
	public static ComponentT setEulerAngleYTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleYTo(transform.eulerAngleY(), boolean);
	public static ComponentT setEulerAngleYTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleYTo(gameObject.eulerAngleY(), boolean);
	public static ComponentT setEulerAngleYTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleYTo(otherComponent.eulerAngleY(), boolean);
	// method: (according to the given boolean:) reset the (global) y euler angle for the transform of this given component to zero, then return this given component //
	public static ComponentT resetEulerAngleY<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetEulerAngleY(boolean);

		return component;
	}



	// method: return the (global) z euler angle of the transform of this given component //
	public static float eulerAngleZ<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.eulerAngleZ();
	// method: (according to the given boolean:) set the (global) z euler angle of the transform of this given component to the given z value, then return this given component //
	public static ComponentT setEulerAngleZTo<ComponentT>(this ComponentT component, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setEulerAngleZTo(z, boolean);

		return component;
	}
	public static ComponentT setEulerAngleZTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleZTo(transform.eulerAngleZ(), boolean);
	public static ComponentT setEulerAngleZTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleZTo(gameObject.eulerAngleZ(), boolean);
	public static ComponentT setEulerAngleZTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleZTo(otherComponent.eulerAngleZ(), boolean);
	// method: (according to the given boolean:) reset the (global) z euler angle for the transform of this given component to zero, then return this given component //
	public static ComponentT resetEulerAngleZ<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetEulerAngleZ(boolean);

		return component;
	}



	// method: (according to the given boolean:) set this given transform's (global) scale to the given transform's (global) scale, then return this given transform //
	public static ComponentT setScaleTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.after(()=>
			component.transform.setScaleTo(transform),
			boolean);
	// method: (according to the given boolean:) set this given transform's (global) scale to the given game object's (global) scale, then return this given transform //
	public static ComponentT setScaleTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.after(()=>
			component.transform.setScaleTo(gameObject),
			boolean);
	// method: (according to the given boolean:) set this given transform's (global) scale to the other given component's (global) scale, then return this given transform //
	public static ComponentT setScaleTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.after(()=>
			component.transform.setScaleTo(otherComponent),
			boolean);



	// method: (according to the given boolean:) set the global transformations (global position, global rotation) for the transform of this given component respectively to the given (global) position and (global) rotation //
	public static ComponentT setGlobalsTo<ComponentT>(this ComponentT component, Vector3 position, Quaternion rotation, bool boolean = true) where ComponentT : Component
	{
		component.transform.setGlobalsTo(position, rotation, boolean);

		return component;
	}
	public static ComponentT setGlobalsTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setGlobalsTo(transform.position, transform.rotation, boolean);
	public static ComponentT setGlobalsTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setGlobalsTo(gameObject.position(), gameObject.rotation(), boolean);
	public static ComponentT setGlobalsTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setGlobalsTo(otherComponent.position(), otherComponent.rotation(), boolean);
	// method: (according to the given boolean:) set the global transformations (global position, global euler angles) for the transform of this given component respectively to the given (global) position and (global) euler angles //
	public static ComponentT setGlobalsTo<ComponentT>(this ComponentT component, Vector3 position, Vector3 eulerAngles, bool boolean = true) where ComponentT : Component
	{
		component.transform.setGlobalsTo(position, eulerAngles, boolean);

		return component;
	}
	// method: (according to the given boolean:) reset the global transformations (global position, global rotation) for the transform of this given component respectively to zeroes and no rotation //
	public static ComponentT resetGlobals<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetGlobals(boolean);

		return component;
	}



	// method: (according to the given boolean:) set the global transformations (global position, global rotation) and local scale for the transform of this given component respectively to the given (global) position and (global) rotation and local scale //
	public static ComponentT setGlobalsAndLocalScaleTo<ComponentT>(this ComponentT component, Vector3 position, Quaternion rotation, Vector3 localScale, bool boolean = true) where ComponentT : Component
	{
		component.transform.setGlobalsAndLocalScaleTo(position, rotation, localScale, boolean);

		return component;
	}
	public static ComponentT setGlobalsAndLocalScaleTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setGlobalsAndLocalScaleTo(transform.position, transform.rotation, transform.localScale, boolean);
	public static ComponentT setGlobalsAndLocalScaleTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setGlobalsAndLocalScaleTo(gameObject.position(), gameObject.rotation(), gameObject.localScale(), boolean);
	public static ComponentT setGlobalsAndLocalScaleTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setGlobalsAndLocalScaleTo(otherComponent.position(), otherComponent.rotation(), otherComponent.localScale(), boolean);
	// method: (according to the given boolean:) set the global transformations (global position, global euler angles) and local scale for the transform of this given component respectively to the given (global) position and (global) euler angles and local scale //
	public static ComponentT setGlobalsAndLocalScaleTo<ComponentT>(this ComponentT component, Vector3 position, Vector3 eulerAngles, Vector3 localScale, bool boolean = true) where ComponentT : Component
	{
		component.transform.setGlobalsAndLocalScaleTo(position, eulerAngles, localScale, boolean);

		return component;
	}
	// method: (according to the given boolean:) reset the global transformations (global position, global rotation) and local scale for the transform of this given component respectively to zeroes, no rotation, and ones //
	public static ComponentT resetGlobalsAndLocalScale<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetGlobalsAndLocalScale(boolean);

		return component;
	}



	// method: (according to the given boolean:) set this given component's (global) transformations respectively to the given (global) position and (global) rotation, and set this given component's (global) scale to the (global) scale of the given provided transform, then return this given component //
	public static ComponentT setTransformationsTo<ComponentT>(this ComponentT component, Vector3 position, Quaternion rotation, object transform_TransformProvider, bool boolean = true) where ComponentT : Component
	{
		Transform transform = Provide.transformVia(transform_TransformProvider);

		return component.after(()=>
			component.transform.setTransformationsTo(position, rotation, transform, boolean));
	}
	// method: (according to the given boolean:) set this given component's (global) transformations respectively to the given (global) position and (global) euler angles, and set this given component's (global) scale to the (global) scale of the given provided transform, then return this given component //
	public static ComponentT setTransformationsTo<ComponentT>(this ComponentT component, Vector3 position, Vector3 eulerAngles, object transform_TransformProvider, bool boolean = true) where ComponentT : Component
	{
		Transform transform = Provide.transformVia(transform_TransformProvider);

		return component.after(()=>
			component.transform.setTransformationsTo(position, eulerAngles, transform, boolean));
	}
	// method: (according to the given boolean:) set this given component's (global) transformations respectively to (global) transformations of the given provided transform, then return this given component //
	public static ComponentT setTransformationsTo<ComponentT>(this ComponentT component, object transform_TransformProvider, bool boolean = true) where ComponentT : Component
	{
		Transform transform = Provide.transformVia(transform_TransformProvider);

		return component.after(()=>
			component.transform.setTransformationsTo(transform, boolean));
	}
}