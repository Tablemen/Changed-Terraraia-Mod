using changedmod.Content.Tiles;
using System;
using Terraria.ModLoader;

namespace changedmod.Common.Systems
{
	public class CityRuinsBiomeTileCount : ModSystem
	{
		public int CityRuinsBlockCount;

		public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts) {
			CityRuinsBlockCount = tileCounts[ModContent.TileType<DryDirt>()];
		}
	}
}
