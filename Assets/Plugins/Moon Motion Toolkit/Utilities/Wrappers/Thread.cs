using System;
using static DigitalRuby.Threading.EZThread;

// Thread:
// • wraps the EZThread thread class called "EZThreadRunner"
// #threading #execution
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
		=> thread.end();
}