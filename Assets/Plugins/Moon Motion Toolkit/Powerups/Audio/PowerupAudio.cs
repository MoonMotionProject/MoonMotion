using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Powerup Audio:
// • defines this object as a powerup audio (in general, as there are certain kinds) of a powerup, and expects to initially be an immediate child of a parent Powerup
// • provides a method to play the attached audio
// • provides a method to destroy this object (after a delay equal to the duration of the attached audio), which is called by the parent Powerup's permanent destruction method
public abstract class PowerupAudio : MonoBehaviour
{
	// variables //

	
	// variables for: playing //
	private AudioSource audioSource;		// connection - automatic: the attached audio source
	private new AudioClip audio;		// connection - automatic: the attached audio
	private float audioDuration;		// tracking: the duration of the attached audio (for planning to destroy this object after a delay equal to this duration)




	// methods //

	
	// methods for: playing //

	// method: play the attached audio //
	public virtual void play()
	{
		audioSource.PlayOneShot(audio);
	}


	// methods for: destruction //
	
	// method: destroy this object //
	protected virtual void destroyObject()
	{
		Destroy(gameObject);
	}
	// method: plan to destroy this object after a delay equal to the attached audio's duration //
	public virtual void destroy()
	{
		print("destroying audio object in: "+audioDuration);
		Invoke("destroyObject", audioDuration);
	}




	// updating //

	
	// before the start: //
	private void Awake()
	{
		// connect to the attached audio source and audio //
		audioSource = GetComponent<AudioSource>();
		audio = audioSource.clip;

		// track the duration of the attached audio //
		audioDuration = audio.length;
	}
}