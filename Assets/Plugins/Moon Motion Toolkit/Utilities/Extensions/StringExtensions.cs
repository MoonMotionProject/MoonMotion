using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// StringExtensions: provides extension methods for handling strings //
public static class StringExtensions
{
	// methods for: handling emptiness and nullness //
	
	// method: return whether this given string is empty //
	public static bool empty(this string string_)
		=> string_.Equals("");

	// method: return whether this given string is empty or null //
	public static bool emptyOrNull(this string string_)
		=> ((string_ == null) || string_.empty());

	// method: return this given string set to the given target string if this given string is empty //
	public static string replaceIfEmpty(this string string_, string targetString)
		=> (string_.empty() ? targetString : string_);


	// methods for: printing //

	// method: print this given string, then return it //
	public static string print(this string string_)
	{
		MonoBehaviour.print(string_);

		return string_;
	}


	// methods for: removing characters //

	public static string removedCharacterLast(this string string_)
		=> string_.Substring(0, string_.Length - 1);

	public static string removedCharactersFromEnd(this string string_, int numberOfCharactersToRemove)
		=> string_.Substring(0, string_.Length - numberOfCharactersToRemove);

	public static string removedCharacterFirst(this string string_)
		=> string_.Substring(1);

	public static string removedCharactersFromStart(this string string_, int numberOfCharactersToRemove)
		=> string_.Substring(numberOfCharactersToRemove);
}