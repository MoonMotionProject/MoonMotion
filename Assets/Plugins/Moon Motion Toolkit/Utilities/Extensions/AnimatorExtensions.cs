using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Animator Extensions: provides extension methods for handling animators //
public static class AnimatorExtensions
{
	#region triggering animatriggers
	
	// method: (according to the given boolean:) trigger this given animator's animatrigger for the given target animatrigger name (if an animatrigger with that name exists), then return this given animator //
	public static Animator trigger(this Animator animator, string targetAnimatriggerName, bool boolean = true)
	{
		if (boolean)
		{
			animator.SetTrigger(targetAnimatriggerName);
		}

		return animator;
	}
	#endregion triggering animatriggers

	
	#region setting enablement of animatoggles
	
	// method: (according to the given boolean:) set the enablement of this given animator's animatoggle for the given target animatoggle name to the given new boolean (if an animatoggle with that name exists), then return this given animator //
	public static Animator setEnablementOf(this Animator animator, string targetAnimatoggleName, bool newBoolean, bool boolean = true)
	{
		if (boolean)
		{
			animator.SetBool(targetAnimatoggleName, newBoolean);
		}

		return animator;
	}

	// method: (according to the given boolean:) enable this given animator's animatoggle for the given target animatoggle name (if an animatoggle with that name exists), then return this given animator //
	public static Animator enable(this Animator animator, string targetAnimatoggleName, bool boolean = true)
		=> animator.setEnablementOf(targetAnimatoggleName, true,
			boolean);

	// method: (according to the given boolean:) disable this given animator's animatoggle for the given target animatoggle name (if an animatoggle with that name exists), then return this given animator //
	public static Animator disable(this Animator animator, string targetAnimatoggleName, bool boolean = true)
		=> animator.setEnablementOf(targetAnimatoggleName, false,
			boolean);
	#endregion setting enablement of animatoggles
}