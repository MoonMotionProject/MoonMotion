using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class)]
public class ErrorInEditorIfNotSolitarilyLodalToCorrespondingAttribute : ValidationAttribute
{
	public Type correspondingType {get; private set;} = null;

	public ErrorInEditorIfNotSolitarilyLodalToCorrespondingAttribute(Type correspondingType)
	{
		this.correspondingType = correspondingType;
	}
}