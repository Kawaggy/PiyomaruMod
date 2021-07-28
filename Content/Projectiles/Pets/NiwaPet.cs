using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace PiyomaruMod.Content.Projectiles.Pets
{
    public class NiwaPet : ModProjectile
    {
        internal string pathToExtraTextures = "PiyomaruMod/Assets/ExtraTextures/Niwa/";

        public override void SetDefaults()
        {

        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D eyeWhite = ModContent.GetTexture(pathToExtraTextures + "EyeWhite");
            Texture2D pupil = ModContent.GetTexture(pathToExtraTextures + "Pupil");
            Texture2D eyeMask = ModContent.GetTexture(pathToExtraTextures + "EyeMask");
        }
    }
}
