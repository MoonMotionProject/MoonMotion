using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game: provides properties and methods about the game's time //
public static class Game
{
	public static float time => Time.time;
	public static float timeSince(float previousTime)
		=> time.since(previousTime);
	public static float timeSinceLastUpdate => Time.deltaTime;
	public static float timeSinceLastFixedUpdate => Time.fixedDeltaTime;
	public static float timeInteger => time.toInteger();

	#region divisibility
	public static bool timeIntegerIsDivisibleBy(float divisor)
		=> timeInteger.isDivisibleBy(divisor);
	public static bool timeIntegerIsEven => timeIntegerIsDivisibleBy(2f);
	public static bool timeIntegerIsOdd => !timeIntegerIsEven;
	public static bool timeIntegerIsDivisibleByFive => timeIntegerIsDivisibleBy(5f);
	public static bool timeIntegerIsDivisibleByTen => timeIntegerIsDivisibleBy(10f);
	#endregion divisibility
}