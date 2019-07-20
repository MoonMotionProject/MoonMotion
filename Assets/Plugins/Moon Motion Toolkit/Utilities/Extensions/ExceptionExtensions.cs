using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Exception Extensions: provides extension methods for handling exceptions //
public static class ExceptionExtensions
{
	// methods for: logging errors //

	
	// method: log this given exception as an error with the given suffixed line //
	public static string logAsError<ExceptionT>(this ExceptionT exception, string suffixedLine = "") where ExceptionT : Exception
		=> (exception+suffixedLine.withPotentialPrefixedNewline()).asError();
}