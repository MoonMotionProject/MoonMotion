using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ressing Extensions:
// • provides extension methods for ressing (as in the creation of (file) addresses or filepaths)
// #ressing
public static class RessingExtensions
{
	public static string ress(this string string_)
		=> string_+Ress.string_;
	
	public static string potentiallyPreressed(this string string_)
		=> string_.withPotentialPrefix(Ress.string_);
	
	public static string potentiallyPostressed(this string string_)
		=> string_.withPotentialSuffix(Ress.string_);
	
	public static string withPotentialRessingSuffix(this string string_, string suffix)
		=> string_+suffix.potentiallyPreressed();
}