using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// At End Of Frame:
// #execution
// • provides methods to plan to execute the given function with the given parameters at the end of the current frame, then return 'executingObject'
//   · creates/caches 'executingObject' once needed – a universal, temporary game object with a At End Of Frame Execute Mono Behaviour – and provides a property to access the game object's At End Of Frame Execute Mono Behaviour, which is used in executing the methods here
// • this class is provided so that its methods are available to be called when not in the context of an auto behaviour, since auto behaviours have the 'atEndOfFrameExecute' methods already
public static class AtEndOfFrame
{
	private static GameObject executingObject_ = null;
	public static GameObject executingObject
		=>	executingObject_.isYull() ?
				executingObject_ :
				(executingObject_ = Hierarchy.createUniversalAndTemporaryObject().add<AtEndOfFrameExecuteMonoBehaviour>());

	private static AtEndOfFrameExecuteMonoBehaviour executingBehaviour_ = null;
	public static AtEndOfFrameExecuteMonoBehaviour executingBehaviour
		=>	executingBehaviour_.isYull() ?
				executingBehaviour_ :
				(executingBehaviour_ = executingObject.first<AtEndOfFrameExecuteMonoBehaviour>());

	public static GameObject execute(Delegate function, params object[] parameters)
		=> executingBehaviour.atEndOfFrameExecute(function, parameters).gameObject;
	public static GameObject execute(Action action, params object[] parameters)
		=> executingBehaviour.atEndOfFrameExecute(action, parameters).gameObject;
}