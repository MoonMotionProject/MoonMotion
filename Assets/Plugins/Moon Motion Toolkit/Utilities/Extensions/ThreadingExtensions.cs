using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.Threading;
using static DigitalRuby.Threading.EZThread;
using System;

// Threading Extensions: provides extension methods and related functionality for handling threading //
public static class ThreadingExtensions
{
	// on a background thread, execute this given action, then return this given action //
	public static Action executeInBackground(this Action action)
	{
		ExecuteInBackground(action);

		return action;
	}

	// on a background thread, execute this given function, using its result to run the given action, then return this given function //
	public static Func<object> executeInBackground(this Func<object> function, Action<object> resultAction)
	{
		ExecuteInBackground(function, resultAction);

		return function;
	}

	// on the main thread, queue this given action to execute as soon as possible, then return this given action //
	public static Action executeOnMainThread(this Action action)
	{
		ExecuteOnMainThread(action);

		return action;
	}

	// on the main thread, queue this given action to run after the given delay (in seconds), then return this given action //
	public static Action executeOnMainThread(Action action, float delay)
	{
		ExecuteOnMainThread(action, delay);

		return action;
	}

	// Thread:
	// • wraps the EZThread thread class called "EZThreadRunner"
	public class Thread
	{
		// variables //


		// trackings //

		private EZThreadRunner thread;




		// constructors //


		public Thread(EZThreadRunner thread)
		{
			this.thread = thread;
		}




		// methods //


		// method: end this given thread //
		public void end()
			=> thread.end();
	}

	// on a new thread, repeatedly execute this given action (until the returned thread is ended), optionally in sync with Update according to the given boolean, then return the new thread //
	public static Thread beginThread(this Action action, bool syncWithUpdate = true)
		=> new Thread(BeginThread(action, syncWithUpdate));

	// end this given "EZThreadRunner" thread //
	public static void end(this EZThreadRunner threadRunner)
		=> EndThread(threadRunner);
}