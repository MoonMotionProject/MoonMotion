using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// IAutoBehaviour:
// • provides unspecialized identity to auto behaviours
// • ensures all auto behaviours implement 'update' and 'physicsUpdate'
// #auto #updating
public interface IAutoBehaviour
{
	void physicsUpdate();

	void update();
	
	void lateUpdate();
}