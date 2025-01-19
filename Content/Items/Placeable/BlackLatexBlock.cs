﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace changedmod.Content.Items.Placeable
{
    public class BlackLatexBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
            ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;

            // Mods can be translated to any of the languages tModLoader supports. See https://github.com/tModLoader/tModLoader/wiki/Localization
            // Translations go in localization files (.hjson files), but these are listed here as an example to help modders become aware of the possibility that users might want to use your mod in other lauguages:
            // English: "Example Block", "This is a modded tile."
            // German: "Beispielblock", "Dies ist ein modded Block"
            // Italian: "Blocco di esempio", "Questo è un blocco moddato"
            // French: "Bloc d'exemple", "C'est un bloc modgé"
            // Spanish: "Bloque de ejemplo", "Este es un bloque modded"
            // Russian: "Блок примера", "Это модифицированный блок"
            // Chinese: "例子块", "这是一个修改块"
            // Portuguese: "Bloco de exemplo", "Este é um bloco modded"
            // Polish: "Przykładowy blok", "Jest to modded blok"
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Content.Tiles.BlackLatexTile>());
            Item.width = 12;
            Item.height = 12;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BlackLens, 1);
            recipe.AddIngredient(ItemID.LeadBar, 2);
            recipe.AddIngredient(ItemID.FlinxFur, 1);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.Register();
        }
    }
}