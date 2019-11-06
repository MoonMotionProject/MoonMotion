using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Yull: provides methods for determining yullness //
public static class Yull
{
	// method: return whether both of the given objects are yull //
	public static bool areBoth(object firstObject, object secondObject)
		=> firstObject.isYull() && secondObject.isYull();
}