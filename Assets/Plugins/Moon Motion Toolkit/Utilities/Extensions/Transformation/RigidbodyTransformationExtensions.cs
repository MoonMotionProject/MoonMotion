using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rigidbody Transformation Extensions: provides extension methods for handling rigidbody transformations //
public static class RigidbodyTransformationExtensions
{
	// method: (according to the given boolean:) move this given rigidbody's position to the given position (try to set it, but respect collisions in the way), then return this given rigidbody //
	public static Rigidbody movePositionTo(this Rigidbody rigidbody, Vector3 position, bool boolean = true)
	{
		if (boolean)
		{
			rigidbody.MovePosition(position);
		}

		return rigidbody;
	}
}