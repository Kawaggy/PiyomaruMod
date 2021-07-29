using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PiyomaruMod.Core.Systems;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Shaders;

namespace PiyomaruMod.Content.Projectiles.Pets
{
    public class SleepParticle : Particle
    {
        public SleepParticle(Vector2 position, Vector2 velocity, Vector2 scale, float alpha) : base(position, velocity, scale, alpha) { }

        float OriginalX;
        public override void Initialize()
        {
            OriginalX = position.X;
            timer[0] = (MathHelper.TwoPi / 120) * Main.rand.Next(120);
        }

        public override void Update()
        {
            timer[0] += MathHelper.TwoPi / 120;
            timer[0] = MathHelper.WrapAngle(timer[0]);

            position = new Vector2(OriginalX, position.Y);
            position.Y -= 0.25f;
            position.X += (float)Math.Sin(timer[0]) * 16f;
            position += velocity;

            if (++frameCounter >= 45 && frame < 5)
            {
                frame++;
                frameCounter = 0;
            }
            else if (frame >= 5)
            {
                active = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = ModContent.GetTexture("PiyomaruMod/Assets/ExtraTextures/Niwa/Sleeping");
            Rectangle rectangle = texture.Frame(1, 5, 0, frame);

            if (entity is Player player)
                shader = GameShaders.Armor.GetSecondaryShader(player.cPet, player);

            if (shader != null)
            {
                if (shader is ArmorShaderData data)
                    data.Apply(null);
            }

            spriteBatch.Draw(texture, position - Main.screenPosition, rectangle, Color.White * alpha, 0, texture.Size() / 2, scale, SpriteEffects.None, 0);

            Main.pixelShader.CurrentTechnique.Passes[0].Apply();
        }

        public override void Kill()
        {
            float angle = MathHelper.Pi / 4f;
            for (int i = 0; i < 4; i++)
            {
                Explodey explodey = new Explodey(position, new Vector2(0, 4).RotatedBy(angle), Vector2.One, 1f);
                explodey.entity = entity;
                explodey.shader = shader;
                angle += MathHelper.PiOver2;
            }
        }
    }
}
