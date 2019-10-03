using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Powerup
// • defines this object as a powerup
// • expects a child Powerup Collider, which allows this object to be pickuped by the player via trigger collision
//   · upon pickup, something happens, usually to affect a mechanic of the player, such as particular locomotion settings
//     - by default, a powerup just destroys itself upon pickup
// • expects the following child Powerup Audios:
//   · Powerup Bump Audio, which the Powerup Collider has play whenever a collision is detected
//   · Powerup Pickup Audio, which this powerup has play upon pickup
// • provides optional functionality to respawn this powerup after its destruction
//   · a respawns count setting determines how many times this will happen
//   · the respawning is delayed by the duration of a respawning delay setting
//   · this is achieved by actually disabling and reenabling this powerup object to seemingly destroy it, instead of truly destroying it
// • instance methods are also provided to:
//   - destroy this powerup permanently (ignoring any remaining respawns)
//   - destroy this powerup (and plan to respawn it if any respawns are left)
//     – (this is the one used internally when pickuping)
//   - cast this pickup (do what it does upon pickup, besides play pickup audio first and get destroyed after)
//   - pickup this powerup
public class Powerup : AutoBehaviour<Powerup>
{
	// variables //

	
	// variables for: pickuping and respawning //
	[BoxGroup("Audio")]
	[ReadOnly]
	public PowerupBumpAudio bumpAudio;		// connection - auto: the child Powerup Bump Audio
	protected string originalBumpAudioName;     // tracking: the original name of the Powerup Bump Audio's object
	[BoxGroup("Audio")]
	[ReadOnly]
	public PowerupPickupAudio pickupAudio;		// connection - auto: the child Powerup Pickup Audio
	protected string originalPickupAudioName;		// tracking: the original name of the Powerup Pickup Audio's object
	[BoxGroup("Respawning")]
	[Tooltip("the number of times to respawn this powerup, where any negative value is treated as infinity")]
	public int respawnsCount = -1;      // setting: the number of times to respawn this powerup, where any negative value is treated as infinity
	[BoxGroup("Respawning")]
	[Tooltip("the delay duration to wait before respawning this powerup after its destruction (if any respawns remain)")]
	public float respawningDelay = 2f;		// setting: the delay duration to wait before respawning this powerup after its destruction (if any respawns remain)
	
	
	
	
	// methods //

	
	// methods for: pickuping and respawning //
	
	// method: take out the child Powerup Audios (to be parallel in the hierarchy with this powerup object) – and rename them according to their new lack of context to also have the prefix 'Powerup ' //
	protected virtual void takeOutAudios()
	{
		// take out the child Powerup Bump Audio (to be parallel in the hierarchy to this powerup) //
		bumpAudio.setParentTo(parent);
		// rename the Powerup Bump Audio's object //
		bumpAudio.name = "Powerup "+bumpAudio.name;

		// take out the child Powerup Pickup Audio (to be parallel in the hierarchy to this powerup) //
		pickupAudio.setParentTo(parent);
		// rename the Powerup Pickup Audio's object //
		pickupAudio.name = "Powerup "+pickupAudio.name;
	}
	
	// method: bring back the Powerup Audios (that became parallel in the hierarchy to this powerup) – and rename them according to their revitalized context to be back to their original names //
	protected virtual void bringBackAudios()
	{
		// return the Powerup Bump Audio (that is parallel in the hierarchy to this powerup) to being the child of this powerup //
		bumpAudio.setParentTo(transform);
		// return the Powerup Bump Audio object's name to what it was named before //
		bumpAudio.name = originalBumpAudioName;
		
		// return the Powerup Pickup Audio (that is parallel in the hierarchy to this powerup) to being the child of this powerup //
		pickupAudio.setParentTo(transform);
		// return the Powerup Pickup Audio object's name to what it was named before //
		pickupAudio.name = originalPickupAudioName;
	}

	// method: have the Powerup Audios plan their destructions //
	protected virtual void destroyAudios()
	{
		// have the Powerup Bump Audio plan its object's destruction //
		bumpAudio.destroyAfterAudioDuration();

		// have the Powerup Pickup Audio plan its object's destruction //
		pickupAudio.destroyAfterAudioDuration();
	}
	
	// method: destroy this powerup (but taking out its audios and having them uniquely plan their own objects' destructions) permanently (ignoring any remaining respawns) //
	[ContextMenu("Destroy Permanently")]
	public virtual void destroyPermanently()
	{
		// take out the Powerup Audios //
		takeOutAudios();

		// have the Powerup Audios uniquely plan their own objects' destructions //
		destroyAudios();

		// destroy this powerup object //
		destroyThisObject();
	}

	// method: respawn this powerup (by default, just by reenabling it and returning its Powerup Bump Audio object back to how it was) //
	protected virtual void respawn()
	{
		// reactivate this powerup object //
		activate();
		
		// bring back the Powerup Audios //
		bringBackAudios();
	}
	
	// method: destroy/respawn this powerup: destroy this powerup and plan to respawn it if any respawns are left – if so, destroy it only by disabling it instead of permanently destroying it //
	[ContextMenu("Destroy Powerup")]
	public virtual void destroyPowerup()
	{
		// if any respawns are left: //
		if (respawnsCount != 0)
		{
			// if the respawns count is not negative (which is treated as infinity): decrement it //
			if (respawnsCount > 0)
			{
				respawnsCount--;
			}

			// take out the Powerup Audios //
			takeOutAudios();

			// deactivate this powerup object //
			deactivate();

			// plan to respawn this powerup object after a duration equal to the respawning delay setting //
			Invoke("respawn", respawningDelay);
		}
		// otherwise (if no respawns are left): //
		else
		{
			// destroy this powerup permanently //
			destroyPermanently();
		}
	}

	// method: cast this powerup (by default, do nothing) //
	[ContextMenu("Cast")]
	public virtual void cast()
	{

	}

	// method: pickup this powerup //
	[ContextMenu("Pickup")]
	public virtual void pickup()
	{
		// have the pickup audio play //
		pickupAudio.play();

		// cast this powerup //
		cast();

		// destroy/respawn this powerup //
		destroyPowerup();
	}




	// updating //


	// before the start: //
	protected virtual void Awake()
	{
		// connect to the child Powerup Bump Audio and track the original name of the Powerup Bump Audio's object //
		bumpAudio = firstLocalOrChild<PowerupBumpAudio>();
		originalBumpAudioName = bumpAudio.name;

		// connect to the child Powerup Pickup Audio and track the original name of the Powerup Pickup Audio's object //
		pickupAudio = firstLocalOrChild<PowerupPickupAudio>();
		originalPickupAudioName = pickupAudio.name;
	}
}