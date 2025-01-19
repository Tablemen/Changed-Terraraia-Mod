using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace changedmod.Content.Tiles
{
	public class ExampleCactus : ModCactus
	{
		public override void SetStaticDefaults() {
			// Makes Example Cactus grow on ExampleOre
			GrowsOnTileId = new int[1] { ModContent.TileType<WhiteLatexTile>() };
		}

		public override Asset<Texture2D> GetTexture() {
			return ModContent.Request<Texture2D>("changedmod/Content/Tiles/Plants/WhiteLatexPillar");
		}

		// This would be where the Cactus Fruit Texture would go, if we had one.
		public override Asset<Texture2D> GetFruitTexture() {
			return null;
		}
	}
}