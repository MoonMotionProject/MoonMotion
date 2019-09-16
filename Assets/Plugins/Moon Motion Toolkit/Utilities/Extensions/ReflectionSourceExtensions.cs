using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Reflection Source Extensions: provides extension methods for handling reflection sources //
public static class ReflectionSourceExtensions
{
	#region conversion
	
	// method: return the 'ReflectionProbeUsage' for this given reflection source //
	public static ReflectionProbeUsage asReflectionProbeUsage(this ReflectionSource reflectionSource)
	{
		switch (reflectionSource)
		{
			case ReflectionSource.skybox:
				return ReflectionProbeUsage.Off;
			case ReflectionSource.blendedReflectionProbesOtherwiseSkybox:
				return ReflectionProbeUsage.BlendProbes;
			case ReflectionSource.blendedReflectionProbesAndSkybox:
				return ReflectionProbeUsage.BlendProbesAndSkybox;
			case ReflectionSource.singleMostRelevantProbeOrSkybox:
				return ReflectionProbeUsage.Simple;
		}
		return ReflectionProbeUsage.BlendProbesAndSkybox;		// fallback
	}
	#endregion conversion
}