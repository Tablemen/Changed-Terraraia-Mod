using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace changedmod.Content.Items.Placeable.Furniture
{
	public class PackingBox : ModItem
	{
		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.PackingBox>());
			// Item.placeStyle = 1; // Use this to place the chest in its locked style
			Item.width = 26;
			Item.height = 22;
			Item.value = 500;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		
	}

	public class PackingBoxKey : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 3; // Biome keys usually take 1 item to research instead.
		}

		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.GoldenKey);
		}
	}
}
