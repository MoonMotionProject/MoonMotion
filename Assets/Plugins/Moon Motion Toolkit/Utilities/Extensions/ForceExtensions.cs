using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Force Extensions: provides extension methods for handling forces //
public static class ForceExtensions
{
	#region applying force
	// methods: (should be called during FixedUpdate:) (according to the given boolean:) apply the given force (which should not be a product from multiplication with an update interval) to this given rigidbody or provider of a rigidbody (respectively) (accelerate it with respect to (by dividing the acceleration by) its mass), then return this given rigidbody //

	public static Rigidbody applyForceOf(this Rigidbody rigidbody, Vector3 force, bool boolean = true)
	{
		if (boolean)
		{
			rigidbody.AddForce(force);
		}

		return rigidbody;
	}
	public static Rigidbody applyForceOf(this Rigidbody rigidbody, float forceX, float forceY, float forceZ, bool boolean = true)
		=> rigidbody.applyForceOf(new Vector3(forceX, forceY, forceZ), boolean);

	public static GameObject applyForceOf(this GameObject gameObject, Vector3 force, bool boolean = true)
		=>	boolean ?
				gameObject.rigidbody().applyForceOf(force).gameObject :
				gameObject;
	public static GameObject applyForceOf(this GameObject gameObject, float forceX, float forceY, float forceZ, bool boolean = true)
		=> gameObject.applyForceOf(new Vector3(forceX, forceY, forceZ), boolean);

	public static ComponentT applyForceOf<ComponentT>(this ComponentT component, Vector3 force, bool boolean = true) where ComponentT : Component
		=>	component.after(()=>
				component.rigidbody().applyForceOf(force, boolean));
	public static ComponentT applyForceOf<ComponentT>(this ComponentT component, float forceX, float forceY, float forceZ, bool boolean = true) where ComponentT : Component
		=> component.applyForceOf(new Vector3(forceX, forceY, forceZ), boolean);
	#endregion applying force
}