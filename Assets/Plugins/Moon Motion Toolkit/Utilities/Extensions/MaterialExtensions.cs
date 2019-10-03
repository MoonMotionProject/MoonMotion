using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Material Extensions: provides extension methods for handling materials //
public static class MaterialExtensions
{
	#region creation
	
	// method: return a new material for the shader found using this given shader address string //
	public static Material asShaderAddressToNewMaterial_IfInAwakeOrStart(this string shaderAddress)
		=> new Material(shaderAddress.asShaderAddressToShader_IfInAwakeOrStart());
	#endregion creation
}