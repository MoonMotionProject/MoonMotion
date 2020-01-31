using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dependency Requisition Extensions:
// • provides extension methods for handling dependency requisitions
public static class DependencyRequisitionExtensions
{
	public static bool isWhen(this DependencyRequisition dependencyRequisition)
		=> dependencyRequisition == DependencyRequisition.when;

	public static bool isWhenNot(this DependencyRequisition dependencyRequisition)
		=> dependencyRequisition == DependencyRequisition.whenNot;
}