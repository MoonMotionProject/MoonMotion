using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Flipped Material: at the start, flips this mesh's material facing (via flipping its "normals") //
[RequireComponent(typeof(MeshFilter))]
public class FlippedMaterial : MonoBehaviour
{
	// updating //

	
	// at the start: //
	private void Start()
	{
		MeshFilter meshFilter = (GetComponent(typeof(MeshFilter)) as MeshFilter);
		if (meshFilter.isYull())
		{
			Mesh mesh = meshFilter.mesh;
			
			Vector3[] normals = mesh.normals;
			for (int normalIndex = 0; normalIndex < normals.Length; normalIndex++)
			{
				normals[normalIndex] = -normals[normalIndex];
			}
			mesh.normals = normals;
			
			for (int submeshIndex = 0; submeshIndex < mesh.subMeshCount; submeshIndex++)
			{
				int[] triangles = mesh.GetTriangles(submeshIndex);
				for (int triangleIndex = 0; triangleIndex < triangles.Length; triangleIndex += 3)
				{
					int temp = triangles[triangleIndex];
					triangles[triangleIndex] = triangles[triangleIndex + 1];
					triangles[triangleIndex + 1] = temp;
				}
				mesh.SetTriangles(triangles, submeshIndex);
			}
		}
	}
}