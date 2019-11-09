using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rigidbody Transformation Extensions: provides extension methods for handling rigidbody transformations
// #auto #transform #transformations
public static class RigidbodyTransformationExtensions
{
	#region position

	// methods: (according to the given boolean:) move this given rigidbody's position to the given position provider (try to set, but respect collisions in the way), then return this given rigidbody //
	public static Rigidbody movePositionTo(this Rigidbody rigidbody, Vector3 position, bool boolean = true)
	{
		if (boolean)
		{
			rigidbody.MovePosition(position);
		}

		return rigidbody;
	}
	public static Rigidbody movePositionTo(this Rigidbody rigidbody, Transform transform, bool boolean = true)
		=> rigidbody.movePositionTo(transform.position);
	public static Rigidbody movePositionTo(this Rigidbody rigidbody, GameObject gameObject, bool boolean = true)
		=> rigidbody.movePositionTo(gameObject.position());
	public static Rigidbody movePositionTo(this Rigidbody rigidbody, Component component, bool boolean = true)
		=> rigidbody.movePositionTo(component.position());
	public static Rigidbody movePositionTo(this Rigidbody rigidbody, RaycastHit raycastHit, bool boolean = true)
		=> rigidbody.movePositionTo(raycastHit.position());

	public static Rigidbody movePositionToward(this Rigidbody rigidbody, object targetPosition_PositionProvider, float honingDistance, bool boolean = true)
		=>	rigidbody.movePositionTo
			(
				rigidbody.position().honedTo
				(
					targetPosition_PositionProvider.providePosition(),
					honingDistance
				),
				boolean
			);
	#endregion position


	#region x position

	// methods: (according to the given boolean:) move this given rigidbody's x position to the given x position provider (try to set, but respect collisions in the way), then return this given rigidbody //
	public static Rigidbody movePositionXTo(this Rigidbody rigidbody, float x, bool boolean = true)
		=> rigidbody.movePositionTo(rigidbody.position().withX(x), boolean);
	public static Rigidbody movePositionXTo(this Rigidbody rigidbody, Transform transform, bool boolean = true)
		=> rigidbody.movePositionXTo(transform.position.x);
	public static Rigidbody movePositionXTo(this Rigidbody rigidbody, GameObject gameObject, bool boolean = true)
		=> rigidbody.movePositionXTo(gameObject.position().x);
	public static Rigidbody movePositionXTo(this Rigidbody rigidbody, Component component, bool boolean = true)
		=> rigidbody.movePositionXTo(component.position().x);
	// method: return the x position lockedness of this given rigidbody //
	public static bool positionXLockedness(this Rigidbody rigidbody)
		=> rigidbody.constraints.has(RigidbodyConstraints.FreezePositionX);
	// method: (according to the given boolean:) set the x position lockedness of this given rigidbody to the given lockedness boolean, then return this given rigidbody //
	public static Rigidbody setPositionXLockednessTo(this Rigidbody rigidbody, bool lockedness, bool boolean = true)
		=>	rigidbody.after(()=>
				rigidbody.constraints =
					lockedness ?
						rigidbody.constraints |= RigidbodyConstraints.FreezePositionX :
						rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionX,
				boolean);
	// method: (according to the given boolean:) lock this given rigidbody's x position, then return this given rigidbody //
	public static Rigidbody lockPositionX(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setPositionXLockednessTo(true, boolean);
	// method: (according to the given boolean:) unlock this given rigidbody's x position, then return this given rigidbody //
	public static Rigidbody unlockPositionX(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setPositionXLockednessTo(false, boolean);
	#endregion x position


	#region y position

	// methods: (according to the given boolean:) move this given rigidbody's y position to the given y position provider (try to set, but respect collisions in the way), then return this given rigidbody //
	public static Rigidbody movePositionYTo(this Rigidbody rigidbody, float y, bool boolean = true)
		=> rigidbody.movePositionTo(rigidbody.position().withY(y), boolean);
	public static Rigidbody movePositionYTo(this Rigidbody rigidbody, Transform transform, bool boolean = true)
		=> rigidbody.movePositionYTo(transform.position.y);
	public static Rigidbody movePositionYTo(this Rigidbody rigidbody, GameObject gameObject, bool boolean = true)
		=> rigidbody.movePositionYTo(gameObject.position().y);
	public static Rigidbody movePositionYTo(this Rigidbody rigidbody, Component component, bool boolean = true)
		=> rigidbody.movePositionYTo(component.position().y);
	// method: return the y position lockedness of this given rigidbody //
	public static bool positionYLockedness(this Rigidbody rigidbody)
		=> rigidbody.constraints.has(RigidbodyConstraints.FreezePositionY);
	// method: (according to the given boolean:) set the y position lockedness of this given rigidbody to the given lockedness boolean, then return this given rigidbody //
	public static Rigidbody setPositionYLockednessTo(this Rigidbody rigidbody, bool lockedness, bool boolean = true)
		=>	rigidbody.after(()=>
				rigidbody.constraints =
					lockedness ?
						rigidbody.constraints |= RigidbodyConstraints.FreezePositionY :
						rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY,
				boolean);
	// method: (according to the given boolean:) lock this given rigidbody's y position, then return this given rigidbody //
	public static Rigidbody lockPositionY(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setPositionYLockednessTo(true, boolean);
	// method: (according to the given boolean:) unlock this given rigidbody's y position, then return this given rigidbody //
	public static Rigidbody unlockPositionY(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setPositionYLockednessTo(false, boolean);
	#endregion y position


	#region z position

	// methods: (according to the given boolean:) move this given rigidbody's z position to the given z position provider (try to set, but respect collisions in the way), then return this given rigidbody //
	public static Rigidbody movePositionZTo(this Rigidbody rigidbody, float z, bool boolean = true)
		=> rigidbody.movePositionTo(rigidbody.position().withZ(z), boolean);
	public static Rigidbody movePositionZTo(this Rigidbody rigidbody, Transform transform, bool boolean = true)
		=> rigidbody.movePositionZTo(transform.position.z);
	public static Rigidbody movePositionZTo(this Rigidbody rigidbody, GameObject gameObject, bool boolean = true)
		=> rigidbody.movePositionZTo(gameObject.position().z);
	public static Rigidbody movePositionZTo(this Rigidbody rigidbody, Component component, bool boolean = true)
		=> rigidbody.movePositionZTo(component.position().z);
	// method: return the z position lockedness of this given rigidbody //
	public static bool positionZLockedness(this Rigidbody rigidbody)
		=> rigidbody.constraints.has(RigidbodyConstraints.FreezePositionZ);
	// method: (according to the given boolean:) set the z position lockedness of this given rigidbody to the given lockedness boolean, then return this given rigidbody //
	public static Rigidbody setPositionZLockednessTo(this Rigidbody rigidbody, bool lockedness, bool boolean = true)
		=>	rigidbody.after(()=>
				rigidbody.constraints =
					lockedness ?
						rigidbody.constraints |= RigidbodyConstraints.FreezePositionZ :
						rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ,
				boolean);
	// method: (according to the given boolean:) lock this given rigidbody's z position, then return this given rigidbody //
	public static Rigidbody lockPositionZ(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setPositionZLockednessTo(true, boolean);
	// method: (according to the given boolean:) unlock this given rigidbody's z position, then return this given rigidbody //
	public static Rigidbody unlockPositionZ(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setPositionZLockednessTo(false, boolean);
	#endregion z position


	#region x euler angle

	// method: return the x euler angle lockedness of this given rigidbody //
	public static bool eulerAngleXLockedness(this Rigidbody rigidbody)
		=> rigidbody.constraints.has(RigidbodyConstraints.FreezeRotationX);
	// method: (according to the given boolean:) set the x euler angle lockedness of this given rigidbody to the given lockedness boolean, then return this given rigidbody //
	public static Rigidbody setEulerAngleXLockednessTo(this Rigidbody rigidbody, bool lockedness, bool boolean = true)
		=>	rigidbody.after(()=>
				rigidbody.constraints =
					lockedness ?
						rigidbody.constraints |= RigidbodyConstraints.FreezeRotationX :
						rigidbody.constraints &= ~RigidbodyConstraints.FreezeRotationX,
				boolean);
	// method: (according to the given boolean:) lock this given rigidbody's x euler angle, then return this given rigidbody //
	public static Rigidbody lockEulerAngleX(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setEulerAngleXLockednessTo(true, boolean);
	// method: (according to the given boolean:) unlock this given rigidbody's x euler angle, then return this given rigidbody //
	public static Rigidbody unlockEulerAngleX(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setEulerAngleXLockednessTo(false, boolean);
	#endregion x euler angle


	#region y euler angle

	// method: return the y euler angle lockedness of this given rigidbody //
	public static bool eulerAngleYLockedness(this Rigidbody rigidbody)
		=> rigidbody.constraints.has(RigidbodyConstraints.FreezeRotationY);
	// method: (according to the given boolean:) set the y euler angle lockedness of this given rigidbody to the given lockedness boolean, then return this given rigidbody //
	public static Rigidbody setEulerAngleYLockednessTo(this Rigidbody rigidbody, bool lockedness, bool boolean = true)
		=>	rigidbody.after(()=>
				rigidbody.constraints =
					lockedness ?
						rigidbody.constraints |= RigidbodyConstraints.FreezeRotationY :
						rigidbody.constraints &= ~RigidbodyConstraints.FreezeRotationY,
				boolean);
	// method: (according to the given boolean:) lock this given rigidbody's y euler angle, then return this given rigidbody //
	public static Rigidbody lockEulerAngleY(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setEulerAngleYLockednessTo(true, boolean);
	// method: (according to the given boolean:) unlock this given rigidbody's y euler angle, then return this given rigidbody //
	public static Rigidbody unlockEulerAngleY(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setEulerAngleYLockednessTo(false, boolean);
	#endregion y euler angle


	#region z euler angle

	// method: return the z euler angle lockedness of this given rigidbody //
	public static bool eulerAngleZLockedness(this Rigidbody rigidbody)
		=> rigidbody.constraints.has(RigidbodyConstraints.FreezeRotationZ);
	// method: (according to the given boolean:) set the z euler angle lockedness of this given rigidbody to the given lockedness boolean, then return this given rigidbody //
	public static Rigidbody setEulerAngleZLockednessTo(this Rigidbody rigidbody, bool lockedness, bool boolean = true)
		=>	rigidbody.after(()=>
				rigidbody.constraints =
					lockedness ?
						rigidbody.constraints |= RigidbodyConstraints.FreezeRotationZ :
						rigidbody.constraints &= ~RigidbodyConstraints.FreezeRotationZ,
				boolean);
	// method: (according to the given boolean:) lock this given rigidbody's z euler angle, then return this given rigidbody //
	public static Rigidbody lockEulerAngleZ(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setEulerAngleZLockednessTo(true, boolean);
	// method: (according to the given boolean:) unlock this given rigidbody's z euler angle, then return this given rigidbody //
	public static Rigidbody unlockEulerAngleZ(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setEulerAngleZLockednessTo(false, boolean);
	#endregion z euler angle
}