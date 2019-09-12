using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

// String Extensions: provides extension methods for handling strings //
public static class StringExtensions
{
	#region equality

	// method: return whether this given string is equal to the other given string //
	public static bool equals(this string string_, string otherString)
		=> string_.Equals(otherString);
	#endregion equality


	#region handling emptiness, nullness, and onlyness

	// method: return whether this given string is empty //
	public static bool isEmpty(this string string_)
		=> string_.equals("");

	// method: return whether this given string is not empty //
	public static bool isNotEmpty(this string string_)
		=> !string_.isEmpty();

	// method: return whether this given string is empty or null //
	public static bool isEmptyOrNull(this string string_)
		=> (string_.isNull() || string_.isEmpty());

	// method: return whether this given string is not empty nor null //
	public static bool isNotEmptyNorNull(this string string_)
		=> !string_.isEmptyOrNull();

	// method: if this given string is null, return an empty string; otherwise, return this given string //
	public static string emptyIfNull(this string string_)
		=> string_.isNull() ? "" : string_;

	// method: return this given string with a newline prefix if it is not empty nor null //
	public static string withPotentialPrefixedNewline(this string string_)
		=> string_.withPotentialPrefix("\n");

	// method: return this given string with a newline suffix if it is not empty nor null //
	public static string withPotentialSuffixedNewline(this string string_)
		=> string_.withPotentialSuffix("\n");

	// method: according to the given boolean, return the given target string instead of this given string //
	public static string substituteIf(this string string_, bool boolean, string targetString)
		=> boolean ? targetString : string_;

	// method: if this given string is empty, return the given target string instead of this given string //
	public static string substituteIfEmpty(this string string_, string targetString)
		=> string_.substituteIf(string_.isEmpty(), targetString);

	// method: return whether this given string contains only (some amount of) the given character //
	public static bool containsOnly(this string string_, char character)
	{
		char[] characters = string_.ToCharArray();
		foreach (char characterInString in characters)
		{
			if (characterInString != character)
			{
				return false;
			}
		}
		return true;
	}

	// method: return whether this given string contains only spaces //
	public static bool containsOnlySpaces(this string string_)
		=> string_.containsOnly(' ');

	// method: if this given string is contains only spaces, return the given target string instead of this given string //
	public static string substituteIfContainsOnlySpaces(this string string_, string targetString)
		=> string_.substituteIf(string_.containsOnlySpaces(), targetString);
	#endregion handling emptiness, nullness, and onlyness


	#region regex

	// method: return whether this given string matches the given regex //
	public static bool matches(this string string_, Regex regex)
		=> regex.IsMatch(string_);
	// method: return whether this given string matches the regex for the given regex string //
	public static bool matches(this string string_, string regexString)
		=> string_.matches(regexString.toRegex());
	#endregion regex


	#region email

	// method: return whether this given string is an email address //
	public static bool isAnEmailAddress(this string string_)
		=> string_.matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
	#endregion email


	#region reversing

	// method: return this given string reversed //
	public static string reversed(this string string_)
		=> string_.characters().reversed().toString();
	#endregion reversing


	#region removing characters

	public static string withoutCharacterLast(this string string_)
		=> string_.Substring(0, string_.Length - 1);

	public static string withoutCharactersFromEnd(this string string_, int numberOfCharactersToRemove)
		=> string_.Substring(0, string_.Length - numberOfCharactersToRemove);

	public static string withoutCharacterFirst(this string string_)
		=> string_.Substring(1);

	public static string withoutCharactersFromStart(this string string_, int numberOfCharactersToRemove)
		=> string_.Substring(numberOfCharactersToRemove);

	public static string trimmedToLength(this string string_, int targetLength)
		=> string_.Substring(0, targetLength);

	public static string withoutHyphens(this string string_)
		=> string_.Replace("-", "");
	#endregion removing characters


	#region repeating

	// method: return the concatenation of this given string repeated the given count of times //
	public static string repeated(this string string_, int repetitionCount)
	{
		string concatenatedRepetitions = "";
		ForEach.inCount(repetitionCount, repetitionIndex =>
			concatenatedRepetitions = concatenatedRepetitions.withSuffix(string_));
		return concatenatedRepetitions;
	}
	#endregion repeating


	#region prefixing

	// method: return this given string with the given prefix //
	public static string withPrefix(this string string_, string prefix)
		=> prefix+string_;
	// method: return this given string with the given prefix if this given string is not empty nor null //
	public static string withPotentialPrefix(this string string_, string potentialPrefix)
		=> (string_.isNotEmptyNorNull() ? string_.withPrefix(potentialPrefix) : string_);
	#endregion prefixing


	#region suffixing

	// method: return this given string with the given suffix //
	public static string withSuffix(this string string_, string suffix)
		=> string_+suffix;
	// method: return this given string with the given suffix if this given string is not empty nor null //
	public static string withPotentialSuffix(this string string_, string potentialSuffix)
		=> (string_.isNotEmptyNorNull() ? string_.withSuffix(potentialSuffix) : string_);

	// method: return this given string with the given repeated suffix repeated the given count of times //
	public static string withSuffixRepeated(this string string_, string repeatedSuffix, int suffixRepetitionCount)
		=> string_.withSuffix(repeatedSuffix.repeated(suffixRepetitionCount));
	// method: return this given string with the given repeated suffix repeated the given count of times if this given string is not empty nor null //
	public static string withPotentialSuffixRepeated(this string string_, string repeatedSuffix, int suffixRepetitionCount)
		=> string_.withPotentialSuffix(repeatedSuffix.repeated(suffixRepetitionCount));

	// method: return this given string with a space suffixed //
	public static string withTrailingSpace(this string string_)
		=> string_.withSuffix(" ");
	// method: return this given string with a space suffixed if this given string is not empty nor null //
	public static string withPotentialTrailingSpace(this string string_)
		=> string_.withPotentialSuffix(" ");

	// method: return this given string with the given number of spaces suffixed //
	public static string withTrailingSpaces(this string string_, int trailingSpacesCount)
		=> string_.withSuffixRepeated(" ", trailingSpacesCount);
	// method: return this given string with the given number of spaces suffixed if this given string is not empty nor null //
	public static string withPotentialTrailingSpaces(this string string_, int trailingSpacesCount)
		=> string_.withPotentialSuffixRepeated(" ", trailingSpacesCount);
	#endregion suffixing


	#region surrounding

	// method: return this given string surrounded by the other given string //
	public static string surroundedBy(this string string_, string otherString)
		=> otherString+string_+otherString;

	// method: return this given string surrounded by quotes //
	public static string quoted(this string string_)
		=> string_.surroundedBy("'");

	// method: return this given string surrounded by airquotes //
	public static string airquoted(this string string_)
		=> string_.surroundedBy("\"");
	#endregion surrounding


	#region representation

	// method: return this given string represented as a string such that if it is null then "null" is returned (otherwise the given string is returned) //
	public static string withNullRepresented(this string string_)
		=> string_ ?? "null";
	#endregion representation


	#region conversion

	// method: return the bytes corresponding to this given string //
	public static byte[] bytes(this string string_)
		=> Encoding.UTF8.GetBytes(string_);
	// method: return the string parsed from these given bytes //
	public static string asString(this byte[] bytes)
		=> BitConverter.ToString(bytes);

	// method: return the characters (in order) of this given string //
	public static char[] characters(this string string_)
		=> string_.ToCharArray();
	// method: return the string corresponding to these given characters (in order) //
	public static string toString(this char[] characters)
		=> new string(characters);

	// method: return the hexadecimal string for this given hashed string //
	public static string asHashedStringToHexadecimalString(this string hashedString)
		=> hashedString.withoutHyphens().trimmedToLength(6).withPrefix("#");

	// method: return the color for this given hexadecimal string (assumed to be of the format ~"#ABCDEF") //
	public static Color asHexadecimalColor(this string hexadecimalString)
	{
		Color convertedColor;
		ColorUtility.TryParseHtmlString(hexadecimalString, out convertedColor);
		return convertedColor;
	}

	// method: return the color for the hexadecimal string for this given hashed string //
	public static Color asHashedStringToColor(this string hashedString)
		=> hashedString.asHashedStringToHexadecimalString().asHexadecimalColor();

	// method: return the random color corresponding to this string as a seed //
	public static Color seedRandomColor(this string string_)
		=> string_.hashedString().asHashedStringToColor();

	// method: return the regex for this given string //
	public static Regex toRegex(this string string_)
		=> new Regex(string_);
	#endregion conversion
}