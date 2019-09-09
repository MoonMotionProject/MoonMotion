using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

// Hashing Extensions: provides extension methods and the algorithm for hashing //
public static class HashingExtensions
{
	#region constants


	private static readonly MD5 hashingAlgorithm = MD5.Create();
	#endregion constants




	#region methods


	// method: return the hashed bytes for these given bytes //
	public static byte[] hashed(this byte[] bytes)
		=> hashingAlgorithm.ComputeHash(bytes);

	// method: return the hashed bytes for this given string //
	public static byte[] hashedBytes(this string string_)
		=> hashed(string_.bytes());

	// method: return the hashed bytes for this given integer //
	public static byte[] hashedBytes(this int integer)
		=> hashed(integer.bytes());

	// method: return the hashed string for this given string //
	public static string hashedString(this string string_)
		=> string_.hashedBytes().asString();

	// method: return the hashed string for this given integer //
	public static string hashedString(this int integer)
		=> integer.hashedBytes().asString();
	#endregion methods
}