using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Provide:
// • provides methods for having dynamos provide certain types
//   · a 'dynamo' is a dynamic type, which can be specified as a parameter in a method using the keyword 'dynamic', or as an object
//   · in the current implementation's version of C#, dynamics cannot be the 'this' parameter in extension methods unless the extension method is called upon the static class; thus, this class is used as a cleaner alternative... however, 'object' parameters can be used that way, but for the purpose this class provides, it still seems cleaner
//   · occasionally when using a 'dynamic' Provide method within a Unity method the Unity method will not work as expected, so to be sure, always declare Provide results as variables before using them (for example, 'Vector3 position = Provide.positionVia(position_PositionProvider)')... this shouldn't be a problem with 'object' Provide methods
// #auto #dynamics
public static class Provide
{
	#region Transform

	public static Transform transformVia(object dynamo)
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
			return default(Transform).returnWithError("Provide.transformVia given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion Transform


	#region Collider

	public static Collider colliderVia(object dynamo)
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
			return default(Collider).returnWithError("Provide.colliderVia given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion Collider


	#region RaycastHit

	public static RaycastHit raycastHitVia(object dynamo)
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
			return default(RaycastHit).returnWithError("Provide.raycastHitVia given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion RaycastHit


	#region position

	public static Vector3 positionVia(object dynamo)
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
			return default(Vector3).returnWithError("Provide.positionVia given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion position


	#region Rigidbody
	
	public static Rigidbody rigidbodyVia(object dynamo)
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
			return default(Rigidbody).returnWithError("Provide.rigidbodyVia given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion Rigidbody


	#region List<Rigidbody>
	
	public static List<Rigidbody> rigidbodiesVia(object dynamo)
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
			return default(List<Rigidbody>).returnWithError("Provide.rigidbodiesVia given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion List<Rigidbody>


	#region mesh

	public static Mesh meshVia(object dynamo)
	{
		if (dynamo is Mesh)
		{
			return dynamo.castTo<Mesh>();
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).mesh();
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).mesh();
		}
		else
		{
			return default(Mesh).returnWithError("Provide.meshVia given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion mesh


	#region shared mesh

	public static Mesh sharedMeshVia(object dynamo)
	{
		if (dynamo is Mesh)
		{
			return dynamo.castTo<Mesh>();
		}
		else if (dynamo is GameObject)
		{
			return (dynamo as GameObject).sharedMesh();
		}
		else if (dynamo is Component)
		{
			return (dynamo as Component).sharedMesh();
		}
		else
		{
			return default(Mesh).returnWithError("Provide.sharedMeshVia given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion shared mesh


	#region layer index

	public static int layerIndexVia(object dynamo)
	{
		if (dynamo is int)
		{
			return dynamo.castTo<int>();
		}
		else if (dynamo is string)
		{
			return (dynamo as string).asLayerIndex();
		}
		else
		{
			return default(int).returnWithError("Provide.layerIndexVia given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion layer index


	#region layer name

	public static string layerNameVia(object dynamo)
	{
		if (dynamo is string)
		{
			return dynamo as string;
		}
		else if (dynamo is int)
		{
			return dynamo.castTo<int>().asLayerName();
		}
		else
		{
			return default(string).returnWithError("Provide.layerNameVia given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion layer name


	#region HashSet<GameObject>
	
	public static HashSet<GameObject> uniqueGameObjectsVia(object dynamo)
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
			return default(HashSet<GameObject>).returnWithError("Provide.uniqueGameObjectsVia given unrecognized dynamo of type "+dynamo.type());
		}
	}
	#endregion HashSet<GameObject>
}