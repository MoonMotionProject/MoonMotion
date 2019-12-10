using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

// Mono Behaviour Extensions: provides extension methods for handling mono behaviours //
// #mono #coroutines #execution
public static class MonoBehaviourExtensions
{
	#if UNITY_EDITOR
	#region project path

	// method: return the project path of this given mono behaviour's script asset //
	public static string projectPath(this MonoBehaviour monoBehaviour)
		=> Project.pathForMonoBehaviour(monoBehaviour);
	#endregion project path
	#endif


	#region coroutines

	// method: have this given mono behaviour have Unity begin a coroutine using the given enumerator, then return the begun coroutine //
	public static Coroutine beginCoroutine(this MonoBehaviour monoBehaviour, IEnumerator enumerator)
		=> monoBehaviour.StartCoroutine(enumerator);
	#endregion coroutines


	#region planning to execute methods

	// method: plan to execute the method on this given mono behaviour with the given name after the given delay, then return this given mono behaviour //
	public static MonoBehaviour executeAfter(this MonoBehaviour monoBehaviour, float delay, string methodName)
		=> monoBehaviour.after(()=>
			monoBehaviour.Invoke(methodName, delay));
	#endregion planning to execute methods


	#region validation

	// method: (via reflection:) (if in the editor:) have this given mono behaviour validate if it has validation defined (if it has an 'OnValidate' method, call it), then return this given mono behaviour //
	public static MonoBehaviourT validate_IfInEditor_ViaReflection<MonoBehaviourT>(this MonoBehaviourT monoBehaviour) where MonoBehaviourT : MonoBehaviour
	{
		#if UNITY_EDITOR
		if (monoBehaviour.isNull())
		{
			return "MonoBehaviourExtensions.validate_IfInEditor_ViaReflection given null mono behaviour".printAsErrorAndReturnDefault<MonoBehaviourT>();
		}

		dynamic monoBehaviourDynamo = monoBehaviour;
		try
		{
			monoBehaviourDynamo.OnValidate();
		}
		catch (Exception exception)		// should be a 'RuntimeBinderException' – unfortunately, that class isn't available in with Unity, for some unknown reason... so it's checked to be via reflection, below, and an error is printed if it isn't
		{
			if
			(
				exception.hasNoSelfOrInheritedSimpleClassName_ViaReflection(selfOrInheritedSimpleClassName =>
					selfOrInheritedSimpleClassName.contains("RuntimeBinder"))
			)
			{
				monoBehaviour.returnWithError("MonoBehaviourExtensions.validate_IfInEditor_ViaReflection encountered unexpected exception:\n"+exception);
			}
		}
		#endif

		return monoBehaviour;
	}

	/* (via reflection) */
	public static MonoBehaviourI validateI_IfInEditor_ViaReflection<MonoBehaviourI>(this MonoBehaviourI monoBehaviour) where MonoBehaviourI : class
	{
		if (Interfaces.doesNotInclude<MonoBehaviourI>())
		{
			return default(MonoBehaviourI).returnWithError(typeof(MonoBehaviourI).simpleClassName_ViaReflection()+" is not an interface");
		}

		return	monoBehaviour.after(()=>
					monoBehaviour.castTo<MonoBehaviour>().validate_IfInEditor_ViaReflection());
	}

	// method: (if in the editor:) have this given set of mono behaviours validate, then return this given set of mono behaviours //
	public static HashSet<MonoBehaviourT> validate_IfInEditor_ViaReflection<MonoBehaviourT>(this HashSet<MonoBehaviourT> monoBehaviours) where MonoBehaviourT : MonoBehaviour
		=> monoBehaviours.forEach(monoBehaviour => monoBehaviour.validate_IfInEditor_ViaReflection());

	/* (via reflection) */
	public static HashSet<MonoBehaviourI> validateI_IfInEditor_ViaReflection<MonoBehaviourI>(this HashSet<MonoBehaviourI> monoBehaviours) where MonoBehaviourI : class
	{
		if (Interfaces.doesNotInclude<MonoBehaviourI>())
		{
			return default(HashSet<MonoBehaviourI>).returnWithError(typeof(MonoBehaviourI).simpleClassName_ViaReflection()+" is not an interface");
		}

		return	monoBehaviours.after(()=>
					monoBehaviours.forEach(monoBehaviour => monoBehaviour.validateI_IfInEditor_ViaReflection()));
	}
	#endregion validation


	#region conversion

	#if UNITY_EDITOR
	// method: return this given mono behaviour as a Unity script file //
	public static MonoScript asScript(this MonoBehaviour monoBehaviour)
		=> MonoScript.FromMonoBehaviour(monoBehaviour);
	#endif
	#endregion conversion
}