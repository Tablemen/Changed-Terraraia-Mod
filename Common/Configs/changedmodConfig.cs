
using Terraria.ModLoader.Config;

namespace changedmod.Common.Configs
{
	public class changedmodConfig : ModConfig
	{
		// ConfigScope.ClientSide should be used for client side, usually visual or audio tweaks.
		// ConfigScope.ServerSide should be used for basically everything else, including disabling items or changing NPC behaviors
		public override ConfigScope Mode => ConfigScope.ServerSide;

		// The things in brackets are known as "Attributes".

		
	}
}
