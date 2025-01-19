using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace changedmod.Content.Items.Placeable
{
	public class CityRuinsCampfire : ModItem
	{
		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.CityRuinsCampfire>(), 0);
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddRecipeGroup(RecipeGroupID.Wood, 10)
				.AddIngredient<CityRuinsTorch>(5)
				.Register();
		}
	}
}
