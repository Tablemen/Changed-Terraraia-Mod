using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace changedmod.Common
{
	public class RaceHead : PlayerDrawLayer
	{
		private Asset<Texture2D>[,] Hair_Texture = new Asset<Texture2D>[10, 165];
		private Asset<Texture2D>[,] HairAlt_Texture = new Asset<Texture2D>[10, 165];
		private Asset<Texture2D>[] Head_Texture = new Asset<Texture2D>[10];
		private Asset<Texture2D>[] EyeLids_Texture = new Asset<Texture2D>[10];
		private Asset<Texture2D>[] Eyes_Texture = new Asset<Texture2D>[10];
		private string[] PlayerColors = { "ColorSkin", "ColorDetail", "Colorless", "ColorEyes", "ColorHair", "ColorSkin/Glowmask", "ColorDetail/Glowmask", "Colorless/Glowmask", "ColorEyes/Glowmask", "ColorHair/Glowmask" };

		public override bool IsHeadLayer => true;
		public override Position GetDefaultPosition() => new BeforeParent(PlayerDrawLayers.Head);

		public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) 
		{
			return (drawInfo.skinVar < 10);
		}

		protected override void Draw(ref PlayerDrawSet drawInfo) 
		{
			Player drawPlayer = drawInfo.drawPlayer;
			Vector2 helmetOffset = drawInfo.helmetOffset;

			var changedmodPlayer = drawPlayer.GetModPlayer<changedmodPlayer>();
			
			if (changedmodPlayer.race != null) {
				TextureAssets.PlayerHair[drawPlayer.hair] = ModContent.Request<Texture2D>("changedmod/Patches/Blank");
				TextureAssets.PlayerHairAlt[drawPlayer.hair] = ModContent.Request<Texture2D>("changedmod/Patches/Blank");
				TextureAssets.Players[drawInfo.skinVar, 0] = ModContent.Request<Texture2D>("changedmod/Patches/Blank");
				TextureAssets.Players[drawInfo.skinVar, 1] = ModContent.Request<Texture2D>("changedmod/Patches/Blank");
				TextureAssets.Players[drawInfo.skinVar, 2] = ModContent.Request<Texture2D>("changedmod/Patches/Blank");
				TextureAssets.Players[drawInfo.skinVar, 15] = ModContent.Request<Texture2D>("changedmod/Patches/Blank");

				for (int i = 0; i < 10; i++)
				{
					Hair_Texture[i, drawPlayer.hair] = changedmodPlayer.GetRaceTexture(drawPlayer, $"{PlayerColors[i]}/Hairstyles/Hair_{drawPlayer.hair + 1}");
					HairAlt_Texture[i, drawPlayer.hair] = changedmodPlayer.GetRaceTexture(drawPlayer, $"{PlayerColors[i]}/Hairstyles/HairAlt_{drawPlayer.hair + 1}");
					Head_Texture[i] = changedmodPlayer.GetRaceTexture(drawPlayer, $"{PlayerColors[i]}/Head");
					EyeLids_Texture[i] = changedmodPlayer.GetRaceTexture(drawPlayer, $"{PlayerColors[i]}/EyeLids");
					Eyes_Texture[i] = changedmodPlayer.GetRaceTexture(drawPlayer, $"{PlayerColors[i]}/Eyes");
				}

				Vector2 headPosition = new Vector2((float)(int)(drawInfo.Position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2)), (float)(int)(drawInfo.Position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f)) + drawPlayer.headPosition + drawInfo.headVect;
				if ((!drawInfo.hideHair || changedmodPlayer.race.AlwaysDrawHair) && drawInfo.backHairDraw)
				{
					if (drawPlayer.head == -1 || drawInfo.fullHair || drawInfo.drawsBackHairWithoutHeadgear || changedmodPlayer.race.AlwaysDrawHair)
					{
						MakeColoredDrawDatas(ref drawInfo, null, Hair_Texture, headPosition, drawInfo.hairBackFrame, drawPlayer.headRotation, drawInfo.headVect, 1f, drawInfo.playerEffect, 0);
					}
					else if (drawInfo.hatHair || changedmodPlayer.race.AlwaysDrawHair)
					{
						MakeColoredDrawDatas(ref drawInfo, null, Hair_Texture, headPosition, drawInfo.hairBackFrame, drawPlayer.headRotation, drawInfo.headVect, 1f, drawInfo.playerEffect, 0);
					}
				}

				Vector2 eyelidOffset = Main.OffsetsPlayerHeadgear[drawPlayer.bodyFrame.Y / drawPlayer.bodyFrame.Height];
				eyelidOffset.Y -= 2f;
#pragma warning disable CS0618 // Type or member is obsolete
                Rectangle eyelidFrame = EyeLids_Texture[0].Frame(1, 3, 0, drawPlayer.eyeHelper.EyeFrameToShow);
#pragma warning restore CS0618 // Type or member is obsolete
                MakeColoredDrawDatas(ref drawInfo, Head_Texture, null, headPosition, drawPlayer.bodyFrame, drawPlayer.headRotation, drawInfo.headVect, 1f, drawInfo.playerEffect, 0);
				MakeColoredDrawDatas(ref drawInfo, Eyes_Texture, null, headPosition, drawPlayer.bodyFrame, drawPlayer.headRotation, drawInfo.headVect, 1f, drawInfo.playerEffect, 0);
				MakeColoredDrawDatas(ref drawInfo, EyeLids_Texture, null, headPosition + eyelidOffset, eyelidFrame, drawPlayer.headRotation, drawInfo.headVect, 1f, drawInfo.playerEffect, 0);
				
				if (!drawPlayer.invis && drawInfo.hatHair || changedmodPlayer.race.AlwaysDrawHair)
				{
					MakeColoredDrawDatas(ref drawInfo, null, HairAlt_Texture, headPosition, drawInfo.hairFrontFrame, drawPlayer.headRotation, drawInfo.headVect, 1f, drawInfo.playerEffect, 0);
				}
				if (!drawPlayer.invis && (!drawInfo.hatHair || changedmodPlayer.race.AlwaysDrawHair) && (((drawPlayer.face < 0 || !ArmorIDs.Face.Sets.PreventHairDraw[drawPlayer.face]) && (drawPlayer.head < 0 || ArmorIDs.Head.Sets.DrawFullHair[drawPlayer.head] || (drawPlayer.armor[0].type == ItemID.FamiliarWig || drawPlayer.armor[10].type == ItemID.FamiliarWig))) || changedmodPlayer.race.AlwaysDrawHair))
				{
					MakeColoredDrawDatas(ref drawInfo, null, Hair_Texture, headPosition, drawInfo.hairFrontFrame, drawPlayer.headRotation, drawInfo.headVect, 1f, drawInfo.playerEffect, 0);
				}
			}
		}

		private void MakeColoredDrawDatas(ref PlayerDrawSet drawInfo, Asset<Texture2D>[] texture, Asset<Texture2D>[,] textureHair, Vector2 position, Rectangle? sourceRect, float rotation, Vector2 origin, float scale, SpriteEffects effect, int inactiveLayerDepth)
		{
			DrawData drawData;
			Player drawPlayer = drawInfo.drawPlayer;
			int index;
			for (index = 0; index < 10; index++)
			{
				if (textureHair != null && textureHair[index, drawPlayer.hair] != ModContent.Request<Texture2D>("changedmod/Patches/Blank"))
				{
					drawData = new DrawData(textureHair[index, drawPlayer.hair].Value, position, sourceRect, PlayerColor(ref drawInfo, index), rotation, origin, scale, effect, 0);
					drawData.shader = PlayerShader(ref drawInfo, index);
					drawInfo.DrawDataCache.Add(drawData);
				}
				if (texture != null && texture[index] != ModContent.Request<Texture2D>("changedmod/Patches/Blank"))
				{
					drawData = new DrawData(texture[index].Value, position, sourceRect, PlayerColor(ref drawInfo, index), rotation, origin, scale, effect, 0);
					drawData.shader = PlayerShader(ref drawInfo, index);
					drawInfo.DrawDataCache.Add(drawData);
				}
			}
		}

		private Color PlayerColor(ref PlayerDrawSet drawInfo, int index)
		{
			Player drawPlayer = drawInfo.drawPlayer;
			Color color = Color.White;
			return color;
		}

		private int PlayerShader(ref PlayerDrawSet drawInfo, int index)
		{
			int shader = (index == 0 ? drawInfo.skinDyePacked : index == 1 ? drawInfo.skinDyePacked : index == 2 ? 0 : index == 3 ? 0 : index == 4 ? drawInfo.hairDyePacked : index == 5 ? drawInfo.skinDyePacked : index == 6 ? drawInfo.skinDyePacked : index == 7 ? 0 : index == 8 ? 0 : drawInfo.hairDyePacked);
			return shader;
		}
	}
}