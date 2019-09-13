﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tug Extensions: provides extension methods for handling tugs //
public static class TugExtensions
{
	#region conversion
	
	// method: return the sign for this given tug //
	public static int asSign(this Tug tug)
		=> tug.castTo<int>().asBoolean().asSign();
	#endregion conversion
}