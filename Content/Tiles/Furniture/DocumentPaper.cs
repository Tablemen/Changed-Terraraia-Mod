
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace changedmod.Content.Tiles.Furniture
{
	// Simple 2x2 tile that can be placed on a wall
	public class DocumentPaper : ModTile
	{
		public override void SetStaticDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			Main.tileSign[Type] = true;
			TileID.Sets.FramesOnKillWall[Type] = false;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(Type);
			DustType = 7;
		}
	}
}
