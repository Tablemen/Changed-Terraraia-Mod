using Microsoft.Xna.Framework.Graphics;
using changedmod.Common.Races;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;

namespace changedmod
{
    public class changedmodPlayer : ModPlayer
    {
        public Race race;

        public Asset<Texture2D> GetRaceTexture(Player player, string texturePath, string defaultTexturePath = "changedmod/Patches/Blank")
        {
            Asset<Texture2D> Race_Texture = null;
            if (race != null)
            {
                if (player.Male)
                {
                    if (ModContent.HasAsset($"{race.Mod.Name}/{race.TextureLocation}/{race.Name}/Male/{texturePath}"))
                    {
                        Race_Texture = ModContent.Request<Texture2D>($"{race.Mod.Name}/{race.TextureLocation}/{race.Name}/Male/{texturePath}");
                    }
                    else
                    {
                        Race_Texture = ModContent.Request<Texture2D>($"{defaultTexturePath}");
                    }
                }
                else
                {
                    if (ModContent.HasAsset($"{race.Mod.Name}/{race.TextureLocation}/{race.Name}/Female/{texturePath}"))
                    {
                        Race_Texture = ModContent.Request<Texture2D>($"{race.Mod.Name}/{race.TextureLocation}/{race.Name}/Female/{texturePath}");
                    }
                    else
                    {
                        if (ModContent.HasAsset($"{race.Mod.Name}/{race.TextureLocation}/{race.Name}/Male/{texturePath}"))
                        {
                            Race_Texture = ModContent.Request<Texture2D>($"{race.Mod.Name}/{race.TextureLocation}/{race.Name}/Male/{texturePath}");
                        }
                        else
                        {
                            Race_Texture = ModContent.Request<Texture2D>($"{defaultTexturePath}");
                        }
                    }
                }
            }
            else
            {
                Race_Texture = ModContent.Request<Texture2D>($"{defaultTexturePath}");
            }
            return Race_Texture;
        }
    }
}
