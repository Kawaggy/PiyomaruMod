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
            position += velocity;
            velocity *= 0.95f;

            if (++timer[0] > 60)
                active = false;

            alpha = 0.5f - (timer[0] / 120);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (entity is Player player)
                shader = GameShaders.Armor.GetSecondaryShader(player.cPet, player);

            if (shader != null)
                if (shader is ArmorShaderData data)
                    data.Apply(null);

            spriteBatch.Draw(Main.magicPixel, position - Main.screenPosition, new Rectangle(0, 0, 2, 6), new Color(208, 0, 52, 255) * alpha, velocity.ToRotation() + MathHelper.PiOver2, new Vector2(1, 0), scale, SpriteEffects.None, 0f);

            Main.pixelShader.CurrentTechnique.Passes[0].Apply();
        }
    }
}
