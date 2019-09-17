using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Extensions: provides extension methods for handling the player //
public static class PlayerExtensions
{
	#region identification

	// method: return whether this given game object is named as though it is a Moon Motion Player //
	public static bool isPlayer(this GameObject gameObject)
		=> gameObject.nameMatches(MoonMotion.playerName);

	// method: return whether this given component's game object is named as though it is a Moon Motion Player //
	public static bool isAttachedToPlayer(this Component component)
		=> component.gameObject.isPlayer();
	#endregion identification
}