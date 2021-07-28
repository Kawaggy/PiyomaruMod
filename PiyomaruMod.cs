using Microsoft.Xna.Framework.Graphics;
using PiyomaruMod.Core.Systems;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace PiyomaruMod
{
	public class PiyomaruMod : Mod
	{
        public static List<IParticle> particles;
        public override void Load()
        {
            particles = new List<IParticle>();
            On.Terraria.Main.DrawDust += DrawParticles;
            On.Terraria.Main.DoUpdate += UpdateParticles;
        }

        public override void Unload()
        {
            particles.Clear();
            particles = null;
        }

        private void UpdateParticles(On.Terraria.Main.orig_DoUpdate orig, Main self, Microsoft.Xna.Framework.GameTime gameTime)
        {
            orig(self, gameTime);

            if (!Main.gamePaused)
            {
                ParticlesToUpdate();
            }
        }

        private void DrawParticles(On.Terraria.Main.orig_DrawDust orig, Terraria.Main self)
        {
            orig(self);

            ParticlesToDraw();
        }

        internal void ParticlesToUpdate()
        {
            for (int i = 0; i < particles.Count; i++)
            {
                if (!particles[i].Active)
                {
                    particles[i].Kill();
                    particles.RemoveAt(i);
                    continue;
                }

                if (!particles[i].Initialized)
                {
                    particles[i].Initialize();
                    particles[i].Initialized = true;
                }

                particles[i].Update();
            }
        }

        internal void ParticlesToDraw()
        {
            Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);
            for (int i = 0; i < particles.Count; i++)
            {
                if (!particles[i].Active)
                {
                    continue;
                }

                particles[i].Draw(Main.spriteBatch);
            }
            Main.spriteBatch.End();
        }
    }
}