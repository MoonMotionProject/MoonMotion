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
				typeof(UnityEngine.Object).IsInstanceOfType(object_) &&
				((object_.castTo<UnityEngine.Object>()) == null)
			);
	
	public static bool isYull(this object object_)
		=> !object_.isNull();
	#endregion yullness (whether an object is not null)



	#region class

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

	// method: return whether this given object is "baseline equal" to the other given object (whether it is equal as a value type or as a reference, respective to it's type) //
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


	#region retrieval

	// method: execute the given function upon this given object and return the function's result //
	public static TResult pick<ObjectT, TResult>(this ObjectT object_, Func<ObjectT, TResult> function)
		=> function(object_);

	// method: if this given object is yull, execute the given function upon it and return the function's result, otherwise returning the default value of the function's result type //
	public static TResult pickIfYull<ObjectT, TResult>(this ObjectT object_, Func<ObjectT, TResult> function)
		=> object_.isYull() ?
			function(object_) :
			default(TResult);

	// method: if this given object is null, execute the given function upon it and return the function's result, otherwise returning the default value of the function's result type //
	public static TResult pickIfNull<ObjectT, TResult>(this ObjectT object_, Func<ObjectT, TResult> function)
		=> object_.isNull() ?
			function(object_) :
			default(TResult);
	#endregion retrieval


	#region conversion

	// method: return this given object cast to the specified type (however, there is no guarantee that the given object can be cast to the specified type) //
	public static TCast castTo<TCast>(this object object_)
		=> (TCast) object_;

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