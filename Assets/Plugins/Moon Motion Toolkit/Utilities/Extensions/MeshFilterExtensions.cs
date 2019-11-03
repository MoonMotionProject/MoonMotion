using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mesh Filter Extensions: provides extension methods for handling mesh filters //
public static class MeshFilterExtensions
{
	#region accessing meshes

	public static Mesh mesh(this GameObject gameObject)
	{
		MeshFilter meshFilter = gameObject.meshFilter();
		if (meshFilter.isYull())
		{
			return meshFilter.mesh;
		}
		return null;
	}
	public static Mesh mesh(this Component component)
		=> component.gameObject.mesh();

	public static Mesh sharedMesh(this GameObject gameObject)
	{
		MeshFilter meshFilter = gameObject.meshFilter();
		if (meshFilter.isYull())
		{
			return meshFilter.sharedMesh;
		}
		return null;
	}
	public static Mesh sharedMesh(this Component component)
		=> component.gameObject.sharedMesh();

	public static Mesh firstLocalOrDescendantMesh(this GameObject gameObject)
	{
		MeshFilter firstLocalOrDescendantMeshFilter = gameObject.firstLocalOrDescendantMeshFilter();
		if (firstLocalOrDescendantMeshFilter.isYull())
		{
			return firstLocalOrDescendantMeshFilter.mesh;
		}
		return null;
	}
	public static Mesh firstLocalOrDescendantMesh(this Component component)
		=> component.gameObject.firstLocalOrDescendantMesh();

	public static Mesh firstLocalOrDescendantSharedMesh(this GameObject gameObject)
	{
		MeshFilter firstLocalOrDescendantMeshFilter = gameObject.firstLocalOrDescendantMeshFilter();
		if (firstLocalOrDescendantMeshFilter.isYull())
		{
			return firstLocalOrDescendantMeshFilter.sharedMesh;
		}
		return null;
	}
	public static Mesh firstLocalOrDescendantSharedMesh(this Component component)
		=> component.gameObject.firstLocalOrDescendantSharedMesh();
	#endregion accessing meshes


	#region setting meshes

	public static MeshFilter setMeshTo(this MeshFilter meshFilter, object mesh_MeshProvider, bool boolean = true)
	{
		if (boolean)
		{
			meshFilter.mesh = mesh_MeshProvider.provideMesh();
		}

		return meshFilter;
	}
	public static GameObject setMeshTo(this GameObject gameObject, object mesh_MeshProvider, bool boolean = true)
	{
		if (boolean)
		{
			gameObject.ensuredMeshFilter().setMeshTo(mesh_MeshProvider.provideMesh());
		}

		return gameObject;
	}
	public static ComponentT setMeshTo<ComponentT>(this ComponentT component, object mesh_MeshProvider, bool boolean = true) where ComponentT : Component
	{
		if (boolean)
		{
			component.ensuredMeshFilter().setMeshTo(mesh_MeshProvider.provideMesh());
		}

		return component;
	}

	public static MeshFilter setSharedMeshTo(this MeshFilter meshFilter, object sharedMesh_SharedMeshProvider, bool boolean = true)
	{
		if (boolean)
		{
			meshFilter.sharedMesh = sharedMesh_SharedMeshProvider.provideSharedMesh();
		}

		return meshFilter;
	}
	public static GameObject setSharedMeshTo(this GameObject gameObject, object sharedMesh_SharedMeshProvider, bool boolean = true)
	{
		if (boolean)
		{
			gameObject.meshFilter().setSharedMeshTo(sharedMesh_SharedMeshProvider.provideSharedMesh());
		}

		return gameObject;
	}
	public static ComponentT setSharedMeshTo<ComponentT>(this ComponentT component, object sharedMesh_SharedMeshProvider, bool boolean = true) where ComponentT : Component
	{
		if (boolean)
		{
			component.meshFilter().setSharedMeshTo(sharedMesh_SharedMeshProvider.provideSharedMesh());
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
			MeshFilter potentialMeshFilter = gameObject.meshFilter();
			if (potentialMeshFilter.isYull())
			{
				potentialMeshFilter.mesh = null;
			}
		}

		return gameObject;
	}
	public static ComponentT removeMeshIfAny<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		if (boolean)
		{
			MeshFilter potentialMeshFilter = component.meshFilter();
			if (potentialMeshFilter.isYull())
			{
				potentialMeshFilter.mesh = null;
			}
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
			MeshFilter potentialMeshFilter = gameObject.meshFilter();
			if (potentialMeshFilter.isYull())
			{
				potentialMeshFilter.sharedMesh = null;
			}
		}

		return gameObject;
	}
	public static ComponentT removeSharedMeshIfAny<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		if (boolean)
		{
			MeshFilter potentialMeshFilter = component.meshFilter();
			if (potentialMeshFilter.isYull())
			{
				potentialMeshFilter.sharedMesh = null;
			}
		}

		return component;
	}
	#endregion removing meshes
}