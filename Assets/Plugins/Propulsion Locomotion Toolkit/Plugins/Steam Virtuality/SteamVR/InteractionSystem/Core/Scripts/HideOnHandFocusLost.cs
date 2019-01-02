//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Sets this GameObject as inactive when it loses focus from the hand
//
//=============================================================================

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class HideOnHandFocusLost : MonoBehaviour
	{
		public bool hidingEnabled = true;
		//-------------------------------------------------
		private void OnHandFocusLost( Hand hand )
		{
			if (hidingEnabled)
			{
				gameObject.SetActive( false );
			}
		}
	}
}
