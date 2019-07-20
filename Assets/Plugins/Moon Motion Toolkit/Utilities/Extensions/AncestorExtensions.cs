using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ancestor Extensions: provides extension methods for handling ancestors //
public static class AncestorExtensions
{
	// method: return whether this given transform is local to or an ancestor of the other given transform //
	public static bool isLocalToOrAncestorOf(this Transform transform, Transform otherTransform)
		=> otherTransform.isLocalToOrDescendantOf(transform);
}