using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object Extensions: provides extension methods for handling objects //
public static class ObjectExtensions
{
	#region yullness (whether an object is not null)
	// methods: return whether this given object is null\yull, respectively... also checking in case of being a Unity object since Unity overloads null to be true sometimes and I want to recognize those cases, to be consistent //
	
	public static bool isNull(this object object_)
		=>	(object_ == null) ||
			(
				object_.isOfTheType<UnityEngine.Object>() &&
				object_.castTo<UnityEngine.Object>() == null
			);
	
	public static bool isYull(this object object_)
		=> !object_.isNull();
	#endregion yullness (whether an object is not null)


	#region logic

	// method: return null if the given boolean is true, otherwise returning this given object //
	public static ObjectT nullIfNullOr<ObjectT>(this ObjectT object_, bool boolean) where ObjectT : class
	{
		if (object_.isNull())
		{
			return null;
		}

		return boolean ? null : object_;
	}

	// method: return null if the given function on this object returns true, otherwise returning this given object //
	public static ObjectT nullIfNullOr<ObjectT>(this ObjectT object_, Func<ObjectT, bool> function) where ObjectT : class
	{
		if (object_.isNull())
		{
			return null;
		}

		return object_.nullIfNullOr(function(object_));
	}

	// method: return null if the given boolean is false, otherwise returning this given object //
	public static ObjectT yullOnlyIf<ObjectT>(this ObjectT object_, bool boolean) where ObjectT : class
	{
		if (object_.isNull())
		{
			return null;
		}

		return object_.nullIfNullOr(!boolean);
	}

	// method: return null if the given function on this object returns false, otherwise returning this given object //
	public static ObjectT yullOnlyIf<ObjectT>(this ObjectT object_, Func<ObjectT, bool> function) where ObjectT : class
	{
		if (object_.isNull())
		{
			return null;
		}

		return object_.nullIfNullOr(!function(object_));
	}

	// method: return this given object if it is yull, otherwise returning the result of the given function //
	public static ObjectT ifYullOtherwise<ObjectT>(this ObjectT object_, Func<ObjectT> function)
		=> object_.isYull() ? object_ : function();
	#endregion logic


	#region class

	// method: return whether this given object is of the specified type //
	public static bool isOfTheType<TPotentialType>(this object object_)
		=> typeof(TPotentialType).IsInstanceOfType(object_);

	// method: return the type of this given object //
	public static Type type<ObjectT>(this ObjectT object_)
		=> typeof(ObjectT);

	// method: return the class name of this given object //
	public static string className<ObjectT>(this ObjectT object_)
		=> object_.type().className();

	// method: return the simple class name of this given object //
	public static string simpleClassName<ObjectT>(this ObjectT object_)
		=> object_.type().simpleClassName();
	#endregion class


	#region determining content

	// method: return whether this given object is any of the given other objects
	public static bool isAnyOf<ObjectT>(this ObjectT object_, IEnumerable<ObjectT> otherObjects)
		=> otherObjects.contains(object_);
	// method: return whether this given object is any of the given other objects
	public static bool isAnyOf<ObjectT>(this ObjectT object_, params ObjectT[] otherObjects)
		=> object_.isAnyOf(otherObjects.asEnumerable());
	#endregion determining content


	#region accessing

	// method: (re)return this given object (useful for triggering getters, perhaps to force a getter to cache) //
	public static ObjectT rereturn<ObjectT>(this ObjectT objectT_)
		=> objectT_;
	#endregion accessing


	#region comparison

	// method: return whether this given object is "baseline equal" to the other given object (whether it is equal as a value type or as a reference, respective to its type) //
	public static bool baselineEquals<ObjectT>(this ObjectT object_, ObjectT objectOther)
		=> EqualityComparer<ObjectT>.Default.Equals(object_, objectOther);

	// method: return whether this given object is not baseline equal to the other given object //
	public static bool isNotBaselineEqualTo<ObjectT>(this ObjectT object_, ObjectT objectOther)
		=> !object_.baselineEquals(objectOther);
	#endregion comparison


	#region setting

	// method: set the other given object to this given object, then return the each of them //
	public static ObjectT replace<ObjectT>(this ObjectT objectThis, ref ObjectT objectOther) where ObjectT : class
		=> objectOther = objectThis;
	#endregion setting


	#region acting

	/*// method: return this given object (ignoring the other given object; it serves as a place to execute code before returning this given object) //
	public static ObjectT after<ObjectT>(this ObjectT object_, object whatever)
		=> object_;
	Ideally, the below method should not be needed, thus removing the need for lambda expressions to be passed by allowing mere statements to be passed; however, statements returning void cannot be passed as objects to the above method; relevant:
	  • https://github.com/dotnet/csharplang/issues/1603
	  • https://github.com/dotnet/csharplang/issues/135
	  As such, the below method is being used exclusively over the above method so as to keep syntax consistent. This requires the lambda syntax to be passed using the empty left side '()=>'.
	  If ever the option becomes available to use the above method instead (like, if void-passing support is added), then keep in mind it would not support the use of a boolean upon which to actually execute the code, since such code would execute before being passed as the generic object type, so an if would need to be used inside the code*/
	// method: (according to the given boolean:) execute the given action, then return this given object //
	public static ObjectT after<ObjectT>(this ObjectT object_, Action action, bool boolean = true)
	{
		action.predicatedWith(boolean)();

		return object_;
	}

	// method: (according to the given boolean:) execute the given action on this given object, then return this given object //
	public static ObjectT after<ObjectT>(this ObjectT object_, Action<ObjectT> action, bool boolean = true)
	{
		action.predicatedWith(boolean)(object_);

		return object_;
	}

	// method: (according to the given boolean:) if this given object is yull, execute the given action, then return this given object //
	public static ObjectT afterIfYullDoing<ObjectT>(this ObjectT object_, Action action, bool boolean = true)
		=> object_.after(
			action,
			object_.isYull().and(boolean));

	// method: if this given object is yull and the given boolean is true, execute the given action on this given object and return this given object //
	public static ObjectT afterIfYullDoing<ObjectT>(this ObjectT object_, Action<ObjectT> action, bool boolean = true)
		=> object_.after(
			action,
			object_.isYull().and(boolean));

	// method: (according to the given boolean:) if this given object is null, execute the given action, then return this given object //
	public static ObjectT afterIfNullDoing<ObjectT>(this ObjectT object_, Action action, bool boolean = true)
		=> object_.after(
			action,
			object_.isNull().and(boolean));

	// method: if this given object is null and the given boolean is true, execute the given action on this given object and return this given object //
	public static ObjectT afterIfNullDoing<ObjectT>(this ObjectT object_, Action<ObjectT> action, bool boolean = true)
		=> object_.after(
			action,
			object_.isNull().and(boolean));
	#endregion acting


	#region conversion

	// method: return this given object cast to the specified type (however, there is no guarantee that the given object can be cast to the specified type) //
	public static TCast castTo<TCast>(this object object_)
		=> (TCast) object_;
	
	// method: return this given object cast as the specified type (as long as it is a class, it will be cast to that class or null) //
	public static ObjectT castAs<ObjectT>(object object_) where ObjectT : class
		=> object_ as ObjectT;

	// method: return this given object converted to a string with null represented //
	public static string asStringWithNullRepresented(this object object_)
		=> object_.isYull() ? ""+object_ : "null";
	#endregion conversion


	#region composition

	// method: return the key value pair for this given object as the key and the other given object as the value //
	public static KeyValuePair<TKey, TValue> asKeyPairWithValue<TKey, TValue>(this TKey key, TValue value)
		=> new KeyValuePair<TKey, TValue>(key, value);

	// method: return the key value pair for this given object as the value and the other given object as the key //
	public static KeyValuePair<TKey, TValue> asValuePairWithKey<TValue, TKey>(this TValue value, TKey key)
		=> key.asKeyPairWithValue(value);
	#endregion composition
}