using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scrolling Material:
// • updates this material according to a changing offset (using a set speed) in order to appear scrolling
//   · speed is set per x and y axes; as such, offsets are determined per x and y axes, allowing for scrolling to be directionally adjusted
//   · a toggle is provided for whether the scrolling shall currently be active
public class ScrollingMaterial : AutoBehaviour<ScrollingMaterial>
{
	// variables //

	// settings: the speed by which to scroll this material, in x and y (respectively) //
	[Header("Speeds")]
	public float speedX, speedY;
	
	// setting: whether this material should scroll currntly
	[Header("Toggle")]
	public bool active = true;




	// updating //

	
	// at each update: //
	protected virtual void Update()
	{
		// if scrolling is currently active: scroll the material of this renderer according to the set speeds //
		if (active)
		{
			// offset the material by x and y offsets based on the current time //
			renderer.material.SetTextureOffset
			(
				"_MainTex",
				new Vector2
				(
					Time.time * speedX,
					Time.time * speedY
				)
			);
		}
	}
}