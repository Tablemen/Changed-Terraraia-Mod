using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace changedmod.Content.Items.Placeable.Furniture
{
	public class GreenOfficeChair : ModItem
	{
		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.GreenOfficeChair>());
			Item.width = 12;
			Item.height = 30;
			Item.value = 150;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
                .AddIngredient(ItemID.Wood, 5)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
	}
}
