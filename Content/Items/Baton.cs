using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace changedmod.Content.Items
{
    public class Baton : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.changedmod.hjson file.

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.DamageType = DamageClass.Melee;
            Item.width = 30;
            Item.height = 30;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = 1;
            Item.knockBack = 10;
            Item.value = 10000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.AddIngredient(ItemID.StoneBlock, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}