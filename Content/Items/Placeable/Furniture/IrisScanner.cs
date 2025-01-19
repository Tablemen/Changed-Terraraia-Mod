
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace changedmod.Content.Items.Placeable.Furniture
{
	public class IrisScanner : ModItem
	{
		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.IrisScanner>());
			Item.width = 28;
			Item.height = 20;
			Item.value = 2000;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
                .AddIngredient(ItemID.LeadBar, 5)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
	}
}