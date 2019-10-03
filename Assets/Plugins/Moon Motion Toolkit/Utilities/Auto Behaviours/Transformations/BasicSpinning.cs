using UnityEngine;
using System.Collections;

// Basic Spinning:
// • spins this object in a basic direction according to the specified settings
// #transform #transformations
[CacheTransform]
public class BasicSpinning : AutoBehaviour<BasicSpinning>
{
	// variables //

	
	// settings for: spinning this object //
	[Tooltip("the basic direction in which to rotate this object")]
	public BasicDirection basicDirection = BasicDirection.up;
	[Tooltip("whether this rotation should be relative to the object's transform (versus absolute)")]
	public bool relative = false;
	[Tooltip("the speed at which to rotate this object")]
	public float spinningSpeed = 10f;




	// updating //

	
	// at each update: //
	protected virtual void Update()
	{
		// determine the direction for rotation //
		Vector3 direction =	(relative ?
										basicDirection.asDirectionRelativeTo(transform) :
										basicDirection.asGlobalDirection()
									);

		// rotate this object by the set speed in the determined direction vector //
		rotate((direction * spinningSpeed).forUpdateInterval());
	}
}