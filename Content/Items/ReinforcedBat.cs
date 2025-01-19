using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace changedmod.Content.Items
{
    public class ReinforcedBat : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.changedmod.hjson file.

        public override void SetDefaults()
        {
            Item.damage = 26;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ItemID.StoneBlock, 2);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}