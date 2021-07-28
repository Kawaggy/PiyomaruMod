using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace PiyomaruMod.Core.Systems
{
    public interface IParticle
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        Vector2 Scale { get; set; }

        object Shader { get; set; }
        Entity Entity { get; set; }

        bool Initialized { get; set; }
        bool Active { get; set; }
        int Frame { get; set; }
        int FrameCounter { get; set; }
        float Alpha { get; set; }
        float[] Timer { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
        void Initialize();
        void Kill();
    }
}
