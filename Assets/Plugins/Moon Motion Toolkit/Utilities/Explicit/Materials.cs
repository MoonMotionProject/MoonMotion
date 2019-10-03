using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Materials: provides material properties //
public static class Materials
{
	#region new materials from the respective shaders

	#region Unity
	public static Material standard_IfInAwakeOrStart => Shaders.standard_IfInAwakeOrStart.toNewMaterial();
	#endregion Unity

	#region Moon Motion Toolkit
	#if MOON_MOTION_TOOLKIT
	public static Material penetratingStroke_IfInAwakeOrStart => Shaders.penetratingStroke_IfInAwakeOrStart.toNewMaterial();
	#endif
	#endregion Moon Motion Toolkit

	#endregion new materials from the respective shaders
}