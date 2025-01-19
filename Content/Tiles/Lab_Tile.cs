using changedmod.Content.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using changedmod.Content.Dusts;

namespace changedmod.Content.Tiles
{
    public class Lab_TileTile : ModTile
    {
        public int ItemDrop { get; private set; }

        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[ModContent.TileType<Lab_TileTile>()][TileID.Stone] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            DustType = ModContent.DustType<Sparkle>();
            ItemDrop = ModContent.ItemType <LabTileBlock>();
            AddMapEntry(new Color(200, 200, 200));
            // Set other values here
        }
    }
}

