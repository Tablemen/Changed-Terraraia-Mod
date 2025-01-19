
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria.ModLoader.Config;

// This file contains fake ModConfig class that showcase various attributes
// that can be used to customize behavior config fields.

// Because this config was designed to show off various UI capabilities,
// this config have no effect on the mod and provides purely teaching example.
namespace changedmod.Common.Configs.ModConfigShowcases
{
	/// <summary>
	/// This config is just a showcase of various attributes and their effects in the UI window.
	/// </summary>
	public class ModConfigShowcaseMisc : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		

		/*
		// Here are some more examples, showing a complex JsonDefaultListValue and a initializer overriding the defaults of the constructor.
		[CustomModConfigItem(typeof(GradientElement))]
		public Gradient gradient2 = new Gradient() {
			start = Color.AliceBlue,
			end = Color.DeepSkyBlue
		};

		[JsonDefaultListValue("{\"start\": \"238, 248, 255, 255\", \"end\": \"0, 191, 255, 255\"}")]
		public List<Gradient> gradients = new List<Gradient>();
		*/

		// In this case, CustomModConfigItem is annotating the Enum instead of the Field. Either is acceptable and can be used for different situations.
		
		// You can put multiple attributes in the same [] if you like.
		// ColorHueSliderAttribute displays Hue Saturation Lightness. Passing in false means only Hue is shown.
		[DefaultValue(typeof(Color), "255, 0, 0, 255"), ColorHSLSlider(false), ColorNoAlpha]
		public Color hsl;

	


		

		// In this example, the list defaults to collapse.
		[Expand(false)]
		public List<string> collapsedList = new List<string>() { "1", "2", "3", "4", "5" };

		// This example collapses the list elements as well as the list itself.
		
		[JsonExtensionData]
		private IDictionary<string, JToken> _additionalData = new Dictionary<string, JToken>();

		// See _additionalData usage in OnDeserializedMethod to see how this ListOfInts can be populated from old versions of this mod.
		public List<int> ListOfInts = new List<int>();

		

		[OnDeserialized]
		internal void OnDeserializedMethod(StreamingContext context) {
			// If you change ModConfig fields between versions, your users might notice their configuration is lost when they update their mod.
			// We can use [JsonExtensionData] to capture un-de-serialized data and manually restore them to new fields.
			// Imagine in a previous version of this mod, we had a field "OldListOfInts" and we want to preserve that data in "ListOfInts".
			// To test this, insert the following into changedmod_ModConfigShowcase.json: "OldListOfInts": [ 99, 999],
			if (_additionalData.TryGetValue("OldListOfInts", out var token)) {
				var OldListOfInts = token.ToObject<List<int>>();
				ListOfInts.AddRange(OldListOfInts);
			}
			_additionalData.Clear(); // make sure to clear this or it'll crash.
		}
	}
}
