using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

// String Extensions: provides extension methods for handling strings //
public static class StringExtensions
{
	#region equality

	// method: return whether this given string matches (is equal to) the other given string //
	public static bool matches(this string string_, string otherString)
		=> string_.Equals(otherString);
	#endregion equality


	#region handling emptiness, nullness, and onlyness

	// method: return whether this given string is empty //
	public static bool isEmpty(this string string_)
		=> !string_.hasAny();

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

	// method: return this given string represented as a string such that if it is null then "null" is returned (otherwise the given string is returned) //
	public static string withNullRepresented(this string string_)
		=> string_ ?? "null";

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
	public static bool matchesRegex(this string string_, Regex regex)
		=> regex.IsMatch(string_);
	// method: return whether this given string matches the regex for the given regex string //
	public static bool matchesRegex(this string string_, string regexString)
		=> string_.matchesRegex(regexString.toRegex());
	#endregion regex


	#region email

	// method: return whether this given string is an email address //
	public static bool isAnEmailAddress(this string string_)
		=> string_.matchesRegex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
	#endregion email


	#region reversing

	// method: return this given string reversed //
	public static string reversed(this string string_)
		=> string_.characters().reversed().toString();
	#endregion reversing


	#region locating contained string

	// method: return the index of the first occurrence of the given sought string in this given string, otherwise returning -1 if the given sought string is not found in this given string //
	public static int indexOfFirst(this string string_, string soughtString)
		=> string_.IndexOf(soughtString);

	// method: return the index after the end of the first currence of the given sought string, otherwise returning -1 if the given sought string is not found in this given string //
	public static int indexAfterFirst(this string string_, string soughtString)
		=> string_.indexOfFirst(soughtString).ifNonnegativeThenPlus(soughtString.Length);
	#endregion locating contained string


	#region replacing characters

	public static string withReplaced(this string string_, string stringTemplateToReplace, string replacementString)
		=> string_.Replace(stringTemplateToReplace, replacementString);
	#endregion replacing characters


	#region removing characters

	public static string fromThenUntil(this string string_, int indexFrom, int indexUntil)
		=> string_.Substring(indexFrom, indexUntil);

	public static string from(this string string_, int index)
		=> string_.Substring(index);

	public static string until(this string string_, int index)
		=> string_.Substring(0, index);

	public static string withoutCharactersFromFirst(this string string_, string soughtString)
		=> string_.until(string_.indexOfFirst(soughtString));

	public static string withoutCharactersFromFirstBackslash(this string string_)
		=> string_.withoutCharactersFromFirst("\\");

	public static string withoutCharactersAfterFirst(this string string_, string soughtString)
		=> string_.until(string_.indexAfterFirst(soughtString));

	public static string withoutCharactersAfterFirstBackslash(this string string_)
		=> string_.withoutCharactersAfterFirst("\\");

	public static string withoutCharacterLast(this string string_)
		=> string_.until(string_.Length - 1);

	public static string withoutCharactersFromEnd(this string string_, int numberOfCharactersToRemove)
		=> string_.until(string_.Length - numberOfCharactersToRemove);

	public static string withoutCharacterFirst(this string string_)
		=> string_.from(1);

	public static string withoutCharactersFromStart(this string string_, int numberOfCharactersToRemove)
		=> string_.from(numberOfCharactersToRemove);

	public static string trimmedToLength(this string string_, int targetLength)
		=> string_.until(targetLength);

	public static string without(this string string_, string stringTemplateToRemove)
		=> string_.withReplaced(stringTemplateToRemove, "");

	public static string withoutSpaces(this string string_)
		=> string_.without(" ");

	public static string withoutHyphens(this string string_)
		=> string_.without("-");
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

	// method: return this given string with a newline suffixed //
	public static string thenNewline(this string string_)
		=> string_.withSuffix("\n");

	// method: return this given string with a newline – suffixed with the given suffix – suffixed //
	public static string thenNewlineAnd(this string string_, string suffix)
		=> string_.thenNewline().withSuffix(suffix);

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


	#region splitting

	// method: return a list of the strings resulting from splitting this given string by the given delimiter template character //
	public static List<string> splitBy(this string string_, char delimiterTemplate)
		=> string_.Split(delimiterTemplate).manifested();

	// method: return a list of the strings resulting from splitting this given string by each semicolon //
	public static List<string> splitByEachSemicolon(this string string_)
		=> string_.splitBy(';');
	#endregion splitting


	#region joining
	// methods: return the string that is the joining of the given strings by this given delimiter string //

	public static string join(this string delimiter, IEnumerable<string> strings)
		=> string.Join(delimiter, strings);

	public static string join(this string delimiter, params string[] strings)
		=> delimiter.join(strings.asEnumerable());

	public static string joinBy(this IEnumerable<string> strings, string delimiter)
		=> delimiter.join(strings);

	public static string joinBySemicolons(this IEnumerable<string> strings)
		=> strings.joinBy(";");
	#endregion joining


	#region file writing

	// method: write this given string to the given path, then return this given string //
	public static void writeTo(this string string_, string path)
	{
		StreamWriter streamWriter = new StreamWriter(path);
		streamWriter.Write(string_);
		streamWriter.Flush();
		streamWriter.Close();
		streamWriter.Dispose();
	}
	#endregion file writing


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