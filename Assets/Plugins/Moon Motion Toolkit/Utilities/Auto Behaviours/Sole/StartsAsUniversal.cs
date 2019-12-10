using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using NaughtyAttributes;
#endif

// Starts As Universal:
// • makes this object universal at the start
public class StartsAsUniversal : SoleBehaviour<StartsAsUniversal>
{
	private void Start()
		=> makeUniversal();
}