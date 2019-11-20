using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

// Unscaled: provides properties and methods about realtime (unscaled time) //
[InitializeOnLoad]
public static class Unscaled
{
	public static float time => Time.unscaledTime;
	public static float timeSince(float previousTime)
		=> time.since(previousTime);
	public static double timeSince(double previousTime)
		=> time.since(previousTime);
	#if UNITY_EDITOR
	public static double timeSinceStartingEditor => EditorApplication.timeSinceStartup;
	private static double? timeOfLastCompilation_ = null;
	public static double timeOfLastCompilation
		=>	timeOfLastCompilation_.isYull() ?
				timeOfLastCompilation_.GetValueOrDefault() :
				"Unscaled: time of last compilation unexpectedly not tracked at last compilation as intended".printAsErrorAndReturnDefault<double>();
	public static double timeSinceLastCompilation => timeSince(timeOfLastCompilation);
	public static bool timeOfLastCompilationIsRightNow => timeSinceLastCompilation == 0d;
	#endif

	#if UNITY_EDITOR
	static Unscaled()
	{
		timeOfLastCompilation_ = time;
	}
	#endif
}