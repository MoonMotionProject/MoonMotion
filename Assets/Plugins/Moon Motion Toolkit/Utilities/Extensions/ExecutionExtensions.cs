using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Execution Extensions: 
// • provides extension methods for handling execution
// #coroutines #execution
public static class ExecutionExtensions
{
	#region starting coroutines


	#region the ether

	// method: have the ether have Unity start a coroutine using this given enumerator, then return the started coroutine //
	public static Coroutine startAsCoroutine(this IEnumerator enumerator)
		=> Start.coroutine(enumerator);
	#endregion the ether


	#region this given game object

	// method: have this given game object have Unity start a coroutine using the given enumerator, then return the started coroutine //
	public static Coroutine startCoroutine(this GameObject gameObject, IEnumerator enumerator)
		=> gameObject.ensuredDefaultAutoBehaviour().startCoroutine(enumerator);

	// methods: have this given game object have Unity start a coroutine using the given function executing the given parameters and following the given coroute, then return the started coroutine //
	public static Coroutine startCoroutine(this GameObject gameObject, Coroute coroute, Delegate function, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().startCoroutine(coroute, function, parameters);
	public static Coroutine startCoroutine(this GameObject gameObject, Coroute coroute, Action action)
		=> gameObject.ensuredDefaultAutoBehaviour().startCoroutine(coroute, action);
	
	public static Coroutine startCoroutineWithInterval(this GameObject gameObject, float interval, Coroute coroute, Delegate function, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().startCoroutineWithInterval(interval, coroute, function, parameters);
	public static Coroutine startCoroutineWithInterval(this GameObject gameObject, float interval, Coroute coroute, Action action)
		=> gameObject.ensuredDefaultAutoBehaviour().startCoroutineWithInterval(interval, coroute, action);

	// methods: have this given game object have Unity start a repeating coroutine using the given function executing the given parameters, starting now versus at next check according to the given boolean, then return the started coroutine //
	public static Coroutine startRepeatingCoroutine(this GameObject gameObject, Delegate function, bool startNowVersusAtNextCheck = Default.startingNowVersusAtNextCycle, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().startRepeatingCoroutine(function, startNowVersusAtNextCheck, parameters);
	public static Coroutine startRepeatingCoroutine(this GameObject gameObject, Action action, bool startNowVersusAtNextCheck = Default.startingNowVersusAtNextCycle)
		=> gameObject.ensuredDefaultAutoBehaviour().startRepeatingCoroutine(action, startNowVersusAtNextCheck);
	
	public static Coroutine startCoroutineRepeatingEvery(this GameObject gameObject, float interval, Delegate function, bool startNowVersusAfterFirstInterval = Default.startingNowVersusAtNextCycle, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().startCoroutineRepeatingEvery(interval, function, startNowVersusAfterFirstInterval, parameters);
	public static Coroutine startCoroutineRepeatingEvery(this GameObject gameObject, float interval, Action action, bool startNowVersusAfterFirstInterval = Default.startingNowVersusAtNextCycle)
		=> gameObject.ensuredDefaultAutoBehaviour().startCoroutineRepeatingEvery(interval, action, startNowVersusAfterFirstInterval);
	#endregion this given game object


	#region this given component

	// method: have this given component have Unity start a coroutine using the given enumerator, then return the started coroutine //
	public static Coroutine startCoroutine(this Component component, IEnumerator enumerator)
		=> component.ensuredDefaultAutoBehaviour().startCoroutine(enumerator);

	// methods: have this given component have Unity start a coroutine using the given function executing the given parameters and following the given coroute, then return the started coroutine //
	public static Coroutine startCoroutine(this Component component, Coroute coroute, Delegate function, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().startCoroutine(coroute, function, parameters);
	public static Coroutine startCoroutine(this Component component, Coroute coroute, Action action)
		=> component.ensuredDefaultAutoBehaviour().startCoroutine(coroute, action);
	
	public static Coroutine startCoroutineWithInterval(this Component component, float interval, Coroute coroute, Delegate function, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().startCoroutineWithInterval(interval, coroute, function, parameters);
	public static Coroutine startCoroutineWithInterval(this Component component, float interval, Coroute coroute, Action action)
		=> component.ensuredDefaultAutoBehaviour().startCoroutineWithInterval(interval, coroute, action);

	// methods: have this given component have Unity start a repeating coroutine using the given function executing the given parameters, starting now versus at next check according to the given boolean, then return the started coroutine //
	public static Coroutine startRepeatingCoroutine(this Component component, Delegate function, bool startNowVersusAtNextCheck = Default.startingNowVersusAtNextCycle, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().startRepeatingCoroutine(function, startNowVersusAtNextCheck, parameters);
	public static Coroutine startRepeatingCoroutine(this Component component, Action action, bool startNowVersusAtNextCheck = Default.startingNowVersusAtNextCycle)
		=> component.ensuredDefaultAutoBehaviour().startRepeatingCoroutine(action, startNowVersusAtNextCheck);
	
	public static Coroutine startCoroutineRepeatingEvery(this Component component, float interval, Delegate function, bool startNowVersusAfterFirstInterval = Default.startingNowVersusAtNextCycle, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().startCoroutineRepeatingEvery(interval, function, startNowVersusAfterFirstInterval, parameters);
	public static Coroutine startCoroutineRepeatingEvery(this Component component, float interval, Action action, bool startNowVersusAfterFirstInterval = Default.startingNowVersusAtNextCycle)
		=> component.ensuredDefaultAutoBehaviour().startCoroutineRepeatingEvery(interval, action, startNowVersusAfterFirstInterval);
	#endregion this given component
	#endregion starting coroutines




	#region stopping coroutines


	#region this given game object

	// method: have this given game object stop its given coroutine //
	public static GameObject stopCoroutine(this GameObject gameObject, Coroutine coroutine)
		=>	gameObject.after(()=>
				gameObject.ensuredDefaultAutoBehaviour().stopCoroutine(coroutine));

	// method: have this given game object stop all of its coroutines //
	public static GameObject stopAllCoroutines(this GameObject gameObject)
		=>	gameObject.after(()=>
				gameObject.ensuredDefaultAutoBehaviour().stopAllCoroutines());
	#endregion this given game object


	#region this given component

	// method: have this given component stop its given coroutine //
	public static Component stopCoroutine(this Component component, Coroutine coroutine)
		=>	component.after(()=>
				component.ensuredDefaultAutoBehaviour().stopCoroutine(coroutine));

	// method: have this given component stop all of its coroutines //
	public static Component stopAllCoroutines(this Component component)
		=>	component.after(()=>
				component.ensuredDefaultAutoBehaviour().stopAllCoroutines());
	#endregion this given component
	#endregion stopping coroutines




	#region planning to execute functions after a delay


	#region this given game object

	// methods: have this given game object plan to execute the given function with the given parameters after the given delay, then return the new coroutine that will do so //
	public static Coroutine executeAfter(this GameObject gameObject, float delay, Delegate function, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().executeAfter(delay, function, parameters);
	public static Coroutine executeAfter(this GameObject gameObject, float delay, Action action, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().executeAfter(delay, action, parameters);
	#endregion this given game object


	#region this given component

	// methods: have this given component plan to execute the given function with the given parameters after the given delay, then return the new coroutine that will do so //
	public static Coroutine executeAfter(this Component component, float delay, Delegate function, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().executeAfter(delay, function, parameters);
	public static Coroutine executeAfter(this Component component, float delay, Action action, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().executeAfter(delay, action, parameters);
	#endregion this given component
	#endregion planning to execute functions after a delay




	#region planning to execute functions\actions at next check


	#region this given game object

	// methods: have this given game object plan to execute the given function with the given parameters at the next coroutine check, then return the new coroutine that will do so //
	public static Coroutine executeAtNextCheck(this GameObject gameObject, Delegate function, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().atNextCheckExecute(function, parameters);
	public static Coroutine executeAtNextCheck(this GameObject gameObject, Action action, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().atNextCheckExecute(action, parameters);
	#endregion this given game object


	#region this given component

	// methods: have this given component plan to execute the given function with the given parameters at the next coroutine check, then return the new coroutine that will do so //
	public static Coroutine executeAtNextCheck(this Component component, Delegate function, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().atNextCheckExecute(function, parameters);
	public static Coroutine executeAtNextCheck(this Component component, Action action, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().atNextCheckExecute(action, parameters);
	#endregion this given component
	#endregion planning to execute functions\actions at next check




	#region planning to execute functions\actions now and at every check


	#region this given game object

	// methods: have this given game object plan to execute the given function with the given parameters at every coroutine check, then return the new coroutine that will do so //
	public static Coroutine executeNowAndAtEveryCheck(this GameObject gameObject, Delegate function, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().nowAndAtEveryCheckExecute(function, parameters);
	public static Coroutine executeNowAndAtEveryCheck(this GameObject gameObject, Action action, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().nowAndAtEveryCheckExecute(action, parameters);
	#endregion this given game object


	#region this given component

	// methods: have this given game object plan to execute the given function with the given parameters at every coroutine check, then return the new coroutine that will do so //
	public static Coroutine executeNowAndAtEveryCheck(this Component component, Delegate function, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().nowAndAtEveryCheckExecute(function, parameters);
	public static Coroutine executeNowAndAtEveryCheck(this Component component, Action action, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().nowAndAtEveryCheckExecute(action, parameters);
	#endregion this given component
	#endregion planning to execute functions\actions now and at every check




	#region planning to execute functions\actions at next check and every check after


	#region this given game object

	// methods: have this given game object plan to execute the given function with the given parameters at every coroutine check, then return the new coroutine that will do so //
	public static Coroutine executeAtNextCheckAndEveryCheckAfter(this GameObject gameObject, Delegate function, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().atNextCheckAndEveryCheckAfterExecute(function, parameters);
	public static Coroutine executeAtNextCheckAndEveryCheckAfter(this GameObject gameObject, Action action, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().atNextCheckAndEveryCheckAfterExecute(action, parameters);
	#endregion this given game object


	#region this given component

	// methods: have this given component plan to execute the given function with the given parameters at every coroutine check, then return the new coroutine that will do so //
	public static Coroutine executeAtNextCheckAndEveryCheckAfter(this Component component, Delegate function, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().atNextCheckAndEveryCheckAfterExecute(function, parameters);
	public static Coroutine executeAtNextCheckAndEveryCheckAfter(this Component component, Action action, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().atNextCheckAndEveryCheckAfterExecute(action, parameters);
	#endregion this given component
	#endregion planning to execute functions\actions at next check and every check after




	#region planning to execute functions\actions at the end of the current frame


	#region this given game object

	// methods: have this given game object plan to execute the given function with the given parameters at the end of the current frame, then return the new coroutine that will do so //
	public static Coroutine executeAtEndOfFrame(this GameObject gameObject, Delegate function, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().atEndOfFrameExecute(function, parameters);
	public static Coroutine executeAtEndOfFrame(this GameObject gameObject, Action action, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().atEndOfFrameExecute(action, parameters);
	#endregion this given game object


	#region this given component

	// methods: have this given component plan to execute the given function with the given parameters at the end of the current frame, then return the new coroutine that will do so //
	public static Coroutine executeAtEndOfFrame(this Component component, Delegate function, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().atEndOfFrameExecute(function, parameters);
	public static Coroutine executeAtEndOfFrame(this Component component, Action action, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().atEndOfFrameExecute(action, parameters);
	#endregion this given component
	#endregion planning to execute functions\actions at the end of the current frame




	#region planning to execute functions\actions now and on interval


	#region this given game object

	public static Coroutine executeNowAndEvery(this GameObject gameObject, float interval, Delegate function, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().executeNowAndEvery(interval, function, parameters);
	public static Coroutine executeNowAndEvery(this GameObject gameObject, float interval, Action action, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().executeNowAndEvery(interval, action, parameters);
	#endregion this given game object

	
	#region this given component

	public static Coroutine executeNowAndEvery(this Component component, float interval, Delegate function, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().executeNowAndEvery(interval, function, parameters);
	public static Coroutine executeNowAndEvery(this Component component, float interval, Action action, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().executeNowAndEvery(interval, action, parameters);
	#endregion this given component
	#endregion planning to execute functions\actions now and on interval




	#region planning to execute functions\actions after every interval


	#region this given game object

	public static Coroutine executeAfterEvery(this GameObject gameObject, float interval, Delegate function, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().executeAfterEvery(interval, function, parameters);
	public static Coroutine executeAfterEvery(this GameObject gameObject, float interval, Action action, params object[] parameters)
		=> gameObject.ensuredDefaultAutoBehaviour().executeAfterEvery(interval, action, parameters);
	#endregion this given game object


	#region this given component

	public static Coroutine executeAfterEvery(this Component component, float interval, Delegate function, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().executeAfterEvery(interval, function, parameters);
	public static Coroutine executeAfterEvery(this Component component, float interval, Action action, params object[] parameters)
		=> component.ensuredDefaultAutoBehaviour().executeAfterEvery(interval, action, parameters);
	#endregion this given component
	#endregion planning to execute functions\actions after every interval
}