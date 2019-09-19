using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using static UnityEditor.EditorApplication;
#endif

// Auto Behaviour Layer Static Shortcuts:
// #auto
// • provides this behaviour with easier access to typical static state and methods
public abstract class	AutoBehaviourLayerStaticShortcuts<AutoBehaviourT> :
					AutoBehaviourLayerAutoBehaviour<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
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


	#region Direction

	public static Vector3 forwardGlobal => Direction.forward;
	public static Vector3 backwardGlobal => Direction.backward;
	public static Vector3 rightGlobal => Direction.right;
	public static Vector3 leftGlobal => Direction.left;
	public static Vector3 upGlobal => Direction.up;
	public static Vector3 downGlobal => Direction.down;
	#endregion Direction


	#region Doubles

	#region extremes
	public static double maxOf(double firstDouble, double secondDouble)
		=> Doubles.maxOf(firstDouble, secondDouble);
	public static double minOf(double firstDouble, double secondDouble)
		=> Doubles.minOf(firstDouble, secondDouble);
	#endregion extremes
	#endregion Doubles


	#region EditorEvents
	
	#if UNITY_EDITOR
	public static CallbackFunction afterAllInspectorsHaveNextUpdatedExecute(CallbackFunction callbackFunction, bool preventExecutionIfEditorModeChangesFirst = false)
		=> EditorEvents.afterAllInspectorsHaveNextUpdatedExecute(callbackFunction, preventExecutionIfEditorModeChangesFirst);
	#endif
	#endregion EditorEvents


	#region Floats

	#region extremes
	public static double maxOf(float firstFloat, float secondFloat)
		=> Floats.maxOf(firstFloat, secondFloat);
	public static double minOf(float firstFloat, float secondFloat)
		=> Floats.minOf(firstFloat, secondFloat);
	#endregion extremes
	#endregion Floats

	
	#region Functions
	
	public static Func<TInputAndOutput, TInputAndOutput> identityFunction<TInputAndOutput>()
		=> Functions.identity<TInputAndOutput>();
	#endregion Functions

	
	#region FloatsVector
	
	public static Vector3 zeroesFloatsVector => FloatsVector.zeroes;
	public static Vector3 onesFloatsVector => FloatsVector.ones;
	#endregion FloatsVector
	#endregion Moon Motion - Moon Motion Toolkit - Utilities - Explicit
}