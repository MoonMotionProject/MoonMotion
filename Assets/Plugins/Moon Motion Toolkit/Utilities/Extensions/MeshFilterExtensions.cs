using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mesh Filter Extensions: provides extension methods for handling mesh filters //
public static class MeshFilterExtensions
{
	#region accessing meshes

	public static Mesh mesh(this GameObject gameObject)
		=> gameObject.meshFilter().mesh;
	public static Mesh mesh(this Component component)
		=> component.meshFilter().mesh;

	public static Mesh sharedMesh(this GameObject gameObject)
		=> gameObject.meshFilter().sharedMesh;
	public static Mesh sharedMesh(this Component component)
		=> component.meshFilter().sharedMesh;
	#endregion accessing meshes


	#region setting meshes

	public static MeshFilter setMeshTo(this MeshFilter meshFilter, object mesh_MeshProvider, bool boolean = true)
	{
		if (boolean)
		{
			meshFilter.mesh = Provide.meshVia(mesh_MeshProvider);
		}

		return meshFilter;
	}
	public static GameObject setMeshTo(this GameObject gameObject, object mesh_MeshProvider, bool boolean = true)
	{
		if (boolean)
		{
			Mesh mesh = Provide.meshVia(mesh_MeshProvider);
			gameObject.ensuredMeshFilter().setMeshTo(mesh);
		}

		return gameObject;
	}
	public static ComponentT setMeshTo<ComponentT>(this ComponentT component, object mesh_MeshProvider, bool boolean = true) where ComponentT : Component
	{
		if (boolean)
		{
			Mesh mesh = Provide.meshVia(mesh_MeshProvider);
			component.ensuredMeshFilter().setMeshTo(mesh);
		}

		return component;
	}

	public static MeshFilter setSharedMeshTo(this MeshFilter meshFilter, object sharedMesh_SharedMeshProvider, bool boolean = true)
	{
		if (boolean)
		{
			meshFilter.sharedMesh = Provide.sharedMeshVia(sharedMesh_SharedMeshProvider);
		}

		return meshFilter;
	}
	public static GameObject setSharedMeshTo(this GameObject gameObject, object sharedMesh_SharedMeshProvider, bool boolean = true)
	{
		if (boolean)
		{
			Mesh mesh = Provide.sharedMeshVia(sharedMesh_SharedMeshProvider);
			gameObject.meshFilter().setSharedMeshTo(mesh);
		}

		return gameObject;
	}
	public static ComponentT setSharedMeshTo<ComponentT>(this ComponentT component, object sharedMesh_SharedMeshProvider, bool boolean = true) where ComponentT : Component
	{
		if (boolean)
		{
			Mesh mesh = Provide.sharedMeshVia(sharedMesh_SharedMeshProvider);
			component.meshFilter().setSharedMeshTo(mesh);
		}

		return component;
	}
	#endregion setting meshes


	#region removing meshes

	public static MeshFilter removeMeshIfAny(this MeshFilter meshFilter, bool boolean = true)
	{
		if (boolean)
		{
			meshFilter.mesh = null;
		}

		return meshFilter;
	}
	public static GameObject removeMeshIfAny(this GameObject gameObject, bool boolean = true)
	{
		if (boolean)
		{
			gameObject.meshFilter().mesh = null;
		}

		return gameObject;
	}
	public static ComponentT removeMeshIfAny<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		if (boolean)
		{
			component.meshFilter().mesh = null;
		}

		return component;
	}

	public static MeshFilter removeSharedMeshIfAny(this MeshFilter meshFilter, bool boolean = true)
	{
		if (boolean)
		{
			meshFilter.sharedMesh = null;
		}

		return meshFilter;
	}
	public static GameObject removeSharedMeshIfAny(this GameObject gameObject, bool boolean = true)
	{
		if (boolean)
		{
			gameObject.meshFilter().sharedMesh = null;
		}

		return gameObject;
	}
	public static ComponentT removeSharedMeshIfAny<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		if (boolean)
		{
			component.meshFilter().sharedMesh = null;
		}

		return component;
	}
	#endregion removing meshes
}