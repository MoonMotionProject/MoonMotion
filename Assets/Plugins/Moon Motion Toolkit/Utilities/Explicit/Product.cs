using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Product: provides properties about the product //
public static class Product
{
	#region name
	public static string name => Application.productName;
	public static string nameWithoutSpaces => name.withoutSpaces();
	#endregion name

	#region company
	public static string company => Application.companyName;
	#endregion company
}
