using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shader Extensions: provides extension methods for handling shaders //
public static class ShaderExtensions
{
	#region conversion
	
	// method: return the shader found using this given shader address string //
	public static Shader asShaderAddressToShader_IfInAwakeOrStart(this string shaderAddress)
		=> Shader.Find(shaderAddress);
	
	// method: return a new material using this given shader //
	public static Material toNewMaterial(this Shader shader)
		=> new Material(shader);
	#endregion conversion
}