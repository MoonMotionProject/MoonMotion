using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Controller;

// Handedness Extensions: provides extension methods for handling (controller) handedness //
public static class HandednessExtensions
{
	#region determination
	
	public static bool isInfinite(this Handedness handedness)
		=> handedness == Handedness.infinite;
	#endregion determination
}