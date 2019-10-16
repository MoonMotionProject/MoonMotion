using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Providing Extensions:
// • provides extension methods for having dynamos provide certain types
//   · a 'dynamo' is a dynamic type, which can be specified as a parameter in a method using the keyword 'dynamic', or as an object – in the current implementation, these methods are intended for use with 'object' parameters
// #auto #dynamics #primitives
public static class ProvidingExtensions
{
	#region Transform

	public static Transform provideTransform(this object dynamo)
	{
		if (dynamo is Transform)
		{
			return dynamo as Transform;
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).transform;
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).transform;
		}
		else
		{
			return default(Transform).returnWithError("ProvidingExtensions.provideTransform given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion Transform


	#region Collider

	public static Collider provideCollider(this object dynamo)
	{
		if (dynamo is Collider)
		{
			return (dynamo as Collider);
		}
		else if (dynamo is RaycastHit?)
		{
			return (dynamo as RaycastHit?).GetValueOrDefault().collider;
		}
		else if (dynamo is RaycastHit)
		{
			return dynamo.castTo<RaycastHit>().collider;
		}
		else
		{
			return default(Collider).returnWithError("ProvidingExtensions.provideCollider given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion Collider


	#region RaycastHit

	public static RaycastHit provideRaycastHit(this object dynamo)
	{
		if (dynamo is RaycastHit?)
		{
			return (dynamo as RaycastHit?).GetValueOrDefault();
		}
		else if (dynamo is RaycastHit)
		{
			return dynamo.castTo<RaycastHit>();
		}
		else
		{
			return default(RaycastHit).returnWithError("ProvidingExtensions.provideRaycastHit given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion RaycastHit


	#region position

	public static Vector3 providePosition(this object dynamo)
	{
		if (dynamo is Vector3?)
		{
			return (dynamo as Vector3?).GetValueOrDefault();
		}
		else if (dynamo is Vector3)
		{
			return dynamo.castTo<Vector3>();
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).position();
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).position();
		}
		else if (dynamo is RaycastHit?)
		{
			return (dynamo as RaycastHit?).GetValueOrDefault().position();
		}
		else if (dynamo is RaycastHit)
		{
			return dynamo.castTo<RaycastHit>().position();
		}
		else
		{
			return default(Vector3).returnWithError("ProvidingExtensions.providePosition given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion position


	#region Rigidbody
	
	public static Rigidbody provideRigidbody(this object dynamo)
	{
		if (dynamo is Rigidbody)
		{
			return dynamo as Rigidbody;
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).rigidbody();
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).rigidbody();
		}
		else
		{
			return default(Rigidbody).returnWithError("ProvidingExtensions.provideRigidbody given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion Rigidbody


	#region List<Rigidbody>
	
	public static List<Rigidbody> provideRigidbodies(this object dynamo)
	{
		if (dynamo is IEnumerable<Rigidbody>)
		{
			return (dynamo as IEnumerable<Rigidbody>).manifested();
		}
		else if (dynamo is IEnumerable<GameObject>)
		{
			return (dynamo as IEnumerable<GameObject>).rigidbodies();
		}
		else if (dynamo is IEnumerable<Component>)
		{
			return (dynamo as IEnumerable<Component>).rigidbodies();
		}
		else if (dynamo is Rigidbody)
		{
			return (dynamo as Rigidbody).startList();
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).rigidbodies();
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).rigidbodies();
		}
		else
		{
			return default(List<Rigidbody>).returnWithError("ProvidingExtensions.provideRigidbodies given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion List<Rigidbody>


	#region mesh

	public static Mesh provideMesh(this object dynamo)
	{
		if (dynamo is Mesh)
		{
			return dynamo.castTo<Mesh>();
		}
		else if (dynamo is GameObject)
		{
			GameObject gameObject = (dynamo as GameObject);
			Mesh mesh = gameObject.firstLocalOrDescendantMesh();
			if (mesh.isNull())
			{
				if (gameObject.firstLocalOrDescendant<BoxCollider>().isYull())
				{
					return Meshes.cube;
				}
				else if (gameObject.firstLocalOrDescendant<SphereCollider>().isYull())
				{
					return Meshes.sphere;
				}
				else if (gameObject.firstLocalOrDescendant<CapsuleCollider>().isYull())
				{
					return Meshes.capsule;
				}
				return null;
			}
			return mesh;
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).gameObject.provideMesh();
		}
		else
		{
			return default(Mesh).returnWithError("ProvidingExtensions.provideMesh given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion mesh


	#region shared mesh

	public static Mesh provideSharedMesh(this object dynamo)
	{
		if (dynamo is Mesh)
		{
			return dynamo.castTo<Mesh>();
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).firstLocalOrDescendantSharedMesh();
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).firstLocalOrDescendantSharedMesh();
		}
		else
		{
			return default(Mesh).returnWithError("ProvidingExtensions.provideSharedMesh given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion shared mesh


	#region primitive collider center position
	
	public static Vector3 providePrimitiveColliderCenterPosition(this object dynamo)
	{
		if (dynamo is BoxCollider)
		{
			return (dynamo as BoxCollider).centerPosition();
		}
		else if (dynamo is SphereCollider)
		{
			return (dynamo as SphereCollider).centerPosition();
		}
		else if (dynamo is CapsuleCollider)
		{
			return (dynamo as CapsuleCollider).centerPosition();
		}
		else if (dynamo is GameObject)
		{
			GameObject gameObject = (dynamo as GameObject);
			BoxCollider firstLocalOrDescendantBoxCollider = gameObject.firstLocalOrDescendant<BoxCollider>();
			if (firstLocalOrDescendantBoxCollider.isYull())
			{
				return firstLocalOrDescendantBoxCollider.centerPosition();
			}
			SphereCollider firstLocalOrDescendantSphereCollider = gameObject.firstLocalOrDescendant<SphereCollider>();
			if (firstLocalOrDescendantSphereCollider.isYull())
			{
				return firstLocalOrDescendantSphereCollider.centerPosition();
			}
			CapsuleCollider firstLocalOrDescendantCapsuleCollider = gameObject.firstLocalOrDescendant<CapsuleCollider>();
			if (firstLocalOrDescendantCapsuleCollider.isYull())
			{
				return firstLocalOrDescendantCapsuleCollider.centerPosition();
			}
			return default(Vector3).returnWithError("ProvidingExtensions.providePrimitiveColliderCenterPosition given game object (or component, earlier) without a primitive collider");
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).gameObject.providePrimitiveColliderCenterPosition();
		}
		else
		{
			return default(Vector3).returnWithError("ProvidingExtensions.providePrimitiveColliderCenterPosition given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion primitive collider center position


	#region primitive collider local center position
	
	public static Vector3 providePrimitiveColliderLocalCenterPosition(this object dynamo)
	{
		if (dynamo is BoxCollider)
		{
			return (dynamo as BoxCollider).localCenterPosition();
		}
		else if (dynamo is SphereCollider)
		{
			return (dynamo as SphereCollider).localCenterPosition();
		}
		else if (dynamo is CapsuleCollider)
		{
			return (dynamo as CapsuleCollider).localCenterPosition();
		}
		else if (dynamo is GameObject)
		{
			GameObject gameObject = (dynamo as GameObject);
			BoxCollider firstLocalOrDescendantBoxCollider = gameObject.firstLocalOrDescendant<BoxCollider>();
			if (firstLocalOrDescendantBoxCollider.isYull())
			{
				return firstLocalOrDescendantBoxCollider.localCenterPosition();
			}
			SphereCollider firstLocalOrDescendantSphereCollider = gameObject.firstLocalOrDescendant<SphereCollider>();
			if (firstLocalOrDescendantSphereCollider.isYull())
			{
				return firstLocalOrDescendantSphereCollider.localCenterPosition();
			}
			CapsuleCollider firstLocalOrDescendantCapsuleCollider = gameObject.firstLocalOrDescendant<CapsuleCollider>();
			if (firstLocalOrDescendantCapsuleCollider.isYull())
			{
				return firstLocalOrDescendantCapsuleCollider.localCenterPosition();
			}
			return default(Vector3).returnWithError("ProvidingExtensions.providePrimitiveColliderLocalCenterPosition given game object (or component, earlier) without a primitive collider");
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).gameObject.providePrimitiveColliderLocalCenterPosition();
		}
		else
		{
			return default(Vector3).returnWithError("ProvidingExtensions.providePrimitiveColliderLocalCenterPosition given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion primitive collider local center position


	#region layer index

	public static int provideLayerIndex(this object dynamo)
	{
		if (dynamo is int)
		{
			return dynamo.castTo<int>();
		}
		else if (dynamo is string)
		{
			return (dynamo as string).asLayerIndex();
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).layerIndex();
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).layerIndex();
		}
		else
		{
			return default(int).returnWithError("ProvidingExtensions.provideLayerIndex given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion layer index


	#region layer name

	public static string provideLayerName(this object dynamo)
	{
		if (dynamo is string)
		{
			return dynamo as string;
		}
		else if (dynamo is int)
		{
			return dynamo.castTo<int>().asLayerName();
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).layerName();
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).layerName();
		}
		else
		{
			return default(string).returnWithError("ProvidingExtensions.provideLayerName given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion layer name


	#region HashSet<GameObject>
	
	public static HashSet<GameObject> provideUniqueGameObjects(this object dynamo)
	{
		if (dynamo is IEnumerable<GameObject>)
		{
			return (dynamo as IEnumerable<GameObject>).toSet();
		}
		else if (dynamo is IEnumerable<Component>)
		{
			return (dynamo as IEnumerable<Component>).uniqueObjects();
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).startSet();
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).uniqueObjects();
		}
		else
		{
			return default(HashSet<GameObject>).returnWithError("ProvidingExtensions.provideUniqueGameObjects given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion HashSet<GameObject>
}