using UnityEngine;
using System.Collections;

// Average Position:
// • at each update, sets this transform's position to be the determined average position of the connected transforms
// #transform #transformations
[CacheTransform]
public class AveragePosition : AutoBehaviour<AveragePosition>
{
	// variables //

	
	// connections: transforms to average positions of //
	public Transform[] transforms;




	// updating //

	
	// at each update: //
	protected virtual void Update()
		// set this transform's position to be the average position of the connected transforms //
		=> setPositionTo(transforms.averagePosition());
}
