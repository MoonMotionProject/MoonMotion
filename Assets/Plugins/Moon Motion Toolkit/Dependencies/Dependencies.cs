using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dependencies
// • A Dependency is a condition upon a Moon Motion feature's state, where the condition can be either to match the state or match the opposite state of that feature (for example, only while boosting, or only while not boosting). Multiple dependencies can be used in conjunction to determine whether something should happen currently. Within Moon Motion, these conditions are used for controlling the enablement of such features as locomotion movement audio and booster modules; these dependencies can be used outside of Moon Motion as well to easily tap into the state of most of the plugin's important state-based features. This can be done via providing inspector settings of Dependency arrays and using those with this class's methods, or just directly checking hardcoded Dependencies via this class's methods.
// • Dependency Requisites (Moon Motion features upon which their state may be depended) are defined by the Dependency Requisite class of scriptable objects
// • Dependency Requisitions are enumerated/described in 'DependencyRequisition'
// • the Dependency class is defined/described in 'Dependency'
// • provides methods for determining:
//   · the boolean for the given Dependency Requisition
//   · whether the given Dependency is met
//   · whether the given Dependency array
//   · whether the given Dependency array is partially met
public static class Dependencies
{
	// methods //

	
	// method: determine the boolean for the given Dependency Requisition //
	private static bool asBoolean(this DependencyRequisition requisition)
		=> (requisition == DependencyRequisition.when);

	// method: determine whether the given Dependency is met //
	public static bool isMet(this Dependency dependency)
		=>	(dependency.requisite ?
				(dependency.requisite.state == dependency.requisition.asBoolean()) :
				false.returnWithError("dependency requisite not given")
			);

	// method: determine whether the given dependencies are met //
	public static bool areMet(this Dependency[] dependencies)
	{
		foreach (Dependency dependency in dependencies)
		{
			if (!dependency.isMet())
			{
				return false;
			}
		}
		return true;
	}

	// method: determine whether the given dependencies are at least partially met – where empty results in false //
	public static bool arePartiallyMetWhereEmptyIsFalse(this Dependency[] dependencies)
	{
		foreach (Dependency dependency in dependencies)
		{
			if (dependency.isMet())
			{
				return true;
			}
		}
		return false;
	}

	// method: determine whether the given dependencies are at least partially met – where empty results in true //
	public static bool arePartiallyMetWhereEmptyIsTrue(this Dependency[] dependencies)
		=> dependencies.isEmpty().otherwiseWhether(dependencies.arePartiallyMetWhereEmptyIsFalse());
}