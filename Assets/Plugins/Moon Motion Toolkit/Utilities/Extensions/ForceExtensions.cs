using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Force Extensions: provides extension methods for handling forces
// #force
public static class ForceExtensions
{
	#region applying force
	// methods: (should be called during FixedUpdate:) (according to the given boolean:) apply the given force (which should not be a product from multiplication with an update interval) to this given provided rigidbody (accelerate it with respect to (by dividing the acceleration by) its mass), then return this given provided rigidbody //


	#region given a vector

	public static Rigidbody applyForceOf(this Rigidbody rigidbody, Vector3 force, bool boolean = true)
	{
		if (boolean)
		{
			rigidbody.AddForce(force);
		}

		return rigidbody;
	}
	public static GameObject applyForceOf(this GameObject gameObject, Vector3 force, bool boolean = true)
		=> boolean ?
				gameObject.rigidbody().applyForceOf(force).gameObject :
				gameObject;
	public static ComponentT applyForceOf<ComponentT>(this ComponentT component, Vector3 force, bool boolean = true) where ComponentT : Component
		=> component.after(()=>
			   component.rigidbody().applyForceOf(force, boolean));
	#endregion given a vector


	#region given vector axes

	public static Rigidbody applyForceOf(this Rigidbody rigidbody, float forceX, float forceY, float forceZ, bool boolean = true)
		=> rigidbody.applyForceOf(new Vector3(forceX, forceY, forceZ), boolean);

	public static GameObject applyForceOf(this GameObject gameObject, float forceX, float forceY, float forceZ, bool boolean = true)
		=> gameObject.applyForceOf(new Vector3(forceX, forceY, forceZ), boolean);

	public static ComponentT applyForceOf<ComponentT>(this ComponentT component, float forceX, float forceY, float forceZ, bool boolean = true) where ComponentT : Component
		=> component.applyForceOf(new Vector3(forceX, forceY, forceZ), boolean);
	#endregion given vector axes


	#region given a direction and magnitude

	public static Rigidbody applyForceAlong(this Rigidbody rigidbody, Vector3 direction, float magnitude, bool boolean = true)
		=> rigidbody.applyForceOf(magnitude * direction, boolean);
	public static GameObject applyForceAlong(this GameObject gameObject, Vector3 direction, float magnitude, bool boolean = true)
		=> gameObject.applyForceOf(magnitude * direction, boolean);
	public static ComponentT applyForceAlong<ComponentT>(this ComponentT component, Vector3 direction, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceOf(magnitude * direction, boolean);
	#endregion given a magnitude and direction


	#region given a local basic direction and magnitude

	public static Rigidbody applyForceAlongLocal(this Rigidbody rigidbody, BasicDirection basicDirection, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(basicDirection.asDirectionRelativeTo(rigidbody), magnitude, boolean);
	public static GameObject applyForceAlongLocal(this GameObject gameObject, BasicDirection basicDirection, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(basicDirection.asDirectionRelativeTo(gameObject), magnitude, boolean);
	public static ComponentT applyForceAlongLocal<ComponentT>(this ComponentT component, BasicDirection basicDirection, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(basicDirection.asDirectionRelativeTo(component), magnitude, boolean);
	#endregion given a local basic direction and magnitude


	#region given a global basic direction and magnitude

	public static Rigidbody applyForceAlongGlobal(this Rigidbody rigidbody, BasicDirection basicDirection, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(basicDirection.asGlobalDirection(), magnitude, boolean);
	public static GameObject applyForceAlongGlobal(this GameObject gameObject, BasicDirection basicDirection, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(basicDirection.asGlobalDirection(), magnitude, boolean);
	public static ComponentT applyForceAlongGlobal<ComponentT>(this ComponentT component, BasicDirection basicDirection, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(basicDirection.asGlobalDirection(), magnitude, boolean);
	#endregion given a global basic direction and magnitude


	#region in the respective basic direction – relative to this given rigidbody provider – given a magnitude

	#region forward – relative to this given rigidbody provider – given a magnitude
	public static Rigidbody applyForwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(rigidbody.forward(), magnitude, boolean);
	public static GameObject applyForwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(gameObject.forward(), magnitude, boolean);
	public static ComponentT applyForwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(component.forward(), magnitude, boolean);
	#endregion forward – relative to this given rigidbody provider – given a magnitude
	
	#region backward – relative to this given rigidbody provider – given a magnitude
	public static Rigidbody applyBackwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(rigidbody.backward(), magnitude, boolean);
	public static GameObject applyBackwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(gameObject.backward(), magnitude, boolean);
	public static ComponentT applyBackwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(component.backward(), magnitude, boolean);
	#endregion backward – relative to this given rigidbody provider – given a magnitude
	
	#region rightward – relative to this given rigidbody provider – given a magnitude
	public static Rigidbody applyRightwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(rigidbody.right(), magnitude, boolean);
	public static GameObject applyRightwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(gameObject.right(), magnitude, boolean);
	public static ComponentT applyRightwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(component.right(), magnitude, boolean);
	#endregion rightward – relative to this given rigidbody provider – given a magnitude
	
	#region leftward – relative to this given rigidbody provider – given a magnitude
	public static Rigidbody applyLeftwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(rigidbody.left(), magnitude, boolean);
	public static GameObject applyLeftwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(gameObject.left(), magnitude, boolean);
	public static ComponentT applyLeftwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(component.left(), magnitude, boolean);
	#endregion leftward – relative to this given rigidbody provider – given a magnitude
	
	#region upward – relative to this given rigidbody provider – given a magnitude
	public static Rigidbody applyUpwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(rigidbody.up(), magnitude, boolean);
	public static GameObject applyUpwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(gameObject.up(), magnitude, boolean);
	public static ComponentT applyUpwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(component.up(), magnitude, boolean);
	#endregion upward – relative to this given rigidbody provider – given a magnitude
	
	#region downward – relative to this given rigidbody provider – given a magnitude
	public static Rigidbody applyDownwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(rigidbody.down(), magnitude, boolean);
	public static GameObject applyDownwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(gameObject.down(), magnitude, boolean);
	public static ComponentT applyDownwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(component.down(), magnitude, boolean);
	#endregion downward – relative to this given rigidbody provider – given a magnitude
	#endregion in the respective basic direction – relative to this given rigidbody provider – given a magnitude


	#region in the respective basic direction – globally – given a magnitude

	#region forward – globally – given a magnitude
	public static Rigidbody applyGlobalForwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(Direction.forward, magnitude, boolean);
	public static GameObject applyGlobalForwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(Direction.forward, magnitude, boolean);
	public static ComponentT applyGlobalForwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(Direction.forward, magnitude, boolean);
	#endregion forward – globally – given a magnitude

	#region backward – globally – given a magnitude
	public static Rigidbody applyGlobalBackwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(Direction.backward, magnitude, boolean);
	public static GameObject applyGlobalBackwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(Direction.backward, magnitude, boolean);
	public static ComponentT applyGlobalBackwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(Direction.backward, magnitude, boolean);
	#endregion backward – globally – given a magnitude

	#region rightward – globally – given a magnitude
	public static Rigidbody applyGlobalRightwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(Direction.right, magnitude, boolean);
	public static GameObject applyGlobalRightwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(Direction.right, magnitude, boolean);
	public static ComponentT applyGlobalRightwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(Direction.right, magnitude, boolean);
	#endregion rightward – globally – given a magnitude

	#region leftward – globally – given a magnitude
	public static Rigidbody applyGlobalLeftwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(Direction.left, magnitude, boolean);
	public static GameObject applyGlobalLeftwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(Direction.left, magnitude, boolean);
	public static ComponentT applyGlobalLeftwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(Direction.left, magnitude, boolean);
	#endregion leftward – globally – given a magnitude

	#region upward – globally – given a magnitude
	public static Rigidbody applyGlobalUpwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(Direction.up, magnitude, boolean);
	public static GameObject applyGlobalUpwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(Direction.up, magnitude, boolean);
	public static ComponentT applyGlobalUpwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(Direction.up, magnitude, boolean);
	#endregion upward – globally – given a magnitude

	#region downward – globally – given a magnitude
	public static Rigidbody applyGlobalDownwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(Direction.down, magnitude, boolean);
	public static GameObject applyGlobalDownwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(Direction.down, magnitude, boolean);
	public static ComponentT applyGlobalDownwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(Direction.down, magnitude, boolean);
	#endregion downward – globally – given a magnitude
	#endregion in the respective basic direction – globally – given a magnitude

	#endregion applying force
}