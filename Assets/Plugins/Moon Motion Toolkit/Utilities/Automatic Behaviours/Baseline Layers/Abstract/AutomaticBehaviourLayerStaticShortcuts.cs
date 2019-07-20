using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using static UnityEditor.EditorApplication;
#endif

// Automatic Behaviour Layer Static Shortcuts:
// #auto
// • provides this behaviour with easier access to typical static state and methods
public abstract class	AutomaticBehaviourLayerStaticShortcuts<AutomaticBehaviourT> :
					AutomaticBehaviourLayerAutomaticBehaviour<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	#region not: Moon Motion - Moon Motion Toolkit - Utilities - Explicit




	#region time


	public static float time => Time.time;
	public static float timeSince(float previousTime)
		=> time.since(previousTime);

	public static float timeSinceLastUpdate => Time.deltaTime;

	public static float timeSinceLastFixedUpdate => Time.fixedDeltaTime;
	#endregion time
	#endregion not: Moon Motion - Moon Motion Toolkit - Utilities - Explicit








	#region Moon Motion - Moon Motion Toolkit - Utilities - Explicit




	#region Doubles


	// methods for: extremes //

	public static double maxOf(double firstDouble, double secondDouble)
		=> Doubles.maxOf(firstDouble, secondDouble);
	
	public static double minOf(double firstDouble, double secondDouble)
		=> Doubles.minOf(firstDouble, secondDouble);
	#endregion Doubles




	#region Floats


	// methods for: extremes //

	public static double maxOf(float firstFloat, float secondFloat)
		=> Floats.maxOf(firstFloat, secondFloat);

	public static double minOf(float firstFloat, float secondFloat)
		=> Floats.minOf(firstFloat, secondFloat);
	#endregion Floats




	#region Functions


	public static Func<TInputAndOutput, TInputAndOutput> identityFunction<TInputAndOutput>()
		=> Functions.identity<TInputAndOutput>();
	#endregion Functions




	#region Vectors


	// the vector of zeroes //
	public static Vector3 zeroesVector => Vector3.zero;


	// properties for: directions //

	public static Vector3 forwardGlobal => Vectors.forward;
	
	public static Vector3 backwardGlobal => Vectors.backward;
	
	public static Vector3 rightGlobal => Vectors.right;
	
	public static Vector3 leftGlobal => Vectors.left;
	
	public static Vector3 upGlobal => Vectors.up;
	
	public static Vector3 downGlobal => Vectors.down;
	#endregion Vectors




	#region EditorEvents

	
	#if UNITY_EDITOR
	public static CallbackFunction afterAllInspectorsHaveNextUpdatedExecute(CallbackFunction callbackFunction, bool preventExecutionIfEditorModeChangesFirst = false)
		=> EditorEvents.afterAllInspectorsHaveNextUpdatedExecute(callbackFunction, preventExecutionIfEditorModeChangesFirst);
	#endif
	#endregion EditorEvents
	#endregion Moon Motion - Moon Motion Toolkit - Utilities - Explicit
}