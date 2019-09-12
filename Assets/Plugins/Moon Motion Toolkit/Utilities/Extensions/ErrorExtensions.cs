using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ErrorExtensions: provides extension methods for handling errors //
public static class ErrorExtensions
{
	// method: print this given error string as an error and return this given error string //
	public static string printAsError(this string errorString)
	{
		Debug.LogError(errorString.withNullRepresented());

		return errorString;
	}

	// method: print this given exception as an error with the given suffixed line //
	public static string logAsError<ExceptionT>(this ExceptionT exception, string suffixedLine = "") where ExceptionT : Exception
		=> (exception+suffixedLine.withPotentialPrefixedNewline()).printAsError();

	// method: print the given error ("error" by default), mentioning only this given boolean as what is being returned, then return this given boolean //
	public static bool returnWithError(this bool boolean, string error = "error")
	{
		Debug.LogError(error+"; returning "+boolean);

		return boolean;
	}

	// method: print the given error ("error" by default), mentioning only this given float as what is being returned, then return this given float //
	public static float returnWithError(this float float_, string error = "error")
	{
		Debug.LogError(error+"; returning "+float_);

		return float_;
	}

	// method: print the given error ("error" by default), mentioning only this given double as what is being returned, then return this given double //
	public static double returnWithError(this double double_, string error = "error")
	{
		Debug.LogError(error+"; returning "+double_);

		return double_;
	}

	// method: print the given error ("error" by default), mentioning only this given integer as what is being returned, then return this given integer //
	public static int returnWithError(this int integer, string error = "error")
	{
		Debug.LogError(error+"; returning "+integer);

		return integer;
	}

	// method: print the given error ("error" by default), mentioning only this given string as what is being returned, then return this given string //
	public static string returnWithError(this string string_, string error = "error")
	{
		Debug.LogError(error+"; returning "+string_.withNullRepresented());

		return string_;
	}

	// method: print the given error ("error" by default), mentioning only this given vector as what is being returned, then return this given vector //
	public static Vector3 returnWithError(this Vector3 vector, string error = "error")
	{
		Debug.LogError(error+"; returning "+vector);

		return vector;
	}

	// method: print the given error ("error" by default), mentioning only this given object as what is being returned, then return this given object //
	public static ObjectT returnWithError<ObjectT>(this ObjectT object_, string error = "error")
	{
		Debug.LogError(error+"; returning "+object_.asStringWithNullRepresented());

		return object_;
	}
	
	// method: print this given error string as an error and return the default of the specified type //
	public static TDefault printAsErrorAndReturnDefault<TDefault>(this string errorString)
	{
		TDefault defaultToReturn = default(TDefault);

		(errorString+"; returning "+defaultToReturn.asStringWithNullRepresented()).printAsError();

		return defaultToReturn;
	}
}