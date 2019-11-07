using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ether:
// • creates/caches 'etherGameObject' once needed (first called) – a universal, temporary game object with a Default Auto Behaviour – and provides a property, 'behaviour', to access the game object's Default Auto Behaviour, which is used to execute auto behaviour methods that would otherwise require an auto behaviour
//  · of course, an auto behaviour instance is used here too, but the pretense is that one isn't used because this class is static so the instance is not seen in code; effectively making it easier to execute such methods
// #auto #coroutines #execution
public static class Ether
{
	private static GameObject etherGameObject_ = null;
	public static GameObject etherGameObject
		=>	etherGameObject_.isYull() ?
				etherGameObject_ :
				(etherGameObject_ = Hierarchy.createUniversalAndTemporaryObject().add<DefaultAutoBehaviour>());

	private static DefaultAutoBehaviour behaviour_ = null;
	public static DefaultAutoBehaviour behaviour
		=>	behaviour_.isYull() ?
				behaviour_ :
				(behaviour_ = etherGameObject.first<DefaultAutoBehaviour>());
}