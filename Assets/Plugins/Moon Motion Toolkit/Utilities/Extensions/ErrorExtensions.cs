using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Error Extensions:
// • provides extension methods for handling errors
// #console
public static class ErrorExtensions
{
	// method: print this given error string as an error, optionally with the given game object as the context, then return this given error string //
	public static string printAsError(this string errorString, GameObject contextGameObject = null)
		=>	errorString.after(()=>
				Debug.LogError
				(
					errorString.withNullRepresented(),
					contextGameObject
				));

	// method: print this given error string as an error, optionally with the given game object as the context, logged as following the given prefix and using the given logging separator, then return this given error string //
	public static string logAsError(this string errorString, string prefix, GameObject contextGameObject = null, string loggingSeparator = Default.loggingSeparator)
		=>	errorString.after(()=>
				(prefix+loggingSeparator+errorString).printAsError(contextGameObject));

	// method: print this given exception as an error with the given suffixed line, optionally with the given game object as the context, then return the printed string //
	public static string logAsError<ExceptionT>(this ExceptionT exception, string suffixedLine = "", GameObject contextGameObject = null) where ExceptionT : Exception
		=> (exception+suffixedLine.withPotentialPrefixedNewline()).printAsError(contextGameObject);
	// method: print this given exception as an error by printing it, followed by the given error string on a new line, followed by a return statement on a new line, optionally with the given game object as the context, then return the default of the specified type //
	public static TDefault logAsErrorAndReturnDefault<TDefault>(this Exception exception, string errorString = "", GameObject contextGameObject = null)
	{
		TDefault defaultToReturn = default(TDefault);

		exception.logAsError
		(
			(errorString.withPotentialSuffix(";\n")
				+"returning "+defaultToReturn.asStringWithNullRepresented()),
			contextGameObject
		);

		return defaultToReturn;
	}

	// method: print the given error ("error" by default), optionally with the given game object as the context, mentioning only this given boolean as what is being returned, then return this given boolean //
	public static bool returnWithError(this bool boolean, string error = "error", GameObject contextGameObject = null)
	{
		Debug.LogError(error+"; returning "+boolean, contextGameObject);

		return boolean;
	}

	// method: print the given error ("error" by default), optionally with the given game object as the context, mentioning only this given float as what is being returned, then return this given float //
	public static float returnWithError(this float float_, string error = "error", GameObject contextGameObject = null)
	{
		Debug.LogError(error+"; returning "+float_, contextGameObject);

		return float_;
	}

	// method: print the given error ("error" by default), optionally with the given game object as the context, mentioning only this given double as what is being returned, then return this given double //
	public static double returnWithError(this double double_, string error = "error", GameObject contextGameObject = null)
	{
		Debug.LogError(error+"; returning "+double_, contextGameObject);

		return double_;
	}

	// method: print the given error ("error" by default), optionally with the given game object as the context, mentioning only this given integer as what is being returned, then return this given integer //
	public static int returnWithError(this int integer, string error = "error", GameObject contextGameObject = null)
	{
		Debug.LogError(error+"; returning "+integer, contextGameObject);

		return integer;
	}

	// method: print the given error ("error" by default), optionally with the given game object as the context, mentioning only this given string as what is being returned, then return this given string //
	public static string returnWithError(this string string_, string error = "error", GameObject contextGameObject = null)
	{
		Debug.LogError(error+"; returning "+string_.withNullRepresented(), contextGameObject);

		return string_;
	}

	// method: print the given error ("error" by default), optionally with the given game object as the context, mentioning only this given vector as what is being returned, then return this given vector //
	public static Vector3 returnWithError(this Vector3 vector, string error = "error", GameObject contextGameObject = null)
	{
		Debug.LogError(error+"; returning "+vector, contextGameObject);

		return vector;
	}

	// method: print the given error ("error" by default), optionally with the given game object as the context, mentioning only this given object as what is being returned, then return this given object //
	public static ObjectT returnWithError<ObjectT>(this ObjectT object_, string error = "error", GameObject contextGameObject = null)
	{
		Debug.LogError(error+"; returning "+object_.asStringWithNullRepresented(), contextGameObject);

		return object_;
	}
	
	// method: print this given error string as an error, optionally with the given game object as the context, then return the default of the specified type //
	public static TDefault printAsErrorAndReturnDefault<TDefault>(this string errorString, GameObject contextGameObject = null)
	{
		TDefault defaultToReturn = default(TDefault);

		(errorString+"; returning "+defaultToReturn.asStringWithNullRepresented()).printAsError(contextGameObject);

		return defaultToReturn;
	}
}