using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Any Controller Operation Tracker:
// • tracks whether any controller operation is operated
//   · only accurate while playing (since controller input isn't processed in editor edit mode)
public class AnyControllerOperationTracker : SingletonBehaviour<AnyControllerOperationTracker>
{
	public static bool state =>
		
		Controller.left.triggerTouched() ||
		Controller.left.touchpadTouched() ||
		Controller.left.menuButtonTouched() ||
		Controller.left.gripTouched() ||

		Controller.right.triggerTouched() ||
		Controller.right.touchpadTouched() ||
		Controller.right.menuButtonTouched() ||
		Controller.right.gripTouched();
}