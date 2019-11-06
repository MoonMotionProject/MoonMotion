using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Current:
// • provides properties about what is current
// #time
public static class Current
{
	public static int frame => Time.frameCount;
}