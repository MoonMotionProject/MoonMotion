using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using NaughtyAttributes;
#endif

// Face Object:
// • has this object face the target object, only on the set axes
// #transform #transformations
[CacheTransform]
public class FaceObject : AutoBehaviour<FaceObject>
{
	#region variables

	
	[SerializeField]
	[HideInInspector]
	private GameObject targetObject_ = null;
	#if ODIN_INSPECTOR
	private string targetObject_TitleSubtitle
		=>	targetObject.isYull() ?
				targetObject.name :
				"null";
	[Title("What:", "$targetObject_TitleSubtitle", horizontalLine: false)]
	[PropertyOrder(-1)]
	[PreviewField(Alignment = ObjectFieldAlignment.Left, AlignmentHasValue = true, Height = 80)]
	[InlineButton("targetCamera", "Target Camera")]
	[HideLabel]
	[ShowInInspector]
	#endif
	public GameObject targetObject
	{
		get
		{
			return	targetObject_.ifYullOtherwise(()=>
						targetObject_ = Camera.main.gameObject);
		}
		set {targetObject_ = value;}
	}

	#if ODIN_INSPECTOR
	#else
	[ContextMenu("Target Camera")]
	#endif
	public void targetCamera()
		=> targetObject = Camera.main.gameObject;

	#if ODIN_INSPECTOR
	[Title("Via:")]
	[LabelText("X")]
	#endif
	public bool faceX = true;

	#if ODIN_INSPECTOR
	[LabelText("Y")]
	#endif
	public bool faceY = true;

	#if ODIN_INSPECTOR
	[LabelText("Z")]
	#endif
	public bool faceZ = true;
	#endregion variables




	#region methods


	// method: face the target object //
	private void faceTarget()
		=>	face
			(
				targetObject,
				faceX,
				faceY,
				faceZ
			);
	#endregion methods




	#region updating


	// at each update: //
	public override void update()
		=> faceTarget();
	#endregion updating
}