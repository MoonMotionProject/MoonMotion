using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component Caching Extensions: provides extension methods and related functionality for caching components of game objects //
public static class ComponentCachingExtensions
{
	// variables //

	
	// tracking //

	public static Dictionary<GameObject, Dictionary<Type, Component>> cachedComponentDictionaries = new Dictionary<GameObject, Dictionary<Type, Component>>();      // a dictionary of cached component dictionaries (dictionaries of those components on a particular game object which are cached here, keyed by their type) for game object keys




	// methods //


	// method: cachingly return the component of the specified class in the cached components for this given game object, optionally adding the specified type of component if none is found //
	public static ComponentT cache<ComponentT>(this GameObject gameObject, bool addComponentIfNoneFound = false) where ComponentT : Component
		=>	cachedComponentDictionaries.cache
			(
				gameObject,
				()=> new Dictionary<Type, Component>()
			)
			.cache
			(
				typeof(ComponentT),
				()=> gameObject.first<ComponentT>().ifYullOtherwise(()=>
					addComponentIfNoneFound ? gameObject.addGet<ComponentT>() : null)
			)
			.castTo<ComponentT>();

	// method: untrack the cached components for this given game object, then return whether this given game object actually had cached components //
	public static bool tryToUncache(this GameObject gameObject)
		=> cachedComponentDictionaries.tryToRemove(gameObject);

	// method: in the cached component dictionaries dictionary, remove all (game object) keys which are destroyed, then return the cached component dictionaries dictionary //
	public static Dictionary<GameObject, Dictionary<Type, Component>> clean()
		=> cachedComponentDictionaries.clean();
}