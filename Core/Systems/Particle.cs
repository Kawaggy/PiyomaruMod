using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace PiyomaruMod.Core.Systems
{
    public abstract class Particle : IParticle
    {
        public Particle(Vector2 position, Vector2 velocity, Vector2 scale, float alpha)
        {
            this._position = position;
            this._velocity = velocity;
            this._scale = scale;
            this._alpha = alpha;
            this._active = true;
            PiyomaruMod.particles.Add(this);
        }

        public void SetShader(object shader)
        {
            this._shader = shader;
        }

        public void SetEntity(Entity entity)
        {
            this._entity = entity;
        }

        private Vector2 _position = Vector2.Zero;
        private Vector2 _velocity = Vector2.Zero;
        private Vector2 _scale = Vector2.One;
        private object _shader = null;
        private Entity _entity = null;
        private bool _active = true;
        private int _frame = 0;
        private int _frameCounter = 0;
        private float _alpha = 1f;
        private float[] _timer = new float[4];
        private bool _initialized = false;

        public Vector2 Position { get => _position; set => _position = value; }
        public Vector2 Velocity { get => _velocity; set => _velocity = value; }
        public Vector2 Scale { get => _scale; set => _scale = value; }
        public object Shader { get => _shader; set => _shader = value; }
        public Entity Entity { get => _entity; set => _entity = value; }
        public bool Active { get => _active; set => _active = value; }
        public int Frame { get => _frame; set => _frame = value; }
        public int FrameCounter { get => _frameCounter; set => _frameCounter = value; }
        public float Alpha { get => _alpha; set => _alpha = value; }
        public float[] Timer { get => _timer; set => _timer = value; }
        public bool Initialized { get => _initialized; set => _initialized = value; }

        public virtual void Draw(SpriteBatch spriteBatch) { }
        public virtual void Kill() { }
        public virtual void Initialize() { }
        public virtual void Update() { }
    }
}
