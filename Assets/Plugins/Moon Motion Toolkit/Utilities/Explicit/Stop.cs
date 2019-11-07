using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stop: provides methods for stopping things
// #coroutines #execution
public static class Stop
{
	#region coroutines
	
	// method: have the ether stop its given coroutine //
	public static void coroutine(Coroutine coroutine)
		=> Ether.behaviour.stopCoroutine(coroutine);

	// method: have the ether stop all of its coroutines //
	public static void allCoroutines()
		=> Ether.behaviour.stopAllCoroutines();
	#endregion coroutines
}