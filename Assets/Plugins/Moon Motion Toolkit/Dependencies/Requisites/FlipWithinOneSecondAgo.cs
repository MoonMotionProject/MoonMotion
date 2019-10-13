using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Flip Within One Second Ago", menuName = "Moon Motion/Dependency Requisites/Flip Within One Second Ago")]
public class FlipWithinOneSecondAgo : DependencyRequisite
{
	public override bool state => (Time.time - Flipper.lastFlippingTime()) <= 1f;
}