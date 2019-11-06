using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using NaughtyAttributes;
#endif

public class EphemeralContainer : AutoBehaviour<EphemeralContainer>
{
	private void Update()
	{
		if (childless)
		{
			destroyThisObject();
		}
	}
}