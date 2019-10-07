using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Struct Extensions: provides extension methods for handling structs //
public static class StructExtensions
{
	#region conversion
	
	// method: return the nullable struct for this given struct //
	public static StructT? toNullable<StructT>(this StructT struct_) where StructT : struct
		=> struct_;
	#endregion conversion
}