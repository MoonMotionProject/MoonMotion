using UnityEngine;
using System.Collections;

// Spinning: spins this object according to the specified settings //
public class Spinning : AutomaticBehaviour<Spinning>
{
	// variables //

	
	// settings for: spinning this object //
	[Header("Spinning")]
	public Direction direction;		// setting: direction in which to rotate this object
	public bool relative = false;		// setting: whether this rotation should be relative to the object's transform (versus absolute)
	public float spinningSpeed;		// setting: the speed at which to rotate this object




	// updating //

	
	// at each update: //
	protected virtual void Update()
	{
		// determine the direction vector for rotation //
		Vector3 directionVector =	(relative ?
										direction.asVectorRelativeTo(transform) :
										direction.asVector()
									);

		// rotate this object by the set speed in the determined direction vector //
		rotate((directionVector * spinningSpeed).forUpdateInterval());
	}
}
