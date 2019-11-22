using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

// Stop: provides methods for stopping things
// #coroutines #execution
public static class Stop
{
	#region coroutines
	
	// method: have the ether stop its given coroutine //
	public static void coroutine(Coroutine coroutine)
		=> Ether.stopCoroutine(coroutine);

	// method: have the ether stop all of its coroutines //
	public static void allCoroutines()
		=> Ether.stopAllCoroutines();
	#endregion coroutines


	#if UNITY_EDITOR
	public static void playing()
		=> EditorApplication.isPlaying = false;
	#endif
}