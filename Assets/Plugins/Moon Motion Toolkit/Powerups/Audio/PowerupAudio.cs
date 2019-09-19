using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Powerup Audio:
// • defines this object as a powerup audio (in general, as there are certain kinds) of a powerup, and expects to initially be an immediate child of a parent Powerup
// • provides a method to play the attached audio
// • provides a method to destroy this object (after a delay equal to the duration of the attached audio), which is called by the parent Powerup's permanent destruction method
public abstract class PowerupAudio : AutoBehaviour<PowerupAudio>
{
	// methods //

	
	// methods for: playing //

	// method: play the attached audio //
	public virtual void play()
		=> audioSource.PlayOneShot(audio);


	// methods for: destruction //

	// method: plan to destroy this object after a delay equal to the attached audio's duration //
	public virtual void destroyAfterAudioDuration()
		=> Invoke("destroyObject", audioDuration);
}