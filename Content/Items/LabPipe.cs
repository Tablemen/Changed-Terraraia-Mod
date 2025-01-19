using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace changedmod.Content.Items
{
    public class LabPipe : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.changedmod.hjson file.

        public override void SetDefaults()
        {
            Item.damage = 32;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 18;
            Item.useStyle = 1;
            Item.knockBack = 8;
            Item.value = 10000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 23);
            recipe.AddIngredient(ItemID.StoneBlock, 73);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}