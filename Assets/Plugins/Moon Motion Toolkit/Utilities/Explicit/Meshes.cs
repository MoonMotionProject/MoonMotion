using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Meshes: provides methods and properties for meshes
// #primitives
public static class Meshes
{
	#region primitive meshes

	public static Mesh meshFrom(PrimitiveType primitiveType)
	{
		GameObject primitive = GameObject.CreatePrimitive(primitiveType);
		Mesh mesh = primitive.mesh();
		primitive.destroy();
		return mesh;
	}

	public static Mesh cube => meshFrom(PrimitiveType.Cube);
	public static Mesh sphere => meshFrom(PrimitiveType.Sphere);
	public static Mesh cylinder => meshFrom(PrimitiveType.Cylinder);
	public static Mesh capsule => meshFrom(PrimitiveType.Capsule);
	public static Mesh plane => meshFrom(PrimitiveType.Plane);
	public static Mesh quad => meshFrom(PrimitiveType.Quad);
	#endregion primitive meshes
}