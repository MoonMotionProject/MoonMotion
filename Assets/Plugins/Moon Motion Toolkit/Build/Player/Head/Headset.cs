using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

// Headset: provides headset properties //
public static class Headset
{
	public static bool isApparentlyBeingWorn => SteamVR_Controller.Input(0).GetPress(EVRButtonId.k_EButton_ProximitySensor);
	public static bool isApparentlyNotBeingWorn => !isApparentlyBeingWorn;
}