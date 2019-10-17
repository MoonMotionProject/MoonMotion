using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Animator Extensions: provides extension methods for handling animators //
public static class AnimatorExtensions
{
	#region setting enablement of booleans
	
	// method: (according to the given boolean:) set the enablement of this given animator's boolean for the given target boolean name to the given new boolean (if a boolean with that name exists), then return this given animator //
	public static Animator setEnablementOf(this Animator animator, string targetBooleanName, bool newBoolean, bool boolean = true)
	{
		if (boolean)
		{
			animator.SetBool(targetBooleanName, newBoolean);
		}

		return animator;
	}

	// method: (according to the given boolean:) enable this given animator's boolean for the given target boolean name (if a boolean with that name exists), then return this given animator //
	public static Animator enable(this Animator animator, string targetBooleanName, bool boolean = true)
		=> animator.setEnablementOf(targetBooleanName, true,
			boolean);

	// method: (according to the given boolean:) disable this given animator's boolean for the given target boolean name (if a boolean with that name exists), then return this given animator //
	public static Animator disable(this Animator animator, string targetBooleanName, bool boolean = true)
		=> animator.setEnablementOf(targetBooleanName, false,
			boolean);
	#endregion setting enablement of booleans
}