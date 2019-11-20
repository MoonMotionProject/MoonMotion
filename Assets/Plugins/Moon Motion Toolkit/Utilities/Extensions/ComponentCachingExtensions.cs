using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Component Caching Extensions:
// • provides extension methods and related functionality for caching components of game objects
// #component #correspondence #lodespondence
public static class ComponentCachingExtensions
{
	// variables //

	
	// tracking //

	// a dictionary of cached component dictionaries (dictionaries of those components on a particular game object which are cached here, keyed by their type) for game object keys //
	public static Dictionary<GameObject, Dictionary<Type, Component>> cachedComponentDictionaries
		= New.dictionaryOf<GameObject, Dictionary<Type, Component>>();
	
	// a dictionary of cached corresponding component dictionaries (dictionaries of those components corresponding to a particular game object which are cached here, keyed by their type) for game object keys //
	public static Dictionary<GameObject, Dictionary<Type, Component>> cachedCorrespondingComponentDictionaries =
		New.dictionaryOf<GameObject, Dictionary<Type, Component>>();
	
	// a dictionary of cached lodesponding component dictionaries (dictionaries of those components lodesponding to a particular game object which are cached here, keyed by their type) for game object keys //
	public static Dictionary<GameObject, Dictionary<Type, Component>> cachedLodespondingComponentDictionaries =
		New.dictionaryOf<GameObject, Dictionary<Type, Component>>();




	// methods //


	// method: cachingly return the component of the specified type in the cached components for this given game object, optionally adding the specified type of component to this given game object if none is found //
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

	// method: cachingly return the corresponding component of the specified type for this given game object, optionally adding the specified type of component to this given game object if none is found //
	public static ComponentT cacheCorresponding<ComponentT>(this GameObject gameObject, bool addComponentIfNoneFound = false) where ComponentT : Component
		=>	cachedCorrespondingComponentDictionaries.cache
			(
				gameObject,
				()=> new Dictionary<Type, Component>()
			)
			.cache
			(
				typeof(ComponentT),
				()=> gameObject.corresponding<ComponentT>().ifYullOtherwise(()=>
					addComponentIfNoneFound ? gameObject.addGet<ComponentT>() : null)
			)
			.castTo<ComponentT>();

	// method: cachingly return the lodesponding component of the specified type for this given game object, optionally adding the specified type of component to this given game object if none is found //
	public static ComponentT cacheLodesponding<ComponentT>(this GameObject gameObject, bool addComponentIfNoneFound = false) where ComponentT : Component
		=>	cachedLodespondingComponentDictionaries.cache
			(
				gameObject,
				()=> new Dictionary<Type, Component>()
			)
			.cache
			(
				typeof(ComponentT),
				()=> gameObject.lodesponding<ComponentT>().ifYullOtherwise(()=>
					addComponentIfNoneFound ? gameObject.addGet<ComponentT>() : null)
			)
			.castTo<ComponentT>();

	// method: untrack the cached components (including corresponding rigidbodies) for this given game object, then return whether this given game object actually had cached components //
	public static bool tryToUncache(this GameObject gameObject)
		=>	cachedComponentDictionaries.tryToRemove(gameObject) ||
			cachedCorrespondingComponentDictionaries.tryToRemove(gameObject) ||
			cachedLodespondingComponentDictionaries.tryToRemove(gameObject);

	// method: in both the cached component dictionaries dictionary and the cached corresponding rigidbodies dictionary, remove all (game object) keys which are destroyed //
	public static void clean()
	{
		cachedComponentDictionaries.clean();
		cachedCorrespondingComponentDictionaries.clean();
		cachedLodespondingComponentDictionaries.clean();
	}
}