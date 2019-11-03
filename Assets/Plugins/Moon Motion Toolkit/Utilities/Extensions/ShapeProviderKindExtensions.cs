using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shape Provider Kind Extensions:
// • provides extension methods for handling shape provider kinds
// #shape #providing #primitives
public static class ShapeProviderKindExtensions
{
	#region determination

	public static bool isMeshFilter(this ShapeProviderKind shapeProvider)
		=> shapeProvider == ShapeProviderKind.meshFilter;
	public static bool isSkinnedMeshRenderer(this ShapeProviderKind shapeProvider)
		=> shapeProvider == ShapeProviderKind.skinnedMeshRenderer;
	public static bool isPrimitiveCollider(this ShapeProviderKind shapeProvider)
		=> shapeProvider == ShapeProviderKind.primitiveCollider;
	#endregion determination
}