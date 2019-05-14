using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dependencies
// • A Dependency is a condition upon a Moon Motion feature's state, where the condition can be either to match the state or match the opposite state of that feature (for example, only while boosting, or only while not boosting). Multiple dependencies can be used in conjunction to determine whether something should happen currently. Within Moon Motion, these conditions are used for controlling the enablement of such features as locomotion movement audio and booster modules; these dependencies can be used outside of Moon Motion as well to easily tap into the state of most of the plugin's important state-based features. This can be done via providing inspector settings of the Dependencies Combination class and using those with this class's methods, or just directly checking a hardcoded combination of Dependencies via this class's methods.
// • Dependency Requisites (Moon Motion features upon which their state may be depended) are defined by the Dependency Requisite class of scriptable objects
// • enumerates Dependency Requisitions (by which a Dependency is either dependent as 'when' or 'when not' matching the state of a Dependency Requisite)
// • defines a Dependency (as a pair of both a Dependency Requisite and a Dependency Requisition)
// • defines a Dependencies Combination (as an array of multiple declarations of the Dependency class)
// • provides methods for determining:
//   · the boolean for the given Dependency Requisition
//   · whether the given Dependency is met
//   · whether the given Dependencies Combination is met
//   · whether the given Dependencies Combination is partially met
public static class Dependencies
{
	// enumerations //
	

	// enumeration of: Dependency Requisitions //
	public enum DependencyRequisition
	{
		when,
		whenNot
	}




	// definitions //

	
	// definition of a Dependency //
	[System.Serializable]
	public class Dependency
	{
		public DependencyRequisition requisition;		// setting: the Dependency Requisition of this Dependency (by which this Dependency is either dependent as 'when' or 'when not' matching the state of this Dependency's Dependency Requisite)
		public DependencyRequisite requisite;		// setting: the Dependency Requisite (Moon Motion feature upon which its state may be depended) of this Dependency

		// constructors //
		public Dependency()
		{
			requisition = DependencyRequisition.when;
		}
		public Dependency(DependencyRequisition requisition)
		{
			this.requisition = requisition;
		}
		public Dependency(DependencyRequisite requisite)
		{
			requisition = DependencyRequisition.when;
			this.requisite = requisite;
		}
		public Dependency(DependencyRequisition requisition, DependencyRequisite requisite)
		{
			this.requisition = requisition;
			this.requisite = requisite;
		}
	}
	
	// definition of a Dependencies Combination //
	[System.Serializable]
	public class DependenciesCombination
	{
		public Dependency[] array;

		// constructors //
		public DependenciesCombination()
		{
			array = new Dependency[] {};
		}
		public DependenciesCombination(Dependency dependency)
		{
			array = new Dependency[] {dependency};
		}
		public DependenciesCombination(Dependency[] dependencies)
		{
			array = dependencies;
		}
	}




	// methods //

	
	// method: determine the boolean for the given Dependency Requisition //
	private static bool requisitionBooleanFor(DependencyRequisition requisition)
	{
		switch (requisition)
		{
			case DependencyRequisition.when:
			{
				return true;
			}
			case DependencyRequisition.whenNot:
			{
				return false;
			}
		}
		Debug.Log("error in Dependencies.requisitionBooleanFor(...); returning true");
		return true;
	}

	// method: determine whether the given Dependency is met //
	public static bool metFor(Dependency dependency)
	{
		if (dependency.requisite)
		{
			return (dependency.requisite.state() == requisitionBooleanFor(dependency.requisition));
		}
		else
		{
			Debug.Log("ERROR: Dependency requisite not given.");
			return false;
		}
	}
	// method: determine whether the given Dependencies Combination is met //
	public static bool metFor(DependenciesCombination dependenciesCombination)
	{
		foreach (Dependency dependency in dependenciesCombination.array)
		{
			if (!metFor(dependency))
			{
				return false;
			}
		}
		return true;
	}
	// method: determine whether the given Dependencies Combination is at least partially met, where empty results in false //
	public static bool partiallyMetForWhereEmptyIsFalse(DependenciesCombination dependenciesCombination)
	{
		foreach (Dependency dependency in dependenciesCombination.array)
		{
			if (metFor(dependency))
			{
				return true;
			}
		}
		return false;
	}
	// method: determine whether the given Dependencies Combination is at least partially met, where empty results in true //
	public static bool partiallyMetForWhereEmptyIsTrue(DependenciesCombination dependenciesCombination)
	{
		if (dependenciesCombination.array.Length == 0)
		{
			return true;
		}

		return partiallyMetForWhereEmptyIsFalse(dependenciesCombination);
	}
}