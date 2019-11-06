using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// At End Of Frame Execute Mono Behaviour
// #coroutines #execution
// • provides methods within the context of a mono behaviour, as needed by At End Of Frame, to execute the given function with the given parameters at the end of the current frame (then return this behaviour)
public class AtEndOfFrameExecuteMonoBehaviour : MonoBehaviour
{
	public Coroutine atEndOfFrameExecute(Delegate function, params object[] parameters)
		=> this.castTo<MonoBehaviour>().startCoroutine(atEndOfFrameExecute_Coroutine(function, parameters));
	private IEnumerator atEndOfFrameExecute_Coroutine(Delegate function, params object[] parameters)
	{
		yield return Wait.untilEndOfFrame;
		function.execute(parameters);
	}
	private Coroutine atEndOfFrameExecute_(Delegate function, params object[] parameters)
		=> atEndOfFrameExecute(function, parameters);
	public Coroutine atEndOfFrameExecute(Action action, params object[] parameters)
		=> atEndOfFrameExecute_(action, parameters);
}