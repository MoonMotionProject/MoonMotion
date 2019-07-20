using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mesh Filter Extensions: provides extension methods for handling mesh filters //
public static class MeshFilterExtensions
{
	public static MeshFilter setMeshTo(this MeshFilter meshFilter, Mesh mesh, bool boolean = true)
	{
		if (boolean)
		{
			meshFilter.mesh = mesh;
		}

		return meshFilter;
	}

	public static MeshFilter setSharedMeshTo(this MeshFilter meshFilter, Mesh sharedMesh, bool boolean = true)
	{
		if (boolean)
		{
			meshFilter.sharedMesh = sharedMesh;
		}

		return meshFilter;
	}
}