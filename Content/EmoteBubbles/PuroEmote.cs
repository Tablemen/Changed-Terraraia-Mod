
using Terraria.GameContent.UI;
using Terraria.ModLoader;

namespace changedmod.Content.EmoteBubbles
{
	public class PuroEmote : ModEmoteBubble
	{
		public override void SetStaticDefaults() {
			// The default emote command name will be a lowercase version of the classname to match other vanilla commands.
			// This can be changed in the localization files.

			// Add the emote to "bosses" category
			AddToCategory(EmoteID.Category.Town);
		}
	}
}
