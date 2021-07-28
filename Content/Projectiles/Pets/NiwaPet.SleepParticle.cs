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
            OriginalX = Position.X;
            Timer[0] = (MathHelper.TwoPi / 120) * Main.rand.Next(120);
        }

        public override void Update()
        {
            Timer[0] += MathHelper.TwoPi / 120;
            Timer[0] = MathHelper.WrapAngle(Timer[0]);

            Position = new Vector2(OriginalX, Position.Y);
            Position -= new Vector2(0, 0.25f);
            Position += new Vector2((float)Math.Sin(Timer[0]) * 16f, 0f);
            Position += Velocity;

            if (++FrameCounter >= 45 && Frame < 5)
            {
                Frame++;
                FrameCounter = 0;
            }
            else if (Frame >= 5)
            {
                Active = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = ModContent.GetTexture("PiyomaruMod/Assets/ExtraTextures/Niwa/Sleeping");
            Rectangle frame = texture.Frame(1, 5, 0, Frame);

            if (Entity is Player player)
                Shader = GameShaders.Armor.GetSecondaryShader(player.cPet, player);

            if (Shader != null)
                if (Shader is ArmorShaderData data)
                    data.Apply(null);

            spriteBatch.Draw(texture, Position - Main.screenPosition, frame, Color.White * Alpha, 0, texture.Size() / 2, Scale, SpriteEffects.None, 0);

            Main.pixelShader.CurrentTechnique.Passes[0].Apply();
        }

        public override void Kill()
        {
            float angle = MathHelper.Pi / 4f;
            for (int i = 0; i < 4; i++)
            {
                Explodey explodey = new Explodey(Position, new Vector2(0, 4).RotatedBy(angle), Vector2.One, 1f);
                explodey.SetEntity(Entity);
                explodey.SetShader(Shader);
                angle += MathHelper.PiOver2;
            }
        }
    }
}
