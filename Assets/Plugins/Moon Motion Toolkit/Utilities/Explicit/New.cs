using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// New:
// • provides members for that allow for fluent creation of certain objects
// #new #threading #execution
public static class New
{
	public static List<TItem> List<TItem>()
		=> new List<TItem>();
	
	public static Action Action(this Action action)
		=> action;
}