using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Log: provides methods for logging //
public static class Log
{
	public static string newExceptionAsError(string suffixedLine = "", GameObject contextGameObject = null)
		=> New.exception.logAsError(suffixedLine, contextGameObject);
}