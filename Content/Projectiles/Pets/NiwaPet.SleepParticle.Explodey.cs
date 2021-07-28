using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PiyomaruMod.Core.Systems;
using Terraria;
using Terraria.Graphics.Shaders;

namespace PiyomaruMod.Content.Projectiles.Pets
{
    public class Explodey : Particle
    {
        public Explodey(Vector2 position, Vector2 velocity, Vector2 scale, float alpha) : base(position, velocity, scale, alpha) { }

        public override void Update()
        {
            Position += Velocity;
            Velocity *= 0.95f;

            if (++Timer[0] > 60)
                Active = false;

            Alpha = 0.5f - (Timer[0] / 120);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Entity is Player player)
                Shader = GameShaders.Armor.GetSecondaryShader(player.cPet, player);

            if (Shader != null)
                if (Shader is ArmorShaderData data)
                    data.Apply(null);

            spriteBatch.Draw(Main.magicPixel, Position - Main.screenPosition, new Rectangle(0, 0, 2, 6), new Color(208, 0, 52, 255) * Alpha, Velocity.ToRotation() + MathHelper.PiOver2, new Vector2(1, 0), Scale, SpriteEffects.None, 0f);

            Main.pixelShader.CurrentTechnique.Passes[0].Apply();
        }
    }
}
