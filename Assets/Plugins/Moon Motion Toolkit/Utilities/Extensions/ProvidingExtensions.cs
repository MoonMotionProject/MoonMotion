using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Providing Extensions:
// • provides extension methods for having dynamos provide certain types
//   · a 'dynamo' is a dynamic type, which can be specified as a parameter in a method using the keyword 'dynamic', or as an object – in the current implementation, these methods are intended for use with 'object' parameters
// #dynamics #providing #primitives
public static class ProvidingExtensions
{
	#region Unity

	
	/* (via reflection if error) */
	public static Transform provideTransform(this object dynamo)
	{
		if (dynamo.isNull())
		{
			return null;
		}
		else if (dynamo is Transform)
		{
			return dynamo as Transform;
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).transform;
		}
		#if UNITOLOGY
		else if (dynamo is Unit)
		{
			return (dynamo as Unit).unitTargetTransform;
		}
		#endif
		else if (dynamo is Component)
		{
			return (dynamo as Component).transform;
		}
		else
		{
			return default(Transform).returnWithError("ProvidingExtensions.provideTransform given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}
	
	
	/* (via reflection if error) */
	public static GameObject provideGameObject(this object dynamo)
	{
		if (dynamo.isNull())
		{
			return null;
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject);
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).gameObject;
		}
		else
		{
			return default(GameObject).returnWithError("ProvidingExtensions.provideGameObject given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}
	
	
	/* (via reflection if error) */
	public static string provideTag(this object dynamo)
	{
		if (dynamo.isNull())
		{
			return null;
		}
		else if (dynamo is string)
		{
			return (dynamo as string);
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).tag;
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).tag;
		}
		else
		{
			return default(string).returnWithError("ProvidingExtensions.provideTag given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}
	
	
	/* (via reflection if error) */
	public static int provideLayerIndex(this object dynamo)
	{
		if (dynamo.isNull())
		{
			return default(int).returnWithError("ProvidingExtensions.provideLayerIndex given null dynamo");
		}
		else if (dynamo is int)
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
			return default(int).returnWithError("ProvidingExtensions.provideLayerIndex given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}
	/* (via reflection if error) */
	public static string provideLayerName(this object dynamo)
	{
		if (dynamo.isNull())
		{
			return null;
		}
		else if (dynamo is string)
		{
			return (dynamo as string);
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
			return default(string).returnWithError("ProvidingExtensions.provideLayerName given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}
	/* (via reflection if error) */
	public static HashSet<string> provideUniqueLayerNames(this object dynamo)
	{
		if (dynamo.isNull())
		{
			return null;
		}
		else if (dynamo is string)
		{
			return (dynamo as string).startSet();
		}
		else if (dynamo is int)
		{
			return dynamo.castTo<int>().asLayerName().startSet();
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).layerName().startSet();
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).layerName().startSet();
		}
		else if (dynamo is IEnumerable<string>)
		{
			return (dynamo as IEnumerable<string>).uniqueYulls();
		}
		else if (dynamo is IEnumerable<int>)
		{
			return (dynamo as IEnumerable<int>).pickUnique(integer => integer.asLayerName());
		}
		else if (dynamo is IEnumerable<GameObject>)
		{
			return (dynamo as IEnumerable<GameObject>).pickUnique(gameObject => gameObject.layerName());
		}
		else if (dynamo is IEnumerable<Component>)
		{
			return (dynamo as IEnumerable<Component>).pickUnique(component => component.layerName());
		}
		else
		{
			return default(HashSet<string>).returnWithError("ProvidingExtensions.provideUniqueLayerNames given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}

	
	/* (via reflection if error) */
	public static Collider provideCollider(this object dynamo)
	{
		if (dynamo.isNull())
		{
			return null;
		}
		else if (dynamo is Collider)
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
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).firstLodal<Collider>();
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).firstLodal<Collider>();
		}
		else
		{
			return default(Collider).returnWithError("ProvidingExtensions.provideCollider given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}
	/* (via reflection if error) */
	public static Collider provideSolidCollider(this object dynamo)
	{
		if (dynamo.isNull())
		{
			return null;
		}
		else if (dynamo is RaycastHit?)
		{
			return (dynamo as RaycastHit?).GetValueOrDefault().collider.ifSolidOtherwiseNull();
		}
		else if (dynamo is RaycastHit)
		{
			return dynamo.castTo<RaycastHit>().collider.ifSolidOtherwiseNull();
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).firstLodalSolid<Collider>();
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).firstLodalSolid<Collider>();
		}
		else
		{
			return default(Collider).returnWithError("ProvidingExtensions.provideSolidCollider given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}
	/* (via reflection if error) */
	public static Collider provideTriggerCollider(this object dynamo)
	{
		if (dynamo.isNull())
		{
			return null;
		}
		else if (dynamo is RaycastHit?)
		{
			return (dynamo as RaycastHit?).GetValueOrDefault().collider.ifTriggerOtherwiseNull();
		}
		else if (dynamo is RaycastHit)
		{
			return dynamo.castTo<RaycastHit>().collider.ifTriggerOtherwiseNull();
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).firstLodalTrigger<Collider>();
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).firstLodalTrigger<Collider>();
		}
		else
		{
			return default(Collider).returnWithError("ProvidingExtensions.provideTriggerCollider given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}

	
	/* (via reflection if error) */
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
			return default(RaycastHit).returnWithError("ProvidingExtensions.provideRaycastHit given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}

	
	/* (via reflection if error) */
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
		#if UNITOLOGY
		else if (dynamo is Unit)
		{
			return (dynamo as Unit).unitTargetPosition;
		}
		#endif
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
			return default(Vector3).returnWithError("ProvidingExtensions.providePosition given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}

	
	/* (via reflection if error) */
	public static Rigidbody provideRigidbody(this object dynamo)
	{
		if (dynamo.isNull())
		{
			return null;
		}
		else if (dynamo is Rigidbody)
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
			return default(Rigidbody).returnWithError("ProvidingExtensions.provideRigidbody given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}
	/* (via reflection if error) */
	public static List<Rigidbody> provideRigidbodies(this object dynamo)
	{
		if (dynamo.isNull())
		{
			return null;
		}
		else if (dynamo is IEnumerable<Rigidbody>)
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
			return default(List<Rigidbody>).returnWithError("ProvidingExtensions.provideRigidbodies given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}

	
	/* (via reflection if error) */
	public static Mesh provideMesh(this object dynamo)
	{
		if (dynamo.isNull())
		{
			return null;
		}
		else if (dynamo is Mesh)
		{
			return dynamo.castTo<Mesh>();
		}
		else if (dynamo is GameObject)
		{
			GameObject gameObject = (dynamo as GameObject);
			Mesh mesh = gameObject.firstLodalMesh();
			if (mesh.isNull())
			{
				if (gameObject.firstLodal<BoxCollider>().isYull())
				{
					return Meshes.cube;
				}
				else if (gameObject.firstLodal<SphereCollider>().isYull())
				{
					return Meshes.sphere;
				}
				else if (gameObject.firstLodal<CapsuleCollider>().isYull())
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
			return default(Mesh).returnWithError("ProvidingExtensions.provideMesh given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}
	/* (via reflection if error) */
	public static Mesh provideSharedMesh(this object dynamo)
	{
		if (dynamo.isNull())
		{
			return null;
		}
		else if (dynamo is Mesh)
		{
			return dynamo.castTo<Mesh>();
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).firstLodalSharedMesh();
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).firstLodalSharedMesh();
		}
		else
		{
			return default(Mesh).returnWithError("ProvidingExtensions.provideSharedMesh given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}

	
	/* (via reflection if error) */
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
			BoxCollider firstLodalBoxCollider = gameObject.firstLodal<BoxCollider>();
			if (firstLodalBoxCollider.isYull())
			{
				return firstLodalBoxCollider.centerPosition();
			}
			SphereCollider firstLodalSphereCollider = gameObject.firstLodal<SphereCollider>();
			if (firstLodalSphereCollider.isYull())
			{
				return firstLodalSphereCollider.centerPosition();
			}
			CapsuleCollider firstLodalCapsuleCollider = gameObject.firstLodal<CapsuleCollider>();
			if (firstLodalCapsuleCollider.isYull())
			{
				return firstLodalCapsuleCollider.centerPosition();
			}
			return default(Vector3).returnWithError("ProvidingExtensions.providePrimitiveColliderCenterPosition given game object (or component, earlier) without a primitive collider");
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).gameObject.providePrimitiveColliderCenterPosition();
		}
		else
		{
			return default(Vector3).returnWithError("ProvidingExtensions.providePrimitiveColliderCenterPosition given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}
	/* (via reflection if error) */
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
			BoxCollider firstLodalBoxCollider = gameObject.firstLodal<BoxCollider>();
			if (firstLodalBoxCollider.isYull())
			{
				return firstLodalBoxCollider.localCenterPosition();
			}
			SphereCollider firstLodalSphereCollider = gameObject.firstLodal<SphereCollider>();
			if (firstLodalSphereCollider.isYull())
			{
				return firstLodalSphereCollider.localCenterPosition();
			}
			CapsuleCollider firstLodalCapsuleCollider = gameObject.firstLodal<CapsuleCollider>();
			if (firstLodalCapsuleCollider.isYull())
			{
				return firstLodalCapsuleCollider.localCenterPosition();
			}
			return default(Vector3).returnWithError("ProvidingExtensions.providePrimitiveColliderLocalCenterPosition given game object (or component, earlier) without a primitive collider");
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).gameObject.providePrimitiveColliderLocalCenterPosition();
		}
		else
		{
			return default(Vector3).returnWithError("ProvidingExtensions.providePrimitiveColliderLocalCenterPosition given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}

	
	/* (via reflection if error) */
	public static HashSet<GameObject> provideUniqueGameObjects(this object dynamo)
	{
		if (dynamo.isNull())
		{
			return null;
		}
		else if (dynamo is IEnumerable<GameObject>)
		{
			return (dynamo as IEnumerable<GameObject>).uniques();
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
			return default(HashSet<GameObject>).returnWithError("ProvidingExtensions.provideUniqueGameObjects given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}
	#endregion Unity




	#region nonUnity


	#region Unitology
	#if UNITOLOGY
	
	/* (via reflection if error) */
	public static Unit provideUnit(this object dynamo)
	{
		if (dynamo.isNull())
		{
			return null;
		}
		else if (dynamo is Unit)
		{
			return dynamo as Unit;
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).correspondingUnit();
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).correspondingUnit();
		}
		else
		{
			return default(Unit).returnWithError("ProvidingExtensions.provideUnit given unrecognized dynamo of type "+dynamo.derivedType_ViaReflection());
		}
	}
	
	public static Unit provideUnitIfYullOtherwiseProvideUnitVia(this object unit_UnitProvider, Func<object> function)
		=> unit_UnitProvider.isYull() ? unit_UnitProvider.provideUnit() : function().provideUnit();
	#endif
	#endregion Unitology
	#endregion nonUnity
}