﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Flip Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Flip Within One Second Ago")]
public class FlipWithinOneSecondAgoRequisite : DependencyRequisite
{
	public override bool state => UnityIs.playing && ((Time.time - Flipper.lastFlippingTime()) <= 1f);
}