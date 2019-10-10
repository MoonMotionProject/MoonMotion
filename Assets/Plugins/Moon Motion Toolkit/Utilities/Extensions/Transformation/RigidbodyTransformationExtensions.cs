using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rigidbody Transformation Extensions: provides extension methods for handling rigidbody transformations
// #auto #transform #transformations
public static class RigidbodyTransformationExtensions
{
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
	public static Vector3 positionForMovingPositionTo(this Rigidbody rigidbody, Vector3 targetPosition)
	{
		Vector3 originalPosition = rigidbody.position();
		rigidbody.movePositionTo(targetPosition);
		Vector3 movedPosition = rigidbody.position();
		rigidbody.setPositionTo(originalPosition);
		return movedPosition;
	}
	public static Vector3 displacementForMovingPositionTo(this Rigidbody rigidbody, Vector3 targetPosition)
		=> rigidbody.displacementTo(rigidbody.positionForMovingPositionTo(targetPosition));


	// methods: (according to the given boolean:) move this given rigidbody's x position to the given x position provider (try to set, but respect collisions in the way), then return this given rigidbody //

	public static Rigidbody movePositionXTo(this Rigidbody rigidbody, float x, bool boolean = true)
		=> rigidbody.movePositionTo(rigidbody.position().withX(x), boolean);
	public static Rigidbody movePositionXTo(this Rigidbody rigidbody, Transform transform, bool boolean = true)
		=> rigidbody.movePositionXTo(transform.position.x);
	public static Rigidbody movePositionXTo(this Rigidbody rigidbody, GameObject gameObject, bool boolean = true)
		=> rigidbody.movePositionXTo(gameObject.position().x);
	public static Rigidbody movePositionXTo(this Rigidbody rigidbody, Component component, bool boolean = true)
		=> rigidbody.movePositionXTo(component.position().x);


	// methods: (according to the given boolean:) move this given rigidbody's y position to the given y position provider (try to set, but respect collisions in the way), then return this given rigidbody //

	public static Rigidbody movePositionYTo(this Rigidbody rigidbody, float y, bool boolean = true)
		=> rigidbody.movePositionTo(rigidbody.position().withY(y), boolean);
	public static Rigidbody movePositionYTo(this Rigidbody rigidbody, Transform transform, bool boolean = true)
		=> rigidbody.movePositionYTo(transform.position.y);
	public static Rigidbody movePositionYTo(this Rigidbody rigidbody, GameObject gameObject, bool boolean = true)
		=> rigidbody.movePositionYTo(gameObject.position().y);
	public static Rigidbody movePositionYTo(this Rigidbody rigidbody, Component component, bool boolean = true)
		=> rigidbody.movePositionYTo(component.position().y);


	// methods: (according to the given boolean:) move this given rigidbody's z position to the given z position provider (try to set, but respect collisions in the way), then return this given rigidbody //

	public static Rigidbody movePositionZTo(this Rigidbody rigidbody, float z, bool boolean = true)
		=> rigidbody.movePositionTo(rigidbody.position().withZ(z), boolean);
	public static Rigidbody movePositionZTo(this Rigidbody rigidbody, Transform transform, bool boolean = true)
		=> rigidbody.movePositionZTo(transform.position.z);
	public static Rigidbody movePositionZTo(this Rigidbody rigidbody, GameObject gameObject, bool boolean = true)
		=> rigidbody.movePositionZTo(gameObject.position().z);
	public static Rigidbody movePositionZTo(this Rigidbody rigidbody, Component component, bool boolean = true)
		=> rigidbody.movePositionZTo(component.position().z);
}