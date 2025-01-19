
using Terraria.ID;
using Terraria.ModLoader.Config;

// This file contains fake ModConfig class that showcase making config fields more readable
// with use of labels, headers and tooltips.

// Because this config was designed to show off various UI capabilities,
// this config have no effect on the mod and provides purely teaching example.
namespace changedmod.Common.Configs.ModConfigShowcases
{
	[BackgroundColor(154, 152, 181)]
	public class ModConfigShowcaseLabels : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		// By default, all ModConfig fields and properties will have an automatically assigned Label and Tooltip translation key. You'll find these translation keys in your translation files. All of the English translations for the configs in changedmod are found in changedmod/Localization/en-US_Mods.changedmod.Configs.hjson

		// Use Tooltip to convey additional information about the config item.
		// This example shows additional text when hovered.
		[SliderColor(255, 0, 127)]
		public float SomeFloat;

		// Modders can pass in custom localization keys. This can be useful for reusing translations.
		[LabelKey("$Mods.changedmod.Configs.Common.LocalizedLabel")]
		[TooltipKey("$Mods.changedmod.Configs.Common.LocalizedTooltip")]
		public int LocalizedLabel;

		// These 3 examples showcase the power of interpolating values into the translations.
		// Note how all 3 are using the same label key, but are interpolating different values into the label translation, resulting in different text. The same is done for tooltips.
		// Use this approach to reduce unnecessary duplication of text.
		// Note: using nameof can help avoid typos and errors. That would look like: $"$Mods.changedmod.Items.{nameof(ExampleYoyo)}.DisplayName"
		// Note: These examples use color and item chat tags. See here for help on using Tags: https://terraria.wiki.gg/wiki/Chat#Tags
		const string InterpolatedLabel = "$Mods.changedmod.Configs.Common.InterpolatedLabel";
		const string InterpolatedTooltip = "$Mods.changedmod.Configs.Common.InterpolatedTooltip";

		[LabelKey(InterpolatedLabel), TooltipKey(InterpolatedTooltip)] // Attributes can also be combined into a single line
		[LabelArgs("changedmod/ExampleYoyo", 1, "=>", "$Mods.changedmod.Items.ExampleYoyo.DisplayName")]
		[TooltipArgs("$Mods.changedmod.Items.ExampleYoyo.DisplayName", "FF55AA", "22a2dd")]
		public bool InterpolatedTextA;

		[LabelKey(InterpolatedLabel), TooltipKey(InterpolatedTooltip)]
		[LabelArgs("changedmod/ExampleSword", 2, "=>", "$Items.ExampleSword.DisplayName")] // due to scope simplification, "Mods.changedmod." can be omitted. (https://github.com/tModLoader/tModLoader/wiki/Localization#scope-simplification)
		[TooltipArgs("$Mods.changedmod.Items.ExampleSword.DisplayName", "77bd8e", "88AADD")]
		public bool InterpolatedTextB;

		[LabelKey(InterpolatedLabel), TooltipKey(InterpolatedTooltip)]
		[LabelArgs(ItemID.Meowmere, 3, "=>", $"$ItemName.{nameof(ItemID.Meowmere)}")]
		[TooltipArgs($"$ItemName.{nameof(ItemID.Meowmere)}", "c441c6", "deeb55")]
		public bool InterpolatedTextC;

		// This example shows advanced capabilities of string formatting. Values can be formatted to appear as percentages, with language appropriate thousandths separators, and with specific padding or precision.
		// The c# documentation has more information: https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
		[LabelArgs(.15753f, 1234567890, 12, 1.77777f)]
		public bool StringFormatting;

		

	

		// We can also add section headers, separating fields for organization
		// Using [Header("HeaderIdentifier")], Mods.changedmod.Configs.ModConfigShowcaseLabels.Headers.HeaderIdentifier will automatically appear in localization files. We have populated the English entry with the value "Headers Section".
		[Header("HeaderIdentifier")]
		public int TypicalHeader;

		// We can also specify a specific translation key, if desired.
		// The "$" character before a name means it should interpret the value as a translation key and use the loaded translation with the same key.
		[Header("$Mods.changedmod.Configs.Common.LocalizedHeader")]
		public int LocalizedHeader;

		// Chat tags such as colored text or item icons can help users find config sections quickly
		[Header("ChatTagExample")]
		public int CoolHeader;

	}
}
