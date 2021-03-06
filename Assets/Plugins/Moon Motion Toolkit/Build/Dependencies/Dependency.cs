﻿using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

// Dependency
// • a Dependency is a pair of both a Dependency Requisite and a Dependency Requisition
//   · see 'Dependencies' for further context
[System.Serializable]
public class Dependency
{
	#region state
	
	
	#if ODIN_INSPECTOR
	private Color GUIColor
		=> Colors.colorForAccuracyFor(isMet());
	#endif
	
	#if ODIN_INSPECTOR
	[HorizontalGroup("Horizontal Group")]
	[GUIColor("GUIColor")]
	[EnumToggleButtons]
	[HideLabel]
	#endif
	public DependencyRequisition requisition;       // the Dependency Requisition of this Dependency (by which this Dependency is either dependent as 'when' or 'when not' matching the state of this Dependency's Dependency Requisite)
	
	#if ODIN_INSPECTOR
	[HorizontalGroup("Horizontal Group")]
	[GUIColor("GUIColor")]
	[HideLabel]
	#endif
	public DependencyRequisite requisite;       // the Dependency Requisite (Moon Motion feature upon which its state may be depended) of this Dependency
	
	// method: determine whether this dependency is met //
	public bool isMet()
		=>	(requisite ?
				(requisite.state == requisition.asBoolean()) :
				false.returnWithError("dependency requisite not given")
			);
	#endregion state
	
	
	
	
	#region constructors
	
	
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
	#endregion constructors
}