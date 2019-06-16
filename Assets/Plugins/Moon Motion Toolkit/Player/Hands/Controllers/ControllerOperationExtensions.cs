using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller Operation Extensions: provides extension methods for handling controller operations //
public static class ControllerOperationExtensions
{
	// method: determine whether these operations are currently operated //
	public static bool operated(this ControllerOperation[] controllerOperations)
		=> Controller.operated(controllerOperations);
}