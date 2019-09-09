using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TimeExtensions: provides extension methods for handling time //
public static class TimeExtensions
{
	#region update intervals

	// method: return this given float multiplied by the most recent Update duration //
	public static float forUpdateInterval(this float float_)
		=> (float_ * Time.deltaTime);

	// method: return this given float multiplied by the most recent FixedUpdate duration //
	public static float forFixedUpdateInterval(this float float_)
		=> (float_ * Time.fixedDeltaTime);

	// method: return this given integer multiplied by the most recent Update duration //
	public static float forUpdateInterval(this int integer)
		=> (integer * Time.deltaTime);

	// method: return this given integer multiplied by the most recent FixedUpdate duration //
	public static float forFixedUpdateInterval(this int integer)
		=> (integer * Time.fixedDeltaTime);

	// method: return this given vector multiplied by the most recent Update duration //
	public static Vector3 forUpdateInterval(this Vector3 vector)
		=> (vector * Time.deltaTime);

	// method: return this given vector multiplied by the most recent FixedUpdate duration //
	public static Vector3 forFixedUpdateInterval(this Vector3 vector)
		=> (vector * Time.fixedDeltaTime);
	#endregion update intervals


	#region displacement

	// method: return the amount of time past the given previous time this given time is //
	public static float since(this float time, float previousTime)
		=> time - previousTime;
	#endregion displacement
}