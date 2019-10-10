using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Basic Direction Extensions: provides extension methods for handling basic directions //
public static class BasicDirectionExtensions
{
	#region relative directions
	// methods: return the vector for the respective direction relative to this given transform provider //

	public static Vector3 forward(this Transform transform)
		=> transform.forward;
	public static Vector3 forward(this GameObject gameObject)
		=> gameObject.transform.forward();
	public static Vector3 forward(this Component component)
		=> component.transform.forward();

	public static Vector3 backward(this Transform transform)
		=> -transform.forward;
	public static Vector3 backward(this GameObject gameObject)
		=> gameObject.transform.backward();
	public static Vector3 backward(this Component component)
		=> component.transform.backward();

	public static Vector3 right(this Transform transform)
		=> transform.right;
	public static Vector3 right(this GameObject gameObject)
		=> gameObject.transform.right();
	public static Vector3 right(this Component component)
		=> component.transform.right();

	public static Vector3 left(this Transform transform)
		=> -transform.right;
	public static Vector3 left(this GameObject gameObject)
		=> gameObject.transform.left();
	public static Vector3 left(this Component component)
		=> component.transform.left();

	public static Vector3 up(this Transform transform)
		=> transform.up;
	public static Vector3 up(this GameObject gameObject)
		=> gameObject.transform.up();
	public static Vector3 up(this Component component)
		=> component.transform.up();

	public static Vector3 down(this Transform transform)
		=> -transform.up;
	public static Vector3 down(this GameObject gameObject)
		=> gameObject.transform.down();
	public static Vector3 down(this Component component)
		=> component.transform.down();

	public static Vector3 relativeDirectionFor(this Transform transform, BasicDirection basicDirection)
		=> basicDirection.asDirectionRelativeTo(transform);
	public static Vector3 relativeDirectionFor(this GameObject gameObject, BasicDirection basicDirection)
		=> gameObject.transform.relativeDirectionFor(basicDirection);
	public static Vector3 relativeDirectionFor(this Component component, BasicDirection basicDirection)
		=> component.transform.relativeDirectionFor(basicDirection);
	#endregion relative directions


	#region conversion

	// method: return the (global) direction corresponding to this given basic direction //
	public static Vector3 asGlobalDirection(this BasicDirection basicDirection)
	{
		switch (basicDirection)
		{
			case BasicDirection.forward:
				return Direction.forward;
			case BasicDirection.backward:
				return Direction.backward;
			case BasicDirection.right:
				return Direction.right;
			case BasicDirection.left:
				return Direction.left;
			case BasicDirection.up:
				return Direction.up;
			case BasicDirection.down:
				return Direction.down;
		}
		return Vector3.zero;        // fallback
	}

	// method: return the local direction for this given basic direction, as relative to the given transform provider //
	public static Vector3 asDirectionRelativeTo(this BasicDirection basicDirection, object transform_TransformProvider)
	{
		Transform transform = Provide.transformVia(transform_TransformProvider);

		switch (basicDirection)
		{
			case BasicDirection.forward:
				return transform.forward();
			case BasicDirection.backward:
				return transform.backward();
			case BasicDirection.right:
				return transform.right();
			case BasicDirection.left:
				return transform.left();
			case BasicDirection.up:
				return transform.up();
			case BasicDirection.down:
				return transform.down();
		}
		return Vector3.zero;        // fallback
	}

	// method: return the direction for this given basic direction and the given distinctivity and given potential transform provider (used only if the distinctivity is relative) //
	public static Vector3 asDirection(this BasicDirection basicDirection, Distinctivity distinctivity, object potentialTransform_TransformProvider)
	{
		if (distinctivity.isAbsolute())
		{
			return basicDirection.asGlobalDirection();
		}
		
		Transform transform = Provide.transformVia(potentialTransform_TransformProvider);
		return basicDirection.asDirectionRelativeTo(transform);
	}
	#endregion conversion
}