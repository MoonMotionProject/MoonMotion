using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shape Provider:
// • provides methods for handling shape provider kinds
// #shape #providing #primitives
public static class ShapeProvider
{
	// method: return the shape provider kind for the given boolean for whether the kind is a mesh filter and the given boolean for whether the kind is a skinned mesh renderer //
	public static ShapeProviderKind kindFor(bool kindIsMeshFilter, bool kindIsSkinnedMeshRenderer)
		=>	kindIsMeshFilter ?
				ShapeProviderKind.meshFilter :
				kindIsSkinnedMeshRenderer ?
					ShapeProviderKind.skinnedMeshRenderer :
						ShapeProviderKind.primitiveCollider;
}