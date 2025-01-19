using changedmod.Content.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using changedmod.Content.Dusts;

namespace changedmod.Content.Tiles
{
    public class BlackLatexTile : ModTile
    {
        public int ItemDrop { get; private set; }

        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[ModContent.TileType<BlackLatexTile>()][TileID.Stone] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            DustType = ModContent.DustType<Sparkle>();
            ItemDrop = ModContent.ItemType<BlackLatexBlock>();
            AddMapEntry(new Color(35, 34, 41));
            // Set other values here
        }
    }
}