#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Compilation:
// • provides properties about compilation
// #compilation
public static class Compilation
{
	public static bool hasOnlyHappenedOnceSinceStartingEditor => Unscaled.timeOfLastCompilation == 0d;
}
#endif