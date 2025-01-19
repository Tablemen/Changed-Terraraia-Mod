using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace changedmod.Content.Items.Placeable.Furniture
{
	public class MountBookest : ModItem
	{
		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.MountBookest>());
			Item.width = 38;
			Item.height = 24;
			Item.value = 150;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.WoodenTable)
				.AddIngredient(ItemID.Wood, 10)
				.Register();
		}
	}
}
