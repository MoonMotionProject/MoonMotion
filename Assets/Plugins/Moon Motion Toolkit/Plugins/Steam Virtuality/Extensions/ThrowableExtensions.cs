using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Throwable Extensions: provides extension methods for handling throwables //
public static class ThrowableExtensions
{
	#region toggling swapping

	// method: set the enablement of this given throwable's swapping setting to the given boolean, then return this given throwable //
	public static Throwable setSwappingEnablementTo(this Throwable throwable, bool boolean)
	{
		throwable.swappingEnabled = boolean;

		return throwable;
	}

	// method: disable swapping for this given throwable, then return it //
	public static Throwable disableSwapping(this Throwable throwable)
		=> throwable.setSwappingEnablementTo(false);

	// method: enable swapping for this given throwable, then return it //
	public static Throwable enableSwapping(this Throwable throwable)
		=> throwable.setSwappingEnablementTo(true);
	#endregion toggling swapping


	#region toggling catching

	// method: set the enablement of this given throwable's catching setting to the given boolean, then return this given throwable //
	public static Throwable setCatchingEnablementTo(this Throwable throwable, bool boolean)
	{
		throwable.catchingEnabled = boolean;

		return throwable;
	}

	// method: disable catching for this given throwable, then return it //
	public static Throwable disableCatching(this Throwable throwable)
		=> throwable.setCatchingEnablementTo(false);

	// method: enable catching for this given throwable, then return it //
	public static Throwable enableCatching(this Throwable throwable)
		=> throwable.setCatchingEnablementTo(true);
	#endregion toggling catching
}