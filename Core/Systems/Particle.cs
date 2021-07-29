using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace PiyomaruMod.Core.Systems
{
    public abstract class Particle
    {
        public Particle(Vector2 position, Vector2 velocity, Vector2 scale, float alpha)
        {
            this.position = position;
            this.velocity = velocity;
            this.scale = scale;
            this.alpha = alpha;
            this.active = true;
            PiyomaruMod.particles.Add(this);
        }


        public Vector2 position = Vector2.Zero;
        public Vector2 velocity = Vector2.Zero;
        public Vector2 scale = Vector2.One;
        public object shader = null;
        public Entity entity = null;
        public bool active = true;
        public int frame = 0;
        public int frameCounter = 0;
        public float alpha = 1f;
        public float[] timer = new float[4];
        public bool initialized = false;

        public virtual void Draw(SpriteBatch spriteBatch) { }
        public virtual void Kill() { }
        public virtual void Initialize() { }
        public virtual void Update() { }
    }
}
