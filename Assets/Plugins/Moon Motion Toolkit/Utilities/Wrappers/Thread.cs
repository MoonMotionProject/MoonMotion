using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.Threading;
using static DigitalRuby.Threading.EZThread;

// Thread:
// • wraps the EZThread thread class called "EZThreadRunner"
public class Thread
{
	// variables //

	
	// trackings //

	private EZThreadRunner thread;




	// constructors //

	
	public Thread(EZThreadRunner thread)
	{
		this.thread = thread;
	}



	
	// methods //

	
	// method: end this given thread //
	public void end()
	{
		thread.end();
	}
}