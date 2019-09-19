using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Powerup Collider:
// • defines this object as the collider of a powerup, and expects to be an immediate child of a parent with a Powerup, and a sibling to a Powerup Bump Audio
// • detects collisions with this powerup
//   · upon a collision, has the sibling Powerup Bump Audio play its attached bump audio
//   · if collided with the player layer, has the parent Powerup pickup
public class PowerupCollider : MonoBehaviour
{
	// variables //

	
	// variables for: handling collisions //
	private Powerup powerup;        // connection - auto: the parent Powerup
	private PowerupBumpAudio bumpAudio;		// connection - auto: the sibling Powerup Bump Audio
	
	
	
	
	// updating //

	
	// before the start: //
	private void Awake()
	{
		// connect to the parent Powerup //
		powerup = transform.parent.GetComponent<Powerup>();

		// connect to the sibling Powerup Bump Audio //
		bumpAudio = powerup.GetComponentInChildren<PowerupBumpAudio>();
	}

	// upon trigger entry: //
	private void OnTriggerEnter(Collider collider)
	{
		// have the sibling Powerup Bump Audio play its attached bump audio //
		bumpAudio.play();

		// if triggered by the player, have the parent Powerup pickup //
		if (collider.GetComponentInParent<Player>())
		{
			powerup.pickup();
		}
	}
}