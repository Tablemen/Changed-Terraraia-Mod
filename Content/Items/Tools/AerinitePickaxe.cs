using changedmod.Content.Dusts;
using changedmod.Content.EmoteBubbles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace changedmod.Content.Items.Tools
{
	public class AerinitePickaxe : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 25;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 8;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(gold: 1); // Buy this item for one gold - change gold to any coin and change the value to any number <= 100
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

			Item.pick = 170; // How strong the pickaxe is, see https://terraria.wiki.gg/wiki/Pickaxe_power for a list of common values
			Item.attackSpeedOnlyAffectsWeaponAnimation = true; // Melee speed affects how fast the tool swings for damage purposes, but not how fast it can dig
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(10)) {
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Sparkle>());
			}
		}

		public override void UseAnimation(Player player) {
			// Randomly causes the player to use Example Pickaxe Emote when using the item
			if (Main.myPlayer == player.whoAmI && player.ItemTimeIsZero && Main.rand.NextBool(60)) {
				EmoteBubble.MakePlayerEmote(player, ModContent.EmoteBubbleType<AerinitePickaxeEmote>());
			}
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<Items.Placeable.AeriniteBar>()
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
