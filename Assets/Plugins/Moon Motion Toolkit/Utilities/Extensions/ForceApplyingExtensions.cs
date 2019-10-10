using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Force Applying Extensions: provides extension methods for applying force
// #force
public static class ForceApplyingExtensions
{
	// methods: (should be called during FixedUpdate:) (according to the given boolean:) apply the force (which should not be a product from multiplication with an update interval) for the respective givens to this given provided rigidbody (accelerate it with respect to (by dividing the acceleration by) its mass), then return this given provided rigidbody //

	
	
	
	#region given a (global direction) vector
	
	
	public static Rigidbody applyForceOf(this Rigidbody rigidbody, Vector3 force, bool boolean = true)
	{
		if (boolean)
		{
			rigidbody.AddForce(force);
		}

		return rigidbody;
	}

	public static List<Rigidbody> applyForceOf(this IEnumerable<Rigidbody> rigidbodies, Vector3 force, bool boolean = true)
		=> rigidbodies.forEachManifested(rigidbody =>
			rigidbody.applyForceOf(force),
			boolean);


	public static GameObject applyForceOf(this GameObject gameObject, Vector3 force, bool boolean = true)
		=> boolean ?
				gameObject.rigidbody().applyForceOf(force).gameObject :
				gameObject;

	public static List<GameObject> applyForceOf(this IEnumerable<GameObject> objects, Vector3 force, bool boolean = true)
		=> objects.forEachManifested(gameObject =>
			gameObject.applyForceOf(force),
			boolean);


	public static ComponentT applyForceOf<ComponentT>(this ComponentT component, Vector3 force, bool boolean = true) where ComponentT : Component
		=>	component.after(()=>
				component.rigidbody().applyForceOf(force),
				boolean);

	public static List<ComponentT> applyForceOf<ComponentT>(this IEnumerable<ComponentT> components, Vector3 force, bool boolean = true) where ComponentT : Component
		=> components.forEachManifested(component =>
			component.applyForceOf(force),
			boolean);
	#endregion given a (global direction) vector




	#region given (global direction) vector axes


	public static Rigidbody applyForceOf(this Rigidbody rigidbody, float forceX, float forceY, float forceZ, bool boolean = true)
		=> rigidbody.applyForceOf(new Vector3(forceX, forceY, forceZ), boolean);

	public static List<Rigidbody> applyForceOf(this IEnumerable<Rigidbody> rigidbodies, float forceX, float forceY, float forceZ, bool boolean = true)
		=> rigidbodies.forEachManifested(rigidbody =>
			rigidbody.applyForceOf(forceX, forceY, forceZ),
			boolean);


	public static GameObject applyForceOf(this GameObject gameObject, float forceX, float forceY, float forceZ, bool boolean = true)
		=> gameObject.applyForceOf(new Vector3(forceX, forceY, forceZ), boolean);

	public static List<GameObject> applyForceOf(this IEnumerable<GameObject> objects, float forceX, float forceY, float forceZ, bool boolean = true)
		=> objects.forEachManifested(gameObject =>
			gameObject.applyForceOf(forceX, forceY, forceZ),
			boolean);


	public static ComponentT applyForceOf<ComponentT>(this ComponentT component, float forceX, float forceY, float forceZ, bool boolean = true) where ComponentT : Component
		=> component.applyForceOf(new Vector3(forceX, forceY, forceZ), boolean);

	public static List<ComponentT> applyForceOf<ComponentT>(this IEnumerable<ComponentT> components, float forceX, float forceY, float forceZ, bool boolean = true) where ComponentT : Component
		=> components.forEachManifested(component =>
			component.applyForceOf(forceX, forceY, forceZ),
			boolean);
	#endregion given (global direction) vector axes




	#region given a (global) direction and magnitude


	public static Rigidbody applyForceAlong(this Rigidbody rigidbody, Vector3 direction, float magnitude, bool boolean = true)
		=> rigidbody.applyForceOf(magnitude * direction, boolean);

	public static List<Rigidbody> applyForceAlong(this IEnumerable<Rigidbody> rigidbodies, Vector3 direction, float magnitude, bool boolean = true)
		=> rigidbodies.forEachManifested(rigidbody =>
			rigidbody.applyForceAlong(direction, magnitude),
			boolean);


	public static GameObject applyForceAlong(this GameObject gameObject, Vector3 direction, float magnitude, bool boolean = true)
		=> gameObject.applyForceOf(magnitude * direction, boolean);

	public static List<GameObject> applyForceAlong(this IEnumerable<GameObject> objects, Vector3 direction, float magnitude, bool boolean = true)
		=> objects.forEachManifested(gameObject =>
			gameObject.applyForceAlong(direction, magnitude),
			boolean);


	public static ComponentT applyForceAlong<ComponentT>(this ComponentT component, Vector3 direction, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceOf(magnitude * direction, boolean);

	public static List<ComponentT> applyForceAlong<ComponentT>(this IEnumerable<ComponentT> components, Vector3 direction, float magnitude, bool boolean = true) where ComponentT : Component
		=> components.forEachManifested(component =>
			component.applyForceAlong(direction, magnitude),
			boolean);
	#endregion given a (global) direction and magnitude




	#region given a direction, distinctivity, potential transform provider, and magnitude


	public static Rigidbody applyForceAlong(this Rigidbody rigidbody, Vector3 direction, Distinctivity distinctivity, object potentialTransform_TransformProvider, float magnitude, bool boolean = true)
	{
		Transform potentialTransform = Provide.transformVia(potentialTransform_TransformProvider);

		return rigidbody.applyForceAlong(direction.toGlobalDirectionFromDistinctivityOf(distinctivity, potentialTransform), magnitude, boolean);
	}

	public static List<Rigidbody> applyForceAlong(this IEnumerable<Rigidbody> rigidbodies, Vector3 direction, Distinctivity distinctivity, object potentialTransform_TransformProvider, float magnitude, bool boolean = true)
	{
		Transform potentialTransform = Provide.transformVia(potentialTransform_TransformProvider);

		return	rigidbodies.forEachManifested(rigidbody =>
					rigidbody.applyForceAlong(direction, distinctivity, potentialTransform, magnitude),
					boolean);
	}


	public static GameObject applyForceAlong(this GameObject gameObject, Vector3 direction, Distinctivity distinctivity, object potentialTransform_TransformProvider, float magnitude, bool boolean = true)
	{
		Transform potentialTransform = Provide.transformVia(potentialTransform_TransformProvider);

		return gameObject.applyForceAlong(direction.toGlobalDirectionFromDistinctivityOf(distinctivity, potentialTransform), magnitude, boolean);
	}

	public static List<GameObject> applyForceAlong(this IEnumerable<GameObject> objects, Vector3 direction, Distinctivity distinctivity, object potentialTransform_TransformProvider, float magnitude, bool boolean = true)
	{
		Transform potentialTransform = Provide.transformVia(potentialTransform_TransformProvider);

		return	objects.forEachManifested(gameObject =>
					gameObject.applyForceAlong(direction, distinctivity, potentialTransform, magnitude),
					boolean);
	}


	public static ComponentT applyForceAlong<ComponentT>(this ComponentT component, Vector3 direction, Distinctivity distinctivity, object potentialTransform_TransformProvider, float magnitude, bool boolean = true) where ComponentT : Component
	{
		Transform potentialTransform = Provide.transformVia(potentialTransform_TransformProvider);

		return component.applyForceAlong(direction.toGlobalDirectionFromDistinctivityOf(distinctivity, potentialTransform), magnitude, boolean);
	}

	public static List<ComponentT> applyForceAlong<ComponentT>(this IEnumerable<ComponentT> components, Vector3 direction, Distinctivity distinctivity, object potentialTransform_TransformProvider, float magnitude, bool boolean = true) where ComponentT : Component
	{
		Transform potentialTransform = Provide.transformVia(potentialTransform_TransformProvider);

		return	components.forEachManifested(component =>
					component.applyForceAlong(direction, distinctivity, potentialTransform, magnitude),
					boolean);
	}
	#endregion given a direction, distinctivity, and magnitude




	#region given a local direction and magnitude


	public static Rigidbody applyForceAlongLocal(this Rigidbody rigidbody, Vector3 localDirection, object transform_TransformProvider, float magnitude, bool boolean = true)
	{
		Transform transform = Provide.transformVia(transform_TransformProvider);

		return rigidbody.applyForceAlong(localDirection, Distinctivity.relative, transform, magnitude, boolean);
	}

	public static List<Rigidbody> applyForceAlongLocal(this IEnumerable<Rigidbody> rigidbodies, Vector3 localDirection, object transform_TransformProvider, float magnitude, bool boolean = true)
	{
		Transform transform = Provide.transformVia(transform_TransformProvider);

		return	rigidbodies.forEachManifested(rigidbody =>
					rigidbody.applyForceAlongLocal(localDirection, transform, magnitude),
					boolean);
	}


	public static GameObject applyForceAlongLocal(this GameObject gameObject, Vector3 localDirection, object transform_TransformProvider, float magnitude, bool boolean = true)
	{
		Transform transform = Provide.transformVia(transform_TransformProvider);

		return gameObject.applyForceAlong(localDirection, Distinctivity.relative, transform, magnitude, boolean);
	}

	public static List<GameObject> applyForceAlongLocal(this IEnumerable<GameObject> objects, Vector3 localDirection, object transform_TransformProvider, float magnitude, bool boolean = true)
	{
		Transform transform = Provide.transformVia(transform_TransformProvider);

		return	objects.forEachManifested(gameObject =>
					gameObject.applyForceAlongLocal(localDirection, transform, magnitude),
					boolean);
	}


	public static ComponentT applyForceAlongLocal<ComponentT>(this ComponentT component, Vector3 localDirection, object transform_TransformProvider, float magnitude, bool boolean = true) where ComponentT : Component
	{
		Transform transform = Provide.transformVia(transform_TransformProvider);

		return component.applyForceAlong(localDirection, Distinctivity.relative, transform, magnitude, boolean);
	}

	public static List<ComponentT> applyForceAlongLocal<ComponentT>(this IEnumerable<ComponentT> components, Vector3 localDirection, object transform_TransformProvider, float magnitude, bool boolean = true) where ComponentT : Component
	{
		Transform transform = Provide.transformVia(transform_TransformProvider);

		return	components.forEachManifested(component =>
					component.applyForceAlongLocal(localDirection, transform, magnitude),
					boolean);
	}
	#endregion given a local direction and magnitude




	#region given a (local) basic direction and magnitude


	public static Rigidbody applyForceAlong(this Rigidbody rigidbody, BasicDirection localBasicDirection, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(localBasicDirection.asDirectionRelativeTo(rigidbody), magnitude, boolean);

	public static List<Rigidbody> applyForceAlong(this IEnumerable<Rigidbody> rigidbodies, BasicDirection localBasicDirection, float magnitude, bool boolean = true)
		=>	rigidbodies.forEachManifested(rigidbody =>
				rigidbody.applyForceAlong(localBasicDirection, magnitude),
				boolean);


	public static GameObject applyForceAlong(this GameObject gameObject, BasicDirection localBasicDirection, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(localBasicDirection.asDirectionRelativeTo(gameObject), magnitude, boolean);

	public static List<GameObject> applyForceAlong(this IEnumerable<GameObject> objects, BasicDirection localBasicDirection, float magnitude, bool boolean = true)
		=>	objects.forEachManifested(gameObject =>
				gameObject.applyForceAlong(localBasicDirection, magnitude),
				boolean);


	public static ComponentT applyForceAlong<ComponentT>(this ComponentT component, BasicDirection localBasicDirection, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(localBasicDirection.asDirectionRelativeTo(component), magnitude, boolean);

	public static List<ComponentT> applyForceAlong<ComponentT>(this IEnumerable<ComponentT> components, BasicDirection localBasicDirection, float magnitude, bool boolean = true) where ComponentT : Component
		=>	components.forEachManifested(component =>
				component.applyForceAlong(localBasicDirection, magnitude),
				boolean);
	#endregion given a (local) basic direction and magnitude




	#region given a global basic direction and magnitude


	public static Rigidbody applyForceAlongGlobal(this Rigidbody rigidbody, BasicDirection basicDirection, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(basicDirection.asGlobalDirection(), magnitude, boolean);

	public static List<Rigidbody> applyForceAlongGlobal(this IEnumerable<Rigidbody> rigidbodies, BasicDirection basicDirection, float magnitude, bool boolean = true)
		=>	rigidbodies.forEachManifested(rigidbody =>
				rigidbody.applyForceAlongGlobal(basicDirection, magnitude),
				boolean);


	public static GameObject applyForceAlongGlobal(this GameObject gameObject, BasicDirection basicDirection, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(basicDirection.asGlobalDirection(), magnitude, boolean);

	public static List<GameObject> applyForceAlongGlobal(this IEnumerable<GameObject> objects, BasicDirection basicDirection, float magnitude, bool boolean = true)
		=>	objects.forEachManifested(gameObject =>
				gameObject.applyForceAlongGlobal(basicDirection, magnitude),
				boolean);


	public static ComponentT applyForceAlongGlobal<ComponentT>(this ComponentT component, BasicDirection basicDirection, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(basicDirection.asGlobalDirection(), magnitude, boolean);

	public static List<ComponentT> applyForceAlongGlobal<ComponentT>(this IEnumerable<ComponentT> components, BasicDirection basicDirection, float magnitude, bool boolean = true) where ComponentT : Component
		=>	components.forEachManifested(component =>
				component.applyForceAlongGlobal(basicDirection, magnitude),
				boolean);
	#endregion given a global basic direction and magnitude




	#region given a basic direction, distinctivity, and magnitude


	public static Rigidbody applyForceAlong(this Rigidbody rigidbody, BasicDirection basicDirection, Distinctivity distinctivity, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(basicDirection.asDirection(distinctivity, rigidbody), magnitude, boolean);

	public static List<Rigidbody> applyForceAlong(this IEnumerable<Rigidbody> rigidbodies, BasicDirection basicDirection, Distinctivity distinctivity, float magnitude, bool boolean = true)
		=>	rigidbodies.forEachManifested(rigidbody =>
				rigidbody.applyForceAlong(basicDirection, distinctivity, magnitude),
				boolean);


	public static GameObject applyForceAlong(this GameObject gameObject, BasicDirection basicDirection, Distinctivity distinctivity, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(basicDirection.asDirection(distinctivity, gameObject), magnitude, boolean);

	public static List<GameObject> applyForceAlong(this IEnumerable<GameObject> objects, BasicDirection basicDirection, Distinctivity distinctivity, float magnitude, bool boolean = true)
		=>	objects.forEachManifested(gameObject =>
				gameObject.applyForceAlong(basicDirection, distinctivity, magnitude),
				boolean);


	public static ComponentT applyForceAlong<ComponentT>(this ComponentT component, BasicDirection basicDirection, Distinctivity distinctivity, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(basicDirection.asDirection(distinctivity, component), magnitude, boolean);

	public static List<ComponentT> applyForceAlong<ComponentT>(this IEnumerable<ComponentT> components, BasicDirection basicDirection, Distinctivity distinctivity, float magnitude, bool boolean = true) where ComponentT : Component
		=>	components.forEachManifested(component =>
				component.applyForceAlong(basicDirection, distinctivity, magnitude),
				boolean);
	#endregion given a basic direction, distinctivity, and magnitude




	#region in the respective basic direction – relative to this given rigidbody provider – given a magnitude


	#region forward – relative to this given rigidbody provider – given a magnitude

	public static Rigidbody applyForwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(rigidbody.forward(), magnitude, boolean);
	public static List<Rigidbody> applyForwardForceOf(this IEnumerable<Rigidbody> rigidbodies, float magnitude, bool boolean = true)
		=>	rigidbodies.forEachManifested(rigidbody =>
				rigidbody.applyForwardForceOf(magnitude),
				boolean);

	public static GameObject applyForwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(gameObject.forward(), magnitude, boolean);
	public static List<GameObject> applyForwardForceOf(this IEnumerable<GameObject> objects, float magnitude, bool boolean = true)
		=>	objects.forEachManifested(gameObject =>
				gameObject.applyForwardForceOf(magnitude),
				boolean);

	public static ComponentT applyForwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(component.forward(), magnitude, boolean);
	public static List<ComponentT> applyForwardForceOf<ComponentT>(this IEnumerable<ComponentT> components, float magnitude, bool boolean = true) where ComponentT : Component
		=>	components.forEachManifested(component =>
				component.applyForwardForceOf(magnitude),
				boolean);
	#endregion forward – relative to this given rigidbody provider – given a magnitude
	

	#region backward – relative to this given rigidbody provider – given a magnitude

	public static Rigidbody applyBackwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(rigidbody.backward(), magnitude, boolean);
	public static List<Rigidbody> applyBackwardForceOf(this IEnumerable<Rigidbody> rigidbodies, float magnitude, bool boolean = true)
		=>	rigidbodies.forEachManifested(rigidbody =>
				rigidbody.applyBackwardForceOf(magnitude),
				boolean);

	public static GameObject applyBackwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(gameObject.backward(), magnitude, boolean);
	public static List<GameObject> applyBackwardForceOf(this IEnumerable<GameObject> objects, float magnitude, bool boolean = true)
		=>	objects.forEachManifested(gameObject =>
				gameObject.applyBackwardForceOf(magnitude),
				boolean);

	public static ComponentT applyBackwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(component.backward(), magnitude, boolean);
	public static List<ComponentT> applyBackwardForceOf<ComponentT>(this IEnumerable<ComponentT> components, float magnitude, bool boolean = true) where ComponentT : Component
		=>	components.forEachManifested(component =>
				component.applyBackwardForceOf(magnitude),
				boolean);
	#endregion backward – relative to this given rigidbody provider – given a magnitude
	

	#region rightward – relative to this given rigidbody provider – given a magnitude

	public static Rigidbody applyRightwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(rigidbody.right(), magnitude, boolean);
	public static List<Rigidbody> applyRightwardForceOf(this IEnumerable<Rigidbody> rigidbodies, float magnitude, bool boolean = true)
		=>	rigidbodies.forEachManifested(rigidbody =>
				rigidbody.applyRightwardForceOf(magnitude),
				boolean);

	public static GameObject applyRightwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(gameObject.right(), magnitude, boolean);
	public static List<GameObject> applyRightwardForceOf(this IEnumerable<GameObject> objects, float magnitude, bool boolean = true)
		=>	objects.forEachManifested(gameObject =>
				gameObject.applyRightwardForceOf(magnitude),
				boolean);

	public static ComponentT applyRightwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(component.right(), magnitude, boolean);
	public static List<ComponentT> applyRightwardForceOf<ComponentT>(this IEnumerable<ComponentT> components, float magnitude, bool boolean = true) where ComponentT : Component
		=>	components.forEachManifested(component =>
				component.applyRightwardForceOf(magnitude),
				boolean);
	#endregion rightward – relative to this given rigidbody provider – given a magnitude
	

	#region leftward – relative to this given rigidbody provider – given a magnitude

	public static Rigidbody applyLeftwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(rigidbody.left(), magnitude, boolean);
	public static List<Rigidbody> applyLeftwardForceOf(this IEnumerable<Rigidbody> rigidbodies, float magnitude, bool boolean = true)
		=>	rigidbodies.forEachManifested(rigidbody =>
				rigidbody.applyLeftwardForceOf(magnitude),
				boolean);

	public static GameObject applyLeftwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(gameObject.left(), magnitude, boolean);
	public static List<GameObject> applyLeftwardForceOf(this IEnumerable<GameObject> objects, float magnitude, bool boolean = true)
		=>	objects.forEachManifested(gameObject =>
				gameObject.applyLeftwardForceOf(magnitude),
				boolean);

	public static ComponentT applyLeftwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(component.left(), magnitude, boolean);
	public static List<ComponentT> applyLeftwardForceOf<ComponentT>(this IEnumerable<ComponentT> components, float magnitude, bool boolean = true) where ComponentT : Component
		=>	components.forEachManifested(component =>
				component.applyLeftwardForceOf(magnitude),
				boolean);
	#endregion leftward – relative to this given rigidbody provider – given a magnitude
	

	#region upward – relative to this given rigidbody provider – given a magnitude

	public static Rigidbody applyUpwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(rigidbody.up(), magnitude, boolean);
	public static List<Rigidbody> applyUpwardForceOf(this IEnumerable<Rigidbody> rigidbodies, float magnitude, bool boolean = true)
		=>	rigidbodies.forEachManifested(rigidbody =>
				rigidbody.applyUpwardForceOf(magnitude),
				boolean);

	public static GameObject applyUpwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(gameObject.up(), magnitude, boolean);
	public static List<GameObject> applyUpwardForceOf(this IEnumerable<GameObject> objects, float magnitude, bool boolean = true)
		=>	objects.forEachManifested(gameObject =>
				gameObject.applyUpwardForceOf(magnitude),
				boolean);

	public static ComponentT applyUpwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(component.up(), magnitude, boolean);
	public static List<ComponentT> applyUpwardForceOf<ComponentT>(this IEnumerable<ComponentT> components, float magnitude, bool boolean = true) where ComponentT : Component
		=>	components.forEachManifested(component =>
				component.applyUpwardForceOf(magnitude),
				boolean);
	#endregion upward – relative to this given rigidbody provider – given a magnitude
	

	#region downward – relative to this given rigidbody provider – given a magnitude

	public static Rigidbody applyDownwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(rigidbody.down(), magnitude, boolean);
	public static List<Rigidbody> applyDownwardForceOf(this IEnumerable<Rigidbody> rigidbodies, float magnitude, bool boolean = true)
		=>	rigidbodies.forEachManifested(rigidbody =>
				rigidbody.applyDownwardForceOf(magnitude),
				boolean);

	public static GameObject applyDownwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(gameObject.down(), magnitude, boolean);
	public static List<GameObject> applyDownwardForceOf(this IEnumerable<GameObject> objects, float magnitude, bool boolean = true)
		=>	objects.forEachManifested(gameObject =>
				gameObject.applyDownwardForceOf(magnitude),
				boolean);

	public static ComponentT applyDownwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(component.down(), magnitude, boolean);
	public static List<ComponentT> applyDownwardForceOf<ComponentT>(this IEnumerable<ComponentT> components, float magnitude, bool boolean = true) where ComponentT : Component
		=>	components.forEachManifested(component =>
				component.applyDownwardForceOf(magnitude),
				boolean);
	#endregion downward – relative to this given rigidbody provider – given a magnitude
	#endregion in the respective basic direction – relative to this given rigidbody provider – given a magnitude




	#region in the respective basic direction – globally – given a magnitude


	#region forward – globally – given a magnitude

	public static Rigidbody applyGlobalForwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(Direction.forward, magnitude, boolean);
	public static List<Rigidbody> applyGlobalForwardForceOf(this IEnumerable<Rigidbody> rigidbodies, float magnitude, bool boolean = true)
		=>	rigidbodies.forEachManifested(rigidbody =>
				rigidbody.applyGlobalForwardForceOf(magnitude),
				boolean);

	public static GameObject applyGlobalForwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(Direction.forward, magnitude, boolean);
	public static List<GameObject> applyGlobalForwardForceOf(this IEnumerable<GameObject> objects, float magnitude, bool boolean = true)
		=>	objects.forEachManifested(gameObject =>
				gameObject.applyGlobalForwardForceOf(magnitude),
				boolean);

	public static ComponentT applyGlobalForwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(Direction.forward, magnitude, boolean);
	public static List<ComponentT> applyGlobalForwardForceOf<ComponentT>(this IEnumerable<ComponentT> components, float magnitude, bool boolean = true) where ComponentT : Component
		=>	components.forEachManifested(component =>
				component.applyGlobalForwardForceOf(magnitude),
				boolean);
	#endregion forward – globally – given a magnitude


	#region backward – globally – given a magnitude

	public static Rigidbody applyGlobalBackwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(Direction.backward, magnitude, boolean);
	public static List<Rigidbody> applyGlobalBackwardForceOf(this IEnumerable<Rigidbody> rigidbodies, float magnitude, bool boolean = true)
		=>	rigidbodies.forEachManifested(rigidbody =>
				rigidbody.applyGlobalBackwardForceOf(magnitude),
				boolean);

	public static GameObject applyGlobalBackwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(Direction.backward, magnitude, boolean);
	public static List<GameObject> applyGlobalBackwardForceOf(this IEnumerable<GameObject> objects, float magnitude, bool boolean = true)
		=>	objects.forEachManifested(gameObject =>
				gameObject.applyGlobalBackwardForceOf(magnitude),
				boolean);

	public static ComponentT applyGlobalBackwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(Direction.backward, magnitude, boolean);
	public static List<ComponentT> applyGlobalBackwardForceOf<ComponentT>(this IEnumerable<ComponentT> components, float magnitude, bool boolean = true) where ComponentT : Component
		=>	components.forEachManifested(component =>
				component.applyGlobalBackwardForceOf(magnitude),
				boolean);
	#endregion backward – globally – given a magnitude


	#region rightward – globally – given a magnitude

	public static Rigidbody applyGlobalRightwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(Direction.right, magnitude, boolean);
	public static List<Rigidbody> applyGlobalRightwardForceOf(this IEnumerable<Rigidbody> rigidbodies, float magnitude, bool boolean = true)
		=>	rigidbodies.forEachManifested(rigidbody =>
				rigidbody.applyGlobalRightwardForceOf(magnitude),
				boolean);

	public static GameObject applyGlobalRightwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(Direction.right, magnitude, boolean);
	public static List<GameObject> applyGlobalRightwardForceOf(this IEnumerable<GameObject> objects, float magnitude, bool boolean = true)
		=>	objects.forEachManifested(gameObject =>
				gameObject.applyGlobalRightwardForceOf(magnitude),
				boolean);

	public static ComponentT applyGlobalRightwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(Direction.right, magnitude, boolean);
	public static List<ComponentT> applyGlobalRightwardForceOf<ComponentT>(this IEnumerable<ComponentT> components, float magnitude, bool boolean = true) where ComponentT : Component
		=>	components.forEachManifested(component =>
				component.applyGlobalRightwardForceOf(magnitude),
				boolean);
	#endregion rightward – globally – given a magnitude


	#region leftward – globally – given a magnitude

	public static Rigidbody applyGlobalLeftwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(Direction.left, magnitude, boolean);
	public static List<Rigidbody> applyGlobalLeftwardForceOf(this IEnumerable<Rigidbody> rigidbodies, float magnitude, bool boolean = true)
		=>	rigidbodies.forEachManifested(rigidbody =>
				rigidbody.applyGlobalLeftwardForceOf(magnitude),
				boolean);

	public static GameObject applyGlobalLeftwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(Direction.left, magnitude, boolean);
	public static List<GameObject> applyGlobalLeftwardForceOf(this IEnumerable<GameObject> objects, float magnitude, bool boolean = true)
		=>	objects.forEachManifested(gameObject =>
				gameObject.applyGlobalLeftwardForceOf(magnitude),
				boolean);

	public static ComponentT applyGlobalLeftwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(Direction.left, magnitude, boolean);
	public static List<ComponentT> applyGlobalLeftwardForceOf<ComponentT>(this IEnumerable<ComponentT> components, float magnitude, bool boolean = true) where ComponentT : Component
		=>	components.forEachManifested(component =>
				component.applyGlobalLeftwardForceOf(magnitude),
				boolean);
	#endregion leftward – globally – given a magnitude


	#region upward – globally – given a magnitude

	public static Rigidbody applyGlobalUpwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(Direction.up, magnitude, boolean);
	public static List<Rigidbody> applyGlobalUpwardForceOf(this IEnumerable<Rigidbody> rigidbodies, float magnitude, bool boolean = true)
		=>	rigidbodies.forEachManifested(rigidbody =>
				rigidbody.applyGlobalUpwardForceOf(magnitude),
				boolean);

	public static GameObject applyGlobalUpwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(Direction.up, magnitude, boolean);
	public static List<GameObject> applyGlobalUpwardForceOf(this IEnumerable<GameObject> objects, float magnitude, bool boolean = true)
		=>	objects.forEachManifested(gameObject =>
				gameObject.applyGlobalUpwardForceOf(magnitude),
				boolean);

	public static ComponentT applyGlobalUpwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(Direction.up, magnitude, boolean);
	public static List<ComponentT> applyGlobalUpwardForceOf<ComponentT>(this IEnumerable<ComponentT> components, float magnitude, bool boolean = true) where ComponentT : Component
		=>	components.forEachManifested(component =>
				component.applyGlobalUpwardForceOf(magnitude),
				boolean);
	#endregion upward – globally – given a magnitude


	#region downward – globally – given a magnitude

	public static Rigidbody applyGlobalDownwardForceOf(this Rigidbody rigidbody, float magnitude, bool boolean = true)
		=> rigidbody.applyForceAlong(Direction.down, magnitude, boolean);
	public static List<Rigidbody> applyGlobalDownwardForceOf(this IEnumerable<Rigidbody> rigidbodies, float magnitude, bool boolean = true)
		=>	rigidbodies.forEachManifested(rigidbody =>
				rigidbody.applyGlobalDownwardForceOf(magnitude),
				boolean);

	public static GameObject applyGlobalDownwardForceOf(this GameObject gameObject, float magnitude, bool boolean = true)
		=> gameObject.applyForceAlong(Direction.down, magnitude, boolean);
	public static List<GameObject> applyGlobalDownwardForceOf(this IEnumerable<GameObject> objects, float magnitude, bool boolean = true)
		=>	objects.forEachManifested(gameObject =>
				gameObject.applyGlobalDownwardForceOf(magnitude),
				boolean);

	public static ComponentT applyGlobalDownwardForceOf<ComponentT>(this ComponentT component, float magnitude, bool boolean = true) where ComponentT : Component
		=> component.applyForceAlong(Direction.down, magnitude, boolean);
	public static List<ComponentT> applyGlobalDownwardForceOf<ComponentT>(this IEnumerable<ComponentT> components, float magnitude, bool boolean = true) where ComponentT : Component
		=>	components.forEachManifested(component =>
				component.applyGlobalDownwardForceOf(magnitude),
				boolean);
	#endregion downward – globally – given a magnitude
	#endregion in the respective basic direction – globally – given a magnitude
}