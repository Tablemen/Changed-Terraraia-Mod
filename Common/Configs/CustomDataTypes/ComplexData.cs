using System;
using System.Collections.Generic;
using System.ComponentModel;

using Terraria.ModLoader.Config;

// This file defines custom data type that contains variety of other data types and can be used in ModConfig classes.
namespace changedmod.Common.Configs.CustomDataTypes
{
	public class ComplexData
	{
		public List<int> ListOfInts = new List<int>();

		[Range(2f, 3f)]
		[Increment(.25f)]
		[DrawTicks]
		[DefaultValue(2f)]
		public float IncrementalFloat = 2f;
		

		
	}
}
