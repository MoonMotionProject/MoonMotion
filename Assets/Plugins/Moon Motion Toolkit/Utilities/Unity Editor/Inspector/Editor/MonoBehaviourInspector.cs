using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Mono Behaviour Inspector:
// • extends Unity's 'Editor' class for behaviours' inspectors to simplify common 'Editor' functionality
public abstract class MonoBehaviourInspector<MonoBehaviourT> : Editor where MonoBehaviourT : MonoBehaviour
{
	// properties //

	// mono behaviour //
	private MonoBehaviourT monoBehaviour_;
	protected MonoBehaviourT monoBehaviour => monoBehaviour_.ifYullOtherwise(()=>
		monoBehaviour_ = target?.castTo<MonoBehaviourT>());

	// game object //
	private GameObject gameObject_;
	protected GameObject gameObject => gameObject_.ifYullOtherwise(()=>
		gameObject_ = monoBehaviour?.gameObject);


	
	
	// methods //
	
	public override bool RequiresConstantRepaint()
		=> monoBehaviour.attributed<MonoBehaviourT, RequiresConstantRepaintAttribute>();
}
