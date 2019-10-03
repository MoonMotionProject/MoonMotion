﻿using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller Operation Extensions: provides extension methods for handling controller operations //
public static class ControllerOperationExtensions
{
	// method: return whether these operations are currently operated //
	public static bool operated(this ControllerOperation[] controllerOperations)
		=> Controller.operated(controllerOperations);

	// method: return the set of controllers for which any of the given operations are currently operated //
	public static HashSet<Controller> operatedControllers(this ControllerOperation[] controllerOperations)
		=> Controller.operatedControllers(controllerOperations);

	// method: return the first controller for which any of the given operations are currently operated //
	public static Controller firstOperatedController(this ControllerOperation[] controllerOperations)
		=> controllerOperations.operatedControllers().first();
}